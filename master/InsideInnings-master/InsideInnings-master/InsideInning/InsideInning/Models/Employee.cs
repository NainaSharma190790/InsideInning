using InsideInning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning
{
   public class Employee : EmployeeDetails
    {
       public override string EmpProfileImage
       {
           get
           {
               //TODO : Have to remove just for demo
               return string.Format("https://raw.githubusercontent.com/rzeem7/InsideInning/master/InsideInning/InsideInning.Droid/Resources/Drawable/{0}{1}.jpg", FirstName, LastName);
           }
           set
           {
               base.EmpProfileImage = value;
           }
       }

        #region Full Property

       public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        private int _employeeID;

        public int EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; OnPropertyChanged("EmployeeID"); }
        }
        
        private string _firstname = string.Empty;
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; OnPropertyChanged("FirstName"); OnPropertyChanged("FullName"); }
        }

        private string _lastname = string.Empty;
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; OnPropertyChanged("LastName"); OnPropertyChanged("FullName"); }
        }

        private string _emailAddress = string.Empty;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; OnPropertyChanged("EmailAddress"); }
        }


        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }

        private string _employeeType = string.Empty;
        public string EmployeeType
        {
            get { return _employeeType; }
            set { _employeeType = value; OnPropertyChanged("EmployeeType"); }
        }

        private bool _isAdmin;
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; OnPropertyChanged("IsAdmin"); }
        }

        #endregion
    }
}
