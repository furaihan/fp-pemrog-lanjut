using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinusPengger.View;

namespace PinusPengger.Controller
{
    internal class CoreController : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ReservasiViewCommand { get; set; }
        public RelayCommand HistoryViewCommand { get; set; }

        private HomeView _homeView;
        private ReservasiView _reservasiView;
        private  HistoryView _historyView;
        private object _currentView;

        public HomeView HomeView
        {
            get => _homeView;
            set => _homeView = value;
        }
        public ReservasiView ReservasiView
        {
            get => _reservasiView;
            set => _reservasiView = value;
        }
        public HistoryView HistoryView
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
            
        }
    }
}
