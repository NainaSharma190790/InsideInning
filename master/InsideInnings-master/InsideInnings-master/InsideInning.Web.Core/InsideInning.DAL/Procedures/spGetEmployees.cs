using System;
using System.Data;
using System.Data.SqlClient;

using iNVERTEDi.DataOperations.SQLHelper;

namespace InsideInning.DAL.Procedures
{

  /// <summary>
  /// The spGetEmployees class. The class contains the genecir DAL functions for GetEmployees SQL Procedure.
  /// </summary>
  public class spGetEmployees
  {
     #region Procedure Parameter Constants
      private static IISQLHelper _sqlHelper = null;
      public static string PROCEDURE_NAME = "GetEmployees";
     #endregion

      #region Procedure Parameters
      #endregion

      #region Constructor
      private spGetEmployees()
      {
          _sqlHelper = new IISQLHelper(InsideInningDB.InsideInning_CONNECTIONSTRING);
      }
      #endregion

      #region Class Methods

      public static DataSet ExecuteDataset()
      {
          return _sqlHelper.ExecuteDataset(PROCEDURE_NAME, null);
      }

      public static void ExecuteNonQuery()
      {
          _sqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, PROCEDURE_NAME);
      }


      #endregion

  }

}
