using PinusPengger.View;

namespace PinusPengger.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {

        public ViewModelCommand HomeViewCommand { get; set; }
        public ViewModelCommand ReservationViewCommand { get; set; }
        public ViewModelCommand HistoryViewCommand { get; set; }
        public ViewModelCommand ProfileCommand { get; set; }

        private object _currentView;
        private bool showUserProfile;

        public HomePage HomeView { get; set; }
        public ReservasiPage ReservasiView { get; set; }
        public HistoryPage HistoryView { get; set; }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public bool ShowUserProfile
        {
            get => showUserProfile;
            set
            {
                showUserProfile = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeView = new HomePage();
            ReservasiView = new ReservasiPage();
            HistoryView = new HistoryPage();

            _currentView = HomeView;
            showUserProfile = false;
            HistoryViewCommand = new ViewModelCommand(o => CurrentView = HistoryView);
            ReservationViewCommand = new ViewModelCommand(o => CurrentView = ReservasiView);
            HomeViewCommand = new ViewModelCommand(o => CurrentView = HomeView);
            ProfileCommand = new ViewModelCommand(x => ShowUserProfile = !ShowUserProfile);
        }

    }
}
