using timeTableApp.ViewModels;

namespace timeTableApp;

public partial class addEvent : ContentPage
{
	public addEvent()
	{
		InitializeComponent();
		BindingContext = new EventViewModel();
	}

	public async void goBack(object sender, EventArgs e)
	{
		await DisplayAlert("Ready!", "Event has been successfully added", "OK");
		nameEditor.Text = "";
		descriptionEditor.Text = "";
		dayEditor.Text = "";
		timeEditor.Text = "";
		MainPage mainPage = new MainPage();
		mainPage.Update();
	}
}