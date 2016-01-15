using System;

namespace InsideInning.BO
{

  /// <summary>
  /// The BOPushNotification class. [Please feel free to enter extra information]
  /// </summary>
  public class BOPushNotification
  {

      #region Public Properties
      public Int32 ID{ get; set;}

      public String Title{ get; set;}

      public String Description{ get; set;}

      public DateTime CretaedOn{ get; set;}

      public Int32 CreatedByID{ get; set;}

      public Boolean IsSent{ get; set;}

      #endregion
  }

}
