using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PinusPengger.ViewModel
{
    public class Ticker : INotifyPropertyChanged
    {
        public Ticker()
        {
            Timer timer = new()
            {
                Interval = 1000 // 1 second updates
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public DateTime Now => DateTime.Now;

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Now)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
