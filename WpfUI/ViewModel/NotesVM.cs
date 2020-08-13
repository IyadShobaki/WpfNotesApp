using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Model;
using WpfUI.ViewModel.Commands;

namespace WpfUI.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        private bool isEditing;

        public bool IsEditing
        {
            get { return isEditing; }
            set 
            {
                isEditing = value;
                OnPropertyChanged("IsEditing");
            }
        }

        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook _selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return _selectedNotebook; }
            set
            {
                _selectedNotebook = value;
                OnPropertyChanged("SelectedNotebook");
                if (_selectedNotebook != null)
                {
                    ReadNotes();
                }
               
            }
        }

        private Note _selectedNote;

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set 
            { 
                _selectedNote = value;
                SelectedNoteChanged(this, new EventArgs());
                OnPropertyChanged("SelectedNote");
            }
        }



        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }

        public BeginEditCommand BeginEditCommand { get; set; }

        public HasEditedCommand HasEditedCommand { get; set; }

        public DeleteNotebookCommand DeleteNotebookCommand { get; set; }
        public DeleteNoteCommand DeleteNoteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler SelectedNoteChanged;
        public NotesVM()
        {
            IsEditing = false;

            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);

            BeginEditCommand = new BeginEditCommand(this);
            HasEditedCommand = new HasEditedCommand(this);

            DeleteNotebookCommand = new DeleteNotebookCommand(this);
            DeleteNoteCommand = new DeleteNoteCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            ReadNotebooks();
            ReadNotes();
        }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New notebook",
                UserId = int.Parse(App.UserId)
            };

            DatabaseHelper.Insert(newNotebook);

            ReadNotebooks();
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title = "New note"
            };

            DatabaseHelper.Insert(newNote);

            ReadNotes();
        }

        public async void DeleteNotebook(Notebook notebook)
        {
            try
            {
                DatabaseHelper.Delete(notebook);
                ReadNotebooks();
            }
            catch (Exception ex)
            {
           
            }
        }

        public async void DeleteNote(Note note)
        {
            try
            {
                DatabaseHelper.Delete(note);
                ReadNotes();
            }
            catch (Exception ex)
            {

            }
        }

        public void ReadNotebooks()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<Notebook>();

                var notebooks = conn.Table<Notebook>().ToList();

                Notebooks.Clear();
                foreach (var notebook in notebooks)
                {
                    Notebooks.Add(notebook);
                }
            }
        }

        public void ReadNotes()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                if (SelectedNotebook != null)
                {
                    var notes = conn.Table<Note>()
                                .Where(n => n.NotebookId == SelectedNotebook.Id)
                                .ToList();

                    Notes.Clear();
                    foreach (var note in notes)
                    {
                        Notes.Add(note);
                    }
                }
                
            }
        }

        public void StartEditing()
        {
            IsEditing = true;

        }
        public void HasRenamed(Notebook notebook)
        {
            if (notebook != null)
            {
                DatabaseHelper.Update(notebook);
                IsEditing = false;
                ReadNotebooks();
            }
        }

        public void UpdateSelectedNote()
        {
            DatabaseHelper.Update(SelectedNote);
        }
    }
}
