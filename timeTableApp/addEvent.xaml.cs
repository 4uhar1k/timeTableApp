using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using timeTableApp.ViewModels;
using timeTableApp.Models;
namespace timeTableApp;

public partial class addEvent : ContentPage
{
	EventViewModel thisContext = new EventViewModel();
	public addEvent()
	{
		InitializeComponent();
		BindingContext = thisContext;
        
    }

    public addEvent(Event e)
    {
        InitializeComponent();
        BindingContext = thisContext;
        if (e != null)
        {
            thisContext.EventToEdit = e;
            
            nameEditor.Text = e.Name;
            descriptionEditor.Text = e.Description;
            dayPicker.SelectedItem = e.Day;
            categoryPicker.SelectedItem = e.EventCategory.CategoryName;
            string[] times = e.Time.Split('-');
            beginTimePicker.SelectedItem = times[0];
            endTimePicker.SelectedItem = times[1];
        }
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
        if (thisContext.EventToEdit != null)
        {
            await Navigation.PopAsync();
        }
        //Application.Current.MainPage.BindingContext = new MainWinViewModel();
    }

    public async void addCategory(object sender, EventArgs e)
    {
        try
        {
            if (categoryPicker.SelectedItem.ToString() == "Add new category...")
            {
                categoryPicker.SelectedItem = null;
                AddCategory popup = new AddCategory();
                this.ShowPopup(popup);
                popup.Closed += UpdateCategories;
                
            }
        }
        catch
        {

        }
        
        //picker.SelectedItem = "None";

    }

    public void UpdateCategories(object sender, PopupClosedEventArgs e)
    {
        string nametxt = nameEditor.Text;
        string desctxt = descriptionEditor.Text;
        object daypick = dayPicker.SelectedItem;
        object begtimepick = beginTimePicker.SelectedItem;
        object endtimepick = endTimePicker.SelectedItem;
        this.BindingContext = new EventViewModel();
        nameEditor.Text = nametxt;
        descriptionEditor.Text = desctxt;
        dayPicker.SelectedItem = daypick;
        beginTimePicker.SelectedItem = begtimepick;
        endTimePicker.SelectedItem = endtimepick;
    }
}