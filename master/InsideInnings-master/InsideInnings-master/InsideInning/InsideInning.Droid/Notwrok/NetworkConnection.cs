using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;
using Xamarin.Forms;
using InsideInning.Droid;

[assembly: Dependency(typeof(NetworkConnection))]
namespace InsideInning.Droid
{
    public class NetworkConnection : INetworkConnection
    {
        #region Is Connected Property

        public bool IsConnected { get; set; }

        #endregion

        #region Check Network Availablity

        public void CheckNetworkConnection()
        {
            var connectivityManager = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }
        }

        #endregion
    }
}