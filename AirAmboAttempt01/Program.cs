using System;
using AirAmboAttempt01.Patients.PatientBlood;
using AirAmboAttempt01.Patients.PatientOrgans;
using AirAmboAttempt01.Patients.PatientPhysical;
using AirAmboAttempt01.Patients.PatientDrugs;
using AirAmboAttempt01.Patients.PatientInterventions;
using AirAmboAttempt01.Patients.PatientExaminations;

namespace AirAmboAttempt01.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager Pod = new PatientManager();
            Pod.TryAddPatient(new Patient());
            Patient temp = Pod.TEMP_GetPatient();

            
            IPatientIntervention intervention = new InsertIV(IVTargetLocation.ArmLeft);

            Console.WriteLine(Pod.PerformIntervention(intervention));
            Console.WriteLine(Pod.PerformIntervention(intervention));

            intervention = new RemoveIV(IVTargetLocation.ArmRight);

            Console.WriteLine(Pod.PerformIntervention(intervention));

            intervention = new RemoveIV(IVTargetLocation.ArmLeft);
            Console.WriteLine(Pod.PerformIntervention(intervention));
        }
    }
}
