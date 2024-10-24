using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTableApp.ViewModels
{
    public class TimeTableViewModel: ViewModelBase
    {
        private readonly ObservableCollection<EventViewModel> _events;
        public IEnumerable<EventViewModel> Events => _events;
        public TimeTableViewModel() 
        {
            _events = new ObservableCollection<EventViewModel>();
        }

    }
}
