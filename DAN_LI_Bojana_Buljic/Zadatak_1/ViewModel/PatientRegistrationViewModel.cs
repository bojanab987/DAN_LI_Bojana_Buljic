using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Model;
using Zadatak_1.Services;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class PatientRegistrationViewModel:ViewModelBase
    {
        PatientRegistrationView patientReg;
        Serivce service = new Serivce();

        public PatientRegistrationViewModel(PatientRegistrationView view)
        {
            patientReg = view;
            Patient = new vwPatient();
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

        private ICommand register;
        public ICommand Register
        {
            get
            {
                if (register == null)
                {
                    register = new RelayCommand(param => RegisterExecute(), param => CanRegisterExecute());
                }
                return register;
            }
        }  

        public void RegisterExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to register?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool isRegistered = service.AddPatient(Patient);
                    if (isRegistered == true)
                    {
                        MessageBox.Show("Patient is registered.", "Notification", MessageBoxButton.OK);
                        patientReg.Close();
                    }
                    else
                    {
                        MessageBox.Show("Patient cannot be registered.", "Notification", MessageBoxButton.OK);
                        patientReg.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }     
        }

        public bool CanRegisterExecute()
        {
            if (String.IsNullOrEmpty(Patient.Name) || String.IsNullOrEmpty(Patient.Surname) || String.IsNullOrEmpty(Patient.JMBG) ||
               String.IsNullOrEmpty(Patient.Username) || String.IsNullOrEmpty(Patient.Password) || String.IsNullOrEmpty(Patient.HealthInsuranceCardNo))
            {
                return false;
            }
            else
                return true;
        }

        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }

        public void CancelExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel registration?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    patientReg.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelExecute()
        {
            return true;
        }
    }
}
