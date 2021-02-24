using System;

namespace PatientManagementSystem.Patients.PatientInfection
{
    public enum InfectionSeverity
    {
        None,
        Mild,
        Moderate,
        Severe,
        Extreme
    }
    public enum InfectionType
    {
        None,
        Bacterial,
        Viral,
        Prion,
        Other
    }
    public enum InfectionResistance
    {
        None,
        Susceptible,
        Stardard,
        Resistant,
        Immune
    }
    public struct Infection
    {
        public InfectionType infectionType;
        public InfectionSeverity infectionSeverity;
        public InfectionResistance infectionResistance; //Should this value automatically increase itself?

        public void IncreaseInfection()
        {
            if (infectionSeverity != InfectionSeverity.Extreme)
                infectionSeverity += 1;
        }

        public void DecreaseInfection()
        {
            if (infectionSeverity != InfectionSeverity.None)
                infectionSeverity -= 1;
            else
            {
                CureInfection();
            }
        }

        public void CureInfection()
        {
            infectionType = InfectionType.None;
            infectionResistance = InfectionResistance.None;
        }
    }

    public class Infections
    {
        public HeadContainer Head { get; set; }

        public ChestContainer Chest { get; set; }

        public AbdomenContainer Abdomen { get; set; }

        public Infection StrongestInfection()
        {
            Infection strongestInfection = new Infection();

            //Not perfect but better than what I was doing
            Infection[] infections = GetInfectionsArray();

            Infection strongest = new Infection();
            foreach (Infection infection in infections)
            {
                if (infection.infectionSeverity > strongest.infectionSeverity)
                    strongest = infection;
            }

            return strongestInfection;
        }//This should find the highest level of infection severity and return an Infection object so that values can be calculated off the severity and type

        public bool TreatInfection(InfectionType infectionType)
        {
            Infection[] infections = GetInfectionsArray();

            foreach (Infection infection in infections)
            {
                if (infection.infectionType == infectionType)
                {
                    infection.DecreaseInfection();
                }
            }
            return true;
        }//Why return a bool???
        private Infection[] GetInfectionsArray()
        {
            return new Infection[]
            {
                //Head
                Head.Surface,
                Head.Brain,

                //Chest
                Chest.Surface,
                Chest.Heart,
                Chest.LeftLung,
                Chest.RightLung,

                //Abdomen
                Abdomen.Surface,
                Abdomen.GastrointestinalTract,
                Abdomen.Liver,
                Abdomen.Spleen,
                Abdomen.Pancreas,
                Abdomen.LeftKidney,
                Abdomen.RightKidney,
                Abdomen.Bladder,
                Abdomen.Reproductives,
            };
        }//Imperfect solution...

        #region ContainerClasses
        public abstract class DefaultContainer
        {
            public Infection Surface;
        }
        public class HeadContainer : DefaultContainer
        {
            public Infection Brain;
        }
        public class ChestContainer : DefaultContainer
        {
            public Infection Heart;
            public Infection LeftLung;
            public Infection RightLung;
        }
        public class AbdomenContainer : DefaultContainer
        {
            public Infection GastrointestinalTract;
            public Infection Liver;
            public Infection Spleen;
            public Infection Pancreas;
            public Infection LeftKidney;
            public Infection RightKidney;
            public Infection Bladder;
            public Infection Reproductives;
        }
        #endregion
    }



}

