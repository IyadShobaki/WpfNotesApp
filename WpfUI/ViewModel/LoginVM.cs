using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Model;
using WpfUI.ViewModel.Commands;

namespace WpfUI.ViewModel
{
    public class LoginVM
    {
        private User _user;

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public RegisterCommand RegisterCommand { get; set; }

        public LoginCommand LoginCommand { get; set; }

        public LoginVM()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }
    }
}
