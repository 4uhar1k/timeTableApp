﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTableApp.Models
{
    public class TimeTable
    {
        private readonly EventsList _eventsList;

        public TimeTable()
        {
            _eventsList = new EventsList();
        }

        public IEnumerable<Event> GetEvents(string day)
        {
            return _eventsList.GetEvents(day);
        }

        public void AddEvent(Event e)
        {
            _eventsList.AddEvent(e);
        }
    }
}
