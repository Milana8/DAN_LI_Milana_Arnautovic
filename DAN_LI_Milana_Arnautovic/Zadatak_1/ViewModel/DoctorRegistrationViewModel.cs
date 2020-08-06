using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class DoctorRegistrationViewModel: ViewModelBase
    {


        DoctorRegistrationView addDoctorView;
        Service service = new Service();

        #region Constructor

        public DoctorRegistrationViewModel(DoctorRegistrationView addOpen)
        {
            addDoctorView = addOpen;
            Doctor = new tblDoctor();
            DoctorList = service.GetAllDoctor().ToList();
        }

        
        #endregion

        #region Properties
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
                OnPropertyChanged("DoctorList");
            }
        }


        private bool isUpdateDoctor;
        public bool IsUpdateDoctor
        {
            get
            {
                return isUpdateDoctor;
            }
            set
            {
                isUpdateDoctor = value;
            }
        }
        #endregion

        #region Commands

        private ICommand save;
        /// <summary>
        /// Save command
        /// </summary>
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        /// <summary>
        /// Save execute
        /// </summary>
        private void SaveExecute()
        {

           
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isUpdateDoctor = service.AddDoctor(Doctor);
                        if (isUpdateDoctor == true)
                        {
                            MessageBox.Show("Doctor is registered.", "Notification", MessageBoxButton.OK);
                        addDoctorView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Doctor is not registered.", "Notification", MessageBoxButton.OK);
                        addDoctorView.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            /// <summary>
            /// Can save
            /// </summary>
            /// <returns></returns>
            private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(doctor.DoctorName) ||
                String.IsNullOrEmpty(doctor.DoctorSurname) ||
                String.IsNullOrEmpty(doctor.JMBG) ||
                String.IsNullOrEmpty(doctor.AccountNumber) ||
                String.IsNullOrEmpty(doctor.Username) ||
                String.IsNullOrEmpty(doctor.Pasword) 

                )
            {
                return false;
            }
            else
                return true;
        }

        private ICommand cancel;
        /// <summary>
        ///Cancel command 
        /// </summary>
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

        /// <summary>
        /// Cancel execute
        /// </summary>
        private void CancelExecute()
        {
            try
            {
                addDoctorView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}