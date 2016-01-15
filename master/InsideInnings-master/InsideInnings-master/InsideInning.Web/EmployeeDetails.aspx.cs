using InsideInning.BO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.UI.WebControls;
using InsideInning.Web.Core.Custom.InsideInning.BO;

namespace InsideInning.Web
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

            //var restClient = new RestClient("http://localhost:26197/api/");
            //var req = new RestRequest("EmployeeDetails/", Method.POST);

            var Client = new RestClient("http://localhost:26197/api/");
            var Request = new RestRequest("ImageUpload/", Method.POST);


            #region Converting the Image To Base64

            byte[] imageArray = System.IO.File.ReadAllBytes("E:/images.jpeg");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            #endregion

            #region Creating Employee Profile Data And Executing the Request

            var _employeeprofile = new EmployeeProfile();
            _employeeprofile.FileData = base64ImageRepresentation;
            _employeeprofile.FileName = Guid.NewGuid().ToString() + ".jpeg";


            // var empDeatilsData = new BOEmployeeDetails();

            //empDeatilsData.gender = RadioBtnFeMale.Checked ? "M" : "F";
            //empDeatilsData.MaritalStatus = RadioBtnMarried.Checked ? "M": "S";
            //empDeatilsData.DateOfBirth = DOBCal.SelectedDate;
            //empDeatilsData.DateOfAniversary = DOACal.SelectedDate;
            //empDeatilsData.ContactNumber = Convert.ToInt32(ContactTxtbox.Text);
            //empDeatilsData.Landline = Convert.ToInt32(lanlinetxtbox.Text);

            //empDeatilsData.JoinningDate = JoinCal.SelectedDate;
            //empDeatilsData.IsActive = CheckIsActive.Checked;

            Request.RequestFormat = RestSharp.DataFormat.Json;
            Request.AddHeader("X-ApiKey", "XMLHttpRequest");
            Request.AddBody(_employeeprofile);
            Client.Execute<EmployeeProfile>(Request);

            #endregion
        }
    }
}