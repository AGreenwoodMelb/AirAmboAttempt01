using System;
using AirAmboAttempt01.Patients.PatientOrgans;


namespace AirAmboAttempt01.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            Lungs newLungs = new Lungs()
            {
                LeftLung = new Lung()
                {
                    UpperLobe = new LungLobe()
                    {
                        Infection = new PatientInfection.Infection()
                        {
                            infectionResistance = PatientInfection.InfectionResistance.Immune,
                            infectionSeverity = PatientInfection.InfectionSeverity.Mild,
                            infectionType = PatientInfection.InfectionType.Bacterial
                        },
                        LobeState = OrganState.Impaired
                    },
                    MiddleLobe = new LungLobe()
                    {
                        Infection = new PatientInfection.Infection()
                        {
                            infectionResistance = PatientInfection.InfectionResistance.Immune,
                            infectionSeverity = PatientInfection.InfectionSeverity.Moderate,
                            infectionType = PatientInfection.InfectionType.Bacterial
                        },
                        LobeState = OrganState.Damaged
                    },
                    LowerLobe = new LungLobe()
                    {
                        Infection = new PatientInfection.Infection()
                        {
                            infectionResistance = PatientInfection.InfectionResistance.Immune,
                            infectionSeverity = PatientInfection.InfectionSeverity.Severe,
                            infectionType = PatientInfection.InfectionType.Bacterial
                        },
                        LobeState = OrganState.Destroyed
                    }
                },
                RightLung = new Lung()
                {
                    UpperLobe = new LungLobe(),
                    MiddleLobe = new LungLobe(),
                    LowerLobe = new LungLobe()
                }
            };

            PatientPhysical.Chest chest = new PatientPhysical.Chest(lungs: newLungs);

            Console.WriteLine(chest.Lungs.LeftLung.OrganState);

        }
    }
}
