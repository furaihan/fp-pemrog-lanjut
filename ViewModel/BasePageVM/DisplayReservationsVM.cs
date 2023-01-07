﻿using PinusPengger.Model.ServiceAgent;
using PinusPengger.ViewModel.ObservableCombinedModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PinusPengger.ViewModel.BasePageVM
{
    public class DisplayReservationsVM : ViewModelBase
    {
        public DisplayReservationsVM()
        {
            _searchCommand = new ViewModelCommand(param => GetData());
            ReservationJoineds = new ObservableCollection<ReservationJoinedObservable>();
        }

        #region Field
        private string _target = string.Empty;
        private string _errorMessage = string.Empty;
        private ViewModelCommand _searchCommand;
        #endregion

        #region Properties
        public string Target
        {
            get => _target;
            set
            {
                _target = value;
                OnPropertyChanged();
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        public ViewModelCommand SearchCommand
        {
            get
            {
                _searchCommand ??= new ViewModelCommand(param => GetData());
                return _searchCommand;
            }
        }
        public ObservableCollection<ReservationJoinedObservable> ReservationJoineds { get; set; }
        #endregion

        #region Method
        public void GetData()
        {
            using (var reservationSA = new ReservationSA())
            {
                try
                {
                    reservationSA.FetchData();
                    var data = reservationSA.GetData(_target);

                    if (data is IEnumerable<ReservationJoinedObservable> convertedData)
                    {
                        ReservationJoineds = new ObservableCollection<ReservationJoinedObservable>(convertedData);
                    }
                    else
                    {
                        throw new Exception("Data tidak ditemukan");
                    }
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            }

            Target = string.Empty;
        }
        #endregion
    }
}