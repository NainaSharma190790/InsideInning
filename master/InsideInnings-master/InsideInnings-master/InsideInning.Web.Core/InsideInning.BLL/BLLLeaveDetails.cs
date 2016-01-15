using System;
using System.ComponentModel;

using InsideInning.BO;
using InsideInning.DAL;

namespace InsideInning.BLL
{

  /// <summary>
  /// The BLLBLLLeaveDetails class is designed to work as a Manager class for BOLeaveDetails
  /// </summary>
  [DataObjectAttribute()]
  public partial class BLLLeaveDetails
  {

      [DataObjectMethod(DataObjectMethodType.Select, true)]
      public static BOLeaveDetailsList GetAllList()
      {
          return tblLeaveDetailsDBManager.GetAllList();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static int GetCount()
      {
          return tblLeaveDetailsDBManager.GetCount();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOLeaveDetailsList GetAllList(int startIndex, int length)
      {
          return tblLeaveDetailsDBManager.GetAllList(startIndex, length);
      }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOLeaveDetails GetItem(Int32 id)
      {
         return tblLeaveDetailsDBManager.GetItem(id);
      }

      [DataObjectMethod(DataObjectMethodType.Delete, true)]
      public static bool Delete(Int32 id)
      {
         return tblLeaveDetailsDBManager.Delete(id);
      }

      [DataObjectMethod(DataObjectMethodType.Update | DataObjectMethodType.Insert, false)]
      public static int Save(BOLeaveDetails entry, bool adding)
      {
         return tblLeaveDetailsDBManager.Save(entry, adding);
      }

      [DataObjectMethod(DataObjectMethodType.Insert, true)]
      public static int Save(BOLeaveDetails entry)
      {
         return tblLeaveDetailsDBManager.Save(entry, true);
      }

      [DataObjectMethod(DataObjectMethodType.Update, true)]
      public static int Update(BOLeaveDetails entry)
      {
         return tblLeaveDetailsDBManager.Save(entry, false);
      }

      public static int Save(BOLeaveDetailsList list, bool adding)
      {
         return tblLeaveDetailsDBManager.Save(list,adding);
      }

  }
}
