namespace timeTableApp.Views;

public partial class addEvent : ContentPage
{
	public addEvent()
	{
		InitializeComponent();
		BindingContext = new ViewModels.AddEventViewModel();
	}

	public async void goBack(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}