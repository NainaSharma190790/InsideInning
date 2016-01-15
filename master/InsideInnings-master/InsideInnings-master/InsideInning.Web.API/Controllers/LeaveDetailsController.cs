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
    public class LeaveDetailsController : ApiController
    {
        // GET api/leavedetails
        public List<BOLeaveDetails> Get()
        {
            try
            {
                return BLLLeaveDetails.GetAllList();
            }
            catch (Exception )
            {

                return new BOLeaveDetailsList();
            }
        }

        // GET api/leavedetails/5
        public BOLeaveDetails Get(int id)
        {
            try
            {
                return BLLLeaveDetails.GetLeaveByEmployeeID(id);
            }
            catch (Exception )
            {

                return new BOLeaveDetails();
            }
            
        }

        // POST api/leavedetails
        public string Post([FromBody]BOLeaveDetails LeaveDetailsObj)
        {
            try
            {
                int id = LeaveDetailsObj != null ? LeaveDetailsObj.EmployeeID : 0;
                int count = BLLLeaveDetails.Save(LeaveDetailsObj, id > 0 ? true : false);
                return count > 0 ? "Record saved successfully" : "There is a problem while saving record";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            

        }

        // PUT api/leavedetails/5
        public void Put(int id, [FromBody]string values)
        {
            
        }

        // DELETE api/leavedetails/5
        public bool Delete(int id)
        {
            try
            {
                return BLLLeaveDetails.Delete(id);
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
