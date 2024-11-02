using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTableApp.ViewModels
{
    public class MainWinViewModel:ViewModelBase
    {
        //public ObservableCollection<Models.Event> Events { get; set; }
    
        public MainWinViewModel()
        {
            //Events = new ObservableCollection<Models.Event>();
            if (!File.Exists(timeTablePath))
            {
                File.Create(timeTablePath);
            }
            using (StreamReader sr = new StreamReader(timeTablePath))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    Models.Event e = new Models.Event();
                    e.Name = line;
                    e.Description = sr.ReadLine();
                    e.Day = sr.ReadLine();
                    e.Time = sr.ReadLine();
                    e.EventCategory = new Models.Category() { Id = Convert.ToInt32(sr.ReadLine()), Name = sr.ReadLine() };
                    Events.Add(e);
                }
                sr.Close();
            }
        }
    }
}
