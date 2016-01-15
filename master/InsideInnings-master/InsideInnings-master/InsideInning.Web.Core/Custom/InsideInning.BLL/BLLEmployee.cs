using System;
using System.ComponentModel;

using InsideInning.BO;
using InsideInning.DAL;

namespace InsideInning.BLL
{

    /// <summary>
    /// The BLLBLLEmployee class is designed to work as a Manager class for BOEmployee
    /// </summary>
    public partial class BLLEmployee
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BOEmployee GetEmployee(int id)
        {
            return tblEmployeeDBManager.GetEmployeeByID(id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BOEmployeeList GetAllEmployees()
        {
            return tblEmployeeDBManager.GetAllEmployees();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BOEmployeeList GetEmployeeDetails()
        {
            return tblEmployeeDBManager.GetEmployeeDetails();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BOEmployee GetEmployeeDetailsByID(int id)
        {
            return tblEmployeeDBManager.GetEmployeeDetailsByID(id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BOEmployee CheckLogin(string username,string password)
        {
            return tblEmployeeDBManager.CheckLogin(username, password);
        }
    }
}
