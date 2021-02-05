namespace AirAmboAttempt01
{
    public enum Gender
    {
        Other,
        Male,
        Female
    }
    public enum BodyRegion
    {
        Head,
        Chest,
        Abdomen,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
        Other //?
    }
    public enum BloodABO
    {
        O,
        A,
        B,
        AB
    }
    public enum BloodRhesus
    {
        Negative,
        Positive
    }
    public struct BloodType
    {
        public BloodABO ABO;
        public BloodRhesus Rhesus;
    }
    public enum BleedingSeverity
    {
        None,
        Mild,
        Moderate,
        Severe,
        Extreme
    }
    public enum PainSeverity
    {
        None,
        Mild,
        Moderate,
        Severe,
        Extreme
    }
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
        public InfectionResistance infectionResistance;

        public void IncreaseInfection()
        {
            if(infectionSeverity != InfectionSeverity.Extreme)
                infectionSeverity += 1;
        }

        public void DecreaseInfection()
        {
            if (infectionSeverity != InfectionSeverity.None)
                infectionSeverity -= 1;
        }

        public void CureInfection()
        {
            infectionSeverity = InfectionSeverity.None;
        }
    }
    public enum Consciousness
    {
       Dead,
       Unresponsive,
       Semi_Responsive,
       Responsive
    }
    public enum MentalState
    {
        Dead,
        Normal,
        Absent,
        Confused,
        Agitated,
    }
    public enum DrugType //For later use
    {
        None,
        Stimulant,
        Sedative,
        Opiods,
        Hallucinogens,
        Detoxer
    }
    public struct IllilcitDrugsProfile
    {
        public bool stimulants;
        public bool sedetives;
        public bool opiods;
        public bool hallucinogens;
    }


    public struct LungLobe
    {
        public LobeLocation lobeLocation;
        public Infection infection;
        public bool isDestroyed;
    }

    public enum LobeLocation
    {
        Upper,
        Middle,
        Lower
    }
}