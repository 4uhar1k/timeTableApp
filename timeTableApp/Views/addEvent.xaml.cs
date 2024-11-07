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
            beginTimePicker.Text = times[0];
            endTimePicker.Text = times[1];
        }
    }

    public async void goBack(object sender, EventArgs e)
	{
		await DisplayAlert("Ready!", "Event has been successfully added", "OK");
        nameEditor.Text = "";
		descriptionEditor.Text = "";
		dayPicker.SelectedItem = null;
        categoryPicker.SelectedItem = null;
        beginTimePicker.Text = "";
        endTimePicker.Text = "";
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
        string begtimepick = beginTimePicker.Text;
        string endtimepick = endTimePicker.Text;
        this.BindingContext = new EventViewModel();
        nameEditor.Text = nametxt;
        descriptionEditor.Text = desctxt;
        dayPicker.SelectedItem = daypick;
        beginTimePicker.Text = begtimepick;
        endTimePicker.Text = endtimepick;
    }

    public void TextChanged(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;
        string text = entry.Text;
        if (text.Length==4 && !text.Contains(':'))
        {
            text = $"{text.Substring(0,2)}:{text.Substring(2,2)}";            
        }
        entry.Text = text;
        sender = entry;
    }
}