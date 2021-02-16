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

            PatientExamResults tempResults = Pod.PatientResults;

            Pod.PerformExamination(new ExamineBrainCT());
            Pod.PerformExamination(new ExamineOxygenSaturation());
            Pod.PerformExamination(new ExamineRespiratoryRate());
            Pod.PerformExamination(new ExamineHeartECG());
            Pod.PerformExamination(new ExamineXRay(BodyRegion.Chest));
            Pod.PerformExamination(new ExamineBloodType());
            Pod.PerformExamination(new ExamineOrgan(OrganName.Reproductives));

            Console.WriteLine(Pod.PatientResults.Blood.BloodType.ToString());
            Console.ReadLine();
        }
    }
}
