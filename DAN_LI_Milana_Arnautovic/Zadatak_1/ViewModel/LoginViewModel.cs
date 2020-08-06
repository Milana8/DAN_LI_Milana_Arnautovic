using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        LoginView view;
        Service service = new Service();

        #region Constructors

        public LoginViewModel(LoginView view)
        {
            this.view = view;
            patient = new tblPatient();
            doctor = new tblDoctor();
            PatientList = service.GetAllPatient().ToList();
            DoctorList = service.GetAllDoctor().ToList();

        }
        #endregion

        #region Property

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
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

        private List<tblPatient> patientList;
        public List<tblPatient> PatientList
        {
            get
            {
                return patientList;
            }
            set
            {
                patientList = value;
                OnPropertyChanged("PatientList");
            }
        }

        private tblPatient patient;
        public tblPatient Patient
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

        private List<tblDoctor> doctorList;
        public List<tblDoctor> DoctorList
        {
            get
            {
                return doctorList;
            }
            set
            {
                doctorList = value;
                OnPropertyChanged("PatientList");
            }
        }

        private tblDoctor doctor;
        public tblDoctor Doctor
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

        #endregion

        #region Commands
        private ICommand login;
        /// <summary>
        /// Command login
        /// </summary>
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(LoginExecute);
                }
                return login;
            }
            set { login = value; }
        }
        /// <summary>
        /// Method for checking username and password
        /// </summary>
        /// <param name="o"></param>
        private void LoginExecute(object o)
        {
            try
            {
                string password = (o as PasswordBox).Password;
                tblDoctor doctor = service.GetDoctor(UserName, Password);
                if (doctor != null)
                {

                    DoctorView doctorView = new DoctorView();
                    doctorView.ShowDialog();
                    view.Close();
                    return;
                }
                tblPatient patient = service.GetPatient(UserName, Password);
                if (patient != null)
                {

                    PatientView patientView = new PatientView();
                    patientView.Show();
                    view.Close();
                    return;
                }

                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ICommand addCommandDoctor;
        /// <summary>
        /// Add Doctor command
        /// </summary>
        public ICommand AddCommandDoctor
        {
            get
            {
                if (addCommandDoctor == null)
                {
                    addCommandDoctor = new RelayCommand(param => AddDoctorCommandExecute(), param => CanAddDoctorCommandExecute());
                }
                return addCommandDoctor;
            }
        }

        /// <summary>
        /// Add doctor execute
        /// </summary>
        private void AddDoctorCommandExecute()
        {
            try
            {
                DoctorRegistrationView addDoctorView = new DoctorRegistrationView();
                addDoctorView.ShowDialog();
                if ((addDoctorView.DataContext as DoctorRegistrationViewModel).IsUpdateDoctor == true)
                {
                    DoctorList = service.GetAllDoctor().ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Can add doctor
        /// </summary>
        /// <returns></returns>
        private bool CanAddDoctorCommandExecute()
        {
            return true;
        }

        //private ICommand addPatientCommand;
        ///// <summary>
        ///// Add patient command
        ///// </summary>
        //public ICommand AddPatientCommand
        //{
        //    get
        //    {
        //        if (addPatientCommand == null)
        //        {
        //            addPatientCommand = new RelayCommand(param => AddPatientCommandExecute(), param => CanAddPatientCommandExecute());
        //        }
        //        return addPatientCommand;
        //    }
        //}

        ///// <summary>
        ///// Add patient execute
        ///// </summary>
        //private void AddPatientCommandExecute()
        //{
        //    try
        //    {
        //        PatientRegistrationView addPatientView = new PatientRegistrationView();
        //        addPatientView.ShowDialog();
        //        if ((addPatientView.DataContext as PatientRegistrationViewModel).IsUpdatePatient == true)
        //        {
        //            PatientList = service.GetAllPatient().ToList();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        ///// <summary>
        ///// Can add patient
        ///// </summary>
        ///// <returns></returns>
        //private bool CanAddPatientCommandExecute()
        //{
        //    return true;
        //}




        #endregion






    }
}

