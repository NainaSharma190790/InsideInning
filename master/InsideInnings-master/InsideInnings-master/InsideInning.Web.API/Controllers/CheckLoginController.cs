using InsideInning.BLL;
using InsideInning.BO;
using InsideInning.Web.Core.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsideInning.Web.API.Controllers
{
    public class CheckLoginController : ApiController
    {
        // GET api/checklogin
        public string Get(int id, [FromBody]string details)
        {
            return  "value1";
        }

        // GET api/checklogin/5
        public string Get()
        {
            try
            {
                //if (userDetail == null)
                   // return new BOEmployee();
                return "";
               // return BLLEmployee.CheckLogin(userDetail.Username, userDetail.Password);
            }
            catch(Exception ex)
            {

                return "";// new BOEmployee(); 
            }
        }

        // POST api/checklogin
        public BOEmployee Post([FromBody]CheckLogin userDetail)
        {
            try
            {
                if (userDetail == null)
                   return new BOEmployee();
               
              return BLLEmployee.CheckLogin(userDetail.UserName, userDetail.Password);
            }
            catch(Exception ex)
            {

                return  new BOEmployee(); 
            }
        }

        // PUT api/checklogin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/checklogin/5
        public void Delete(int id)
        {
        }
    }
}
