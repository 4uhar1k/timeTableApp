using timeTableApp.ViewModels;

namespace timeTableApp;

public partial class addEvent : ContentPage
{
	EventViewModel thisContext = new EventViewModel();
	public addEvent()
	{
		InitializeComponent();
		BindingContext = thisContext;

    }

	public async void goBack(object sender, EventArgs e)
	{
		await DisplayAlert("Ready!", "Event has been successfully added", "OK");
        nameEditor.Text = "";
		descriptionEditor.Text = "";
		dayPicker.SelectedItem = null;
        categoryPicker.SelectedItem = null;
        beginTimePicker.SelectedItem = null;
        endTimePicker.SelectedItem = null;
    }

    public async void addCategory(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        object selectedItem = picker.SelectedItem;
        if (selectedItem.ToString() == "Add new category...")
        {            
            await Navigation.PushAsync(new AddCategory());
        }
        //picker.SelectedItem = "None";

    }
}