using System;


namespace AirAmboAttempt01
{
    class Program
    {

        static void Main(string[] args)
        {
            Organs.Lung lung = new Organs.Lung(true);

            Console.WriteLine($"{ lung.CurrentInfection.infectionSeverity.ToString()}");
            lung.CurrentInfection.IncreaseInfection();
            Console.WriteLine($"{ lung.CurrentInfection.infectionSeverity.ToString()}");
            Console.ReadLine();

        }
    }


}
