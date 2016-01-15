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
    public class EmployeeDetailsController : ApiController
    {
        // GET api/employeedetails
        public BOEmployeeList Get()
        {
            try
            {
                return BLLEmployee.GetEmployeeDetails();
            }
            catch (Exception )
            {

                return new BOEmployeeList();
            }
        }

        // GET api/employeedetails/5
        public BOEmployee Get(int id)
        {
            try
            {
                var dd=BLLEmployee.GetEmployeeDetailsByID(id);
                return dd;
            }
            catch (Exception ex)
            {
                return new BOEmployee();
            }
        }

        // POST api/employeedetails
        public string Post([FromBody]BOEmployeeDetails employeeDetails)
        {
            try
            {
                //TODO : Need to verify Insert and Update
                int id = employeeDetails != null ? employeeDetails.EmployeeID : 0;
                int ret = BLLEmployeeDetails.Save(employeeDetails, id  > 0 ? false : true );
                return ret > 0 ? "Record saved successfully" : "There is a problem while saving record";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        // PUT api/employeedetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/employeedetails/5
        public bool Delete(int id)
        {
            try
            {
                return BLLEmployeeDetails.Delete(id);
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
    }
}
