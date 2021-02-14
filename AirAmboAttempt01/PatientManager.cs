using PatientManagementSystem.Patients;
using PatientManagementSystem.Patients.PatientInterventions;
using PatientManagementSystem.Patients.PatientExaminations;

namespace PatientManagementSystem
{
    public class PatientManager
    {
        #region Props
        protected Patient CurrentPatient { get; private set; }//This should be protected to prevent direct access and manipulation of the patient.

        private PatientExamResults _patientResults;
        public PatientExamResults PatientResults //Accessable by the GUI to display Patient Results and information
        {
            get { return _patientResults; }
            private set { _patientResults = value; }
        }
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

        public bool PerformIntervention(IPatientIntervention patientIntervention)
        {
            return patientIntervention.Intervene(CurrentPatient);
        }

        public bool PerformExamination(IPatientExamination patientExamination)
        {
            patientExamination.Examine(CurrentPatient, ref _patientResults);
            return true;
        }
    }

}
