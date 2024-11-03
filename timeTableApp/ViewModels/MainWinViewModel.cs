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
                string catName;
                int catId;
                while ((line = sr.ReadLine()) != null)
                {
                    Models.Event e = new Models.Event();
                    e.Name = line;
                    e.Description = sr.ReadLine();
                    e.Day = sr.ReadLine();
                    e.Time = sr.ReadLine();
                    catId = Convert.ToInt32(sr.ReadLine());
                    catName = sr.ReadLine();
                    if (catId == 0 && catName=="")
                    {
                        e.EventCategory = new Models.Category() { Id = catId, Name = "without category" };
                    }
                    else
                    {
                        e.EventCategory = new Models.Category() { Id = catId, Name = catName };
                    }
                    
                    AllEvents.Add(e);
                    switch (e.Day)
                    {
                        case "Monday":
                            Events[0].Add(e);
                            break;
                        case "Tuesday":
                            Events[1].Add(e);
                            break;
                        case "Wednesday":
                            Events[2].Add(e);
                            break;
                        case "Thursday":
                            Events[3].Add(e);
                            break;
                        case "Friday":
                            Events[4].Add(e);
                            break;
                        case "Saturday":
                            Events[5].Add(e);
                            break;
                        case "Sunday":
                            Events[6].Add(e);
                            break;

                    }
                }
                sr.Close();
            }
        }
    }
}
