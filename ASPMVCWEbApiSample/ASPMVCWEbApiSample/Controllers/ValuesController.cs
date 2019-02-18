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
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Customer> Get()
        {
            return new List<Customer>()
            {
                new Customer { id = 1, Name = "Sagar" },
                new Customer { id = 2, Name = "Dipti" }
            };
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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
