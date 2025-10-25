using FocusUnit.ViewModels;

namespace FocusUnit
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new FocusUnitViewModel();
            
        }

    
    }

}
