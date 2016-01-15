using InsideInning.Web.Core.Custom.InsideInning.BO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InsideInning.Web.API.Controllers
{
    public class ImageUploadController : ApiController
    {
        // GET api/ImageUpload
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/ImageUpload/5
        public string Get(int id)
        {


            return "value";
        }

        // POST api/ImageUpload
        public void Post([FromBody]EmployeeProfile _EmpProfile)
        {

            byte[] bytes = Convert.FromBase64String(_EmpProfile.FileData);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
                var filePath = HttpContext.Current.Server.MapPath("~/Pics/ " + _EmpProfile.FileName);
                image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        // PUT api/ImageUpload/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ImageUpload/5
        public void Delete(int id)
        {
        }
    }     
}
