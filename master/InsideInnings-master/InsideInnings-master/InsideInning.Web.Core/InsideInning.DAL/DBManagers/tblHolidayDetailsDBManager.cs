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
  /// The tblHolidayDetailsDBManager class is responsible for interacting with the database to retriece and store info about tblHolidayDetails objects.
  /// </summary>
  public partial class tblHolidayDetailsDBManager
  {
      public static BOHolidayDetails GetItem(Int32 id)
      {
          BOHolidayDetails itemObj = null;
          tblHolidayDetails tblObj = new tblHolidayDetails();
          DataTable dt = tblObj.GetAllData(tblHolidayDetails.PRIMARYKEY_FIELD1 + " = " + id);
          if (dt.Rows.Count > 1)
              throw new Exception("More than one row returned");
          if (dt.Rows.Count == 1)
              itemObj = FillDataRecord(dt.Rows[0]);
          return itemObj;
      }

      public static int GetCount()
      {
          tblHolidayDetails tblObj = new tblHolidayDetails();
          int count = tblObj.GetCount();
          return count;
      }

      public static int GetCount(string whereClause)
      {
          tblHolidayDetails tblObj = new tblHolidayDetails();
          int count = tblObj.GetCount(whereClause);
          return count;
      }

      public static BOHolidayDetailsList GetAllList()
      {
          BOHolidayDetailsList itemObjs = null;
          tblHolidayDetails tblObj = new tblHolidayDetails();
          DataTable dt = tblObj.GetAllData();
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOHolidayDetailsList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOHolidayDetailsList GetAllList(int startIndex, int length)
      {
          BOHolidayDetailsList itemObjs = null;
          tblHolidayDetails tblObj = new tblHolidayDetails();
          DataTable dt = tblObj.GetAllData(startIndex, length, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOHolidayDetailsList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOHolidayDetailsList GetAllList(int startIndex, int length, string whereClause)
      {
          BOHolidayDetailsList itemObjs = null;
          tblHolidayDetails tblObj = new tblHolidayDetails();
          DataTable dt = tblObj.GetAllData(startIndex, length, whereClause, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOHolidayDetailsList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static int Save(BOHolidayDetails entry, bool adding)
      {
          tblHolidayDetails tblObj = new tblHolidayDetails();
          DataRow newRow = tblObj.Table().NewRow();

              newRow[tblHolidayDetails.HOLIDAYID_FIELD] = entry.HolidayID;
              newRow[tblHolidayDetails.HOLIDAYTYPE_FIELD] = entry.HolidayType;
              if(entry.HolidayDate.Equals(new DateTime()))
                  newRow[tblHolidayDetails.HOLIDAYDATE_FIELD] = DBNull.Value;
              else
                  newRow[tblHolidayDetails.HOLIDAYDATE_FIELD] = entry.HolidayDate;

          if(adding)
              return tblObj.AddToTable(newRow);
          else
              return tblObj.UpdateTable(newRow);
      }

      public static int Save(BOHolidayDetailsList entryList, bool adding)
      {
          tblHolidayDetails tblObj = new tblHolidayDetails();
          DataTable dt = tblObj.Table();
          int i = 0;

          foreach(BOHolidayDetails entry in entryList)
          {
              DataRow newRow = tblObj.Table().NewRow();

              newRow[tblHolidayDetails.HOLIDAYTYPE_FIELD] = entry.HolidayType;
          if(entry.HolidayDate.Equals(new DateTime()))
              newRow[tblHolidayDetails.HOLIDAYDATE_FIELD] = DBNull.Value;
          else
              newRow[tblHolidayDetails.HOLIDAYDATE_FIELD] = entry.HolidayDate;

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
          tblHolidayDetails tblObj = new tblHolidayDetails();
          int affectedRow = tblObj.DeleteTable(tblHolidayDetails.PRIMARYKEY_FIELD1 + " = " + id);
          if (affectedRow != 1)
              throw new Exception("Could not find entry with id: " + id);
          else
              return true;
      }

      private static BOHolidayDetails FillDataRecord(DataRow dr)
      {
          BOHolidayDetails itemObj = new BOHolidayDetails();
          if(dr["HolidayID"] != DBNull.Value)
              itemObj.HolidayID = Int32.Parse(dr["HolidayID"].ToString());
          if(dr["HolidayType"] != DBNull.Value)
              itemObj.HolidayType = dr["HolidayType"].ToString();
          if(dr["HolidayDate"] != DBNull.Value)
              itemObj.HolidayDate = DateTime.Parse(dr["HolidayDate"].ToString());
          return itemObj;
      }

  }

}
