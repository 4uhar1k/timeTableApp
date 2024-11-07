using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using timeTableApp.Models;


namespace timeTableApp.ViewModels
{
    public class EventViewModel : ViewModelBase
    {
        
        public Event Event; 
        public string beginTime, endTime;
        string name;
        int id;
        public ICommand AddEvent { get; set; }
        public ICommand AddCategory { get; set; }

        public EventViewModel()
        {
            name = "";
            id = 0;
            //Events = new ObservableCollection<Models.Event>();
            Event = new Event();
            

            AddEvent = new Command(() =>
            {
                Event newEvent = new Event()
                {
                    Name = Name,
                    Description = Description,
                    Day = Day,
                    Time = $"{BeginTime}-{EndTime}",
                    
                };
                try
                {
                    Category newCat = new Category();
                    newCat = Categories.First(n => n.CategoryName == CategoryName);
                    newEvent.EventCategory = newCat;
                }
                catch
                {
                    newEvent.EventCategory.Id = 0;
                    newEvent.EventCategory.CategoryName = "";
                }
                
                try
                {
                    Event oldEvent = new Event();
                    oldEvent = AllEvents.First(e => e.Name == EventToEdit.Name & e.Description == EventToEdit.Description & e.Day == EventToEdit.Day & e.Time == EventToEdit.Time & e.EventCategory.Id == EventToEdit.EventCategory.Id & e.EventCategory.CategoryName == EventToEdit.EventCategory.CategoryName);
                    AllEvents.Remove(oldEvent);
                }
                catch
                {
                }
                

                AllEvents.Add(newEvent);

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
                
            });

            AddCategory = new Command(() =>
            {
                Category cat = new Category();
                cat.Id = globalId++;
                cat.CategoryName = CategoryName;
                Categories.Add(cat);
                using (StreamWriter sw = new StreamWriter(categoriesPath, true))
                {
                    sw.WriteLine(cat.Id);
                    sw.WriteLine(cat.CategoryName);
                }
            });
        }

        
        
        
            

            

        

        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CategoryName
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
