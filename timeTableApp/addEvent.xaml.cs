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
		await Navigation.PopAsync();
	}
}