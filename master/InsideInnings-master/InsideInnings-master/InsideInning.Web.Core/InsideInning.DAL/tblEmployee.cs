using System;
using iNVERTEDi.DataOperations;

namespace InsideInning.DAL
{

  /// <summary>
  /// The tblEmployee class. The class contains the genecir DAL functions for Employee table.
  /// </summary>
  public class tblEmployee : IIDataCodeGenerator
  {
     #region Table Field Constants
      public static string EMPLOYEEID_FIELD = "EmployeeID";
      public static string FIRSTNAME_FIELD = "FirstName";
      public static string LASTNAME_FIELD = "LastName";
      public static string EMAILADDRESS_FIELD = "EmailAddress";
      public static string PASSWORD_FIELD = "Password";
      public static string EMPLOYEETYPE_FIELD = "EmployeeType";
      public static string CREATEDON_FIELD = "CreatedOn";
      public static string CREATEDBYID_FIELD = "CreatedByID";
      public static string MODIFIEDON_FIELD = "ModifiedOn";
      public static string MODIFIEDBYID_FIELD = "ModifiedByID";
      public static string ISACTIVE_FIELD = "IsActive";

      public static string TABLE_NAME = "Employee";

      public static string PRIMARYKEY_FIELD1 = "EmployeeID";
     #endregion

      #region Constructor
      public tblEmployee() : base(InsideInningDB.InsideInning_CONNECTIONSTRING, TABLE_NAME)
      {
          SetDataTable(Table());
      }
      #endregion

  }

}
