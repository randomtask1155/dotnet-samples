using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ContactController : ApiController
    {
        public string[] Get()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(WorkThreadFunction));
            thread.Start();

            return new string[]
            {
        "Hello",
        "World"
            };
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("CurrentDomain_UnhandledException:" + e.ToString());
            Console.ReadKey();
        }
        public static void WorkThreadFunction()
        {
            throw new Exception("exception in CLR Thread and exit");
        }

    }
}
