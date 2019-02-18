using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2VS2017.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {

        static List<string> lsString = new List<string>()
        {
            "value0" , "value1","value2"
        };
        // GET api/values
        public IEnumerable<string> Get()
        {
        //return new string[] { "value1", "value2" };
        return lsString;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            //return "value";
            bool temp = lsString.Contains(id.ToString());
            if(temp)
            {
                // return lsString[id];
                return Request.CreateResponse(HttpStatusCode.Found, lsString[id]);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, id.ToString() + " Not found");
                //return string.Empty;
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            lsString.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            lsString[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            lsString.RemoveAt(id);
        }
    }
}
