using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Models
{
    public class LeaveDetails : BaseModel
    {
        #region Public Properties
        public Int32 LeaveRequestID { get; set; }

        public Int32 EmployeeID { get; set; }

        public Int32 TotalCasualLeave { get; set; }

        public Int32 TotalSickLeave { get; set; }

        public Boolean LeaveType { get; set; }

        public Boolean IsApproved { get; set; }

        public String ApprovedByID { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ApprovedOn { get; set; }

        public Int32 ApprovedDays { get; set; }

        #endregion
    }
}
