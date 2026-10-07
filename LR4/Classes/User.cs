using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LR4.Classes
{
    public class User : INotifyPropertyChanged
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Gender { get; set; } = string.Empty;

        string image = string.Empty;

        public string ImageWithPath
        {
            get
            {
                if (!string.IsNullOrEmpty(image) && File.Exists(image))
                {
                    return Path.GetFullPath(image);
                }

                string defaultPath = @"..\..\..\Image\profile.png";
                if (File.Exists(defaultPath))
                {
                    return Path.GetFullPath(defaultPath);
                }

                return null;
            }
            set
            {
                image = value;
                OnPropertyChanged("ImageWithPath");
            }
        }

        public User() { }

        public User(string firstName, string lastName, DateTime birthday, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Gender = gender;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Birthday + " " + Gender;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}