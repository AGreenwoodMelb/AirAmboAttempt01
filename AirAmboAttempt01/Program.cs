using System;


namespace AirAmboAttempt01
{
    class Program
    {

        static void Main(string[] args)
        {
            OrganSystems organs = new OrganSystems(true);

           
            foreach (BodyRegion item in Enum.GetValues(typeof(BodyRegion)))
            {
                if (organs.organs.ContainsKey(item))
                {
                   Organ[] regionOrgans = organs.organs[item];
                    Console.WriteLine(Enum.GetName(typeof(BodyRegion), item));
                    Console.WriteLine("\u2500\u2500\u2500\u2500");
                    foreach (Organ organ in regionOrgans)
                    {
                        Console.WriteLine(organ.GetType().Name);
                    }
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }


}
