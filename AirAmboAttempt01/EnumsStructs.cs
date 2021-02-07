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
    public enum LungLobeLocation
    {
        Upper,
        Middle,
        Lower
    }
  
}