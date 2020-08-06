using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class PatientViewModel:ViewModelBase
    {
        PatientView patientView;

        public PatientViewModel(PatientView view, vwPatient patient)
        {
            patientView = view;
            Patient = patient;
        }

        private vwPatient patient;
        public vwPatient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }
    }
}
