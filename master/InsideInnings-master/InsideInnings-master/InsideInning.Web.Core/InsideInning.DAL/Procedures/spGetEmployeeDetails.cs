using System;
using System.Data;
using System.Data.SqlClient;

using iNVERTEDi.DataOperations.SQLHelper;

namespace InsideInning.DAL.Procedures
{

  /// <summary>
  /// The spGetEmployeeDetails class. The class contains the genecir DAL functions for GetEmployeeDetails SQL Procedure.
  /// </summary>
  public class spGetEmployeeDetails
  {
     #region Procedure Parameter Constants
      private static IISQLHelper _sqlHelper = null;
      public static string PROCEDURE_NAME = "GetEmployeeDetails";
     #endregion

      #region Procedure Parameters
      #endregion

      #region Constructor
      private spGetEmployeeDetails()
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
