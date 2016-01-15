using System;
using System.ComponentModel;

using InsideInning.BO;
using InsideInning.DAL;

namespace InsideInning.BLL
{

  /// <summary>
  /// The BLLBLLPushNotification class is designed to work as a Manager class for BOPushNotification
  /// </summary>
  [DataObjectAttribute()]
  public partial class BLLPushNotification
  {

      [DataObjectMethod(DataObjectMethodType.Select, true)]
      public static BOPushNotificationList GetAllList()
      {
          return tblPushNotificationDBManager.GetAllList();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static int GetCount()
      {
          return tblPushNotificationDBManager.GetCount();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOPushNotificationList GetAllList(int startIndex, int length)
      {
          return tblPushNotificationDBManager.GetAllList(startIndex, length);
      }

      [DataObjectMethod(DataObjectMethodType.Update | DataObjectMethodType.Insert, false)]
      public static int Save(BOPushNotification entry, bool adding)
      {
         return tblPushNotificationDBManager.Save(entry, adding);
      }

      [DataObjectMethod(DataObjectMethodType.Insert, true)]
      public static int Save(BOPushNotification entry)
      {
         return tblPushNotificationDBManager.Save(entry, true);
      }

      [DataObjectMethod(DataObjectMethodType.Update, true)]
      public static int Update(BOPushNotification entry)
      {
         return tblPushNotificationDBManager.Save(entry, false);
      }

      public static int Save(BOPushNotificationList list, bool adding)
      {
         return tblPushNotificationDBManager.Save(list,adding);
      }

  }
}
