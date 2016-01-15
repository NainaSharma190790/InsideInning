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
    public class EmployeeController : ApiController
    {
        // GET api/employee
        public List <BOEmployee> Get()
        {
            try
            {
                return BLLEmployee.GetAllEmployees();
            }
            catch (Exception ex)
            {
                return new BOEmployeeList();
            }
        }

        // GET api/employee/5
        public BOEmployee Get(int id)
        {
            try
            {
                return BLLEmployee.GetEmployee(id);
            }
            catch (Exception )
            {
                return new BOEmployee();
            }
        }

        // POST api/employee
        public string Post([FromBody]BOEmployee employeeDetails)
        {
            try
            {
                //TODO : needto veryfy insert and update 
                int id = employeeDetails != null ? employeeDetails.EmployeeID : 0;
                int ret = BLLEmployee.Save(employeeDetails, id > 0 ? false : true);
                return ret > 0 ? "Record saved successfully" : "There is a problem while saving record";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/employee/5
        public bool Delete(int id)
        {
            try
            {
                return BLLEmployee.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
