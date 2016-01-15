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
  /// The tblPushNotificationDBManager class is responsible for interacting with the database to retriece and store info about tblPushNotification objects.
  /// </summary>
  public partial class tblPushNotificationDBManager
  {
      public static int GetCount()
      {
          tblPushNotification tblObj = new tblPushNotification();
          int count = tblObj.GetCount();
          return count;
      }

      public static int GetCount(string whereClause)
      {
          tblPushNotification tblObj = new tblPushNotification();
          int count = tblObj.GetCount(whereClause);
          return count;
      }

      public static BOPushNotificationList GetAllList()
      {
          BOPushNotificationList itemObjs = null;
          tblPushNotification tblObj = new tblPushNotification();
          DataTable dt = tblObj.GetAllData();
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOPushNotificationList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOPushNotificationList GetAllList(int startIndex, int length)
      {
          BOPushNotificationList itemObjs = null;
          tblPushNotification tblObj = new tblPushNotification();
          DataTable dt = tblObj.GetAllData(startIndex, length, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOPushNotificationList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOPushNotificationList GetAllList(int startIndex, int length, string whereClause)
      {
          BOPushNotificationList itemObjs = null;
          tblPushNotification tblObj = new tblPushNotification();
          DataTable dt = tblObj.GetAllData(startIndex, length, whereClause, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOPushNotificationList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static int Save(BOPushNotification entry, bool adding)
      {
          tblPushNotification tblObj = new tblPushNotification();
          DataRow newRow = tblObj.Table().NewRow();

              newRow[tblPushNotification.ID_FIELD] = entry.ID;
              newRow[tblPushNotification.TITLE_FIELD] = entry.Title;
              newRow[tblPushNotification.DESCRIPTION_FIELD] = entry.Description;
              if(entry.CretaedOn.Equals(new DateTime()))
                  newRow[tblPushNotification.CRETAEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblPushNotification.CRETAEDON_FIELD] = entry.CretaedOn;
              newRow[tblPushNotification.CREATEDBYID_FIELD] = entry.CreatedByID;
              newRow[tblPushNotification.ISSENT_FIELD] = entry.IsSent;

          if(adding)
              return tblObj.AddToTable(newRow);
          else
              return tblObj.UpdateTable(newRow);
      }

      public static int Save(BOPushNotificationList entryList, bool adding)
      {
          tblPushNotification tblObj = new tblPushNotification();
          DataTable dt = tblObj.Table();
          int i = 0;

          foreach(BOPushNotification entry in entryList)
          {
              DataRow newRow = tblObj.Table().NewRow();

                  newRow[tblPushNotification.ID_FIELD] = entry.ID;
                  newRow[tblPushNotification.TITLE_FIELD] = entry.Title;
                  newRow[tblPushNotification.DESCRIPTION_FIELD] = entry.Description;
          if(entry.CretaedOn.Equals(new DateTime()))
              newRow[tblPushNotification.CRETAEDON_FIELD] = DBNull.Value;
          else
              newRow[tblPushNotification.CRETAEDON_FIELD] = entry.CretaedOn;
                  newRow[tblPushNotification.CREATEDBYID_FIELD] = entry.CreatedByID;
                  newRow[tblPushNotification.ISSENT_FIELD] = entry.IsSent;

              dt.Rows.Add(newRow);
              i++;
          }

          //if(adding): Commented out at the moment. KS 28th Aug 2012
              return tblObj.AddToTable(dt);
          //else
              //return tblObj.UpdateTable(dt);
      }

      private static BOPushNotification FillDataRecord(DataRow dr)
      {
          BOPushNotification itemObj = new BOPushNotification();
          if(dr["ID"] != DBNull.Value)
              itemObj.ID = Int32.Parse(dr["ID"].ToString());
          if(dr["Title"] != DBNull.Value)
              itemObj.Title = dr["Title"].ToString();
          if(dr["Description"] != DBNull.Value)
              itemObj.Description = dr["Description"].ToString();
          if(dr["CretaedOn"] != DBNull.Value)
              itemObj.CretaedOn = DateTime.Parse(dr["CretaedOn"].ToString());
          if(dr["CreatedByID"] != DBNull.Value)
              itemObj.CreatedByID = Int32.Parse(dr["CreatedByID"].ToString());
          if(dr["IsSent"] != DBNull.Value)
              itemObj.IsSent = Boolean.Parse(dr["IsSent"].ToString());
          return itemObj;
      }

  }

}
