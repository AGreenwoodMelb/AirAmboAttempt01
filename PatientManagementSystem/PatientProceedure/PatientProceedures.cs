using PatientManagementSystem.Patients.ExaminationResults;
using PatientManagementSystem.Patients.PatientDefaults;
using PatientManagementSystem.Patients.PatientInfection;

namespace PatientManagementSystem.Patients.PatientProceedures
{
    public abstract class PatientProceedure
    {
        public float WasteProduced { get; protected set; }
        public abstract bool Perform(Patient patient, PatientExamResults results, out bool Succeeded);
    }
    public class PerformLumbarPuncture : PatientProceedure
    {
        //Lumbar Puncture. Pain and greater risk of causing CNS infection, High chance to fail
        public override bool Perform(Patient patient, PatientExamResults results, out bool Succeeded)
        {
            Succeeded = false;

            /*
            if(reasonYouCantPerform)
                return false;
            */

            WasteProduced = DefaultWasteProduction.PerformLumbarPuncture;

            if (patient.MagicRandomSeed > DefaultPlayerStatsTEMP.PerformLumbarPunctureSuccess)
            {
                patient.Flags.hasCSFSample = true;
                Succeeded = true;
                ExamineCSF examineCSF = new ExamineCSF();
                examineCSF.Examine(patient, results);
                WasteProduced += examineCSF.WasteProduced;
            }

            if (patient.MagicRandomSeed > DefaultInfectionValues.PerformLumbarPuncture)
            {
                patient.Body.Infections.Head.Brain.Infect(new Infection());
            }
            return true;
        }
    } //This should go back to the Intervene class and an appropriate virtual method be used
}
