using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using iNVERTEDi.DataOperations;
using InsideInning.BO;

namespace InsideInning.DAL
{

  /// <summary>
  /// The tblLeaveDetailsDBManager class is responsible for interacting with the database to retriece and store info about tblLeaveDetails objects.
  /// </summary>
  public partial class tblLeaveDetailsDBManager
  {
      public static BOLeaveDetails GetItem(Int32 id)
      {
          BOLeaveDetails itemObj = null;
          tblLeaveDetails tblObj = new tblLeaveDetails();
          DataTable dt = tblObj.GetAllData(tblLeaveDetails.PRIMARYKEY_FIELD1 + " = " + id);
          if (dt.Rows.Count > 1)
              throw new Exception("More than one row returned");
          if (dt.Rows.Count == 1)
              itemObj = FillDataRecord(dt.Rows[0]);
          return itemObj;
      }

      public static int GetCount()
      {
          tblLeaveDetails tblObj = new tblLeaveDetails();
          int count = tblObj.GetCount();
          return count;
      }

      public static int GetCount(string whereClause)
      {
          tblLeaveDetails tblObj = new tblLeaveDetails();
          int count = tblObj.GetCount(whereClause);
          return count;
      }

      public static BOLeaveDetailsList GetAllList()
      {
          BOLeaveDetailsList itemObjs = null;
          tblLeaveDetails tblObj = new tblLeaveDetails();
          DataTable dt = tblObj.GetAllData();
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOLeaveDetailsList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOLeaveDetailsList GetAllList(int startIndex, int length)
      {
          BOLeaveDetailsList itemObjs = null;
          tblLeaveDetails tblObj = new tblLeaveDetails();
          DataTable dt = tblObj.GetAllData(startIndex, length, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOLeaveDetailsList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOLeaveDetailsList GetAllList(int startIndex, int length, string whereClause)
      {
          BOLeaveDetailsList itemObjs = null;
          tblLeaveDetails tblObj = new tblLeaveDetails();
          DataTable dt = tblObj.GetAllData(startIndex, length, whereClause, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOLeaveDetailsList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static int Save(BOLeaveDetails entry, bool adding)
      {
          tblLeaveDetails tblObj = new tblLeaveDetails();
          DataRow newRow = tblObj.Table().NewRow();

              newRow[tblLeaveDetails.LEAVEREQUESTID_FIELD] = entry.LeaveRequestID;
              newRow[tblLeaveDetails.EMPLOYEEID_FIELD] = entry.EmployeeID;
              newRow[tblLeaveDetails.TOTALCASUALLEAVE_FIELD] = entry.TotalCasualLeave;
              newRow[tblLeaveDetails.TOTALSICKLEAVE_FIELD] = entry.TotalSickLeave;
              newRow[tblLeaveDetails.LEAVETYPE_FIELD] = entry.LeaveType;
              newRow[tblLeaveDetails.ISAPPROVED_FIELD] = entry.IsApproved;
              newRow[tblLeaveDetails.APPROVEDBYID_FIELD] = entry.ApprovedByID;
              if(entry.ToDate.Equals(new DateTime()))
                  newRow[tblLeaveDetails.TODATE_FIELD] = DBNull.Value;
              else
                  newRow[tblLeaveDetails.TODATE_FIELD] = entry.ToDate;
              if(entry.FromDate.Equals(new DateTime()))
                  newRow[tblLeaveDetails.FROMDATE_FIELD] = DBNull.Value;
              else
                  newRow[tblLeaveDetails.FROMDATE_FIELD] = entry.FromDate;
              if(entry.ApprovedOn.Equals(new DateTime()))
                  newRow[tblLeaveDetails.APPROVEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblLeaveDetails.APPROVEDON_FIELD] = entry.ApprovedOn;
              newRow[tblLeaveDetails.APPROVEDDAYS_FIELD] = entry.ApprovedDays;
              if(entry.CreatedOn.Equals(new DateTime()))
                  newRow[tblLeaveDetails.CREATEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblLeaveDetails.CREATEDON_FIELD] = entry.CreatedOn;
              newRow[tblLeaveDetails.CREATEDBYID_FIELD] = entry.CreatedByID;
              if(entry.ModifiedOn.Equals(new DateTime()))
                  newRow[tblLeaveDetails.MODIFIEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblLeaveDetails.MODIFIEDON_FIELD] = entry.ModifiedOn;
              newRow[tblLeaveDetails.MODIFIEDBYID_FIELD] = entry.ModifiedByID;

          if(adding)
              return tblObj.AddToTable(newRow);
          else
              return tblObj.UpdateTable(newRow);
      }

      public static int Save(BOLeaveDetailsList entryList, bool adding)
      {
          tblLeaveDetails tblObj = new tblLeaveDetails();
          DataTable dt = tblObj.Table();
          int i = 0;

          foreach(BOLeaveDetails entry in entryList)
          {
              DataRow newRow = tblObj.Table().NewRow();

              newRow[tblLeaveDetails.EMPLOYEEID_FIELD] = entry.EmployeeID;
              newRow[tblLeaveDetails.TOTALCASUALLEAVE_FIELD] = entry.TotalCasualLeave;
              newRow[tblLeaveDetails.TOTALSICKLEAVE_FIELD] = entry.TotalSickLeave;
              newRow[tblLeaveDetails.LEAVETYPE_FIELD] = entry.LeaveType;
              newRow[tblLeaveDetails.ISAPPROVED_FIELD] = entry.IsApproved;
              newRow[tblLeaveDetails.APPROVEDBYID_FIELD] = entry.ApprovedByID;
          if(entry.ToDate.Equals(new DateTime()))
              newRow[tblLeaveDetails.TODATE_FIELD] = DBNull.Value;
          else
              newRow[tblLeaveDetails.TODATE_FIELD] = entry.ToDate;
          if(entry.FromDate.Equals(new DateTime()))
              newRow[tblLeaveDetails.FROMDATE_FIELD] = DBNull.Value;
          else
              newRow[tblLeaveDetails.FROMDATE_FIELD] = entry.FromDate;
          if(entry.ApprovedOn.Equals(new DateTime()))
              newRow[tblLeaveDetails.APPROVEDON_FIELD] = DBNull.Value;
          else
              newRow[tblLeaveDetails.APPROVEDON_FIELD] = entry.ApprovedOn;
              newRow[tblLeaveDetails.APPROVEDDAYS_FIELD] = entry.ApprovedDays;
          if(entry.CreatedOn.Equals(new DateTime()))
              newRow[tblLeaveDetails.CREATEDON_FIELD] = DBNull.Value;
          else
              newRow[tblLeaveDetails.CREATEDON_FIELD] = entry.CreatedOn;
              newRow[tblLeaveDetails.CREATEDBYID_FIELD] = entry.CreatedByID;
          if(entry.ModifiedOn.Equals(new DateTime()))
              newRow[tblLeaveDetails.MODIFIEDON_FIELD] = DBNull.Value;
          else
              newRow[tblLeaveDetails.MODIFIEDON_FIELD] = entry.ModifiedOn;
              newRow[tblLeaveDetails.MODIFIEDBYID_FIELD] = entry.ModifiedByID;

              dt.Rows.Add(newRow);
              i++;
          }

          //if(adding): Commented out at the moment. KS 28th Aug 2012
              return tblObj.AddToTable(dt);
          //else
              //return tblObj.UpdateTable(dt);
      }

      public static bool Delete(Int32 id)
      {
          tblLeaveDetails tblObj = new tblLeaveDetails();
          int affectedRow = tblObj.DeleteTable(tblLeaveDetails.PRIMARYKEY_FIELD1 + " = " + id);
          if (affectedRow != 1)
              throw new Exception("Could not find entry with id: " + id);
          else
              return true;
      }

      private static BOLeaveDetails FillDataRecord(DataRow dr)
      {
          BOLeaveDetails itemObj = new BOLeaveDetails();
          if(dr["LeaveRequestID"] != DBNull.Value)
              itemObj.LeaveRequestID = Int32.Parse(dr["LeaveRequestID"].ToString());
          if(dr["EmployeeID"] != DBNull.Value)
              itemObj.EmployeeID = Int32.Parse(dr["EmployeeID"].ToString());
          if(dr["TotalCasualLeave"] != DBNull.Value)
              itemObj.TotalCasualLeave = Int32.Parse(dr["TotalCasualLeave"].ToString());
          if(dr["TotalSickLeave"] != DBNull.Value)
              itemObj.TotalSickLeave = Int32.Parse(dr["TotalSickLeave"].ToString());
          if(dr["LeaveType"] != DBNull.Value)
              itemObj.LeaveType = Boolean.Parse(dr["LeaveType"].ToString());
          if(dr["IsApproved"] != DBNull.Value)
              itemObj.IsApproved = Boolean.Parse(dr["IsApproved"].ToString());
          if(dr["ApprovedByID"] != DBNull.Value)
              itemObj.ApprovedByID = dr["ApprovedByID"].ToString();
          if(dr["ToDate"] != DBNull.Value)
              itemObj.ToDate = DateTime.Parse(dr["ToDate"].ToString());
          if(dr["FromDate"] != DBNull.Value)
              itemObj.FromDate = DateTime.Parse(dr["FromDate"].ToString());
          if(dr["ApprovedOn"] != DBNull.Value)
              itemObj.ApprovedOn = DateTime.Parse(dr["ApprovedOn"].ToString());
          if(dr["ApprovedDays"] != DBNull.Value)
              itemObj.ApprovedDays = Int32.Parse(dr["ApprovedDays"].ToString());
          if(dr["CreatedOn"] != DBNull.Value)
              itemObj.CreatedOn = DateTime.Parse(dr["CreatedOn"].ToString());
          if(dr["CreatedByID"] != DBNull.Value)
              itemObj.CreatedByID = dr["CreatedByID"].ToString();
          if(dr["ModifiedOn"] != DBNull.Value)
              itemObj.ModifiedOn = DateTime.Parse(dr["ModifiedOn"].ToString());
          if(dr["ModifiedByID"] != DBNull.Value)
              itemObj.ModifiedByID = dr["ModifiedByID"].ToString();
          return itemObj;
      }

  }

}
