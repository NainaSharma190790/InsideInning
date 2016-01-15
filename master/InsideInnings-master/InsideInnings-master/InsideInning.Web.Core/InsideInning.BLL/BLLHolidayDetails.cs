using System;
using System.ComponentModel;

using InsideInning.BO;
using InsideInning.DAL;

namespace InsideInning.BLL
{

  /// <summary>
  /// The BLLBLLHolidayDetails class is designed to work as a Manager class for BOHolidayDetails
  /// </summary>
  [DataObjectAttribute()]
  public partial class BLLHolidayDetails
  {

      [DataObjectMethod(DataObjectMethodType.Select, true)]
      public static BOHolidayDetailsList GetAllList()
      {
          return tblHolidayDetailsDBManager.GetAllList();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static int GetCount()
      {
          return tblHolidayDetailsDBManager.GetCount();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOHolidayDetailsList GetAllList(int startIndex, int length)
      {
          return tblHolidayDetailsDBManager.GetAllList(startIndex, length);
      }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOHolidayDetails GetItem(Int32 id)
      {
         return tblHolidayDetailsDBManager.GetItem(id);
      }

      [DataObjectMethod(DataObjectMethodType.Delete, true)]
      public static bool Delete(Int32 id)
      {
         return tblHolidayDetailsDBManager.Delete(id);
      }

      [DataObjectMethod(DataObjectMethodType.Update | DataObjectMethodType.Insert, false)]
      public static int Save(BOHolidayDetails entry, bool adding)
      {
         return tblHolidayDetailsDBManager.Save(entry, adding);
      }

      [DataObjectMethod(DataObjectMethodType.Insert, true)]
      public static int Save(BOHolidayDetails entry)
      {
         return tblHolidayDetailsDBManager.Save(entry, true);
      }

      [DataObjectMethod(DataObjectMethodType.Update, true)]
      public static int Update(BOHolidayDetails entry)
      {
         return tblHolidayDetailsDBManager.Save(entry, false);
      }

      public static int Save(BOHolidayDetailsList list, bool adding)
      {
         return tblHolidayDetailsDBManager.Save(list,adding);
      }

  }
}
