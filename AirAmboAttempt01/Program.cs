using System;
using AirAmboAttempt01.Patients.PatientOrgans;


namespace AirAmboAttempt01.Patients
{
    class Program
    {

        static void Main(string[] args)
        {
            Patient p1 = new Patient();
            
            foreach (Organ organ in p1.Body.Abdomen.GetOrgans())
            {
                Console.WriteLine($"{organ.GetType().Name}: {organ.BloodLossRate}");
            }

            p1.Mind.Consciousness = Consciousness.Responsive;

            Console.WriteLine(p1.Mind.Consciousness);

            Console.WriteLine(p1.Body.Head.AnyBonesBroken());
            Console.WriteLine(p1.Body.Head.PainSeverity);
            Console.WriteLine(p1.Body.Limbs.Arms.LeftArm.AnyBonesBroken());
            Console.WriteLine(p1.Body.Head.Brain.CurrentPressure);
        }
    }
}
