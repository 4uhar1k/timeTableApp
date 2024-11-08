using timeTableApp.ViewModels;
namespace timeTableApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //thisTabbar.
            //Navigated += Update;
        }

        //public void Update(object sender, ShellNavigatedEventArgs e)
        //{
        //    var curPageUri = e.Current.Location.OriginalString;
        //    if (curPageUri.Contains("MainPage"))
        //    {
        //        Current.BindingContext = new MainWinViewModel();
        //    }
        //    //App.Current.MainPage.BindingContext = new MainWinViewModel();
        //}

    }
}
