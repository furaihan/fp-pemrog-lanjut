using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PinusPengger.ViewModel
{
    public partial class HomeController : UserControl
    {
        public HomeController()
        {
            InitializeComponent();
        }
        private void FillContext()
        {
            Random rnd = new();
            for (int i = 1; i <= rnd.Next(30, 123); i++)
            {
                byte roomFloor = (byte)((i / 10 % 10) + 1);
                Person person = new((ulong)((81287387 + i) * rnd.Next(3)),
                                    $"Ngolo Kante {rnd.Next(100, 999)}",
                                    rnd.Next(1000000, 9999999).ToString(),
                                    DateTime.Now);
                Room room = new(new RoomNumbering(roomFloor, (byte)(i % 10)),
                                rnd.Next() % 2 == 0 ? RoomType.Reguler : RoomType.VIP,
                                RoomFeature.DoubleBed);
                Reservation reservation = new(i,
                                              room,
                                              person,
                                              DateTime.Now - TimeSpan.FromDays(rnd.Next(3)),
                                              DateTime.Now + TimeSpan.FromDays(rnd.Next(2, 8)));
                reservation.Status = rnd.Next() % 3 == 1 ? ReservationStatus.CheckedIn : ReservationStatus.Booked;
                tabelHistori.Items.Add(reservation);
            }
        }
    }
}
