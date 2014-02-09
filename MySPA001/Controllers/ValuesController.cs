using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MySPA001.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
