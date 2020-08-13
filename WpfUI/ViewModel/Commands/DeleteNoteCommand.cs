using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUI.Model;

namespace WpfUI.ViewModel.Commands
{
    public class DeleteNoteCommand : ICommand
    {
        public NotesVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public DeleteNoteCommand(NotesVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var note = parameter as Note;

            if (note != null)
            {
                VM.DeleteNote(note);
            }
        }
    }
}
