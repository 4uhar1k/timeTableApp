using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTableApp.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        public ViewModelBase CurViewModel { get; }
        public MainViewModel()
        {
            CurViewModel = new TimeTableViewModel();
        }
    }
}
