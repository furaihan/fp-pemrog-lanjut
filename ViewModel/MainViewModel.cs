namespace PinusPengger.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        
        public ViewModelCommand HomeViewCommand { get; set; }
        public ViewModelCommand ReservationViewCommand { get; set; }
        public ViewModelCommand HistoryViewCommand { get; set; }

        private HomePageViewModel _homeView;
        private ReservationPageViewModel _reservasiView;
        private HistoryPageViewModel _historyView;
        private object _currentView;

        public HomePageViewModel HomeView
        {
            get => _homeView;
            set => _homeView = value;
        }
        public ReservationPageViewModel ReservasiView
        {
            get => _reservasiView;
            set => _reservasiView = value;
        }
        public HistoryPageViewModel HistoryView
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
            HomeView = new HomePageViewModel();
            ReservasiView = new ReservationPageViewModel();
            HistoryView = new HistoryPageViewModel();

            CurrentView = HistoryView;

            HistoryViewCommand = new ViewModelCommand(o => CurrentView = HistoryView);
            ReservationViewCommand = new ViewModelCommand(o => CurrentView = ReservasiView);
            HomeViewCommand = new ViewModelCommand(o => CurrentView = HomeView);
        }
        
    }
}
