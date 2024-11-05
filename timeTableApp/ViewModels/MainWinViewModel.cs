using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace timeTableApp.ViewModels
{
    public class MainWinViewModel : ViewModelBase
    {
        public ICommand DeleteCommand { get; set; }
        public MainWinViewModel()
        {
            DeleteCommand = new Command(() =>
            {
                //Models.Event SelectedEvent = new Models.Event();
                //SelectedEvent = (Models.Event)arg;
                //AllEvents.Remove(SelectedEvent);
            });

        }

    }
}

    

