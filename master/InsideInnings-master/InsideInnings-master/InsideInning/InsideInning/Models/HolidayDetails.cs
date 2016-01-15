using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Models
{
   public class HolidayDetails:BaseModel
   {
       #region Properties
       public int HolidayID { get; set; }
       public string HolidayType { get; set; }
       public DateTime HolidayDate { get; set; }

       #endregion

    }
}
