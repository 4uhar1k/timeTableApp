using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTableApp.Models
{
    public class Event
    {
        public string name { get; set; }
        public string description { get; set; }
        public string time { get; set; }
        public Category category { get; set; }
    }
}
