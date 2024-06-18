using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace kaidy
{
    public class CreateAccountVM : INotifyPropertyChanged
    {
        private KaidyDbContext db;

        public ICommand AccountCreatedButton { get; set; }

        private string fullName;
        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string login;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private UserType selectedUserType;
        public UserType SelectedUserType
        {
            get => selectedUserType;
            set
            {
                selectedUserType = value;
                OnPropertyChanged(nameof(SelectedUserType));
            }
        }

        private ObservableCollection<UserType> userTypes;
        public ObservableCollection<UserType> UserTypes
        {
            get => userTypes;
            set
            {
                userTypes = value;
                OnPropertyChanged(nameof(UserTypes));
            }
        }

        public CreateAccountVM(KaidyDbContext db)
        {
            this.db = db;
            AccountCreatedButton = new RelayCommand(CreateAnAccount);
            LoadUserTypes();
        }

        private void LoadUserTypes()
        {
            UserTypes = new ObservableCollection<UserType>
            {
                new UserType { UserTypeId = Guid.NewGuid(), TypeName = "Researcher" },
                new UserType { UserTypeId = Guid.NewGuid(), TypeName = "Engineer" },
                new UserType { UserTypeId = Guid.NewGuid(), TypeName = "Programmer" },
                new UserType { UserTypeId = Guid.NewGuid(), TypeName = "Administrator" }
            };
        }

        private void CreateAnAccount(object parameter)
        {
            if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || SelectedUserType == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            var user = new User
            {
                UserID = Guid.NewGuid(),
                FullName = FullName,
                Login = Login,
                Password = Password,
                UserType = SelectedUserType
            };

            db.Users.Add(user);
            try
            {
                db.SaveChanges();
                MessageBox.Show("Аккаунт успешно создан. Пожалуйста, теперь авторизируйтесь.");
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    MessageBox.Show(innerException.Message);
                    innerException = innerException.InnerException;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
