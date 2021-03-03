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
    public enum ExcretionRoute
    {
        Urine,
        Respiration,
        Faeces
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
         * This is all wrong now. Shit.
         * None of this will be used 
         */

        protected Patient _patient;
        protected DrugProfile drugProfile;
        public float WasteProduced { get; protected set; }
        public string DrugName => this.GetType().Name;

        public abstract bool UndergoesHepaticMetabolism { get; }
        public abstract ExcretionRoute ExcretionRoute { get; }

        public bool Administer(Patient patient, AdministrationRoute route)
        {
            WasteProduced = DefaultWasteProduction.AdministerDrug[DrugName] * DefaultWasteProduction.AdministerRoute[route]; //Keep
            _patient = patient;
            bool AdministrationSuccessful = false; //Keep

            //AdministrationSuccessful = TEMP_Action(route, AdministrationSuccessful);

            if (AdministrationSuccessful) //If you failed to administer then the drugProfile doesnt change
                UpdatePatientDrugProfile(); //BIN

            return AdministrationSuccessful;
        }

        private void TEMP_Action(AdministrationRoute route)
        {
            switch (route)
            {
                case AdministrationRoute.None:
                    break;
                case AdministrationRoute.Intramuscular:
                    AdministerIntramuscular();
                    break;
                case AdministrationRoute.Oral:
                    //Check PT is conscious and compliant
                    AdministerOral();
                    break;
                case AdministrationRoute.IV:
                    AdministerIV();
                    break;
                case AdministrationRoute.Inhaled:
                    AdministerInhaled();
                    break;
                case AdministrationRoute.Other:
                default:
                    AdministerNotSpecified(route);//LUXURY: FOR EXPANSION
                    break;
            }
        }

        private void UpdatePatientDrugProfile()
        {
            DrugProfile targetProfile = _patient.Body.Blood.DrugsProfile;

            targetProfile.IsStimulant = drugProfile.IsStimulant || targetProfile.IsStimulant;
            targetProfile.IsSedative = drugProfile.IsSedative || targetProfile.IsSedative;
            targetProfile.IsOpiod = drugProfile.IsOpiod || targetProfile.IsOpiod;
            targetProfile.IsHallucinogen = drugProfile.IsHallucinogen || targetProfile.IsHallucinogen;

            _patient.Body.Blood.DrugsProfile = targetProfile;
        } //BIN
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
        public override bool UndergoesHepaticMetabolism => false;
        public override ExcretionRoute ExcretionRoute => ExcretionRoute.Urine;

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
        public override bool UndergoesHepaticMetabolism => true;
        public override ExcretionRoute ExcretionRoute => ExcretionRoute.Faeces;

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
