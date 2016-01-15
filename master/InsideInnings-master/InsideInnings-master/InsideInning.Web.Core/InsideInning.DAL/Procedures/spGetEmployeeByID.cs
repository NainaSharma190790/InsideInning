using System;
using System.Data;
using System.Data.SqlClient;

using iNVERTEDi.DataOperations.SQLHelper;

namespace InsideInning.DAL.Procedures
{

  /// <summary>
  /// The spGetEmployeeByID class. The class contains the genecir DAL functions for GetEmployeeByID SQL Procedure.
  /// </summary>
  public class spGetEmployeeByID
  {
     #region Procedure Parameter Constants
      private static IISQLHelper _sqlHelper = null;
      public static string PROCEDURE_NAME = "GetEmployeeByID";
     #endregion

      #region Procedure Parameters
      private static string PARAM1NAME ="@EmpID";
      #endregion

      #region Constructor
      private spGetEmployeeByID()
      {
          _sqlHelper = new IISQLHelper(InsideInningDB.InsideInning_CONNECTIONSTRING);
      }
      #endregion

      #region Class Methods

      public static DataSet ExecuteDataset(Int32 empid)
      {
          SqlParameter[] param = new SqlParameter[1];
          SqlParameter p1 = new SqlParameter(PARAM1NAME, empid);
			 param[0] = p1;


          return _sqlHelper.ExecuteDataset(PROCEDURE_NAME, param);
      }

      public static void ExecuteNonQuery(Int32 empid)
      {
          SqlParameter[] param = new SqlParameter[1];
          SqlParameter p1 = new SqlParameter(PARAM1NAME, empid);
			 param[0] = p1;


          _sqlHelper.ExecuteNonQuery(PROCEDURE_NAME, param);
      }


      #endregion

  }

}
