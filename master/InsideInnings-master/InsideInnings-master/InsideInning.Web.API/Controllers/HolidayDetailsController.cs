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
    public class HolidayDetailsController : ApiController
    {
        // GET api/holidaydetails
        public List<BOHolidayDetails> Get()
        {
            try
            {
                return BLLHolidayDetails.GetAllList();

            }
            catch (Exception ex)
            {

                return new List<BOHolidayDetails>();
            }
        }

        // GET api/holidaydetails/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/holidaydetails
        public void Post([FromBody]string value)
        {
        }

        // PUT api/holidaydetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/holidaydetails/5
        public void Delete(int id)
        {
        }
    }
}
