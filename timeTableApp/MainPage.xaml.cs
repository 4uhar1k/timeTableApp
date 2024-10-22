

namespace timeTableApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        List<Models.Category> test;

        public MainPage()
        {
            InitializeComponent();
            test = new List<Models.Category>();
            test.Add(new Models.Category() { Id = 1, Name = "sosalnya"});
            test.Add(new Models.Category() { Id = 2, Name = "ebalnya" });
            BindingContext = test;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            
        }

        
    }

}
