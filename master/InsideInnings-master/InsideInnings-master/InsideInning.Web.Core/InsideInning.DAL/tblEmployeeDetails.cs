using System;
using iNVERTEDi.DataOperations;

namespace InsideInning.DAL
{

  /// <summary>
  /// The tblEmployeeDetails class. The class contains the genecir DAL functions for EmployeeDetails table.
  /// </summary>
  public class tblEmployeeDetails : IIDataCodeGenerator
  {
     #region Table Field Constants
      public static string EMPLOYEEDETAILSID_FIELD = "EmployeeDetailsID";
      public static string EMPPROFILEIMAGE_FIELD = "EmpProfileImage";
      public static string EMPLOYEEID_FIELD = "EmployeeID";
      public static string GENDER_FIELD = "gender";
      public static string MARITALSTATUS_FIELD = "MaritalStatus";
      public static string DATEOFBIRTH_FIELD = "DateOfBirth";
      public static string DATEOFANIVERSARY_FIELD = "DateOfAniversary";
      public static string CONTACTNUMBER_FIELD = "ContactNumber";
      public static string LANDLINE_FIELD = "Landline";
      public static string COMPANYPROFILE_FIELD = "CompanyProfile";
      public static string JOINNINGDATE_FIELD = "JoinningDate";
      public static string CREATEDON_FIELD = "CreatedOn";
      public static string CREATEDBYID_FIELD = "CreatedByID";
      public static string MODIFIEDON_FIELD = "ModifiedOn";
      public static string MODIFIEDBYID_FIELD = "ModifiedByID";
      public static string ISACTIVE_FIELD = "IsActive";

      public static string TABLE_NAME = "EmployeeDetails";

      public static string PRIMARYKEY_FIELD1 = "EmployeeDetailsID";
     #endregion

      #region Constructor
      public tblEmployeeDetails() : base(InsideInningDB.InsideInning_CONNECTIONSTRING, TABLE_NAME)
      {
          SetDataTable(Table());
      }
      #endregion

  }

}
