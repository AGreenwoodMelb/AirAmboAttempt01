using System;
using AirAmboAttempt01.Patients;


namespace AirAmboAttempt01
{
    class Program
    {

        static void Main(string[] args)
        {
           Patient p1 = new Patient();

            Console.WriteLine(p1.Body.Abdomen.Reproductives.GetType().Name);
        }
    }


}
