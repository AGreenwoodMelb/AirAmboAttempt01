using System;
using System.Collections.Generic;
using System.Text;
using AirAmboAttempt01.Patients;

namespace AirAmboAttempt01
{
    public class PatientManager
    {
        #region Props
        protected Patient CurrentPatient { get; private set; }//This should be protected to prevent direct access and manipulation of the patient.

        //public Patient CurrentPatient
        //{
        //    get { return _currentPatient; }
        //    private set { _currentPatient = value; }
        //}
        #endregion

        public bool TryAddPatient(Patient newPatient)
        {
            if (CurrentPatient == null)
            {
                CurrentPatient = newPatient;
                return true;
            }
            return false;
        }

        public bool TryRemovePatient()
        {
            if (CurrentPatient != null)
            {
                CurrentPatient = null;
                return true;
            }
            return false;
        }

        public string GetPatientBio()
        {
            if (CurrentPatient == null)
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

        public Patient TEMP_GetPatient()
        {
            return CurrentPatient;
        }

        public bool PerformIntervention(IIntervention i)
        {
            return i.Intervene(CurrentPatient);
        }
    }

    public interface IIntervention
    {
        public virtual bool Intervene(Patient target) { return false; }
        
    }

    public class Transfuse : IIntervention
    {
        private Fluid _fluid;
        public Transfuse(Fluid incFluid)
        {
            _fluid = incFluid;
        }

        public bool Intervene(Patient target)
        {
            return target.Body.Blood.Transfuse(_fluid);
        }
    }

    public class Tester : IIntervention
    {

    }
}
