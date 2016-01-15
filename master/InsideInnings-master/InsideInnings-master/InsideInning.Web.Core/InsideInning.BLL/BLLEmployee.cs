using System;
using System.ComponentModel;

using InsideInning.BO;
using InsideInning.DAL;

namespace InsideInning.BLL
{

  /// <summary>
  /// The BLLBLLEmployee class is designed to work as a Manager class for BOEmployee
  /// </summary>
  [DataObjectAttribute()]
  public partial class BLLEmployee
  {

      [DataObjectMethod(DataObjectMethodType.Select, true)]
      public static BOEmployeeList GetAllList()
      {
          return tblEmployeeDBManager.GetAllList();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static int GetCount()
      {
          return tblEmployeeDBManager.GetCount();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOEmployeeList GetAllList(int startIndex, int length)
      {
          return tblEmployeeDBManager.GetAllList(startIndex, length);
      }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOEmployee GetItem(Int32 id)
      {
         return tblEmployeeDBManager.GetItem(id);
      }

      [DataObjectMethod(DataObjectMethodType.Delete, true)]
      public static bool Delete(Int32 id)
      {
         return tblEmployeeDBManager.Delete(id);
      }

      [DataObjectMethod(DataObjectMethodType.Update | DataObjectMethodType.Insert, false)]
      public static int Save(BOEmployee entry, bool adding)
      {
         return tblEmployeeDBManager.Save(entry, adding);
      }

      [DataObjectMethod(DataObjectMethodType.Insert, true)]
      public static int Save(BOEmployee entry)
      {
         return tblEmployeeDBManager.Save(entry, true);
      }

      [DataObjectMethod(DataObjectMethodType.Update, true)]
      public static int Update(BOEmployee entry)
      {
         return tblEmployeeDBManager.Save(entry, false);
      }

      public static int Save(BOEmployeeList list, bool adding)
      {
         return tblEmployeeDBManager.Save(list,adding);
      }

  }
}
