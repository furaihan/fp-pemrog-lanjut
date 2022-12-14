namespace PinusPengger.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        /*
        public ViewModelCommand HomeViewCommand { get; set; }
        public ViewModelCommand ReservationViewCommand { get; set; }
        public ViewModelCommand HistoryViewCommand { get; set; }

        private HomeViewModel _homeView;
        private ReservationViewModel _reservasiView;
        private HistoryViewModel _historyView;
        private object _currentView;

        public HomeViewModel HomeView
        {
            get => _homeView;
            set => _homeView = value;
        }
        public ReservationViewModel ReservasiView
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
        public MainViewModel()
        {
            HomeView = new HomeViewModel();
            ReservasiView = new ReservationViewModel();
            HistoryView = new HistoryViewModel();

            CurrentView = HistoryView;

            HistoryViewCommand = new ViewModelCommand(o => CurrentView = HistoryView);
            ReservationViewCommand = new ViewModelCommand(o => CurrentView = ReservasiView);
            HomeViewCommand = new ViewModelCommand(o => CurrentView = HomeView);
        }
        */
    }
}
