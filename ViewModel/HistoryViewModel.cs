
using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// Interaction logic for HistoryView2.xaml
    /// </summary>
    public partial class HistoryViewModel : UserControl
    {
        public HistoryViewModel()
        {
            InitializeComponent();
            FillContext();
        }
        public void OnLoaded(object sender, RoutedEventArgs e)
        {
        }
        private void FillContext()
        {
            Random rnd = new();
            for (int i = 1; i <= rnd.Next(30, 123); i++)
            {
                byte roomFloor = (byte)((i / 10 % 10) + 1);
                Person person = new((ulong)((81287387 + i) * rnd.Next(3)),
                                    $"Cristiano Ronaldo SIUU {i * 2}",
                                    "112312312",
                                    DateTime.Now);
                Room room = new(new RoomNumbering(roomFloor, (byte)(i % 10)),
                                rnd.Next() % 2 == 0 ? RoomType.Reguler : RoomType.VIP,
                                RoomFeature.DoubleBed);
                Reservation reservation = new(i,
                                              room,
                                              person,
                                              DateTime.Now - TimeSpan.FromDays(rnd.Next(3)),
                                              DateTime.Now + TimeSpan.FromDays(rnd.Next(2, 8)));
                reservation.Status = ReservationStatus.CheckedOut;
                tabelHistori.Items.Add(reservation);
            }
        }
    }

}

