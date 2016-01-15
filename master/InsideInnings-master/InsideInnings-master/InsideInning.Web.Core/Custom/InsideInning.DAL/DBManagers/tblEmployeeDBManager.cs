using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using iNVERTEDi.DataOperations;
using InsideInning.BO;
using InsideInning.DAL.Procedures;
using InsideInning.Web.Core.Custom.InsideInning.DAL.Procedures;

namespace InsideInning.DAL
{

    /// <summary>
    /// The tblEmployeeDBManager class is responsible for interacting with the database to retriece and store info about tblEmployee objects.
    /// </summary>
    public partial class tblEmployeeDBManager
    {
        public static BOEmployee GetEmployeeByID(int id)
        {
            BOEmployee itemObj = null;
            var ds = spGetEmployeeByID.ExecuteDataset(id);
            if (ds!=null && ds.Tables[0].Rows.Count > 1)
                throw new Exception("More than one row returned");
            if (ds != null &&  ds.Tables[0].Rows.Count == 1)
                itemObj = FillDataRecord(ds.Tables[0].Rows[0]);
            return itemObj;
        }
        public static BOEmployeeList GetAllEmployees()
        {
            BOEmployeeList itemObjs = null;
            var ds = spGetEmployees.ExecuteDataset();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                itemObjs = new BOEmployeeList();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    itemObjs.Add(FillDataRecord(dr));
                }
            }
            return itemObjs;
        }
        public static BOEmployeeList GetEmployeeDetails()
        {
            BOEmployeeList itemObjs = null;
            var ds = spGetEmployeeDetails.ExecuteDataset();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                itemObjs = new BOEmployeeList();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    itemObjs.Add(FillData(FillDataRecord(dr), dr));
                }
            }
            return itemObjs;
        }
        public static BOEmployee GetEmployeeDetailsByID(int id)
        {
            BOEmployee itemObjs = null;
            var ds = spGetEmployeeDetailsByID.ExecuteDataset(id);
            if (ds != null && ds.Tables[0].Rows.Count > 1)
                throw new Exception("More than one row returned");
            if (ds != null && ds.Tables[0].Rows.Count == 1)
                itemObjs = FillDataRecord(ds.Tables[0].Rows[0]);
            return FillData(itemObjs, ds.Tables[0].Rows[0]);
        }

        public static BOEmployee FillData(BOEmployee itemObj, DataRow dr)
        {
           
            if (dr["EmployeeDetailsID"] != DBNull.Value)
                itemObj.EmployeeDetailsID = Int32.Parse(dr["EmployeeDetailsID"].ToString());
            if (dr["EmpProfileImage"] != DBNull.Value)
                itemObj.EmpProfileImage = dr["EmpProfileImage"].ToString();
            if (dr["EmployeeID"] != DBNull.Value)
                itemObj.EmployeeID = Int32.Parse(dr["EmployeeID"].ToString());
            if (dr["gender"] != DBNull.Value)
                itemObj.gender = dr["gender"].ToString();
            if (dr["MaritalStatus"] != DBNull.Value)
                itemObj.MaritalStatus = dr["MaritalStatus"].ToString();
            if (dr["DateOfBirth"] != DBNull.Value)
                itemObj.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString());
            if (dr["DateOfAniversary"] != DBNull.Value)
                itemObj.DateOfAniversary = DateTime.Parse(dr["DateOfAniversary"].ToString());
            if (dr["ContactNumber"] != DBNull.Value)
                itemObj.ContactNumber = Int32.Parse(dr["ContactNumber"].ToString());
            if (dr["Landline"] != DBNull.Value)
                itemObj.Landline = Int32.Parse(dr["Landline"].ToString());
            if (dr["CompanyProfile"] != DBNull.Value)
                itemObj.CompanyProfile = dr["CompanyProfile"].ToString();
            if (dr["JoinningDate"] != DBNull.Value)
                itemObj.JoinningDate = DateTime.Parse(dr["JoinningDate"].ToString());
            if (dr["CreatedOn"] != DBNull.Value)
                itemObj.CreatedOn = DateTime.Parse(dr["CreatedOn"].ToString());
            if (dr["CreatedByID"] != DBNull.Value)
                itemObj.CreatedByID = Int32.Parse(dr["CreatedByID"].ToString());
            if (dr["ModifiedOn"] != DBNull.Value)
                itemObj.ModifiedOn = DateTime.Parse(dr["ModifiedOn"].ToString());
            if (dr["ModifiedByID"] != DBNull.Value)
                itemObj.ModifiedByID = Int32.Parse(dr["ModifiedByID"].ToString());
            if (dr["IsActive"] != DBNull.Value)
                itemObj.IsActive = Boolean.Parse(dr["IsActive"].ToString());
            return itemObj;
        }
        public static BOEmployee CheckLogin(string username, string password)
        {

            BOEmployee itemObj = null;
            var ds = spCheckLogin.ExecuteDataset(username,password);

            if (ds != null && ds.Tables[0].Rows.Count > 1)
                throw new Exception("More than one row returned");
            if (ds != null && ds.Tables[0].Rows.Count == 1)
                itemObj = FillDataRecord(ds.Tables[0].Rows[0]);
            return itemObj;
        }
    }     
}
