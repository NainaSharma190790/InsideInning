using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Models
{
    public class EmployeeDetails : BaseModel
    {
        #region Full Property

        private string _EmpProfileImage = string.Empty;
        public virtual string EmpProfileImage
        {
            get { return _EmpProfileImage; }
            set { _EmpProfileImage = value; OnPropertyChanged("EmpProfileImage"); }
        }

        private int _EmployeeID;
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; OnPropertyChanged("EmployeeID"); }
        }

        private string _gender = string.Empty;
        public string gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged("gender"); }
        }


        private string _MaritalStatus = string.Empty;
        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; OnPropertyChanged("MaritalStatus"); }
        }

        private DateTime _DateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; OnPropertyChanged("DateOfBirth"); }
        }

        private DateTime _DateOfAniversary;
        public DateTime DateOfAniversary
        {
            get { return _DateOfAniversary; }
            set { _DateOfAniversary = value; OnPropertyChanged("DateOfAniversary"); }
        }

        private Int32 _ContactNumber;
        public Int32 ContactNumber
        {
            get { return _ContactNumber; }
            set { _ContactNumber = value; OnPropertyChanged("ContactNumber"); }
        }

        private Int32 _Landline;
        public Int32 Landline
        {
            get { return _Landline; }
            set { _Landline = value; OnPropertyChanged("Landline"); }
        }

        private string _CompanyProfile = string.Empty;
        public string CompanyProfile
        {
            get { return _CompanyProfile; }
            set { _CompanyProfile = value; OnPropertyChanged("CompanyProfile"); }
        }

        private DateTime _JoinningDate;
        public DateTime JoinningDate
        {
            get { return _JoinningDate; }
            set { _JoinningDate = value; OnPropertyChanged("JoinningDate"); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; OnPropertyChanged("IsActive"); }
        }

        #endregion
    }
}
