using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class RegistrationViewModel:ViewModelBase
    {
        RegistrationView regView;

        public RegistrationViewModel(RegistrationView view)
        {
            regView = view;
        }

        private bool isPatient;
        public bool IsPatient
        {
            get
            {
                return isPatient;
            }
            set
            {
                isPatient = value;
                OnPropertyChanged("IsPatient");
            }
        }

        private bool isDoctor;
        public bool IsDoctor
        {
            get
            {
                return isDoctor;
            }
            set
            {
                isDoctor = value;
                OnPropertyChanged("IsDoctor");
            }
        }

        private ICommand next;
        public ICommand Next
        {
            get
            {
                if (next == null)
                {
                    next = new RelayCommand(param => NextExecute(), param => CanNextExecute());
                }
                return next;
            }
        }
        

        public bool CanNextExecute()
        {
            if (IsPatient == true || IsDoctor == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void NextExecute()
        {
            if (IsDoctor)
            {
                DoctorRegistrationView doctorView = new DoctorRegistrationView();
                doctorView.ShowDialog();               
                regView.Close();
            }
            else
            {
                PatientRegistrationView patientView = new PatientRegistrationView();
                patientView.ShowDialog();
                regView.Close();
            }
        }

        private ICommand back;
        public ICommand Back
        {
            get
            {
                if (back == null)
                {
                    back = new RelayCommand(param => BackExecute(), param => CanBackExecute());
                }
                return back;
            }
        }


        public bool CanBackExecute()
        {
            return true;
        }

        public void BackExecute()
        {           
            regView.Close();            
        }
    }
}
