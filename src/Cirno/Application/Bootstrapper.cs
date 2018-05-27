using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Cirno.Http;
using Cirno.Http.Middleware;
using Cirno.Ioc;
using Cirno.Ioc.Simple;
using Cirno.Logging;
using Cirno.Logging.Console;
using Cirno.Server;

namespace Cirno.Application
{
    public class Bootstrapper : IBootstrapper
    {
        private IPAddress address;
        private int port;
        private X509Certificate certificate;

        public Bootstrapper()
        {
            this.address = IPAddress.Any;
            this.port = 8080;
        }

        public IBootstrapper Bind(IPAddress address, int port)
        {
            this.address = address ?? throw new ArgumentNullException(nameof(address));
            this.port = port;
            return this;
        }

        public IBootstrapper UseSsl(X509Certificate certificate)
        {
            this.certificate = certificate ?? throw new ArgumentNullException(nameof(certificate));
            return this;
        }

        public Task<IApplication> RunAsync()
        {
            return Task.Run<IApplication>(async () =>
            {
                var services = this.CreateServiceProvider();
                var logManager = services.GetService<ILogManager>();
                this.ConfigureLogging(logManager, services);
                var handler = services.GetService<IPipelineHttpHandler>();
                var server = services.GetService<IHttpServer>();
                server.UseHandler(handler);
                if (this.certificate != null)
                {
                    server.UseSsl(this.certificate);
                }
                await server.ListenAsync(this.address, this.port).ConfigureAwait(false);
                return new App(services, server);
            });
        }

        protected virtual IServiceProvider CreateServiceProvider()
        {
            var container = new SimpleContainer();
            this.RegisterEssentialServices(container);
            this.RegisterServices(container);
            return container;
        }

        private void RegisterEssentialServices(ISimpleContainer container)
        {
            container
                .RegisterInstance<IServiceProvider>(container)
                .RegisterSingleton<ILogManager, LogManager>()
                .RegisterMethod(this.CreateHttpServer)
                .RegisterMethod(this.CreateHttpHandler);
        }

        protected virtual void RegisterServices(ISimpleContainer container)
        {
        }

        protected virtual void ConfigureLogging(ILogManager manager, IServiceProvider services)
        {
            manager.AddConsole();
        }

        protected virtual IPipelineHttpHandler CreateHttpHandler(IServiceProvider services)
        {
            var pipeline = new MiddlewareHttpHandler();
            this.ConfigurePipeline(pipeline, services);
            return pipeline;
        }

        protected virtual void ConfigurePipeline(IMiddlewarePipeline pipeline, IServiceProvider services)
        {
        }

        protected virtual IHttpServer CreateHttpServer(IServiceProvider services)
        {
            return services.CreateInstance<DefaultHttpServer>();
        }

        private class App : IApplication
        {
            public IServiceProvider Services { get; }

            protected IHttpServer Listener { get; }

            public App(IServiceProvider services, IHttpServer listener)
            {
                this.Services = services ?? throw new ArgumentNullException(nameof(services));
                this.Listener = listener ?? throw new ArgumentNullException(nameof(listener));
            }

            public Task StopAsync()
            {
                return this.Listener.CloseAsync();
            }
        }
    }
}