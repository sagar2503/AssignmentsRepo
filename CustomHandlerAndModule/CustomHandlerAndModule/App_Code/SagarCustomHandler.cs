using System.Web;
using System.Web.Routing;

namespace CustomHandlerAndModule.App_Code
{
    public class SagarCustomHandler : IHttpHandler
    {
        public RequestContext RequestContext { get; set; }

        public bool IsReusable
        {
            get { return true; }
        }

        public SagarCustomHandler()
        { 
        
        }

        // Need to implement custom route in order to call this param constructor

        //public SagarCustomHandler(RequestContext sagarreqcontext)
        //{
        //    RequestContext = sagarreqcontext;
    
        //}

        public void ProcessRequest(HttpContext context)
        {
            //throw new NotImplementedException();
            context.Response.Write("HI FROM SAGAR");
        }
    }
}