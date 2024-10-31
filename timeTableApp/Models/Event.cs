using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTableApp.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Day { get; set; }
        public string Time { get; set; }
        public Category EventCategory { get; set; }
    }
}
