using CommunityToolkit.Maui.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using timeTableApp.Models;

namespace timeTableApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        string name, description, day, time, begintime, endtime;
        Category category;
        bool basicExists;
        public string timeTablePath = Path.Combine(FileSystem.AppDataDirectory, "timetable.txt");
        public string categoriesPath = Path.Combine(FileSystem.AppDataDirectory, "categories.txt");
        public int globalId;
        public ObservableCollection<Event> AllEvents { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<string> NamesOfCategories { get; set; }
        public ObservableCollection<Event>[] Events { get; set; }
        public ICommand AddEvent { get; set; }
        public ICommand AddCategory { get; set; }

        public Event EventToEdit { get; set; }
        public Event EventToSave { get; set; }

        public ViewModelBase()
        {
            AllEvents = new ObservableCollection<Event>();
            Categories = new ObservableCollection<Category>();
            NamesOfCategories = new ObservableCollection<string>();
            Events = new ObservableCollection<Event>[7] { new ObservableCollection<Event>(), new ObservableCollection<Event>(), new ObservableCollection<Event>(), new ObservableCollection<Event>(), new ObservableCollection<Event>(), new ObservableCollection<Event>(), new ObservableCollection<Event>() };
            name = "";
            description = "";
            day = "";
            time = "";
            begintime = "";
            endtime = "";
            category = new Category();
            basicExists = false;
            globalId = 0;
            EventToEdit = new Event();
            //EventToSave = new Event();

            if (!File.Exists(timeTablePath))
            {
                File.Create(timeTablePath);
            }
            if (!File.Exists(categoriesPath))
            {
                File.Create(categoriesPath);
            }
            using (StreamReader sr = new StreamReader(timeTablePath))
            {
                string? line;
                string catName;
                int catId;
                while ((line = sr.ReadLine()) != null)
                {
                    Event e = new Event();
                    e.Name = line;
                    e.Description = sr.ReadLine();
                    e.Day = sr.ReadLine();
                    e.Time = sr.ReadLine();
                    catId = Convert.ToInt32(sr.ReadLine());
                    catName = sr.ReadLine();
                    if (catName == "" || catName == "None")
                    {
                        e.EventCategory = new Category() { Id = catId, CategoryName = "without category" };
                    }
                    else
                    {
                        e.EventCategory = new Category() { Id = catId, CategoryName = catName };
                    }

                    AllEvents.Add(e);
                }
                sr.Close();
            }
            Events[0] = AllEvents.Where(n => n.Day == "Monday").ToObservableCollection();
            Events[1] = AllEvents.Where(n => n.Day == "Tuesday").ToObservableCollection();
            Events[2] = AllEvents.Where(n => n.Day == "Wednesday").ToObservableCollection();
            Events[3] = AllEvents.Where(n => n.Day == "Thursday").ToObservableCollection();
            Events[4] = AllEvents.Where(n => n.Day == "Friday").ToObservableCollection();
            Events[5] = AllEvents.Where(n => n.Day == "Saturday").ToObservableCollection();
            Events[6] = AllEvents.Where(n => n.Day == "Sunday").ToObservableCollection();
            using (StreamReader sr = new StreamReader(categoriesPath))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    Category e = new Category();
                    globalId++;
                    e.Id = Convert.ToInt32(line);
                    e.CategoryName = sr.ReadLine();
                    if (e.CategoryName == "None")
                        basicExists = true;
                    Categories.Add(e);
                    NamesOfCategories.Add(e.CategoryName);
                }
                sr.Close();
            }
            if (!basicExists)
            {
                using (StreamWriter sw = new StreamWriter(categoriesPath, false))
                {
                    sw.WriteLine(0);
                    sw.WriteLine("None");
                    sw.WriteLine(0);
                    sw.WriteLine("Add new category...");
                    foreach (Category cat in Categories)
                    {
                        sw.WriteLine(cat.Id);
                        sw.WriteLine(cat.CategoryName);
                    }
                    sw.Close();
                }
            }

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

        public string BeginTime
        {
            get => begintime;
            set
            {
                if (begintime != value)
                {
                    begintime = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EndTime
        {
            get => endtime;
            set
            {
                if (endtime != value)
                {
                    endtime = value;
                    OnPropertyChanged();
                }
            }
        }

        public Category EventCategory
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
            ((Command)AddEvent).ChangeCanExecute();
            ((Command)AddCategory).ChangeCanExecute();
        }
    }
}
