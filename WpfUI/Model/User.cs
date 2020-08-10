using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Model
{
    public class User : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return _id; }
            set 
            { 
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _firstName;
        [MaxLength(50)]
        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        [MaxLength(50)]
        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set 
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                OnPropertyChanged("Password");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
