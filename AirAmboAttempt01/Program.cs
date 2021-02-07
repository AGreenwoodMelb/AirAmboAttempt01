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
                        IsDestroyed = false
                    },
                    MiddleLobe = new LungLobe()
                    {
                        Infection = new PatientInfection.Infection()
                        {
                            infectionResistance = PatientInfection.InfectionResistance.Immune,
                            infectionSeverity = PatientInfection.InfectionSeverity.Moderate,
                            infectionType = PatientInfection.InfectionType.Bacterial
                        },
                        IsDestroyed = false
                    },
                    LowerLobe = new LungLobe()
                    {
                        Infection = new PatientInfection.Infection()
                        {
                            infectionResistance = PatientInfection.InfectionResistance.Immune,
                            infectionSeverity = PatientInfection.InfectionSeverity.Severe,
                            infectionType = PatientInfection.InfectionType.Bacterial
                        },
                        IsDestroyed = true
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

            //Lungs otherLungs = new Lungs();

            Console.WriteLine(chest.Lungs.LeftLung.MiddleLobe.IsDestroyed);

            //Console.WriteLine(otherLungs.LeftLung.MiddleLobe.IsDestroyed);
        }
    }
}
