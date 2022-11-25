using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PinusPengger.Controller
{
    public partial class ReservasiController : UserControl
    {
        public ObservableCollection<Room> RoomContext { get; set; }
        public ReservasiController()
        {
            InitializeComponent();
            RoomContext = new ObservableCollection<Room>();
        }
        private void FillRoom()
        {
            Random rnd  = new Random();
            for (int i = 0; i < 20; i++)
            {

            }
        }
    }
}
