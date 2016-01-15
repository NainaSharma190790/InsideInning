using System;
using System.Configuration;

namespace InsideInning.DAL
{

  /// <summary>
  /// The InsideInningDB class. The class contains the DAL connectionstring information
  /// </summary>
  public sealed class InsideInningDB
  {
      public static string InsideInning_CONNECTIONSTRING = @"Data Source=192.168.0.117;User Id=sa;Password=Ketan123;Initial Catalog=InsideInning;";
      //public static string InsideInning_CONNECTIONSTRING
      //{
          //get { return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString; }
      //}
  }

}
