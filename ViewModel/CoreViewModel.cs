using PinusPengger.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PinusPengger.ViewModel
{
    internal class CoreViewModel : ObservableObject
    {
        public ViewModelCommand HomeViewCommand { get; set; }
        public ViewModelCommand ReservationViewCommand { get; set; }
        public ViewModelCommand HistoryViewCommand { get; set; }

        private HomeController _homeView;
        private ReservasiController _reservasiView;
        private HistoryViewModel _historyView;
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
        public HistoryViewModel HistoryView
        {
            get => _historyView;
            set => _historyView = value;
        }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public CoreViewModel()
        {
            HomeView = new HomeController();
            ReservasiView = new ReservasiController();
            HistoryView = new HistoryViewModel();

            CurrentView = HistoryView;

            HistoryViewCommand = new ViewModelCommand(o => CurrentView = HistoryView);
            ReservationViewCommand = new ViewModelCommand(o => CurrentView = ReservasiView);
            HomeViewCommand = new ViewModelCommand(o => CurrentView = HomeView);
        }
    }
}
