using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaidy
{
    public class ResearcherVM : INotifyPropertyChanged
    {
        private ObservableCollection<DataAnalysis> dataAnalysisList;
        public ObservableCollection<DataAnalysis> DataAnalysisList
        {
            get { return dataAnalysisList; }
            set
            {
                dataAnalysisList = value;
                OnPropertyChanged(nameof(DataAnalysisList));
            }
        }
        public ResearcherVM(KaidyDbContext db) 
        {
            LoadDataAnalysis();
        }

        private void LoadDataAnalysis()
        {
            using (var db = new KaidyDbContext())
            {
                DataAnalysisList = new ObservableCollection<DataAnalysis>(db.DataAnalysis.ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
