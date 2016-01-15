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
  /// The tblEmployeeDetailsDBManager class is responsible for interacting with the database to retriece and store info about tblEmployeeDetails objects.
  /// </summary>
  public partial class tblEmployeeDetailsDBManager
  {
      public static BOEmployeeDetails GetItem(Int32 id)
      {
          BOEmployeeDetails itemObj = null;
          tblEmployeeDetails tblObj = new tblEmployeeDetails();
          DataTable dt = tblObj.GetAllData(tblEmployeeDetails.PRIMARYKEY_FIELD1 + " = " + id);
          if (dt.Rows.Count > 1)
              throw new Exception("More than one row returned");
          if (dt.Rows.Count == 1)
              itemObj = FillDataRecord(dt.Rows[0]);
          return itemObj;
      }

      public static int GetCount()
      {
          tblEmployeeDetails tblObj = new tblEmployeeDetails();
          int count = tblObj.GetCount();
          return count;
      }

      public static int GetCount(string whereClause)
      {
          tblEmployeeDetails tblObj = new tblEmployeeDetails();
          int count = tblObj.GetCount(whereClause);
          return count;
      }

      public static BOEmployeeDetailsList GetAllList()
      {
          BOEmployeeDetailsList itemObjs = null;
          tblEmployeeDetails tblObj = new tblEmployeeDetails();
          DataTable dt = tblObj.GetAllData();
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOEmployeeDetailsList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOEmployeeDetailsList GetAllList(int startIndex, int length)
      {
          BOEmployeeDetailsList itemObjs = null;
          tblEmployeeDetails tblObj = new tblEmployeeDetails();
          DataTable dt = tblObj.GetAllData(startIndex, length, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOEmployeeDetailsList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static BOEmployeeDetailsList GetAllList(int startIndex, int length, string whereClause)
      {
          BOEmployeeDetailsList itemObjs = null;
          tblEmployeeDetails tblObj = new tblEmployeeDetails();
          DataTable dt = tblObj.GetAllData(startIndex, length, whereClause, null);
          if (dt.Rows.Count > 0)
          {
              itemObjs = new BOEmployeeDetailsList();
              foreach(DataRow dr in dt.Rows)
              {
                  itemObjs.Add(FillDataRecord(dr));
              }
          }
          return itemObjs;
      }

      public static int Save(BOEmployeeDetails entry, bool adding)
      {
          tblEmployeeDetails tblObj = new tblEmployeeDetails();
          DataRow newRow = tblObj.Table().NewRow();

              newRow[tblEmployeeDetails.EMPLOYEEDETAILSID_FIELD] = entry.EmployeeDetailsID;
              newRow[tblEmployeeDetails.EMPPROFILEIMAGE_FIELD] = entry.EmpProfileImage;
              newRow[tblEmployeeDetails.EMPLOYEEID_FIELD] = entry.EmployeeID;
              newRow[tblEmployeeDetails.GENDER_FIELD] = entry.gender;
              newRow[tblEmployeeDetails.MARITALSTATUS_FIELD] = entry.MaritalStatus;
              if(entry.DateOfBirth.Equals(new DateTime()))
                  newRow[tblEmployeeDetails.DATEOFBIRTH_FIELD] = DBNull.Value;
              else
                  newRow[tblEmployeeDetails.DATEOFBIRTH_FIELD] = entry.DateOfBirth;
              if(entry.DateOfAniversary.Equals(new DateTime()))
                  newRow[tblEmployeeDetails.DATEOFANIVERSARY_FIELD] = DBNull.Value;
              else
                  newRow[tblEmployeeDetails.DATEOFANIVERSARY_FIELD] = entry.DateOfAniversary;
              newRow[tblEmployeeDetails.CONTACTNUMBER_FIELD] = entry.ContactNumber;
              newRow[tblEmployeeDetails.LANDLINE_FIELD] = entry.Landline;
              newRow[tblEmployeeDetails.COMPANYPROFILE_FIELD] = entry.CompanyProfile;
              if(entry.JoinningDate.Equals(new DateTime()))
                  newRow[tblEmployeeDetails.JOINNINGDATE_FIELD] = DBNull.Value;
              else
                  newRow[tblEmployeeDetails.JOINNINGDATE_FIELD] = entry.JoinningDate;
              if(entry.CreatedOn.Equals(new DateTime()))
                  newRow[tblEmployeeDetails.CREATEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblEmployeeDetails.CREATEDON_FIELD] = entry.CreatedOn;
              newRow[tblEmployeeDetails.CREATEDBYID_FIELD] = entry.CreatedByID;
              if(entry.ModifiedOn.Equals(new DateTime()))
                  newRow[tblEmployeeDetails.MODIFIEDON_FIELD] = DBNull.Value;
              else
                  newRow[tblEmployeeDetails.MODIFIEDON_FIELD] = entry.ModifiedOn;
              newRow[tblEmployeeDetails.MODIFIEDBYID_FIELD] = entry.ModifiedByID;
              newRow[tblEmployeeDetails.ISACTIVE_FIELD] = entry.IsActive;

          if(adding)
              return tblObj.AddToTable(newRow);
          else
              return tblObj.UpdateTable(newRow);
      }

      public static int Save(BOEmployeeDetailsList entryList, bool adding)
      {
          tblEmployeeDetails tblObj = new tblEmployeeDetails();
          DataTable dt = tblObj.Table();
          int i = 0;

          foreach(BOEmployeeDetails entry in entryList)
          {
              DataRow newRow = tblObj.Table().NewRow();

              newRow[tblEmployeeDetails.EMPPROFILEIMAGE_FIELD] = entry.EmpProfileImage;
              newRow[tblEmployeeDetails.EMPLOYEEID_FIELD] = entry.EmployeeID;
              newRow[tblEmployeeDetails.GENDER_FIELD] = entry.gender;
              newRow[tblEmployeeDetails.MARITALSTATUS_FIELD] = entry.MaritalStatus;
          if(entry.DateOfBirth.Equals(new DateTime()))
              newRow[tblEmployeeDetails.DATEOFBIRTH_FIELD] = DBNull.Value;
          else
              newRow[tblEmployeeDetails.DATEOFBIRTH_FIELD] = entry.DateOfBirth;
          if(entry.DateOfAniversary.Equals(new DateTime()))
              newRow[tblEmployeeDetails.DATEOFANIVERSARY_FIELD] = DBNull.Value;
          else
              newRow[tblEmployeeDetails.DATEOFANIVERSARY_FIELD] = entry.DateOfAniversary;
              newRow[tblEmployeeDetails.CONTACTNUMBER_FIELD] = entry.ContactNumber;
              newRow[tblEmployeeDetails.LANDLINE_FIELD] = entry.Landline;
              newRow[tblEmployeeDetails.COMPANYPROFILE_FIELD] = entry.CompanyProfile;
          if(entry.JoinningDate.Equals(new DateTime()))
              newRow[tblEmployeeDetails.JOINNINGDATE_FIELD] = DBNull.Value;
          else
              newRow[tblEmployeeDetails.JOINNINGDATE_FIELD] = entry.JoinningDate;
          if(entry.CreatedOn.Equals(new DateTime()))
              newRow[tblEmployeeDetails.CREATEDON_FIELD] = DBNull.Value;
          else
              newRow[tblEmployeeDetails.CREATEDON_FIELD] = entry.CreatedOn;
              newRow[tblEmployeeDetails.CREATEDBYID_FIELD] = entry.CreatedByID;
          if(entry.ModifiedOn.Equals(new DateTime()))
              newRow[tblEmployeeDetails.MODIFIEDON_FIELD] = DBNull.Value;
          else
              newRow[tblEmployeeDetails.MODIFIEDON_FIELD] = entry.ModifiedOn;
              newRow[tblEmployeeDetails.MODIFIEDBYID_FIELD] = entry.ModifiedByID;
              newRow[tblEmployeeDetails.ISACTIVE_FIELD] = entry.IsActive;

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
          tblEmployeeDetails tblObj = new tblEmployeeDetails();
          int affectedRow = tblObj.DeleteTable(tblEmployeeDetails.PRIMARYKEY_FIELD1 + " = " + id);
          if (affectedRow != 1)
              throw new Exception("Could not find entry with id: " + id);
          else
              return true;
      }

      private static BOEmployeeDetails FillDataRecord(DataRow dr)
      {
          BOEmployeeDetails itemObj = new BOEmployeeDetails();
          if(dr["EmployeeDetailsID"] != DBNull.Value)
              itemObj.EmployeeDetailsID = Int32.Parse(dr["EmployeeDetailsID"].ToString());
          if(dr["EmpProfileImage"] != DBNull.Value)
              itemObj.EmpProfileImage = dr["EmpProfileImage"].ToString();
          if(dr["EmployeeID"] != DBNull.Value)
              itemObj.EmployeeID = Int32.Parse(dr["EmployeeID"].ToString());
          if(dr["gender"] != DBNull.Value)
              itemObj.gender = dr["gender"].ToString();
          if(dr["MaritalStatus"] != DBNull.Value)
              itemObj.MaritalStatus = dr["MaritalStatus"].ToString();
          if(dr["DateOfBirth"] != DBNull.Value)
              itemObj.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString());
          if(dr["DateOfAniversary"] != DBNull.Value)
              itemObj.DateOfAniversary = DateTime.Parse(dr["DateOfAniversary"].ToString());
          if(dr["ContactNumber"] != DBNull.Value)
              itemObj.ContactNumber = Int32.Parse(dr["ContactNumber"].ToString());
          if(dr["Landline"] != DBNull.Value)
              itemObj.Landline = Int32.Parse(dr["Landline"].ToString());
          if(dr["CompanyProfile"] != DBNull.Value)
              itemObj.CompanyProfile = dr["CompanyProfile"].ToString();
          if(dr["JoinningDate"] != DBNull.Value)
              itemObj.JoinningDate = DateTime.Parse(dr["JoinningDate"].ToString());
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
