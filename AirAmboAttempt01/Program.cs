using System;
using AirAmboAttempt01.Patients;


namespace AirAmboAttempt01
{
    class Program
    {

        static void Main(string[] args)
        {
           Patient p1 = new Patient();
            Organ[] organs = p1.Body.Abdomen.GetOrgans();
            foreach (Organ organ in organs)
            {
                Console.WriteLine(organ.GetType().Name);
            }
        }
    }
}
