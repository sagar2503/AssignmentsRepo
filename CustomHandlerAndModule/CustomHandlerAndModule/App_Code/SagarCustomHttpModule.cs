using System;
using System.IO;
using System.Web;

namespace CustomHandlerAndModule.App_Code
{
    public class SagarCustomHttpModule  : IHttpModule
    {
        private StreamWriter sw;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            string filepath = @"C:\PrivateRepo\GitRepo\AssignmentsRepo\CustomHandlerAndModule\CustomHandlerAndModule\logger.txt";
            //throw new NotImplementedException();
            //if (!File.Exists(filepath))
            //{
            //    sw = new StreamWriter(filepath);
            //}
            //else
            //    sw = File.AppendText(filepath);
            //sw.WriteLine("User send request on : "+ DateTime.Now.ToShortDateString());

        }
    }
}