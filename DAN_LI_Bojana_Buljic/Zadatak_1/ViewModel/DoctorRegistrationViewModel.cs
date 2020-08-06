using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Model;
using Zadatak_1.Services;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class DoctorRegistrationViewModel:ViewModelBase
    {
        DoctorRegistrationView docReg;
        Serivce service = new Serivce();

        public DoctorRegistrationViewModel(DoctorRegistrationView docView)
        {
            docReg = docView;
            Doctor = new vwDoctor();
        }

        private vwDoctor doctor;
        public vwDoctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged("Doctor");
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
                        bool isRegistered = service.AddDoctor(Doctor);
                        if (isRegistered == true)
                        {
                            MessageBox.Show("Doctor is registered.", "Notification", MessageBoxButton.OK);
                            docReg.Close();
                        }
                        else
                        {
                            MessageBox.Show("Doctor cannot be registered.", "Notification", MessageBoxButton.OK);
                            docReg.Close();
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
            if (String.IsNullOrEmpty(Doctor.Name) || String.IsNullOrEmpty(Doctor.Surname) || String.IsNullOrEmpty(Doctor.JMBG) ||
              String.IsNullOrEmpty(Doctor.Username) || String.IsNullOrEmpty(Doctor.Password) || String.IsNullOrEmpty(Doctor.BankAccountNo))
            {
                return false;
            }
            else
            {
                return true;
            }
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
                    docReg.Close();
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
