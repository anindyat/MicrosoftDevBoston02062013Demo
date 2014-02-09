using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace _4SelfHostedWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8092";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started.. in http://localhost:8092");
                Console.ReadKey();
                Console.WriteLine("Stopping ..");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (env, next) =>
            {
                Console.WriteLine("Path = {0}",env.Request.Path);
                Console.WriteLine("Method = {0}",env.Request.Method);
                await next();
            });

            ConfigureWebApi(app);
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional });
            app.UseWebApi(config);
        }
    }
}
