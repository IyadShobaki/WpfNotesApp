using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Model
{
    public class Note : INotifyPropertyChanged
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
        private int _notebookId;
        [Indexed]
        public int NotebookId
        {
            get { return _notebookId; }
            set 
            { 
                _notebookId = value;
                OnPropertyChanged("NotebookId");
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            { 
                _title = value;
                OnPropertyChanged("Title");

            }
        }

        private DateTime _createdTime;

        public DateTime CreatedTime
        {
            get { return _createdTime; }
            set 
            { 
                _createdTime = value;
                OnPropertyChanged("CreatedTime");
            }
        }

        private DateTime _updatedTime;

        public DateTime UpdatedTime
        {
            get { return _updatedTime; }
            set 
            { 
                _updatedTime = value;
                OnPropertyChanged("UpdatedTime");
            }
        }

        private string _fileLocation;

        public string FileLocation
        {
            get { return _fileLocation; }
            set
            { 
                _fileLocation = value;
                OnPropertyChanged("FileLocation");
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
