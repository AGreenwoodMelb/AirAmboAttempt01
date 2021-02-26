using System;
using PatientManagementSystem.Patients.PatientInterventions;

namespace PatientManagementSystem.Patients.PatientDrugs
{

    public enum AdministrationRoute
    {
        /* NOTE:
         * Players can administer drugs via the incorrect route with varying outcomes
         * 
         */
        None,
        Intramuscular,
        Oral,
        IV,
        Inhaled,
        Other,
    }

    public struct DrugProfile
    {
        public bool IsStimulant;
        public bool IsSedative;
        public bool IsOpiod;
        public bool IsHallucinogen;
    }

    public abstract class Drug
    {
        protected Patient _patient;
        protected DrugProfile drugProfile;
        public float WasteProduced { get; protected set; }
        public string DrugName => this.GetType().Name;

        public bool Administer(Patient patient, AdministrationRoute route)
        {
            _patient = patient;
            bool output = false;
            switch (route)
            {
                case AdministrationRoute.None:
                    break;
                case AdministrationRoute.Intramuscular:
                    output = AdministerIntramuscular(patient, route);
                    break;
                case AdministrationRoute.Oral:
                    output = AdministerOral(patient, route);
                    break;
                case AdministrationRoute.IV:
                    output = AdministerIV(patient, route);
                    break;
                case AdministrationRoute.Inhaled:
                    output = AdministerInhaled(patient, route);
                    break;
                case AdministrationRoute.Other:
                    //LUXURY: FOR EXPANSION
                    break;
                default:
                    break;
            }
            UpdatePatientDrugProfile();
            return output;
        }
        
        public void UpdatePatientDrugProfile()
        {
            DrugProfile targetProfile = _patient.Body.Blood.DrugsProfile;

            targetProfile.IsStimulant = drugProfile.IsStimulant || targetProfile.IsStimulant;
            targetProfile.IsSedative = drugProfile.IsSedative || targetProfile.IsSedative;
            targetProfile.IsOpiod = drugProfile.IsOpiod || targetProfile.IsOpiod;
            targetProfile.IsHallucinogen = drugProfile.IsHallucinogen || targetProfile.IsHallucinogen;

            _patient.Body.Blood.DrugsProfile = targetProfile;
        }

        protected abstract bool AdministerIntramuscular(Patient patient, AdministrationRoute route);
        protected abstract bool AdministerOral(Patient patient, AdministrationRoute route);
        protected abstract bool AdministerIV(Patient patient, AdministrationRoute route);
        protected abstract bool AdministerInhaled(Patient patient, AdministrationRoute route);
    }

    public class DrugStim1 : Drug
    {
        public DrugStim1()
        {
            WasteProduced = PatientDefaults.DefaultWasteProduction.AdministerDrug[DrugName];
            drugProfile.IsStimulant = true;
        }

        protected override bool AdministerIntramuscular(Patient patient, AdministrationRoute route)
        {
            return true; //Testing here 
        }
        protected override bool AdministerOral(Patient patient, AdministrationRoute route)
        {
            throw new NotImplementedException();
        }
        protected override bool AdministerInhaled(Patient patient, AdministrationRoute route)
        {
            throw new NotImplementedException();
        }
        protected override bool AdministerIV(Patient patient, AdministrationRoute route)
        {
            throw new NotImplementedException();
        }
    }

    //public class DrugDetoxer : Drug
    //{
    //    public override bool Administer(Patient target, AdministrationRoute route)
    //    {
    //        Target = target;
    //        Target.Body.Blood.DrugsProfile = new DrugProfile();
    //        return true;
    //    }
    //}
}
