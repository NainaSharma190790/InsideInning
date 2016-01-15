using System;
using System.ComponentModel;

using InsideInning.BO;
using InsideInning.DAL;

namespace InsideInning.BLL
{

  /// <summary>
  /// The BLLBLLEmployeeDetails class is designed to work as a Manager class for BOEmployeeDetails
  /// </summary>
  [DataObjectAttribute()]
  public partial class BLLEmployeeDetails
  {

      [DataObjectMethod(DataObjectMethodType.Select, true)]
      public static BOEmployeeDetailsList GetAllList()
      {
          return tblEmployeeDetailsDBManager.GetAllList();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static int GetCount()
      {
          return tblEmployeeDetailsDBManager.GetCount();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOEmployeeDetailsList GetAllList(int startIndex, int length)
      {
          return tblEmployeeDetailsDBManager.GetAllList(startIndex, length);
      }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOEmployeeDetails GetItem(Int32 id)
      {
         return tblEmployeeDetailsDBManager.GetItem(id);
      }

      [DataObjectMethod(DataObjectMethodType.Delete, true)]
      public static bool Delete(Int32 id)
      {
         return tblEmployeeDetailsDBManager.Delete(id);
      }

      [DataObjectMethod(DataObjectMethodType.Update | DataObjectMethodType.Insert, false)]
      public static int Save(BOEmployeeDetails entry, bool adding)
      {
         return tblEmployeeDetailsDBManager.Save(entry, adding);
      }

      [DataObjectMethod(DataObjectMethodType.Insert, true)]
      public static int Save(BOEmployeeDetails entry)
      {
         return tblEmployeeDetailsDBManager.Save(entry, true);
      }

      [DataObjectMethod(DataObjectMethodType.Update, true)]
      public static int Update(BOEmployeeDetails entry)
      {
         return tblEmployeeDetailsDBManager.Save(entry, false);
      }

      public static int Save(BOEmployeeDetailsList list, bool adding)
      {
         return tblEmployeeDetailsDBManager.Save(list,adding);
      }

  }
}
