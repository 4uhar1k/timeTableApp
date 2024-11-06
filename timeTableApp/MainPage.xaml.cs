﻿using timeTableApp.ViewModels;
using timeTableApp.Models;

namespace timeTableApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainWinViewModel();
        }

        
        public void Update(object sender, EventArgs e)
        {
            this.BindingContext = new MainWinViewModel();
        }

        public async void EditNote(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if (btn.CommandParameter is Event)
            {
                Event selectedEvent = (Event)btn.CommandParameter;
                addEvent newPage = new addEvent(selectedEvent);
                newPage.Title = "Editing...";
                await Navigation.PushAsync(newPage);
            }
            
        }

    }

}
