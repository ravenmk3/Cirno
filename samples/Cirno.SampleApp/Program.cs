using System;
using System.Net;
using Cirno.Application;
using Cirno.Http.Middleware;
using Cirno.Ioc.Simple;
using Cirno.Mvc;

namespace Cirno.SampleApp
{
    internal class Program : Bootstrapper
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Startup.");
            var app = new Program()
                .Bind(IPAddress.Any, 8081)
                .RunAsync()
                .Result;
            Console.WriteLine("Running.");
            Console.ReadLine();
            app.StopAsync().Wait();
            Console.WriteLine("Stopped.");
            Console.ReadLine();
        }

        protected override void RegisterServices(ISimpleContainer container)
        {
            container.AddMvc();
        }

        protected override void ConfigurePipeline(IMiddlewarePipeline pipeline, IServiceProvider services)
        {
            pipeline.AddMvc(services);
        }
    }
}