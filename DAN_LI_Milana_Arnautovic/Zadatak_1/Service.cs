using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
   public class Service
    {
        public List<tblPatient> GetAllPatient()
        {
            try
            {
                using (DAN_LIEntities context = new DAN_LIEntities())
                {
                    List<tblPatient> patients = new List<tblPatient>();
                    patients = context.tblPatients.ToList();
                    return patients;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public List<tblDoctor> GetAllDoctor()
        {
            try
            {
                using (DAN_LIEntities context = new DAN_LIEntities())
                {
                    List<tblDoctor> doctors = new List<tblDoctor>();
                    doctors = context.tblDoctors.ToList();
                    return doctors;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public bool AddPatient(tblPatient patient)
        {
            try
            {
                using (DAN_LIEntities context = new DAN_LIEntities())
                {
                    tblPatient newPatient = new tblPatient
                    {
                        FullName = patient.FullName,
                        JMBG = patient.JMBG,
                        MedicalRecord=patient.MedicalRecord,
                        Pasword = patient.Pasword,
                        Username = patient.Username,
                        DoctorID=patient.DoctorID,
                        SickLeaveID=patient.SickLeaveID
                        
                    };
                    context.tblPatients.Add(newPatient);
                    context.SaveChanges();
                                      
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool AddDoctor(tblDoctor doctor)
        {
            try
            {
                using (DAN_LIEntities context = new DAN_LIEntities())
                {
                    tblDoctor newDoctor = new tblDoctor
                    {
                        DoctorName = doctor.DoctorName,
                        DoctorSurname = doctor.DoctorSurname,
                        JMBG = doctor.JMBG,
                        AccountNumber = doctor.AccountNumber,
                        Pasword = doctor.Pasword,
                        Username = doctor.Username,
                       

                    };
                    context.tblDoctors.Add(newDoctor);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public tblDoctor GetDoctor(string username, string password)
        {
            try
            {
                using (DAN_LIEntities context = new DAN_LIEntities())
                {
                    return context.tblDoctors.Where(x => x.Username == username && x.Pasword == password).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPatient GetPatient(string username, string password)
        {
            try
            {
                using (DAN_LIEntities context = new DAN_LIEntities())
                {
                    return context.tblPatients.Where(x => x.Username == username && x.Pasword == password).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
