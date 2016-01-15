using System;

namespace InsideInning.BO
{

  /// <summary>
  /// The BOEmployee class. [Please feel free to enter extra information]
  /// </summary>
  public class BOEmployee
  {

      #region Public Properties
      public Int32 EmployeeID{ get; set;}

      public String FirstName{ get; set;}

      public String LastName{ get; set;}

      public String EmailAddress{ get; set;}

      public String Password{ get; set;}

      public Boolean EmployeeType{ get; set;}

      public DateTime CreatedOn{ get; set;}

      public Int32 CreatedByID{ get; set;}

      public DateTime ModifiedOn{ get; set;}

      public Int32 ModifiedByID{ get; set;}

      public Boolean IsActive{ get; set;}

      #endregion
  }

}
