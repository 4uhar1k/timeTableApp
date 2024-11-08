using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using timeTableApp.ViewModels;
using timeTableApp.Models;
namespace timeTableApp;

public partial class addEvent : ContentPage
{
	EventViewModel thisContext = new EventViewModel();
    public Event CurEventToEdit { get; set; }
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
            CurEventToEdit = e;
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
        if (dayPicker.SelectedItem!=null & nameEditor.Text != "" & CorrectTime(beginTimePicker.Text, endTimePicker.Text)==true)
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
        }
        else
        {            
            await DisplayAlert("Error!", "Invalid data.", "OK");
        }
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
            if (entry == beginTimePicker)
            {
                endTimePicker.Focus();
            }
            else
            {
                nameEditor.Focus();
            }
        }
        else if (text.Length == 4 && text.Contains(':') && text.IndexOf(':')==1)
        {
            text = $"0{text.Substring(0, 1)}:{text.Substring(2, 2)}";
            if (entry == beginTimePicker)
            {
                endTimePicker.Focus();
            }
            else
            {
                nameEditor.Focus();
            }
        }
        entry.Text = text;
        sender = entry;
    }

    public bool CorrectTime(string begintime, string endtime)
    {
        try
        {
            if (begintime.Length == 5 & endtime.Length == 5 & Convert.ToInt32(begintime.Substring(0, 2)) < 24 & Convert.ToInt32(begintime.Substring(0, 2)) >= 0 & Convert.ToInt32(begintime.Substring(3, 2)) <= 59 & Convert.ToInt32(begintime.Substring(3, 2)) >= 0 & Convert.ToInt32(endtime.Substring(0, 2)) < 24 & Convert.ToInt32(endtime.Substring(0, 2)) >= 0 & Convert.ToInt32(endtime.Substring(3, 2)) <= 59 & Convert.ToInt32(endtime.Substring(3, 2)) >= 0)
            {
                if (Convert.ToInt32(begintime.Substring(0, 2)) <= Convert.ToInt32(endtime.Substring(0, 2)))
                {
                    return true;
                }
            }
        }
        catch
        {

        }
        
        return false;
    }
}