using System.Windows;
using Zadatak_1.Model;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : Window
    {
        public PatientView(vwPatient patient)
        {
            InitializeComponent();
            this.DataContext = new PatientViewModel(this, patient);
        }
    }
}
