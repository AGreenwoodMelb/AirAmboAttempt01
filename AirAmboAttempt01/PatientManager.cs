using PatientManagementSystem.Patients;
using PatientManagementSystem.Patients.PatientInterventions;
using PatientManagementSystem.Patients.PatientExaminations;
using PatientManagementSystem.Patients.ExaminationResults;

namespace PatientManagementSystem
{
    public class PatientManager
    {
        #region Props
        private Patient CurrentPatient { get; set; }//This should be private to prevent direct access and manipulation of the patient.

        private PatientExamResults _patientResults = new PatientExamResults();
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

        public bool PerformIntervention(PatientIntervention patientIntervention)
        {
            //TotalWasteProduced += patientIntervention.WasteProduced //FOR LATER
            return patientIntervention.Intervene(CurrentPatient);
        }

        public bool PerformExamination(PatientExamination patientExamination)
        {
            //TotalWasteProduced += patientIntervention.WasteProduced //FOR LATER
            patientExamination.Examine(CurrentPatient, _patientResults);
            return true;
        }

        #region NOT_IMPLEMENTED_YET
        public float TotalWasteProduced { get; private set; }
        public void DumpWasteIntoStorage(object TEMP_wasteStorageObj)
        {
            TotalWasteProduced = 0; //Temp
            //TEMP_wasteStorageObj.WasteContained += WasteProduced;
            //Dump to WasteStorage object
        }//TODO: Implement once the waste system is in production
        #endregion
    }

}
