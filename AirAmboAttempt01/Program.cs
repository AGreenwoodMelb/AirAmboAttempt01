using System;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientOrgans;
using PatientManagementSystem.Patients.PatientPhysical;
using PatientManagementSystem.Patients.PatientDrugs;
using PatientManagementSystem.Patients.PatientInterventions;
using PatientManagementSystem.Patients.PatientExaminations;

namespace PatientManagementSystem.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager Pod = new PatientManager();
            Pod.TryAddPatient(new Patient());
            Patient temp = Pod.TEMP_GetPatient();


            PatientExamResults meow = new PatientExamResults();

            Console.WriteLine(Pod.PerformIntervention(new InsertArtificalAirway(ArtificialAirway.FaceMask)));


            //Pod.PerformExamination(new TEMP_GetO2Sats(), ref meow);
            //Console.WriteLine(meow.tempOutput);
            //Pod.PerformExamination(new TEMP_GetRespiratoryRate(), ref meow);
            //Console.WriteLine(meow.tempOutput);
            //Pod.PerformExamination(new TEMP_ExamineBloodVolumeRatio(),ref meow);
            //Console.WriteLine(meow.tempOutput);
        }
    }
}
