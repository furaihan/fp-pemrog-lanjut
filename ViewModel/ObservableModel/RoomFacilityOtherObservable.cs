using PinusPengger.Model;

namespace PinusPengger.ViewModel.ObservableModel
{
    /// <summary>
    /// Represents an observable object for the <see cref="Model.EntityModel.RoomFacilityOther"/> model in the Model namespace. Inherits from ViewModelBase.
    /// </summary>
    public class RoomFacilityOtherObservable : ViewModelBase
    {
        private string _nameOfFacility;
        private Tag.RoomType _roomType;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomFacilityOtherObservable"/> class. 
        /// Sets the NameOfFacility property to an empty string.
        /// </summary>
        public RoomFacilityOtherObservable()
        {
            _nameOfFacility = string.Empty;
        }

        /// <summary>
        /// Gets or sets the name of the facility.
        /// </summary>
        public string NameOfFacility
        {
            get => _nameOfFacility;
            set
            {
                _nameOfFacility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the type of room associated with the facility.
        /// </summary>
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set
            {
                _roomType = value;
                OnPropertyChanged();
            }
        }

    }
}
