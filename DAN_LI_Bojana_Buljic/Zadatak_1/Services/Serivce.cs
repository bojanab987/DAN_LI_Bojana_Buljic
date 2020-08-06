using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Model;

namespace Zadatak_1.Services
{
    /// <summary>
    /// Class with methods to manipulate with CRUD operations for database
    /// </summary>
    class Serivce
    {
        #region Service methods for tblUser
        /// <summary>
        /// Method to retrieve all users from db.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (MedicalCareCenterEntities context = new MedicalCareCenterEntities())
                {
                    return context.tblUsers.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region service Methods for tblPatient
        /// <summary>
        /// Method to find patient in database with forwarded username and password.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Patient, null if not.</returns>
        public vwPatient GetPatient(string username, string password)
        {           
            try
            {
                using (MedicalCareCenterEntities context = new MedicalCareCenterEntities())
                {
                    return context.vwPatients.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Method to retrieve all patients from db.
        /// </summary>
        /// <returns>List of patients.</returns>
        public List<tblPatient> GetAllPatients()
        {
            try
            {
                using (MedicalCareCenterEntities context = new MedicalCareCenterEntities())
                {
                    return context.tblPatients.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// This method adds patient to database.
        /// </summary>
        /// <param name="patient">patient</param>
        /// <returns>True if created, false if not.</returns>
        public bool AddPatient(vwPatient patient)
        {            
            try
            {
                using (MedicalCareCenterEntities context = new MedicalCareCenterEntities())
                {
                    tblUser newUser = new tblUser
                    {
                        Name = patient.Name,
                        Password = patient.Password,
                        Surname = patient.Surname,
                        Username = patient.Username,
                        JMBG = patient.JMBG
                    };
                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    patient.UserId = newUser.UserId;

                    tblPatient newPatient = new tblPatient
                    {
                        UserId = newUser.UserId,
                        DoctorId = null,
                        HealthInsuranceCardNo = patient.HealthInsuranceCardNo
                    };
                    context.tblPatients.Add(newPatient);
                    context.SaveChanges();
                    patient.PatientId = newPatient.PatientId;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        #endregion

        #region service Methods for tblDoctor
        /// <summary>
        /// Method to find doctor in database with forwarded username and password.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Doctor if finded, null if not finded in db</returns>
        public vwDoctor GetDoctor(string username, string password)
        {            
            try
            {
                using (MedicalCareCenterEntities context = new MedicalCareCenterEntities())
                {
                    return context.vwDoctors.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Method to retrieve all doctors from db.
        /// </summary>
        /// <returns>List of doctors.</returns>
        public List<tblDoctor> GetAllDoctors()
        {
            try
            {
                using (MedicalCareCenterEntities context = new MedicalCareCenterEntities())
                {
                    return context.tblDoctors.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// This method adds doctor to database.
        /// </summary>
        /// <param name="doctor">Doctor.</param>
        /// <returns>True if created, false if not.</returns>
        public bool AddDoctor(vwDoctor doctor)
        {
            try
            {
                using (MedicalCareCenterEntities context = new MedicalCareCenterEntities())
                {
                    tblUser newUser = new tblUser
                    {
                        Name = doctor.Name,
                        Password = doctor.Password,
                        Surname = doctor.Surname,
                        Username = doctor.Username,
                        JMBG = doctor.JMBG
                    };
                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    doctor.UserId = newUser.UserId;
                    tblDoctor newDoctor = new tblDoctor
                    {
                        UserId = newUser.UserId,
                        BankAccountNo = doctor.BankAccountNo
                    };
                    context.tblDoctors.Add(newDoctor);
                    context.SaveChanges();
                    doctor.DoctorId = newDoctor.DoctorId;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        #endregion
    }
}
