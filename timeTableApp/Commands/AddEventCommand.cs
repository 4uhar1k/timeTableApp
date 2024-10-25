using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timeTableApp.Models;
using timeTableApp.ViewModels;

namespace timeTableApp.Commands
{
    public class AddEventCommand : CommandBase
    {
        private readonly TimeTable _timeTable;
        private readonly AddEventViewModel _addEventViewModel;

        public AddEventCommand(ViewModels.AddEventViewModel addEventViewModel, TimeTable timeTable)
        {
            _addEventViewModel = addEventViewModel;
            _timeTable = timeTable;
        }
        public override void Execute(object? parameter)
        {
            Event newEvent = new Event() { name = _addEventViewModel.Name, description = _addEventViewModel.Description,
            day = _addEventViewModel.Day, time = _addEventViewModel.Time, category = _addEventViewModel.Category};

            _timeTable.AddEvent(newEvent);

        }
    }
}
