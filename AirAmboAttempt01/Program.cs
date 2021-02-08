using System;
using AirAmboAttempt01.Patients.PatientOrgans;


namespace AirAmboAttempt01.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager Pod = new PatientManager();
            Pod.TryAddPatient(new Patient());

            Patient temp = Pod.TEMP_GetPatient();

            Console.WriteLine(temp.Body.Blood.Volume);


            Blood blood = new Blood();
            Transfuse transfuse = new Transfuse(blood);
            Console.WriteLine($"{typeof(Transfuse).Name} Succeeded: {Pod.PerformIntervention(transfuse)}");
            Console.WriteLine(temp.Body.Blood.Volume);

            Console.WriteLine($"{typeof(Tester).Name} Succeeded: {Pod.PerformIntervention(new Tester())}");
        }
    }
}
