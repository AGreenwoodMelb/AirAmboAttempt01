namespace PatientManagementSystem.Patients
{
    public enum Gender
    {
        Other,
        Male,
        Female
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

    public enum BodyRegion
    {
        None,
        Head,
        Chest,
        Abdomen,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg
    }
}