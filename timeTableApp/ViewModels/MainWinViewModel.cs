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
        public MainWinViewModel()
        {
            DeleteCommand = new Command((args) =>
            {
                Event SelectedEvent = new Event();
                SelectedEvent = (Event)args;
                if (args is Event)
                {

                    AllEvents.Remove(SelectedEvent);
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

        }

    }
}

    

