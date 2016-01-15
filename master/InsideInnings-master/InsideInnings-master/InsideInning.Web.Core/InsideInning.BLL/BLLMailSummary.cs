using System;
using System.ComponentModel;

using InsideInning.BO;
using InsideInning.DAL;

namespace InsideInning.BLL
{

  /// <summary>
  /// The BLLBLLMailSummary class is designed to work as a Manager class for BOMailSummary
  /// </summary>
  [DataObjectAttribute()]
  public partial class BLLMailSummary
  {

      [DataObjectMethod(DataObjectMethodType.Select, true)]
      public static BOMailSummaryList GetAllList()
      {
          return tblMailSummaryDBManager.GetAllList();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static int GetCount()
      {
          return tblMailSummaryDBManager.GetCount();
      }
      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOMailSummaryList GetAllList(int startIndex, int length)
      {
          return tblMailSummaryDBManager.GetAllList(startIndex, length);
      }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
      public static BOMailSummary GetItem(Int32 id)
      {
         return tblMailSummaryDBManager.GetItem(id);
      }

      [DataObjectMethod(DataObjectMethodType.Delete, true)]
      public static bool Delete(Int32 id)
      {
         return tblMailSummaryDBManager.Delete(id);
      }

      [DataObjectMethod(DataObjectMethodType.Update | DataObjectMethodType.Insert, false)]
      public static int Save(BOMailSummary entry, bool adding)
      {
         return tblMailSummaryDBManager.Save(entry, adding);
      }

      [DataObjectMethod(DataObjectMethodType.Insert, true)]
      public static int Save(BOMailSummary entry)
      {
         return tblMailSummaryDBManager.Save(entry, true);
      }

      [DataObjectMethod(DataObjectMethodType.Update, true)]
      public static int Update(BOMailSummary entry)
      {
         return tblMailSummaryDBManager.Save(entry, false);
      }

      public static int Save(BOMailSummaryList list, bool adding)
      {
         return tblMailSummaryDBManager.Save(list,adding);
      }

  }
}
