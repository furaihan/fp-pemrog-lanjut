using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PinusPengger.Controller
{
    internal class CoreController : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ReservationViewCommand { get; set; }
        public RelayCommand HistoryViewCommand { get; set; }

        private HomeController _homeView;
        private ReservasiController _reservasiView;
        private  HistoryController _historyView;
        private object _currentView;

        public HomeController HomeView
        {
            get => _homeView;
            set => _homeView = value;
        }
        public ReservasiController ReservasiView
        {
            get => _reservasiView;
            set => _reservasiView = value;
        }
        public HistoryController HistoryView
        {
            get => _historyView;
            set => _historyView = value;
        }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView= value;
                OnPropertyChanged();
            }
        }
        public CoreController()
        {
            HomeView = new HomeController();
            ReservasiView = new ReservasiController();
            HistoryView = new HistoryController();


            CurrentView = HistoryView;

            HistoryViewCommand = new RelayCommand(o => CurrentView = HistoryView);
            ReservationViewCommand = new RelayCommand(o => CurrentView = ReservasiView);
            HomeViewCommand = new RelayCommand(o => CurrentView = HomeView);
        }
    }
}
