using InsideInning.BO;
using InsideInning.Web.Core.Custom;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InsideInning.Web
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            var restClient = new RestClient("http://localhost:26197/api/");
            var request = new RestRequest("checklogin/", Method.POST);
            var txtFirstName = EmployeeFirstName.Text;
            var txtLastName = EmployeeLastName.Text;
            //var empData = new BOEmployee();
            //empData.FirstName = txtFirstName;
            //empData.LastName = txtLastName;
            //empData.EmailAddress = EmployeeEmail.Text;
            //empData.Password=EmployeePassword.Text;
            var LoginData = new CheckLogin();
            LoginData.UserName = "test@test.com";
            LoginData.Password = "test";
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("X-ApiKey", "XMLHttpRequest");
            request.AddBody(LoginData);
            var dd = restClient.Execute<BOEmployee>(request);
            Console.WriteLine("thisis the value",dd);
            
        }
    }
}