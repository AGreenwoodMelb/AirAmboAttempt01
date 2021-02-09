using System;
using AirAmboAttempt01.Patients.PatientBlood;
using AirAmboAttempt01.Patients.PatientOrgans;
using AirAmboAttempt01.Patients.PatientPhysical;
using AirAmboAttempt01.Patients.PatientDrugs;
using AirAmboAttempt01.Patients.PatientInterventions;

namespace AirAmboAttempt01.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager Pod = new PatientManager();
            
            Pod.TryAddPatient(new Patient());
            //Console.WriteLine(Pod.TEMP_GetPatient().Body.Blood.bloodType.GetBloodType);


            Patient temp = Pod.TEMP_GetPatient();
            Console.WriteLine(temp.Body.Blood.DrugsProfile.IsStimulant);
            IPatientIntervention intervention = new AdministerDrug(new DrugStim1());
            Pod.PerformIntervention(intervention);
            Console.WriteLine(temp.Body.Blood.DrugsProfile.IsStimulant);

            Pod.PerformIntervention(new AdministerDrug(new DrugDetoxer()));
            Console.WriteLine(temp.Body.Blood.DrugsProfile.IsStimulant);
        }
    }
}
