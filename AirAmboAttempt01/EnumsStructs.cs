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
        Positive,
        Negative
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
        Bacterial,
        Viral,
        Prion,
        Other
    }
    public enum InfectionResistance
    {
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
}