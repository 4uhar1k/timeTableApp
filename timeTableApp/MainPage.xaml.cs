using timeTableApp.ViewModels;

namespace timeTableApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainWinViewModel();
        }

        
        public void Update(object sender, EventArgs e)
        {
            this.BindingContext = new MainWinViewModel();
        }

        

    }

}
