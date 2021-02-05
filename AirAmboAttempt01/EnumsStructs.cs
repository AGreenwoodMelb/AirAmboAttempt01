namespace AirAmboAttempt01
{
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