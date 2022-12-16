using PinusPengger.Model;
using PinusPengger.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinusPengger.ViewModel
{
    internal class ReservationViewModel : ViewModelBase
    {
        private ObservableCollection<RegularRoom> _regularRoom;

        public ObservableCollection<RegularRoom> RegularRoom
        {
            get => _regularRoom; 
            set
            {
                _regularRoom = value;
                OnPropertyChanged();
            }
        }
        private void RegularRoomInit()
        {
            int jumlahLantai = 8;
            List<int> junmlahKamar = new List<int>() { 8, 9, 6, 7, 8, 9, 6, 5 };
            for (int i = 0; i < jumlahLantai; i++)
            {

            }
        }
    }
}
