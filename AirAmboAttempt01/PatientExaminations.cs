using System;
using System.Collections.Generic;
using System.Text;

namespace AirAmboAttempt01.Patients.PatientExaminations
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
            throw new NotImplementedException(message: "IIPatientExamination::Examine is not implemented");
        }
    }

    public class TEMP_ExamineBloodVolumeRatio : IPatientExamination
    {
        public bool Examine(Patient patient, out PatientExamResults results)
        {
            results = new PatientExamResults() { tempOutput = patient.BloodVolumeCheck().ToString() };
            return true;
        }
    }

    public class TEMP_GetO2Sats : IPatientExamination
    {
        public bool Examine(Patient patient, out PatientExamResults results)
        {
            results = new PatientExamResults() { tempOutput = patient.Body.Chest.Lungs.OxygenSaturation.ToString() };
            return true;
        }
    }
}
