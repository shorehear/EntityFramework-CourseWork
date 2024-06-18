using System;
using System.Windows;

namespace kaidy
{
    public partial class Authorization : Window
    {
        private AutorizationVM autorizationVM;
        private KaidyDbContext db;

        public Authorization()
        {
            InitializeComponent();

            db = new KaidyDbContext();
            db.Database.EnsureCreated();


            autorizationVM = new AutorizationVM(db);
            DataContext = autorizationVM;

            autorizationVM.SuccessfulAuthorization += EnterButtonClicked;
            autorizationVM.CreateAccountButtonClicked += CreateAccountButtonClicked;
        }

        private void EnterButtonClicked(object sender, EventArgs e)
        {
            var userType = autorizationVM.CurrentUser.UserType.TypeName;

            switch (userType)
            {
                case "Researcher":
                    MessageBox.Show("Добро пожаловать, Исследователь!");
                    ResearcherWindow researcherWindow = new ResearcherWindow(db);
                    researcherWindow.Show();
                    break;
                case "Engineer":
                    // Действия для инженера
                    MessageBox.Show("Добро пожаловать, Инженер!");
                    break;
                case "Programmer":
                    // Действия для программиста
                    MessageBox.Show("Добро пожаловать, Программист!");
                    break;
                case "Administrator":
                    // Действия для администратора
                    MessageBox.Show("Добро пожаловать, Администратор!");
                    break;
                default:
                    MessageBox.Show("Неизвестный тип пользователя.");
                    break;
            }
        }

        private void CreateAccountButtonClicked(object sender, EventArgs e)
        {
            CreateAccount createAccountWindow = new CreateAccount(db);
            createAccountWindow.Show();
        }
    }
}
