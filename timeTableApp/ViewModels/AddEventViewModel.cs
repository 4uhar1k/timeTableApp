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
    public class AddEventViewModel: ViewModelBase
    {
        private string _name;

        public ObservableCollection<Event> eventsList { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


        private string _time;
        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        private Category _category;
        public Category Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public ICommand AddCommand { get; }

        public AddEventViewModel()
        {
            eventsList = new ObservableCollection<Event>();
            AddCommand = new Command(() =>
            {
                Event newEvent = new Event() { name = Name, description = Description, time = Time, category = Category };
                eventsList.Add(newEvent);
            });
        }
    }
}
