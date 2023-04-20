using Microsoft.IdentityModel.Tokens;
using PinusPengger.Model.CombinedModel;
using PinusPengger.ServiceAgent;
using PinusPengger.View;
using PinusPengger.ViewModel.Helper;
using PinusPengger.ViewModel.ObservableCombinedModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel.BasePageVM
{
    /// <summary>
    /// The DisplayRoomVM class represents the view model for a page 
    /// that displays a list of available rooms with their associated 
    /// facilities and allows for reservation management. 
    /// It inherits from ViewModelBase and implements the IBasePage interface.
    /// </summary>
    public class DisplayRoomVM : ViewModelBase, IBasePage
    {
        /// <summary>
        /// Initializes a new instance of the DisplayRoomVM class with default values for its properties and fields.
        /// </summary>
        public DisplayRoomVM()
        {
            //_roomWithFacilities = new ObservableCollection<RoomWithFacilitiesObservable>();
            _errorMessage = string.Empty;
            SelectedOption = Tag.RoomType.REG;
            _roomPool = Enumerable.Empty<RoomWithFacilities>();
            _reservations = Enumerable.Empty<ReservationJoined>();
            _roomButtonCommand = new ViewModelCommand(ExecuteRoomButtonCommand, CanExecuteRoomButtonCommand);
            _isDetailKamarWindowOpen = false;
            Options = new List<Tag.RoomType>() { Tag.RoomType.REG, Tag.RoomType.VIP };
            RoomWithFacilitiesObservable = new ObservableCollection<RoomWithFacilitiesObservable>();
            PropertyChanged += OnSelectedOptionChanged;
            Mediator.Register("IsDetailKamarWindowOpenChanged", UpdateIsDetailKamarWindowOpen);
            GetData();
            ProcessData();
        }

        #region Field
        //private ObservableCollection<RoomWithFacilitiesObservable> _roomWithFacilities;
        private string _errorMessage;
        private Tag.RoomType _selectedOption;
        private IEnumerable<RoomWithFacilities> _roomPool;
        private IEnumerable<ReservationJoined> _reservations;
        private ICommand _roomButtonCommand;
        private bool _isDetailKamarWindowOpen;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the error message to be displayed to the user.
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the currently selected room type.
        /// </summary>
        public Tag.RoomType SelectedOption
        {
            get => _selectedOption;
            set
            {
                _selectedOption = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the "Detail Kamar" window is open.
        /// </summary>
        public bool IsDetailKamarWindowOpen 
        { 
            get => _isDetailKamarWindowOpen; 
            set => _isDetailKamarWindowOpen = value; 
        }
        /// <summary>
        /// Gets or sets the list of available room types.
        /// </summary>
        public List<Tag.RoomType> Options { get; set; }
        public ObservableCollection<RoomWithFacilitiesObservable> RoomWithFacilitiesObservable { get; set; }
        //get => _roomWithFacilities;
        //set
        //{
        //    _roomWithFacilities = value;
        //    OnPropertyChanged();
        //}
        /// <summary>
        /// Gets or sets the command to be executed when the Room button is clicked.
        /// </summary>
        public ICommand RoomButtonCommand
        {
            get => _roomButtonCommand;
            set => _roomButtonCommand = value;
        }
        #endregion

        #region Method
        private void ExecuteRoomButtonCommand(object parameter)
        {
            if (parameter is RoomWithFacilitiesObservable obj)
            {
                var DetailRoomWindow = new DataKamarPopUp();
                Mediator.NotifyColleagues("ShowDetailRoom", obj);
                IsDetailKamarWindowOpen = true;
                DetailRoomWindow.Show();
            }
        }
        private bool CanExecuteRoomButtonCommand(object obj)
        {
            return !_isDetailKamarWindowOpen;
        }
        private void UpdateIsDetailKamarWindowOpen(object obj)
        {
            if (obj is not bool)
            {
                return;
            }
            IsDetailKamarWindowOpen = (bool)obj;
        }
        public void OnSelectedOptionChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedOption))
            {
                ProcessData();
            }
        }
        /// <summary>
        /// Gets the data from the service agent.
        /// </summary>
        public void GetData()
        {
            using (var reservationSA = new ReservationSA())
            {
                try
                {
                    reservationSA.FetchData();
                    _reservations = reservationSA.GetData().Cast<ReservationJoined>();
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    Debug.WriteLine(e);
                }
            }
            using (var roomSA = new RoomSA())
            {
                try
                {
                    roomSA.FetchData();
                    _roomPool = roomSA.GetData().Cast<RoomWithFacilities>();
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    Debug.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// Processes the data to display in the view.
        /// </summary>
        public void ProcessData()
        {
            try
            {
                if (_roomPool.IsNullOrEmpty())
                {
                    throw new Exception("Data tidak ditemukan");
                }

                var temp = _roomPool.Where(x => x.Room.RoomType == _selectedOption);
                RoomWithFacilitiesObservable.Clear();
                foreach (var item in temp)
                {
                    RoomWithFacilitiesObservable.Add(new RoomWithFacilitiesObservable
                    {
                        Room = DataObservableConverter.FromRoomEntity(item.Room),
                        RoomFacility = DataObservableConverter.FromRoomFacilityEntity(item.RoomFacility),
                        RoomFacilityBathrooms = DataObservableConverter.FromRoomFacilityBathroomEntities(item.RoomFacilityBathrooms),
                        RoomFacilityOthers = DataObservableConverter.FromRoomFacilityOtherEntities(item.RoomFacilityOthers),
                        IsBusy = _reservations.Any(x => x.Room.RoomCode == item.Room.RoomCode)
                    });
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        #endregion
    }
}
