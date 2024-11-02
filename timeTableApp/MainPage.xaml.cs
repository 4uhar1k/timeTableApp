

namespace timeTableApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            /*string timeTablePath = Path.Combine(FileSystem.AppDataDirectory, "timetable.txt");
            File.Delete(timeTablePath);*/
            BindingContext = new ViewModels.MainWinViewModel();
        }

        
        public void Update(object sender, EventArgs e)
        {
            this.BindingContext = new ViewModels.MainWinViewModel();
        }

        public void Update()
        {
            this.BindingContext = new ViewModels.MainWinViewModel();
        }

    }

}
