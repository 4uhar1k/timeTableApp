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
    public class EventViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Models.Event> Events;
        public Models.Event Event; 

        public ICommand AddCommand { get; set; }

        public EventViewModel()
        {
            Events = new ObservableCollection<Models.Event>();

            AddCommand = new Command(() =>
            {
                Models.Event newEvent = new Models.Event()
                {
                    name = Name,
                    description = Description,
                    day = Day,
                    time = Time,
                    category = Category
                };

                Events.Add(newEvent);

            }
            );
        }

        public string Name
        {
            get => Event.name;
            set
            {
                if (Event.name != value) 
                {
                    Event.name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => Event.description;
            set
            {
                if (Event.description != value)
                {
                    Event.description = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Day
        {
            get => Event.day;
            set
            {
                if (Event.day != value)
                {
                    Event.day = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Time
        {
            get => Event.time;
            set
            {
                if (Event.time != value)
                {
                    Event.time = value;
                    OnPropertyChanged();
                }
            }
        }

        public Models.Category Category
        {
            get => Event.category;
            set
            {
                if (Event.category != value)
                {
                    Event.category = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string property="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
