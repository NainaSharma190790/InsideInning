using InsideInning.Models;
using InsideInning.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using InsideInning.Service;
using InsideInning.Helpers;
using XLabs.Platform.Services.Media;
using XLabs.Ioc;

//using XLabs.Platform.Services.Media;
//using XLabs.Ioc;
//using XLabs.Platform.Device;


namespace InsideInning.ViewModels
{
	public class EmployeeViewModel : BaseViewModel
	{
		#region Constructor

		public EmployeeViewModel()
		{
			App.DataBase.CreateTables<Employee>();
			App.DataBase.CreateTables<EmployeeDetails>();
			_employeeList = new ObservableCollection<Employee>();
			_employeeDetail = new EmployeeDetails();
			_employeeInfo = new Employee();
            _holidayDetails = new ObservableCollection<HolidayDetails>();
			Setup();
		}

		#endregion

		#region Peoperties

		private Employee _employeeInfo;

		public Employee EmployeeInfo
		{
			get { return _employeeInfo; }
			set
			{
				_employeeInfo = value;
				OnPropertyChanged("EmployeeInfo");
			}
		}

        private ObservableCollection<HolidayDetails> _holidayDetails;
        public ObservableCollection<HolidayDetails> HolidayDetail
        {
            get { return _holidayDetails; }
            set
            {
                _holidayDetails = value;
                OnPropertyChanged("HolidayDetails");
            }
        }

		private ObservableCollection<Employee> _employeeList;

		public ObservableCollection<Employee> EmployeeList
		{
			get { return _employeeList; }
			set
			{
				_employeeList = value;
				OnPropertyChanged("EmployeeList");
			}
		}

		#endregion

		#region Add Update Delete Commands

		//Save/Update
		//Delete
		//Search

		private Command addUpdateCommand;

		/// <summary>
		/// Command to Save/Update items
		/// </summary>
		public Command AddUpdateCommand
		{
			get
			{
				return addUpdateCommand ?? (addUpdateCommand = new Command(async (param) => await ExecuteAddUpdateCommand(param)));
			}
		}

		private async Task ExecuteAddUpdateCommand(object param)
		{
			try
			{
				EmployeeInfo = (Employee)param;
				if (EmployeeInfo == null)
					return;

				if (IsNetworkConnected)
				{
					await ServiceHandler.PostDataAsync<int, Employee>(EmployeeInfo, Constants.Employee);
				}
				else
				{
					int id = App.DataBase.SaveItem<Employee>(EmployeeInfo);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
				return;
			}
		}

		private Command _LoadAllEmployees;

		public Command LoadAllEmployees
		{
			get
			{
				return _LoadAllEmployees ?? (_LoadAllEmployees = new Command(async () => await ExecuteLoadCommand()));
			}
		}

		private async Task ExecuteLoadCommand()
		{
			try
			{
				IsBusy = true;

				if (IsNetworkConnected)
				{
					EmployeeList.Clear();
					var items = await ServiceHandler.ProcessRequestCollectionAsync<Employee>(Constants.Employee);
					foreach (var item in items)
					{
						EmployeeList.Add(item);
					}  //Server Call
					IsBusy = false;
				}
				else
				{
					_employeeList = App.DataBase.GetItems<Employee>(); //From Local DB
					IsBusy = false;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
			}
		}

		#endregion

		#region EmployeeDetails Properties

		private EmployeeDetails _employeeDetail;

		public EmployeeDetails EmployeeDetail
		{
			get { return _employeeDetail; }
			set
			{
				_employeeDetail = value;
				OnPropertyChanged("EmployeeDetail");
			}
		}

		#endregion

		#region EmployeeDetails Command

		private Command _addUpdateCommand;

		public Command AddUpdateEmployeeDetailsCommand
		{
			get
			{
				return _addUpdateCommand ?? (_addUpdateCommand = new Command(async (param) => await ExecuteAddUpdateEmployeeDetailsCommand(param)));
			}
		}

		private async Task ExecuteAddUpdateEmployeeDetailsCommand(object param)
		{
			try
			{
				EmployeeDetail = (EmployeeDetails)param;
				if (EmployeeDetail == null)
					return;

				if (IsNetworkConnected)
				{
					await ServiceHandler.PostDataAsync<int, EmployeeDetails>(EmployeeDetail, Constants.EmployeeDetails);
				}
				else
				{
					int id = App.DataBase.SaveItem<EmployeeDetails>(EmployeeDetail);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
				return;
			}
		}

		private Command _loadEmpDetail;

		public Command LoadEmpDetail
		{
			get
			{
				return _loadEmpDetail ?? (_loadEmpDetail = new Command(async (param) => await ExecuteLoadEmpDataCommand(param)));
			}
		}

		private async Task ExecuteLoadEmpDataCommand(object param)
		{
			try
			{
				var _empID = (Int32)param;

				if (IsNetworkConnected)
				{
					var items = await ServiceHandler.ProcessRequestItemAsync<Employee>(string.Format("{0}{1}", Constants.EmployeeDetails, _empID));
					EmployeeDetail = items;
				}
				else
				{
                    EmployeeDetail = App.DataBase.GetItem<EmployeeDetails>(_empID);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An Exception Occured During getting the Record {0}", ex.Message);
			}
		}

		#endregion
        
        #region HolidayDetails Command
        private Command _loadHolidayDetail;

        public Command LoadHolidayDetail
        {
            get
            {
                return _loadHolidayDetail ?? (_loadHolidayDetail = new Command(async () => await ExecuteLoadHolidayDataCommand()));
            }
        }
        private async Task ExecuteLoadHolidayDataCommand()
        {
            IsBusy = true;
            try
            {

                if (IsNetworkConnected)
                {
                    var items = await ServiceHandler.ProcessRequestCollectionAsync<HolidayDetails>(Constants.HolidayDetails);

                    foreach (var item in items)
                    {
                        HolidayDetail.Add(item);
                    }  //Server Call
                    IsBusy = false;
                }
                else
                {
                    HolidayDetail = App.DataBase.GetItems<HolidayDetails>();
                    //App.DataBase.GetItems<HolidayDetails>(); //From Local DB
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During getting the Record {0}", ex.Message);
            }
        }

        #endregion

		#region Functionality of profile picture

		/// <summary>
		/// The _scheduler.
		/// </summary>
		private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

		/// <summary>
		/// The picture chooser.
		/// </summary>
		private IMediaPicker _mediaPicker;

		/// <summary>
		/// The image source.
		/// </summary>
        private ImageSource _imageSource = "rzee.png";


		/// <summary>
		/// The take picture command.
		/// </summary>
		private Command _takePictureCommand;

		/// <summary>
		/// The select picture command.
		/// </summary>
		private Command _selectPictureCommand;


		private string _status;


		////private CancellationTokenSource cancelSource;

		/// <summary>
		/// Initializes a new instance of the <see cref="CameraViewModel" /> class.
		/// </summary>
		private void Setup()
		{
			if (_mediaPicker != null)
			{
				return;
			}

			// var device = Resolver.Resolve<IDevice>();

			////RM: hack for working on windows phone? 
			_mediaPicker = Resolver.Resolve<IMediaPicker>();// ?? device.MediaPicker;
		}

		/// <summary>
		/// Gets or sets the image source.
		/// </summary>
		/// <value>The image source.</value>
		public ImageSource ImageSource
		{
			get
			{
				return _imageSource;
			}
			set
			{
				_imageSource = value;
                OnPropertyChanged("ImageSource");
			}
		}
		// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		public string Status
		{
			get { return _status; }
			private set
			{
				_status = value;
				OnPropertyChanged("Status");
			}
		}

		/// <summary>
		/// Gets the take picture command.
		/// </summary>
		/// <value>The take picture command.</value>
		public Command TakePictureCommand
		{
			get
			{
				return _takePictureCommand ?? (_takePictureCommand = new Command(
					async () => await TakePicture(),
					() => true));
			}
		}

		/// <summary>
		/// Takes the picture.
		/// </summary>
		/// <returns>Take Picture Task.</returns>
		private async Task<MediaFile> TakePicture()
		{
			Setup();

			ImageSource = null;

			return await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(t =>
			{
				if (t.IsFaulted)
				{
					Status = t.Exception.InnerException.ToString();
				}
				else if (t.IsCanceled)
				{
					Status = "Canceled";
				}
				else
				{
					var mediaFile = t.Result;

					ImageSource = ImageSource.FromStream(() => mediaFile.Source);

					return mediaFile;
				}

				return null;
			}, _scheduler);
		}

		/// <summary>
		/// Gets the select picture command.
		/// </summary>
		/// <value>The select picture command.</value>
		public Command SelectPictureCommand
		{
			get
			{
				return _selectPictureCommand ?? (_selectPictureCommand = new Command(
					async () => await SelectPicture(),
					() => true));
			}
		}

        public MediaFile m_ediaFile { get; set; }

		/// <summary>
		/// Selects the picture.
		/// </summary>
		/// <returns>Select Picture Task.</returns>
        private async Task SelectPicture()
        {
            Setup();

            //ImageSource = null;
            try
            {
                var mediaFile = await _mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    MaxPixelDimension = 400
                });
                ImageSource = ImageSource.FromStream(() => mediaFile.Source);
            }
            catch (System.Exception ex)
            {
                Status = ex.Message;
            }
        }

		#endregion
	}
}
