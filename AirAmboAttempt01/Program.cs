using System;
using AirAmboAttempt01.Patients.PatientBlood;
using AirAmboAttempt01.Patients.PatientOrgans;
using AirAmboAttempt01.Patients.PatientPhysical;

namespace AirAmboAttempt01.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager Pod = new PatientManager();

            Patient newPatient = new Patient();
            Pod.TryAddPatient(new Patient());
            Console.WriteLine(Pod.TEMP_GetPatient().Body.Blood.bloodType.GetBloodType);


            Patient temp = Pod.TEMP_GetPatient();

            Console.WriteLine(temp.Body.Blood.Volume);
            
            Blood blood = new Blood(new BloodType() { ABO = BloodABO.AB, Rhesus = BloodRhesus.Positive});
            Transfuse transfuse = new Transfuse(blood);
            Console.WriteLine($"{typeof(Transfuse).Name} Succeeded: {Pod.PerformIntervention(transfuse)}");
           
        }
    }
}
