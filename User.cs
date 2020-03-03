using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aflevering1WPF
{
    class User : INotifyPropertyChanged
    {

        public User(string name, int age, int id, int score) { Name = name; Age = age; Id = id; Score = score;}

        private string name;
        public string Name
        {
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
            get { return name; }
        }
        private int age;
        public int Age
        {
            set
            {
                age = value;
                NotifyPropertyChanged(nameof(Age));
            }
            get { return age; }
        }

        private int id;

        public int Id
        {
        set
            {
                id = value;
                NotifyPropertyChanged(nameof(id));
            }
            get { return id; }
        }


        private int score;
        public int Score
        {
            set
            {
                score = value;
                NotifyPropertyChanged(nameof(Score));
            }
            get { return score; }
        }

        public string ListBoxToString
        {
            get
            {
                return Name + " " + Id;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
