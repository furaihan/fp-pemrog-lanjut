using PinusPengger.View.Pages;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// Class that represents the main view model of the application
    /// </summary>
    internal class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the command to navigate to the HomeView
        /// </summary>
        public ViewModelCommand HomeViewCommand { get; set; }
        /// <summary>
        /// Gets or sets the command to navigate to the ReservationView
        /// </summary>
        public ViewModelCommand ReservationViewCommand { get; set; }
        /// <summary>
        /// Gets or sets the command to navigate to the HistoryView
        /// </summary>
        public ViewModelCommand HistoryViewCommand { get; set; }
        /// <summary>
        /// Gets or sets the command to navigate to the ProfileView
        /// </summary>
        public ViewModelCommand ProfileCommand { get; set; }

        private object _currentView;
        private bool showUserProfile;

        ///<summary>
        ///The Home view that is displayed in the content area.
        ///</summary>
        public HomePage HomeView { get; set; }

        ///<summary>
        ///The Reservation view that is displayed in the content area.
        ///</summary>
        public ReservationPage ReservasiView { get; set; }

        ///<summary>
        ///The History view that is displayed in the content area.
        ///</summary>
        public HistoryPage HistoryView { get; set; }

        ///<summary>
        /// The current view displayed in the main window
        ///</summary>
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the value that determines whether the user profile is shown or not
        /// </summary>
        public bool ShowUserProfile
        {
            get => showUserProfile;
            set
            {
                showUserProfile = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class with default values.
        /// </summary>
        public MainViewModel()
        {
            HomeView = new HomePage();
            ReservasiView = new ReservationPage();
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
