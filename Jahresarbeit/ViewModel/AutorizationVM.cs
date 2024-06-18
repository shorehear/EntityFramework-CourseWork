using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace kaidy
{
    public class AutorizationVM : INotifyPropertyChanged
    {
        private KaidyDbContext db;

        public ICommand EnterButton { get; }
        public ICommand CreateAccountButton { get; }


        public event EventHandler SuccessfulAuthorization;
        public event EventHandler CreateAccountButtonClicked;

        private string loginTextBox;
        public string LoginTextBox
        {
            get { return loginTextBox; }
            set
            {
                loginTextBox = value;
                OnPropertyChanged(nameof(LoginTextBox));
            }
        }

        private string passwordTextBox;
        public string PasswordTextBox
        {
            get { return passwordTextBox; }
            set
            {
                passwordTextBox = value;
                OnPropertyChanged(nameof(PasswordTextBox));
            }
        }

        private string messageBlock;
        public string MessageBlock
        {
            get { return messageBlock; }
            set
            {
                messageBlock = value;
                OnPropertyChanged(nameof(MessageBlock));
            }
        }

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public AutorizationVM(KaidyDbContext db)
        {
            this.db = db;
            CreateAccountButton = new RelayCommand(CreateAccount);
            EnterButton = new RelayCommand(Enter);
            if (db.Database.CanConnect()) { MessageBox.Show("База данных доступна"); }
            else { MessageBox.Show("Недоступна"); }
        }

        private void Enter (object parameter)
        {
            if (string.IsNullOrEmpty(LoginTextBox) || string.IsNullOrEmpty(PasswordTextBox))
            {
                MessageBlock = "Пожалуйста, введите логин и пароль.";
                return;
            }

            var user = db.Users.Include(u => u.UserType)
                               .FirstOrDefault(u => u.Login == LoginTextBox && u.Password == PasswordTextBox);

            if (user != null)
            {
                CurrentUser = user;
                MessageBlock = "Авторизация успешна.";
                SuccessfulAuthorization?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBlock = "Неверный логин или пароль.";
            }
        }
        private void CreateAccount(object parameter)
        {
            CreateAccountButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
