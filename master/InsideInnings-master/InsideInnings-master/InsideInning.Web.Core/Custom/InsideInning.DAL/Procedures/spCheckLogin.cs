using InsideInning.DAL;
using iNVERTEDi.DataOperations.SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideInning.Web.Core.Custom.InsideInning.DAL.Procedures
{
    class spCheckLogin
    {
         
     #region Procedure Parameter Constants
      private static IISQLHelper _sqlHelper = null;
      public static string PROCEDURE_NAME = "CheckLogin";
     #endregion

      #region Procedure Parameters
      private static string PARAM1NAME ="@UserName";
      private static string PARAM2NAME = "@Password";
      #endregion

      #region Constructor
      private spCheckLogin()
      {
          _sqlHelper = new IISQLHelper(InsideInningDB.InsideInning_CONNECTIONSTRING);
      }
      #endregion

      #region Class Methods

      public static DataSet ExecuteDataset(string Username, string Password)
      {
          _sqlHelper = new IISQLHelper(InsideInningDB.InsideInning_CONNECTIONSTRING);
          SqlParameter[] param = new SqlParameter[2];
          SqlParameter p1 = new SqlParameter(PARAM1NAME,Username);
          SqlParameter p2 = new SqlParameter(PARAM2NAME,Password);
			 param[0] = p1;
             param[1] = p2;

          return _sqlHelper.ExecuteDataset(PROCEDURE_NAME, param);
      }

      public static void ExecuteNonQuery(Int32 empid)
      {

      }
      #endregion
    }
}
