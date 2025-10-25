using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FocusUnit.ViewModels
{
    public enum Priority
    {
        Niedrig,
        Mittel,
        Hoch
    }

    public class FocusUnitViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public FocusUnitViewModel()
        {
            SaveCommand = new Command(OnSave, () => IsValid);
            ResetCommand = new Command(OnReset);
        }

        #endregion

        #region Fields
        string _title = "";
        Priority _selectedPriority = Priority.Mittel;
        DateTime _dueDate = DateTime.Today;
        bool _isValid;
        bool _isTitleValid;
        bool _isDateValid;

        #endregion

        #region Properties
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
                UpdateValidity();
            }
        }

        public Priority SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged();
            }
        }

        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
                OnPropertyChanged();
                UpdateValidity();
            }
        }

        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                OnPropertyChanged();
                ((Command)SaveCommand).ChangeCanExecute();
            }
        }

        public Array PriorityOptions { get; } = Enum.GetValues(typeof(Priority));

        public bool IsTitleValid
        {
            get => _isTitleValid;
            private set
            {
                if (_isTitleValid != value)
                {
                    _isTitleValid = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsDateValid
        {
            get => _isDateValid;
            private set
            {
                if (_isDateValid != value)
                {
                    _isDateValid = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Commands

        public ICommand SaveCommand { get; }
        public ICommand ResetCommand { get; }

        #endregion

        #region Methods

        private void UpdateValidity()
        {
            IsDateValid = DueDate >= DateTime.Today;
            IsTitleValid = !string.IsNullOrWhiteSpace(Title) && Title.Length >= 3;
            IsValid = IsTitleValid && IsDateValid;
            
        }

        private void OnSave()
        {
            Application.Current!.MainPage!.DisplayAlert("Gespeichert", $"Titel: {Title}\nPriorität: {SelectedPriority}\nfällig: {DueDate:d}", "OK");
        }

        private void OnReset()
        {
            Title = "";
            SelectedPriority = Priority.Mittel;
            DueDate = DateTime.Today;
        }

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion


    }
}
