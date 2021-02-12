using AirAmboAttempt01.Patients;
using AirAmboAttempt01.Patients.PatientInterventions;
using AirAmboAttempt01.Patients.PatientExaminations;

namespace AirAmboAttempt01
{
    public class PatientManager
    {
        #region Props
        protected Patient CurrentPatient { get; private set; }//This should be protected to prevent direct access and manipulation of the patient.
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

#if DEBUG
        public Patient TEMP_GetPatient()
        {
            return CurrentPatient;
        }
#endif

        public bool PerformIntervention(IPatientIntervention patientIntervention)
        {
            return patientIntervention.Intervene(CurrentPatient);
        }

        public bool PerformExamination(IPatientExamination patientExamination)
        {
            patientExamination.Examine(CurrentPatient, out PatientExamResults results);

            //HandleResults(); //Somehow...
            System.Console.WriteLine(results.tempOutput);
            return true;
        }
    }


}
