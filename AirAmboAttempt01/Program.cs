using System;

namespace AirAmboAttempt01
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Blood b = new Blood();
            Console.WriteLine(b.bloodType);
            b.BloodTransfusion(BloodType.APos,100);

            Console.ReadLine();
        }
    }


}
