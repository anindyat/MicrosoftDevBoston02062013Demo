using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3FIrstMiddleware
{
    using System.IO;
    using AppFunc = Func<IDictionary<string, object>, Task>;
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8089";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started ..");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          // Using anonymous function
          app.Use(async (env, next) => { 
                foreach (var item in env.Environment)
                {
                    Console.WriteLine("{0} :{1}", item.Key, item.Value);
                }
                await next();
            });

            app.Use<FirstOwinMiddleware>();
            app.Use<StreamWriterOwinMiddleware>();
        }
    }

    public class FirstOwinMiddleware
    {
        AppFunc next;
        public FirstOwinMiddleware(AppFunc _next)
        {
            next = _next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            await next(environment);
        }
    }

    public class StreamWriterOwinMiddleware
    {
        AppFunc next;
        public StreamWriterOwinMiddleware(AppFunc _next)
        {
            next = _next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello World!!");
            }
        }
    }
}
