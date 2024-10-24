using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTableApp.ViewModels
{
    public class EventViewModel: ViewModelBase
    {
        private readonly Models.Event _event;
        public string name => _event.name;
        public string description => _event.name;
        public string time => _event.name;
        public Models.Category category => _event.category;

        public EventViewModel(Models.Event Event)
        {
            _event = Event;
        }
    }
}
