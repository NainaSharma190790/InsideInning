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
  /// The tblEmployeeDBManager class is responsible for interacting with the database to retriece and store info about tblEmployee objects.
  /// </summary>
  public partial class tblEmployeeDBManager
  {
      public static BOEmployee GetItem(Int32 id)
      {
          BOEmployee itemObj = null;
          tblEmployee tblObj = new tblEmployee();
          DataTable dt = tblObj.GetAllData(tblEmployee.PRIMARYKEY_FIELD1 + " = " + id);
          if (dt.Rows.Count > 1)
              throw new Exception("More than one row returned");
          if (dt.Rows.Count == 1)
              itemObj = FillDataRecord(dt.Rows[0]);
          return itemObj;
      }

      public static int GetCount()
      {
          tblEmployee tblObj = new tblEmployee();
          int count = tblObj.GetCount();
          return count;
      }

      public static int GetCount(string whereClause)
      {
          tblEmployee tblObj = new tblEmployee();
          int count = tblObj.GetCount(whereClause);
          return count;
      }

      public static BOEmployeeList GetAllList()
      {
          BOEmployeeList itemObjs = null;
          tblEmployee tblObj = new tblEmployee();
          DataTable dt = tblObj.GetAllData();
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOEmployeeList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOEmployeeList GetAllList(int startIndex, int length)
      {
          BOEmployeeList itemObjs = null;
          tblEmployee tblObj = new tblEmployee();
          DataTable dt = tblObj.GetAllData(startIndex, length, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOEmployeeList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOEmployeeList GetAllList(int startIndex, int length, string whereClause)
      {
          BOEmployeeList itemObjs = null;
          tblEmployee tblObj = new tblEmployee();
          DataTable dt = tblObj.GetAllData(startIndex, length, whereClause, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOEmployeeList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static int Save(BOEmployee entry, bool adding)
      {
          tblEmployee tblObj = new tblEmployee();
          DataRow newRow = tblObj.Table().NewRow();

              newRow[tblEmployee.EMPLOYEEID_FIELD] = entry.EmployeeID;
              newRow[tblEmployee.FIRSTNAME_FIELD] = entry.FirstName;
              newRow[tblEmployee.LASTNAME_FIELD] = entry.LastName;
              newRow[tblEmployee.EMAILADDRESS_FIELD] = entry.EmailAddress;
              newRow[tblEmployee.PASSWORD_FIELD] = entry.Password;
              newRow[tblEmployee.EMPLOYEETYPE_FIELD] = entry.EmployeeType;
              if(entry.CreatedOn.Equals(new DateTime()))
                  newRow[tblEmployee.CREATEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblEmployee.CREATEDON_FIELD] = entry.CreatedOn;
              newRow[tblEmployee.CREATEDBYID_FIELD] = entry.CreatedByID;
              if(entry.ModifiedOn.Equals(new DateTime()))
                  newRow[tblEmployee.MODIFIEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblEmployee.MODIFIEDON_FIELD] = entry.ModifiedOn;
              newRow[tblEmployee.MODIFIEDBYID_FIELD] = entry.ModifiedByID;
              newRow[tblEmployee.ISACTIVE_FIELD] = entry.IsActive;

          if(adding)
              return tblObj.AddToTable(newRow);
          else
              return tblObj.UpdateTable(newRow);
      }

      public static int Save(BOEmployeeList entryList, bool adding)
      {
          tblEmployee tblObj = new tblEmployee();
          DataTable dt = tblObj.Table();
          int i = 0;

          foreach(BOEmployee entry in entryList)
          {
              DataRow newRow = tblObj.Table().NewRow();

              newRow[tblEmployee.FIRSTNAME_FIELD] = entry.FirstName;
              newRow[tblEmployee.LASTNAME_FIELD] = entry.LastName;
              newRow[tblEmployee.EMAILADDRESS_FIELD] = entry.EmailAddress;
              newRow[tblEmployee.PASSWORD_FIELD] = entry.Password;
              newRow[tblEmployee.EMPLOYEETYPE_FIELD] = entry.EmployeeType;
          if(entry.CreatedOn.Equals(new DateTime()))
              newRow[tblEmployee.CREATEDON_FIELD] = DBNull.Value;
          else
              newRow[tblEmployee.CREATEDON_FIELD] = entry.CreatedOn;
              newRow[tblEmployee.CREATEDBYID_FIELD] = entry.CreatedByID;
          if(entry.ModifiedOn.Equals(new DateTime()))
              newRow[tblEmployee.MODIFIEDON_FIELD] = DBNull.Value;
          else
              newRow[tblEmployee.MODIFIEDON_FIELD] = entry.ModifiedOn;
              newRow[tblEmployee.MODIFIEDBYID_FIELD] = entry.ModifiedByID;
              newRow[tblEmployee.ISACTIVE_FIELD] = entry.IsActive;

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
          tblEmployee tblObj = new tblEmployee();
          int affectedRow = tblObj.DeleteTable(tblEmployee.PRIMARYKEY_FIELD1 + " = " + id);
          if (affectedRow != 1)
              throw new Exception("Could not find entry with id: " + id);
          else
              return true;
      }

      private static BOEmployee FillDataRecord(DataRow dr)
      {
          BOEmployee itemObj = new BOEmployee();
          if(dr["EmployeeID"] != DBNull.Value)
              itemObj.EmployeeID = Int32.Parse(dr["EmployeeID"].ToString());
          if(dr["FirstName"] != DBNull.Value)
              itemObj.FirstName = dr["FirstName"].ToString();
          if(dr["LastName"] != DBNull.Value)
              itemObj.LastName = dr["LastName"].ToString();
          if(dr["EmailAddress"] != DBNull.Value)
              itemObj.EmailAddress = dr["EmailAddress"].ToString();
          if(dr["Password"] != DBNull.Value)
              itemObj.Password = dr["Password"].ToString();
          if(dr["EmployeeType"] != DBNull.Value)
              itemObj.EmployeeType = Boolean.Parse(dr["EmployeeType"].ToString());
          if(dr["CreatedOn"] != DBNull.Value)
              itemObj.CreatedOn = DateTime.Parse(dr["CreatedOn"].ToString());
          if(dr["CreatedByID"] != DBNull.Value)
              itemObj.CreatedByID = Int32.Parse(dr["CreatedByID"].ToString());
          if(dr["ModifiedOn"] != DBNull.Value)
              itemObj.ModifiedOn = DateTime.Parse(dr["ModifiedOn"].ToString());
          if(dr["ModifiedByID"] != DBNull.Value)
              itemObj.ModifiedByID = Int32.Parse(dr["ModifiedByID"].ToString());
          if(dr["IsActive"] != DBNull.Value)
              itemObj.IsActive = Boolean.Parse(dr["IsActive"].ToString());
          return itemObj;
      }

  }

}
