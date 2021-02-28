using PatientManagementSystem.Patients.PatientDrugs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagementSystem.Patients.PatientPharmacology
{
    public class PatientPharmacology //Bad Name
    {
        //List of Drugs in Patient's blood;
        List<PatientDrug> CurrentDrugs = new List<PatientDrug>();


        public void AddDrug(Drug incDrug, AdministrationRoute viaRoute, float dose)
        {
            PatientDrug drug = CurrentDrugs.Find(x => (x.Drug.DrugName == incDrug.DrugName && x.AdministrationRoute == viaRoute));

            if (drug == null)
            {
                CurrentDrugs.Add(new PatientDrug(incDrug, viaRoute, dose));
            }
            else
            {
                drug.IncreaseDose(dose);
            }
        }
    }

    //Add PatientPharmacology(bad name) System which contains a list of drugs in the system, their currentLevels(pre and post-metabolism if applicable),their ExcretionRate(or something like that), their AddictionLevel(If Applicable), SensitivityLevel
    public class PatientDrug //Also bad name
    {
        public readonly Drug Drug;
        public readonly AdministrationRoute AdministrationRoute;
        public float CurrentDose { get; private set; }
        public float ToBeExcreted;


        public PatientDrug(Drug drug, AdministrationRoute administrationRoute, float dose)
        {
            Drug = drug;

        }

        public void IncreaseDose(float dose)
        {
            CurrentDose += dose;
        }
    }
}
