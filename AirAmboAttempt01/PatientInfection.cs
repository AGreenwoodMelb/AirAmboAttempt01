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
        public InfectionType pathogenType;
        public InfectionSeverity Severity;
        public InfectionResistance TreatmentResistance; //Should this value automatically increase itself?

        public void IncreaseInfection()
        {
            if (Severity != InfectionSeverity.Extreme)
                Severity += 1;
        }

        public void DecreaseInfection()
        {
            if (Severity != InfectionSeverity.None)
                Severity -= 1;
            else
            {
                CureInfection();
            }
        }

        public void CureInfection()
        {
            pathogenType = InfectionType.None;
            TreatmentResistance = InfectionResistance.None;
        }
    }

    public class Infections
    {
        #region Props
        public HeadContainer Head { get; set; }

        public ChestContainer Chest { get; set; }

        public AbdomenContainer Abdomen { get; set; }
        #endregion

        #region Constructors
        public Infections()
        {

        }//Default Constructor

        public Infections(Infections infections)
        {
            Head = infections.Head;
            Chest = infections.Chest;
            Abdomen = infections.Abdomen;
        } //Copy Constructor?
        #endregion


        public Infection GetStrongestInfection()
        {
            Infection result = new Infection();
            foreach (Infection infection in GetInfectionsArray())
            {
                if (infection.Severity > result.Severity)
                    result = infection;
            }
            return result;
        }//This should find the highest level of infection severity and return an Infection object so that values can be calculated off the severity and type
        public Infection GetStrongestInfectionHead()
        {
            Infection result = new Infection();
            foreach (Infection infection in Head.GetInfections())
            {
                if (infection.Severity > result.Severity)
                    result = infection;
            }
            return result;
        } //I think this will be useful for the ExamineBrainCT PatientExamination
        public Infection GetStrongestInfectionChest()
        {
            Infection result = new Infection();
            foreach (Infection infection in Chest.GetInfections())
            {
                if (infection.Severity > result.Severity)
                    result = infection;
            }
            return result;
        }
        public Infection GetStrongestInfectionAbdomen()
        {
            Infection result = new Infection();
            foreach (Infection infection in Abdomen.GetInfections())
            {
                if (infection.Severity > result.Severity)
                    result = infection;
            }
            return result;
        }
        public bool TreatInfection(InfectionType infectionType)
        {
            Infection[] infections = GetInfectionsArray();

            foreach (Infection infection in infections)
            {
                if (infection.pathogenType == infectionType)
                {
                    infection.DecreaseInfection();
                }
            }
            return true;
        }//Why return a bool???
        private Infection[] GetInfectionsArray()
        {
            Infection[] head = Head.GetInfections();
            Infection[] chest = Chest.GetInfections();
            Infection[] abdomen = Abdomen.GetInfections();

            Infection[] result = new Infection[head.Length + chest.Length + abdomen.Length];

            head.CopyTo(result, 0);
            chest.CopyTo(result, head.Length);
            abdomen.CopyTo(result, (head.Length + chest.Length));
            return result;

            //return new Infection[]
            //{
            //    //Head
            //    Head.Surface,
            //    Head.Brain,

            //    //Chest
            //    Chest.Surface,
            //    Chest.Heart,
            //    Chest.LeftLung,
            //    Chest.RightLung,

            //    //Abdomen
            //    Abdomen.Surface,
            //    Abdomen.GastrointestinalTract,
            //    Abdomen.Liver,
            //    Abdomen.Spleen,
            //    Abdomen.Pancreas,
            //    Abdomen.LeftKidney,
            //    Abdomen.RightKidney,
            //    Abdomen.Bladder,
            //    Abdomen.Reproductives,
            //};
        }//This is atrocious

        #region ContainerClasses
        public abstract class DefaultContainer
        {
            public Infection Surface;
            public abstract Infection[] GetInfections();
        }
        public class HeadContainer : DefaultContainer
        {
            public Infection Brain;

            public override Infection[] GetInfections()
            {
                return new Infection[]
                {
                    Surface,
                    Brain,
                };
            }
        }
        public class ChestContainer : DefaultContainer
        {
            public Infection Heart;
            public Infection LeftLung;
            public Infection RightLung;

            public override Infection[] GetInfections()
            {
                return new Infection[]
                {
                    Surface,
                    Heart,
                    LeftLung,
                    RightLung,
                };
            }
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

            public override Infection[] GetInfections()
            {
                return new Infection[]
                {
                    Surface,
                    GastrointestinalTract,
                    Liver,
                    Spleen,
                    Pancreas,
                    LeftKidney,
                    RightKidney,
                    Bladder,
                    Reproductives
                };
            }
        }
        #endregion
    }



}

