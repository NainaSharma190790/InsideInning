using System;

namespace InsideInning.BO
{

  /// <summary>
  /// The BOMailSummary class. [Please feel free to enter extra information]
  /// </summary>
  public class BOMailSummary
  {

      #region Public Properties
      public Int32 MailID{ get; set;}

      public Int32 ToEmployeeID{ get; set;}

      public Int32 CCEmployeeID{ get; set;}

      public Int32 FromEmployeeID{ get; set;}

      public String MessageBody{ get; set;}

      public String MailSubject{ get; set;}

      public DateTime CreatedOn{ get; set;}

      public Int32 CreatedByID{ get; set;}

      public DateTime ModifiedOn{ get; set;}

      public Int32 ModifiedByID{ get; set;}

      #endregion
  }

}
