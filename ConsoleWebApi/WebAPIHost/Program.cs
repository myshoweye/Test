using ControllerLibrary;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIHost
{
    class Program
    {
        static void Main(string[] args)
        {
            StartOptions options = new StartOptions();
            options.Urls.Add("http://localhost:3333/");
            options.Urls.Add("http://127.0.1:3333/");
            options.Urls.Add(string.Format("http://{0}:3333/", Environment.MachineName));
            using (WebApp.Start<Startup>(options.Urls[0]))
            {
                Console.WriteLine("Server is opened");
                Console.ReadLine();
            }
        }
    }
}
