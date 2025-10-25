using Lesson03_TaskList.ViewModel;

namespace Lesson03_TaskList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new TaskListViewModel();
        }

     
    }

}
