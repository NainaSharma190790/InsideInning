using System;

namespace InsideInning.BO
{

  /// <summary>
  /// The BOLeaveDetails class. [Please feel free to enter extra information]
  /// </summary>
  public class BOLeaveDetails
  {

      #region Public Properties
      public Int32 LeaveRequestID{ get; set;}

      public Int32 EmployeeID{ get; set;}

      public Int32 TotalCasualLeave{ get; set;}

      public Int32 TotalSickLeave{ get; set;}

      public Boolean LeaveType{ get; set;}

      public Boolean IsApproved{ get; set;}

      public String ApprovedByID{ get; set;}

      public DateTime ToDate{ get; set;}

      public DateTime FromDate{ get; set;}

      public DateTime ApprovedOn{ get; set;}

      public Int32 ApprovedDays{ get; set;}

      public DateTime CreatedOn{ get; set;}

      public String CreatedByID{ get; set;}

      public DateTime ModifiedOn{ get; set;}

      public String ModifiedByID{ get; set;}

      #endregion
  }

}
