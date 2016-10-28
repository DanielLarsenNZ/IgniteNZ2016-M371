using Scale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CamDan.Ticketer.Api.Controllers
{
    public class HealthController : ApiController
    {
        // GET: api/Health
        public dynamic Get()
        {
            var testSetting = LocalSettings.Settings["CAMDAN_TEST_SETTING"];

            return new {
                Status = "Ok",
                Version = "1.0.4",
                DateTime = DateTime.Now,
                TestSetting = testSetting
            };
        }
    }
}
