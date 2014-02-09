using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CORSAPI.Controllers
{
    [DisableCors()]
    public class OtherValuesController : ApiController
    {
        // GET api/othervalues
        public IEnumerable<string> Get()
        {
            return new string[] { "other value 1", "other value 2" };
        }

        // GET api/othervalues/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/othervalues
        public void Post([FromBody]string value)
        {
        }

        // PUT api/othervalues/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/othervalues/5
        public void Delete(int id)
        {
        }
    }
}
