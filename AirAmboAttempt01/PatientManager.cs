using System;
using System.Collections.Generic;
using System.Text;
using AirAmboAttempt01.Patients;

namespace AirAmboAttempt01
{
    class PatientManager
    {
        #region Props
        private Patient CurrentPatient { get; set; }//This should be private to prevent direct access and manipulation of the patient.

        //public Patient CurrentPatient
        //{
        //    get { return _currentPatient; }
        //    private set { _currentPatient = value; }
        //}
        #endregion

        public bool TryAddPatient(Patient newPatient)
        {
            if(CurrentPatient == null)
            {
                CurrentPatient = newPatient;
                return true;
            }
            return false;
        }

        public bool TryRemovePatient()
        {
            if(CurrentPatient != null)
            {
                CurrentPatient = null;
                return true;
            }
            return false;
        }

        public string GetPatientBio()
        {
            if(CurrentPatient == null)
            {
                return "No Patient Found in Pod";
            }

            string title = "";
            switch (CurrentPatient.Biography.Gender)
            {
                case Gender.Other:
                    title = "Mx.";
                    break;
                case Gender.Male:
                    title = "Mr.";
                    break;
                case Gender.Female:
                    title = "Ms. ";
                    break;
            }
            return $"{title} {CurrentPatient.Biography.LastName}, {CurrentPatient.Biography.FirstName} ({CurrentPatient.Biography.Age})";
        }
        public string GetPatientHead()
        {

            return "";
        }

        
    }
}
