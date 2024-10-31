﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace timeTableApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        string name, description, day, time;
        Models.Category category;
        public string timeTablePath = Path.Combine(FileSystem.AppDataDirectory, "timetable.txt");
        
        public ViewModelBase()
        {
            
            name = "";
            description = "";
            day = "";
            time = "";
            category = new Models.Category();
            
        }
        

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Day
        {
            get => day;
            set
            {
                if (day != value)
                {
                    day = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Time
        {
            get => time;
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged();
                }
            }
        }

        public Models.Category EventCategory
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
