using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Model
{
    public class Notebook : INotifyPropertyChanged
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

        private int _userId;
        [Indexed] // Identify it as a foreign key
        public int UserId
        {
            get { return _userId; }
            set 
            {
                _userId = value;
                OnPropertyChanged("UserId");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
