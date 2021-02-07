namespace AirAmboAttempt01.Patients.PatientMental
{
    public class Mental
    {
        public Consciousness Consciousness;
        public MentalState MentalState;
        public PainSeverity OverallPain; //May not need. Should be dynamically calculated by highest PainSeverity in BodyParts
    }

}
