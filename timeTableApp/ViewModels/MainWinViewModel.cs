using CommunityToolkit.Maui.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using timeTableApp.Models;

namespace timeTableApp.ViewModels
{
    public class MainWinViewModel : ViewModelBase
    {
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public MainWinViewModel()
        {
            DeleteCommand = new Command((args) =>
            {
                Event SelectedEvent = new Event();
                SelectedEvent = (Event)args;
                if (args is Event)
                {

                    AllEvents.Remove(SelectedEvent);
                    Events[0] = AllEvents.Where(n => n.Day == "Monday").ToObservableCollection();
                    Events[1] = AllEvents.Where(n => n.Day == "Tuesday").ToObservableCollection();
                    Events[2] = AllEvents.Where(n => n.Day == "Wednesday").ToObservableCollection();
                    Events[3] = AllEvents.Where(n => n.Day == "Thursday").ToObservableCollection();
                    Events[4] = AllEvents.Where(n => n.Day == "Friday").ToObservableCollection();
                    Events[5] = AllEvents.Where(n => n.Day == "Saturday").ToObservableCollection();
                    Events[6] = AllEvents.Where(n => n.Day == "Sunday").ToObservableCollection();
                    using (StreamWriter sw = new StreamWriter(timeTablePath, false))
                    {
                        foreach (Event e in AllEvents)
                        {
                            sw.WriteLine(e.Name);
                            sw.WriteLine(e.Description);
                            sw.WriteLine(e.Day);
                            sw.WriteLine(e.Time);
                            sw.WriteLine(e.EventCategory.Id);
                            sw.WriteLine(e.EventCategory.CategoryName);
                        }
                        
                        sw.Close();
                    }
                }
                
            });

            EditCommand = new Command((args) =>
            {
                Event SelectedEvent = new Event();
                SelectedEvent = (Event)args;
                if (args is Event)
                {
                    EventToEdit = SelectedEvent;
                    EventToSave = SelectedEvent;
                }

            });

        }

    }
}

    

