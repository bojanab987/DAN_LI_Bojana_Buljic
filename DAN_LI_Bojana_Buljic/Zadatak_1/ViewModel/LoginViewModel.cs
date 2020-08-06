using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Model;
using Zadatak_1.Services;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        LoginView view;
        Serivce service = new Serivce();

        public LoginViewModel(LoginView loginView)
        {
            view = loginView;
        }

        #region Properties
        public vwPatient Patient { get; set; }
        public vwDoctor Doctor { get; set; }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        #endregion

        #region Commands
        private ICommand logIn;
        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(LogInExecute, CanLogInExecute);
                }
                return logIn;
            }
        }

        /// <summary>
        /// Method checks if username and password are valid
        /// </summary>
        /// <param name="password">User input for password</param>
        public void LogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (service.GetPatient(Username, Password) != null)
            {
                Patient = service.GetPatient(Username, Password);
                PatientView patientView = new PatientView(Patient);
                patientView.ShowDialog();
                view.Close();
            }
            else if (service.GetDoctor(Username, Password) != null)
            {
                Doctor = service.GetDoctor(Username, Password);
                DoctorView doctorView = new DoctorView(Doctor);
                doctorView.ShowDialog();
                view.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password. Please, try again.", "Notification");
            }
        }

        /// <summary>
        /// Method check if login can be executed.
        /// </summary>
        /// <param name="password">User input for password</param>
        /// <returns>True if login can execute, false if not.</returns>
        public bool CanLogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignUpExecute(), param => CanSignUpExecute());
                }
                return signUp;
            }
        }      
        

        public bool CanSignUpExecute()
        {
            return true;
        }

        public void SignUpExecute()
        {
            RegistrationView registrationView = new RegistrationView();
            registrationView.ShowDialog();
        }
        #endregion
    }
}
