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
        Minor,
        Moderate,
        Severe
    }
    public enum Consciousness
    {
        Awake,
        Responsive,
        UnResponsive
    }

    public struct InfusionFluidProfile
    {
        public float Hematocrit;
        public float ClottingFactor;
        public float Electrolytes;
    }

}