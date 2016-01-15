using System;
using iNVERTEDi.DataOperations;

namespace InsideInning.DAL
{

  /// <summary>
  /// The tblMailSummary class. The class contains the genecir DAL functions for MailSummary table.
  /// </summary>
  public class tblMailSummary : IIDataCodeGenerator
  {
     #region Table Field Constants
      public static string MAILID_FIELD = "MailID";
      public static string TOEMPLOYEEID_FIELD = "ToEmployeeID";
      public static string CCEMPLOYEEID_FIELD = "CCEmployeeID";
      public static string FROMEMPLOYEEID_FIELD = "FromEmployeeID";
      public static string MESSAGEBODY_FIELD = "MessageBody";
      public static string MAILSUBJECT_FIELD = "MailSubject";
      public static string CREATEDON_FIELD = "CreatedOn";
      public static string CREATEDBYID_FIELD = "CreatedByID";
      public static string MODIFIEDON_FIELD = "ModifiedOn";
      public static string MODIFIEDBYID_FIELD = "ModifiedByID";

      public static string TABLE_NAME = "MailSummary";

      public static string PRIMARYKEY_FIELD1 = "MailID";
     #endregion

      #region Constructor
      public tblMailSummary() : base(InsideInningDB.InsideInning_CONNECTIONSTRING, TABLE_NAME)
      {
          SetDataTable(Table());
      }
      #endregion

  }

}
