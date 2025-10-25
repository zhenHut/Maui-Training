using Lesson03_TaskList.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Lesson03_TaskList.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        #region Constructor
        public TaskListViewModel()
        {
            AddCommand = new Command(AddTask, CanAddTask);
            DeleteCommand = new Command<TaskItem>(DeleteTask);
        }


        #endregion


        #region Collection
        public ObservableCollection<TaskItem> Tasks { get; } = new();

        #endregion

        #region Fields

        string _newTitle = "";
        string _newPriority = "Mittel";
        #endregion

        #region Properties

        public string NewTitle
        {
            get => _newTitle;
            set
            {
                if (_newTitle != value)
                {
                    _newTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewPriority
        {
            get => _newPriority;
            set
            {
                if (_newPriority != value)
                {
                    _newPriority = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

            #region events
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Commands

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        #endregion

        #region Methods

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            ((Command)AddCommand).ChangeCanExecute();
        }

        void AddTask()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {

                Tasks.Add(new TaskItem { Title = NewTitle, Priority = NewPriority });
                NewTitle = "";
            });
        }
        
        void DeleteTask(TaskItem task)
        {
            if (Tasks.Contains(task))
                Tasks.Remove(task);
        }

        #endregion

        #region Command Methods
        bool CanAddTask()=>!string.IsNullOrWhiteSpace(NewTitle);

        

        #endregion

    }
}
