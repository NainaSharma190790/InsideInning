using System;
using iNVERTEDi.DataOperations;

namespace InsideInning.DAL
{

  /// <summary>
  /// The tblPushNotification class. The class contains the genecir DAL functions for PushNotification table.
  /// </summary>
  public class tblPushNotification : IIDataCodeGenerator
  {
     #region Table Field Constants
      public static string ID_FIELD = "ID";
      public static string TITLE_FIELD = "Title";
      public static string DESCRIPTION_FIELD = "Description";
      public static string CRETAEDON_FIELD = "CretaedOn";
      public static string CREATEDBYID_FIELD = "CreatedByID";
      public static string ISSENT_FIELD = "IsSent";

      public static string TABLE_NAME = "PushNotification";

     #endregion

      #region Constructor
      public tblPushNotification() : base(InsideInningDB.InsideInning_CONNECTIONSTRING, TABLE_NAME)
      {
          SetDataTable(Table());
      }
      #endregion

  }

}
