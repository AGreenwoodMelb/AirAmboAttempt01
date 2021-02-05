using System;

namespace AirAmboAttempt01
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Blood b = new Blood(0.2f);

            BloodInfusion bi = new BloodInfusion();



            Console.WriteLine($"{bi.Volume}");
           // Console.WriteLine($"Pre-infusion hematocrit: ${b.Hematocrit}");

            //b.BloodTransfusion(BloodGroup.O, BloodRhesus.Negative,500, 0.9f);

            //Console.WriteLine($"Post-infusion hematocrit: ${b.Hematocrit}");

            Console.ReadLine();
        }
    }


}
