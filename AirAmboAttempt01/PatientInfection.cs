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
        public InfectionResistance infectionResistance;

        public void IncreaseInfection()
        {
            if (infectionSeverity != InfectionSeverity.Extreme)
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
}
