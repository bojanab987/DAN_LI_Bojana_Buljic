using System.Windows;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for DoctorRegistrationView.xaml
    /// </summary>
    public partial class DoctorRegistrationView : Window
    {
        public DoctorRegistrationView()
        {
            InitializeComponent();
            this.DataContext = new DoctorRegistrationViewModel(this);
        }
    }
}
