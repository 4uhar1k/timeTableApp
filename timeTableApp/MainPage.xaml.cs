

namespace timeTableApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        //List<Models.Event> test;

        public MainPage()
        {
            InitializeComponent();
            /*test = new List<Models.Event>();
            test.Add(new Models.Event() { name = "1", description = "sosalnya", time="17:00", category=null});
            test.Add(new Models.Event() { name = "2", description = "ebalnya", time = "18:00", category = new Models.Category() { Id = 1, Name = "uni" } });*/
            BindingContext = new ViewModels.AddEventViewModel();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.addEvent());
        }

        
    }

}
