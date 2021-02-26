using System;
using PatientManagementSystem.Patients.PatientDefaults;

namespace PatientManagementSystem.Patients.PatientDrugs
{
    public enum AdministrationRoute
    {
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
        /* NOTE:
         * Players can administer drugs via the incorrect route with varying outcomes
         * 
         * Are Checks for Valid route handled else where?
         */

        protected Patient _patient;
        protected DrugProfile drugProfile;
        public float WasteProduced { get; protected set; }
        public string DrugName => this.GetType().Name;

        public bool Administer(Patient patient, AdministrationRoute route)
        {
            WasteProduced = DefaultWasteProduction.AdministerDrug[DrugName] * DefaultWasteProduction.AdministerRoute[route];
            _patient = patient;
            bool AdministrationSuccessful = false;
            switch (route)
            {
                case AdministrationRoute.None:
                    break;
                case AdministrationRoute.Intramuscular:
                    AdministrationSuccessful = AdministerIntramuscular();
                    break;
                case AdministrationRoute.Oral:
                    //Check PT is conscious and compliant
                    AdministrationSuccessful = AdministerOral();
                    break;
                case AdministrationRoute.IV:
                    AdministrationSuccessful = AdministerIV();
                    break;
                case AdministrationRoute.Inhaled:
                    AdministrationSuccessful = AdministerInhaled();
                    break;
                case AdministrationRoute.Other:
                default:
                    AdministerNotSpecified(route);//LUXURY: FOR EXPANSION
                    break;
            }

            if(AdministrationSuccessful) //If you failed to administer then the drugProfile doesnt change
                UpdatePatientDrugProfile();

            return AdministrationSuccessful;
        }
        private void UpdatePatientDrugProfile()
        {
            DrugProfile targetProfile = _patient.Body.Blood.DrugsProfile;

            targetProfile.IsStimulant = drugProfile.IsStimulant || targetProfile.IsStimulant;
            targetProfile.IsSedative = drugProfile.IsSedative || targetProfile.IsSedative;
            targetProfile.IsOpiod = drugProfile.IsOpiod || targetProfile.IsOpiod;
            targetProfile.IsHallucinogen = drugProfile.IsHallucinogen || targetProfile.IsHallucinogen;

            _patient.Body.Blood.DrugsProfile = targetProfile;
        }
        protected abstract bool AdministerIntramuscular();
        protected abstract bool AdministerOral();
        protected abstract bool AdministerIV();
        protected abstract bool AdministerInhaled();
        protected virtual bool AdministerNotSpecified(AdministrationRoute route) 
        {
            throw new NotImplementedException();
        }//Virtual because this is a luxury task for use if modding becomes a thing (hahahahha)
    }

    public class DrugStim1 : Drug
    {
        public DrugStim1()
        {
            drugProfile.IsStimulant = true;
        }

        protected override bool AdministerIntramuscular()
        {
            return true; //Testing here 
        }
        protected override bool AdministerOral()
        {
            throw new NotImplementedException();
        }
        protected override bool AdministerInhaled()
        {
            throw new NotImplementedException();
        }
        protected override bool AdministerIV()
        {
            throw new NotImplementedException();
        }
    }

    public class DrugDetoxer : Drug
    {
        protected override bool AdministerInhaled() => DefaultAdminister();
        protected override bool AdministerIntramuscular() => DefaultAdminister();
        protected override bool AdministerIV() => DefaultAdminister();
        protected override bool AdministerOral() => DefaultAdminister();

        private bool DefaultAdminister()
        {
            _patient.Body.Blood.DrugsProfile = new DrugProfile();
            return true;
        }
    }
}
