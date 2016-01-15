using System;
using System.Data;
using System.Data.SqlClient;

using iNVERTEDi.DataOperations.SQLHelper;

namespace InsideInning.DAL.Procedures
{

  /// <summary>
  /// The spCheckLogin class. The class contains the genecir DAL functions for CheckLogin SQL Procedure.
  /// </summary>
  public class spCheckLogin
  {
     #region Procedure Parameter Constants
      private static IISQLHelper _sqlHelper = null;
      public static string PROCEDURE_NAME = "CheckLogin";
     #endregion

      #region Procedure Parameters
      private static string PARAM1NAME ="@UserName";
      private static string PARAM2NAME ="@Password";
      #endregion

      #region Constructor
      private spCheckLogin()
      {
          _sqlHelper = new IISQLHelper(InsideInningDB.InsideInning_CONNECTIONSTRING);
      }
      #endregion

      #region Class Methods

      public static DataSet ExecuteDataset(String username, String password)
      {
          SqlParameter[] param = new SqlParameter[2];
          SqlParameter p1 = new SqlParameter(PARAM1NAME, username);
			 param[0] = p1;
          SqlParameter p2 = new SqlParameter(PARAM2NAME, password);
			 param[1] = p2;


          return _sqlHelper.ExecuteDataset(PROCEDURE_NAME, param);
      }

      public static void ExecuteNonQuery(String username, String password)
      {
          SqlParameter[] param = new SqlParameter[2];
          SqlParameter p1 = new SqlParameter(PARAM1NAME, username);
			 param[0] = p1;
          SqlParameter p2 = new SqlParameter(PARAM2NAME, password);
			 param[1] = p2;


          _sqlHelper.ExecuteNonQuery(PROCEDURE_NAME, param);
      }


      #endregion

  }

}
