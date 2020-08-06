using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class DoctorViewModel : ViewModelBase
    {
        DoctorView doctorView;

        public DoctorViewModel(DoctorView view, tblDoctor doctor)
        {
            doctorView = view;
            Doctor = doctor;
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
    }
}
