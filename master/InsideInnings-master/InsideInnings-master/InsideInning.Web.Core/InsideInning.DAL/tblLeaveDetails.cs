using System;
using iNVERTEDi.DataOperations;

namespace InsideInning.DAL
{

  /// <summary>
  /// The tblLeaveDetails class. The class contains the genecir DAL functions for LeaveDetails table.
  /// </summary>
  public class tblLeaveDetails : IIDataCodeGenerator
  {
     #region Table Field Constants
      public static string LEAVEREQUESTID_FIELD = "LeaveRequestID";
      public static string EMPLOYEEID_FIELD = "EmployeeID";
      public static string TOTALCASUALLEAVE_FIELD = "TotalCasualLeave";
      public static string TOTALSICKLEAVE_FIELD = "TotalSickLeave";
      public static string LEAVETYPE_FIELD = "LeaveType";
      public static string ISAPPROVED_FIELD = "IsApproved";
      public static string APPROVEDBYID_FIELD = "ApprovedByID";
      public static string TODATE_FIELD = "ToDate";
      public static string FROMDATE_FIELD = "FromDate";
      public static string APPROVEDON_FIELD = "ApprovedOn";
      public static string APPROVEDDAYS_FIELD = "ApprovedDays";
      public static string CREATEDON_FIELD = "CreatedOn";
      public static string CREATEDBYID_FIELD = "CreatedByID";
      public static string MODIFIEDON_FIELD = "ModifiedOn";
      public static string MODIFIEDBYID_FIELD = "ModifiedByID";

      public static string TABLE_NAME = "LeaveDetails";

      public static string PRIMARYKEY_FIELD1 = "LeaveRequestID";
     #endregion

      #region Constructor
      public tblLeaveDetails() : base(InsideInningDB.InsideInning_CONNECTIONSTRING, TABLE_NAME)
      {
          SetDataTable(Table());
      }
      #endregion

  }

}
