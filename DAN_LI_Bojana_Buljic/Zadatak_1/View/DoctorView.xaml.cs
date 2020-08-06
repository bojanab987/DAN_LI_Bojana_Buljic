using System.Windows;
using Zadatak_1.Model;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for DoctorView.xaml
    /// </summary>
    public partial class DoctorView : Window
    {
        public DoctorView(vwDoctor doctor)
        {
            InitializeComponent();
            this.DataContext = new DoctorViewModel(this, doctor);
        }
    }
}
