using InsideInning.BLL;
using InsideInning.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsideInning.Web.API.Controllers
{
    public class MailSummaryController : ApiController
    {
        // GET api/mailsummary
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/mailsummary/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/mailsummary
        public string Post([FromBody]BOMailSummary employeeMailDetails)
        {
            try
            {
                //TODO : Need to verify Insert 
                int ret = BLLMailSummary.Save(employeeMailDetails);
                return ret > 0 ? "Mail save successfully" : "There is a problem while saving record";
            }
            catch (Exception ex)
            {
                
                return ex.Message;
            }
        }

        // PUT api/mailsummary/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mailsummary/5
        public void Delete(int id)
        {
        }
    }
}
