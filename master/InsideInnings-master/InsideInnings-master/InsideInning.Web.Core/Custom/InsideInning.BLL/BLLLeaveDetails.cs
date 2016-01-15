using System;
using System.ComponentModel;

using InsideInning.BO;
using InsideInning.DAL;

namespace InsideInning.BLL
{

  /// <summary>
  /// The BLLBLLLeaveDetails class is designed to work as a Manager class for BOLeaveDetails
  /// </summary>
  public partial class BLLLeaveDetails
  {
      public static BOLeaveDetails GetLeaveByEmployeeID(Int32 id)
      {
          return tblLeaveDetailsDBManager.GetLeaveDetailByEmpID(id);
      }
  }
}
