using System;

namespace AirAmboAttempt01
{
    class Program
    {

        static void Main(string[] args)
        {
            BloodSystem bs = new BloodSystem();

            Console.WriteLine($"{bs.bloodType.ABO}{ bs.bloodType.Rhesus }");
            Console.WriteLine(bs.Volume);

            bs.Transfuse(new Blood());
            Console.WriteLine(bs.Volume);

            bs.Transfuse(new Drug());
            Console.WriteLine(bs.Volume);


            Console.ReadLine();
        }
    }


}
