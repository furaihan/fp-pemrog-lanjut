using System.Windows.Controls.Primitives;
using System.Windows.Input;
using PinusPengger.View;

namespace PinusPengger.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {

        public ICommand HomeViewCommand { get; set; }
        public ICommand ReservationViewCommand { get; set; }
        public ICommand HistoryViewCommand { get; set; }
        public ICommand ProfileCommand { get; set; }

        private object _currentView;
        private bool showUserProfile;
        private readonly HomePage homePage;
        private readonly ReservasiPage reservasiPage;
        private readonly HistoryPage historyPage;

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
            homePage = new HomePage();
            historyPage = new HistoryPage();
            reservasiPage = new ReservasiPage();

            CurrentView = homePage;
            showUserProfile = false;
            HistoryViewCommand = new ViewModelCommand(o => CurrentView = historyPage);
            ReservationViewCommand = new ViewModelCommand(o => CurrentView = reservasiPage);
            HomeViewCommand = new ViewModelCommand(o => CurrentView = homePage);
            ProfileCommand = new ViewModelCommand(x => ShowUserProfile = !ShowUserProfile);
        }

    }
}
