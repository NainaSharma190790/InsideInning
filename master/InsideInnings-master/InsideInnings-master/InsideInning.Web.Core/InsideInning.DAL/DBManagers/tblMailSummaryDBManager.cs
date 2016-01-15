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
  /// The tblMailSummaryDBManager class is responsible for interacting with the database to retriece and store info about tblMailSummary objects.
  /// </summary>
  public partial class tblMailSummaryDBManager
  {
      public static BOMailSummary GetItem(Int32 id)
      {
          BOMailSummary itemObj = null;
          tblMailSummary tblObj = new tblMailSummary();
          DataTable dt = tblObj.GetAllData(tblMailSummary.PRIMARYKEY_FIELD1 + " = " + id);
          if (dt.Rows.Count > 1)
              throw new Exception("More than one row returned");
          if (dt.Rows.Count == 1)
              itemObj = FillDataRecord(dt.Rows[0]);
          return itemObj;
      }

      public static int GetCount()
      {
          tblMailSummary tblObj = new tblMailSummary();
          int count = tblObj.GetCount();
          return count;
      }

      public static int GetCount(string whereClause)
      {
          tblMailSummary tblObj = new tblMailSummary();
          int count = tblObj.GetCount(whereClause);
          return count;
      }

      public static BOMailSummaryList GetAllList()
      {
          BOMailSummaryList itemObjs = null;
          tblMailSummary tblObj = new tblMailSummary();
          DataTable dt = tblObj.GetAllData();
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOMailSummaryList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOMailSummaryList GetAllList(int startIndex, int length)
      {
          BOMailSummaryList itemObjs = null;
          tblMailSummary tblObj = new tblMailSummary();
          DataTable dt = tblObj.GetAllData(startIndex, length, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOMailSummaryList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOMailSummaryList GetAllList(int startIndex, int length, string whereClause)
      {
          BOMailSummaryList itemObjs = null;
          tblMailSummary tblObj = new tblMailSummary();
          DataTable dt = tblObj.GetAllData(startIndex, length, whereClause, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOMailSummaryList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static int Save(BOMailSummary entry, bool adding)
      {
          tblMailSummary tblObj = new tblMailSummary();
          DataRow newRow = tblObj.Table().NewRow();

              newRow[tblMailSummary.MAILID_FIELD] = entry.MailID;
              newRow[tblMailSummary.TOEMPLOYEEID_FIELD] = entry.ToEmployeeID;
              newRow[tblMailSummary.CCEMPLOYEEID_FIELD] = entry.CCEmployeeID;
              newRow[tblMailSummary.FROMEMPLOYEEID_FIELD] = entry.FromEmployeeID;
              newRow[tblMailSummary.MESSAGEBODY_FIELD] = entry.MessageBody;
              newRow[tblMailSummary.MAILSUBJECT_FIELD] = entry.MailSubject;
              if(entry.CreatedOn.Equals(new DateTime()))
                  newRow[tblMailSummary.CREATEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblMailSummary.CREATEDON_FIELD] = entry.CreatedOn;
              newRow[tblMailSummary.CREATEDBYID_FIELD] = entry.CreatedByID;
              if(entry.ModifiedOn.Equals(new DateTime()))
                  newRow[tblMailSummary.MODIFIEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblMailSummary.MODIFIEDON_FIELD] = entry.ModifiedOn;
              newRow[tblMailSummary.MODIFIEDBYID_FIELD] = entry.ModifiedByID;

          if(adding)
              return tblObj.AddToTable(newRow);
          else
              return tblObj.UpdateTable(newRow);
      }

      public static int Save(BOMailSummaryList entryList, bool adding)
      {
          tblMailSummary tblObj = new tblMailSummary();
          DataTable dt = tblObj.Table();
          int i = 0;

          foreach(BOMailSummary entry in entryList)
          {
              DataRow newRow = tblObj.Table().NewRow();

              newRow[tblMailSummary.TOEMPLOYEEID_FIELD] = entry.ToEmployeeID;
              newRow[tblMailSummary.CCEMPLOYEEID_FIELD] = entry.CCEmployeeID;
              newRow[tblMailSummary.FROMEMPLOYEEID_FIELD] = entry.FromEmployeeID;
              newRow[tblMailSummary.MESSAGEBODY_FIELD] = entry.MessageBody;
              newRow[tblMailSummary.MAILSUBJECT_FIELD] = entry.MailSubject;
          if(entry.CreatedOn.Equals(new DateTime()))
              newRow[tblMailSummary.CREATEDON_FIELD] = DBNull.Value;
          else
              newRow[tblMailSummary.CREATEDON_FIELD] = entry.CreatedOn;
              newRow[tblMailSummary.CREATEDBYID_FIELD] = entry.CreatedByID;
          if(entry.ModifiedOn.Equals(new DateTime()))
              newRow[tblMailSummary.MODIFIEDON_FIELD] = DBNull.Value;
          else
              newRow[tblMailSummary.MODIFIEDON_FIELD] = entry.ModifiedOn;
              newRow[tblMailSummary.MODIFIEDBYID_FIELD] = entry.ModifiedByID;

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
          tblMailSummary tblObj = new tblMailSummary();
          int affectedRow = tblObj.DeleteTable(tblMailSummary.PRIMARYKEY_FIELD1 + " = " + id);
          if (affectedRow != 1)
              throw new Exception("Could not find entry with id: " + id);
          else
              return true;
      }

      private static BOMailSummary FillDataRecord(DataRow dr)
      {
          BOMailSummary itemObj = new BOMailSummary();
          if(dr["MailID"] != DBNull.Value)
              itemObj.MailID = Int32.Parse(dr["MailID"].ToString());
          if(dr["ToEmployeeID"] != DBNull.Value)
              itemObj.ToEmployeeID = Int32.Parse(dr["ToEmployeeID"].ToString());
          if(dr["CCEmployeeID"] != DBNull.Value)
              itemObj.CCEmployeeID = Int32.Parse(dr["CCEmployeeID"].ToString());
          if(dr["FromEmployeeID"] != DBNull.Value)
              itemObj.FromEmployeeID = Int32.Parse(dr["FromEmployeeID"].ToString());
          if(dr["MessageBody"] != DBNull.Value)
              itemObj.MessageBody = dr["MessageBody"].ToString();
          if(dr["MailSubject"] != DBNull.Value)
              itemObj.MailSubject = dr["MailSubject"].ToString();
          if(dr["CreatedOn"] != DBNull.Value)
              itemObj.CreatedOn = DateTime.Parse(dr["CreatedOn"].ToString());
          if(dr["CreatedByID"] != DBNull.Value)
              itemObj.CreatedByID = Int32.Parse(dr["CreatedByID"].ToString());
          if(dr["ModifiedOn"] != DBNull.Value)
              itemObj.ModifiedOn = DateTime.Parse(dr["ModifiedOn"].ToString());
          if(dr["ModifiedByID"] != DBNull.Value)
              itemObj.ModifiedByID = Int32.Parse(dr["ModifiedByID"].ToString());
          return itemObj;
      }

  }

}
