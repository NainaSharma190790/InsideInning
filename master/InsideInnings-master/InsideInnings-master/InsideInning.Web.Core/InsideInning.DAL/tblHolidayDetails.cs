using System;
using iNVERTEDi.DataOperations;

namespace InsideInning.DAL
{

  /// <summary>
  /// The tblHolidayDetails class. The class contains the genecir DAL functions for HolidayDetails table.
  /// </summary>
  public class tblHolidayDetails : IIDataCodeGenerator
  {
     #region Table Field Constants
      public static string HOLIDAYID_FIELD = "HolidayID";
      public static string HOLIDAYTYPE_FIELD = "HolidayType";
      public static string HOLIDAYDATE_FIELD = "HolidayDate";

      public static string TABLE_NAME = "HolidayDetails";

      public static string PRIMARYKEY_FIELD1 = "HolidayID";
     #endregion

      #region Constructor
      public tblHolidayDetails() : base(InsideInningDB.InsideInning_CONNECTIONSTRING, TABLE_NAME)
      {
          SetDataTable(Table());
      }
      #endregion

  }

}
