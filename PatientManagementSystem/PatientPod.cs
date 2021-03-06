﻿using PatientManagementSystem.Patients;
using PatientManagementSystem.Patients.ExaminationResults;
using PatientManagementSystem.Patients.PatientProceedures;

namespace PatientManagementSystem
{
    public class PatientPod
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

        //LATER: Add the equivalent of IV poles for hagging fluid bags and infusions

        public PatientPod()
        {

        } //LATER: Remove this contrutor once ambulance class is setup

        public PatientPod(object ambulance)
        {
            MaximumWasteVolume = 100f; //UNITY: Replace with Defaults value;
        }//LATER: Replace parameter: ambulance type with appropriate class type
        

        public bool TryAddPatient(Patient newPatient)
        {
            if (CurrentPatient == null)
            {
                CurrentPatient = newPatient;
                PatientResults.Anthropometrics = CurrentPatient.Body.Anthropometrics;
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
            return $"{title} {CurrentPatient.Biography.LastName}, {CurrentPatient.Biography.FirstName}";
        }
        public Patient TEMP_GetPatient()
        {
            return CurrentPatient;
        }

        public bool PerformProceedure(PatientProceedure patientProceedure, out bool Succeeded)
        {
            if (false && TotalWasteProduced >= MaximumWasteVolume) //LATER: (Remove) Just to bypass this check for now
            {
                Succeeded = false;
                return false;
            }

            if (patientProceedure.Perform(CurrentPatient, PatientResults, out Succeeded))
            {
                TotalWasteProduced += patientProceedure.WasteProduced;
                return true;
            }
            return false;
        }

        #region NOT_IMPLEMENTED_YET
        public float TotalWasteProduced { get; private set; }
        public readonly float MaximumWasteVolume = 100f; 
        public void DumpWasteIntoStorage(object Ambulance)
        {
            /*
            float WasteToDump = TotalWasteProduced;
            WasteToDump = (Ambulance.WasteSystem.RemainingWasteSpace >= TotalWasteProduced) ? TotalWasteProduced : Ambulance.WasteSystem.RemainingWasteSpace;
            TotalWasteProduced -= WasteToDump;
            Ambulance.WasteSystem.CurrentWasteContained += WasteToDump;
            */
        }//LATER: Implement once the Ambulance waste system is in production
        #endregion

        //IVPole:
        //HangFluidBag (Fluid IncFluid, TargetIVPole)
        //RemoveFluidBag (TargetIVPole) 
        //InjectFluidBag (Drug, TargetIVPole) //Add drug to hanging IV bag
    }
}
