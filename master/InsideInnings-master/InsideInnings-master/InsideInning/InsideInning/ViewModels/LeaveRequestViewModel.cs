using InsideInning.Helpers;
using InsideInning.Models;
using InsideInning.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsideInning.ViewModels
{
    public class LeaveRequestViewModel : BaseViewModel
    {
        public LeaveRequestViewModel()
        {
            App.DataBase.CreateTables<LeaveRequest>();
            _leaveRequestList = new ObservableCollection<LeaveRequest>();
        }

        #region Peoperties

        private LeaveRequest _leaveRequestInfo;
        public LeaveRequest LeaveRequestInfo
        {
            get { return _leaveRequestInfo; }
            set { _leaveRequestInfo = value; OnPropertyChanged("LeaveRequestInfo"); }
        }

        private ObservableCollection<LeaveRequest> _leaveRequestList;
        public ObservableCollection<LeaveRequest> LeaveRequestList
        {
            get { return _leaveRequestList; }
            set { _leaveRequestList = value; OnPropertyChanged("LeaveRequestList"); }
        }
        #endregion


        

        #region Commands
        //Save

        private Command addCommand;
        /// <summary>
        /// Command to Save Record
        /// </summary>
        /// 
        public Command AddCommand
        {
            get
            {
                return addCommand = new Command(async (param) => await ExecuteAddCommand(param));
            }
        }
        private async Task ExecuteAddCommand(object param)
        {
            try
            {
                LeaveRequestInfo = (LeaveRequest)param;
                if (LeaveRequestInfo == null)
                    return;


                if (IsNetworkConnected)
                {
                    var dd = await ServiceHandler.PostDataAsync<int, LeaveRequest>(LeaveRequestInfo, Constants.LeaveRequest);
                }
                else
                {
                    int id = App.DataBase.SaveItem<LeaveRequest>(LeaveRequestInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
            }
        }

        private Command _loadAllLeaveRequests;

        public Command LoadAllLeaveRequests
        {
            get
            {
                return _loadAllLeaveRequests ?? (_loadAllLeaveRequests = new Command(async () => await ExecuteLoadCommand()));
            }
        }

        private async Task ExecuteLoadCommand()
        {
            try
            {
                IsBusy = true;

                if (IsNetworkConnected)
                {
                    LeaveRequestList.Clear();
                    var items = await ServiceHandler.ProcessRequestCollectionAsync<LeaveRequest>(Constants.LeaveRequest);
                    foreach (var item in items)
                    {
                        LeaveRequestList.Add(item);
                    }  //Server Call
                    IsBusy = false;
                }
                else
                {
                    _leaveRequestList = App.DataBase.GetItems<LeaveRequest>(); //From Local DB
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
            }
        }
        #endregion
    }
}