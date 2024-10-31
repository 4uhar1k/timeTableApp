namespace timeTableApp;

public partial class addEvent : ContentPage
{
	public addEvent()
	{
		InitializeComponent();
		BindingContext = new ViewModels.EventViewModel();
	}

	public async void goBack(object sender, EventArgs e)
	{
		await DisplayAlert("Ready!", "Event has been successfully added", "OK");
	}
}