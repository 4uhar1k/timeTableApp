using timeTableApp.Models;

namespace timeTableApp
{
    public partial class App : Application
    {
        private readonly TimeTable timeTable;
        public App()
        {
            InitializeComponent();
            
            timeTable = new TimeTable();
            
            MainPage = new AppShell();

        }

       
    }
}
