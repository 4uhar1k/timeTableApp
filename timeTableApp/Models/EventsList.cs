using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTableApp.Models
{
    public class EventsList
    {
        public List<Event> eventsList { get; set; }

        public EventsList()
        {
            eventsList = new List<Event>();
        }

        public IEnumerable<Event> GetEvents(string day)
        {
            return (IEnumerable<Event>)eventsList.Where(n => n.day == day);
        }

        public void AddEvent(Event e)
        {
            eventsList.Add(e);
        }
    }
}
