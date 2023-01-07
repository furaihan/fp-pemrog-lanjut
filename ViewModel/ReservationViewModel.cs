using PinusPengger.Model.CombinedModel;
using PinusPengger.Model.ServiceAgent;
using PinusPengger.UserControls;
using PinusPengger.ViewModel.ObservableCombinedModel;
using PinusPengger.ViewModel.ObservableModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// View model untuk halaman reservasi
    /// </summary>
    internal class ReservationViewModel : ViewModelBase
    {
        /// <summary>
        /// Menginisialisasi instance sekaligus mengambil data dari database
        /// </summary>
        public ReservationViewModel()
        {
            using (var roomSa = new RoomSA())
            {
                try
                {
                    roomSa.FetchData();
                    var data = roomSa.GetData(null);
                    if (data.FirstOrDefault() is RoomWithFacilities)
                    {
                        RoomTypes = data.Cast<RoomWithFacilities>().Select(x => new RoomWithFacilitiesObservable
                        {
                            Room = RoomObservable.FromEntity(x.Room),
                            RoomFacility = RoomFacilityObservable.FromEntity(x.RoomFacility),
                            RoomFacilityBathrooms = x.RoomFacilityBathrooms.Select(y=> RoomFacilityBathroomObservable.FromEntity(y)),
                            RoomFacilityOthers = x.RoomFacilityOthers.Select(y=> RoomFacilityOtherObservable.FromEntity(y))
                        });
                    }
                }
                catch (Exception e)
                {
                    //do nothing atm
                }
            }
        }

        #region Field
        private ICommand _changeOptionCommand;
        private ICommand _reserveCommand;
        private ICommand _resetCommand;
        private DateTime? _checkin;
        private DateTime? _checkout;
        private RoomWithFacilitiesObservable _selectedType;
        #endregion

        #region Properties
        public ICommand ChangeOptionCommand
        {
            get
            {
                _changeOptionCommand ??= new ViewModelCommand(null);
                return _changeOptionCommand;
            }
        }
        public ICommand ReserveCommand
        {
            get
            {
                _reserveCommand ??= new ViewModelCommand(param => Reserve(param));
                return _reserveCommand;
            }
        }
        public ICommand ResetCommand
        {
            get
            {
                _resetCommand ??= new ViewModelCommand(param => Reset());
                return _resetCommand;
            }
        }
        public DateTime? Checkin
        {
            get => _checkin;
            set
            {
                _checkin = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Checkout
        {
            get => _checkout;
            set
            {
                _checkout = value;
                OnPropertyChanged();
            }
        }
        public RoomWithFacilitiesObservable SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
            }
        }
        public List<RoomWithFacilitiesObservable> RoomTypes { get; set; }
        public ObservableCollection<RegularRoom> RegularRoom { get; set; }
        #endregion

        #region Method
        private void RegularRoomInit()
        {
            int jumlahLantai = 8;
            List<int> junmlahKamar = new List<int>() { 8, 9, 6, 7, 8, 9, 6, 5 };
            for (int i = 0; i < jumlahLantai; i++)
            {

            }
        }
        /// <summary>
        /// Memesan kamar hotel
        /// </summary>
        /// <param name="status">
        /// Pilih salah satu dari <see cref="ReservationStatus"/> sebagai command parameter button
        /// </param>
        public void Reserve(object status)
        {
            
        }
        /// <summary>
        /// Membersihkan data
        /// </summary>
        public void Reset()
        {
            
        }
        #endregion
    }
}
