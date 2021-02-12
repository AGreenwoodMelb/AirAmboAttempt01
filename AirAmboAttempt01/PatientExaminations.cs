using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagementSystem.Patients.PatientExaminations
{
    public struct PatientExamResults
    {
        public string tempOutput;
    }

    public enum PatientExamResultsType //May be useful later
    {
        Error,
        BloodPressure
    }

    public interface IPatientExamination
    {
        public virtual bool Examine(Patient patient, out PatientExamResults results)
        {
            throw new NotImplementedException(message: "IPatientExamination::Examine is not implemented");
        }
    }

    public class ExamineBloodVolumeRatio : IPatientExamination
    {
        public bool Examine(Patient patient, out PatientExamResults results)
        {
            results = new PatientExamResults() { tempOutput = (patient.Body.Blood.Volume / patient.Body.Blood._defaultBloodSystemVolume).ToString() };
            return true;
        }
    }

    public class GetRespiratoryRate : IPatientExamination
    {
        public bool Examine(Patient patient, out PatientExamResults results)
        {
            results = new PatientExamResults() { tempOutput = patient.Body.Chest.Lungs.RespiratoryRate.ToString() };
            return true;
        }
    }

    public class GetO2Sats : IPatientExamination
    {
        public bool Examine(Patient patient, out PatientExamResults results)
        {
            results = new PatientExamResults() { tempOutput = patient.Body.Chest.Lungs.OxygenSaturation.ToString() };
            return true;
        }
    }

}
