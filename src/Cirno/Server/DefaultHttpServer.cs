using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Cirno.Http;
using Cirno.Logging;

namespace Cirno.Server
{
    public class DefaultHttpServer : IHttpServer
    {
        private IHttpHandler handler;
        private HttpListener listener;
        private X509Certificate certificate; // TODO 实现SSL支持
        private bool stop;

        public ILogger Logger { get; }

        public DefaultHttpServer(ILogManager logManager)
        {
            if (logManager == null)
            {
                throw new ArgumentNullException(nameof(logManager));
            }
            this.Logger = logManager.GetLogger<DefaultHttpServer>();
        }

        public void UseHandler(IHttpHandler handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public void UseSsl(X509Certificate certificate)
        {
            this.certificate = certificate ?? throw new ArgumentNullException(nameof(certificate));
        }

        private string GetUriPrefix(IPAddress address, int port)
        {
            if (IPAddress.Any.Equals(address) || IPAddress.IPv6Any.Equals(address))
            {
                return String.Format("http://*:{0}/", port);
            }
            return String.Format("http://{0}:{1}/", address, port);
        }

        public Task ListenAsync(IPAddress address, int port)
        {
            this.StartListener(address, port);
            return Task.CompletedTask;
        }

        private void StartListener(IPAddress address, int port)
        {
            this.stop = false;
            this.listener = new HttpListener();
            this.listener.Prefixes.Add(this.GetUriPrefix(address, port));
            this.listener.Start();
            this.BeginGetContext();
        }

        public Task CloseAsync()
        {
            this.stop = true;
            if (this.listener != null && this.listener.IsListening)
            {
                listener.Stop();
            }
            this.listener = null;
            return Task.CompletedTask;
        }

        private void BeginGetContext()
        {
            if (this.stop)
            {
                return;
            }
            this.listener.BeginGetContext(this.GetContextCallback, this.listener);
        }

        private void GetContextCallback(IAsyncResult result)
        {
            var instance = (HttpListener)result.AsyncState;
            var context = instance.EndGetContext(result);
            if (!this.stop)
            {
                this.BeginGetContext();
                if (context != null)
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            await this.ProcessAsync(context);
                        }
                        catch (Exception exception)
                        {
                            await this.HandleExceptionAsync(exception);
                        }
                    });
                }
            }
        }

        protected virtual Task HandleExceptionAsync(Exception exception)
        {
            return Task.Run(() =>
            {
                this.Logger.Error(exception, exception.Message);
            });
        }

        private async Task ProcessAsync(HttpListenerContext ctx)
        {
            var context = await this.ProcessAsync(ctx.Request);
            this.WriteToResponse(ctx.Response, context.Response);
        }

        private async Task<IHttpContext> ProcessAsync(HttpListenerRequest req)
        {
            var request = this.ConvertRequest(req);
            var context = new HttpContext(request);
            await this.handler.HandleAsync(context).ConfigureAwait(false);
            return context;
        }

        private Request ConvertRequest(HttpListenerRequest source)
        {
            // TODO 读取headers和cookies
            return new Request(HttpUtils.ParseMethod(source.HttpMethod), source.Url, source.InputStream);
        }

        private void WriteToResponse(HttpListenerResponse target, IResponse response)
        {
            using (target)
            {
                if (response == null)
                {
                    return;
                }
                target.StatusCode = response.Status;
                if (response.Headers != null)
                {
                    foreach (var entry in response.Headers)
                    {
                        target.Headers[entry.Key] = entry.Value;
                    }
                }
                // TODO 写入Cookies
                if (response.Body != null)
                {
                    response.Body.WriteTo(target.OutputStream);
                }
            }
        }
    }
}