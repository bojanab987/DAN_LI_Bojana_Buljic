using System.Windows;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for PatientRegistrationView.xaml
    /// </summary>
    public partial class PatientRegistrationView : Window
    {
        public PatientRegistrationView()
        {
            InitializeComponent();
            this.DataContext = new PatientRegistrationViewModel(this);
        }
    }
}
