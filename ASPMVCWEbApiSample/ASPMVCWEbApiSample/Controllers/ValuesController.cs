using ASPMVCWEbApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPMVCWEbApiSample.Controllers
{
    //[Authorize]

    //https://www.youtube.com/watch?v=GbKBcDX8DDQ&index=3&list=PL6n9fhu94yhW7yoUOGNOfHurUE6bpOO2b

    public class ValuesController : ApiController
    {
        // GET api/values

        static List<string> lstStrng = new List<string>();
        
        public IEnumerable<string> Get()
        {
            if (lstStrng.Count == 0)
            {
                lstStrng.Add("sagar");
                lstStrng.Add("dipti");
            }
            return lstStrng;
 
        }

 

        // GET api/values/5
        public Customer Get(int id)
        {
            if (id == 1)
                return new Customer { id = 1, Name = "Sagar" };
            else if (id == 2)
                return new Customer { id = 2, Name = "DIpti" };
            else
                return null;
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            try
            {
                lstStrng.Add(value);
                var message = Request.CreateResponse(HttpStatusCode.Created);
                return message;
            }
            catch (Exception ex)
            {

                var errorMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
                return errorMessage;
            }
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            lstStrng[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            lstStrng.RemoveAt(id);
        }
    }
}
