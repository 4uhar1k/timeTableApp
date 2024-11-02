using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace timeTableApp.ViewModels
{
    public class EventViewModel : ViewModelBase
    {
        
        public Models.Event Event; 

        public ICommand AddCommand { get; set; }

        public EventViewModel()
        {
            //Events = new ObservableCollection<Models.Event>();
            Event = new Models.Event();

            AddCommand = new Command(() =>
            {
                Models.Event newEvent = new Models.Event()
                {
                    Name = Name,
                    Description = Description,
                    Day = Day,
                    Time = Time,
                    EventCategory = EventCategory
                };



                Events.Add(newEvent);

                using (StreamWriter sw = new StreamWriter(timeTablePath, true))
                {
                    sw.WriteLine(newEvent.Name);
                    sw.WriteLine(newEvent.Description);
                    sw.WriteLine(newEvent.Day);
                    sw.WriteLine(newEvent.Time);
                    sw.WriteLine(newEvent.EventCategory.Id);
                    sw.WriteLine(newEvent.EventCategory.Name);
                    sw.Close();
                }

            }
            );
        }

        
    }
}
