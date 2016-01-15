using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using iNVERTEDi.DataOperations;
using InsideInning.BO;
using InsideInning.DAL.Procedures;

namespace InsideInning.DAL
{

  /// <summary>
  /// The tblLeaveDetailsDBManager class is responsible for interacting with the database to retriece and store info about tblLeaveDetails objects.
  /// </summary>
  public partial class tblLeaveDetailsDBManager
  {
      public static BOLeaveDetails GetLeaveDetailByEmpID(Int32 id)
      {
          BOLeaveDetails itemObj = null;

          DataSet ds = spGetLeaveByEmployeeID.ExecuteDataset(id); 
          if (ds.Tables[0].Rows.Count > 1)
              throw new Exception("More than one row returned");
          if (ds.Tables[0].Rows.Count == 1)
              itemObj = FillDataRecord(ds.Tables[0].Rows[0]);
          return itemObj;
      }


  }

}
