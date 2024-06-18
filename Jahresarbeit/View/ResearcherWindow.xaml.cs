
using Jahresarbeit.ViewModel;
using System.Windows;

namespace kaidy
{

    public partial class ResearcherWindow : Window
    {
        private ResearcherVM researcherVM;
        public ResearcherWindow(KaidyDbContext db)
        {
            InitializeComponent();

            researcherVM = new ResearcherVM(db);
            DataContext = researcherVM;
        }
    }
}
