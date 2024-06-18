using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kaidy
{

    public partial class CreateAccount : Window
    {
        private KaidyDbContext db;
        private CreateAccountVM createAccountVM;
        public CreateAccount(KaidyDbContext db)
        {
            InitializeComponent();
            this.db = db;

            createAccountVM = new CreateAccountVM(db);
            DataContext = createAccountVM;
        }
    }
}
