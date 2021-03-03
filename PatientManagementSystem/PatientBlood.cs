using System;
using System.Collections.Generic;
using PatientManagementSystem.Patients.PatientDrugs;

namespace PatientManagementSystem.Patients.PatientBlood
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
        Negative,
        Positive
    }
    public class BloodType
    {
        public BloodABO ABO;
        public BloodRhesus Rhesus;
        public override string ToString() => $"{ABO} {Rhesus}";
    }
    public enum BleedingSeverity
    {
        None,
        Mild,
        Moderate,
        Severe,
        Extreme
    }
    
    public class BloodSystem : Blood //Do I need this?
    {
        #region DefaultValues
        public readonly float _defaultBloodSystemVolume = 6000f; //mL
        #endregion
        #region Props
        private DrugProfile _DrugsProfile = new DrugProfile();
        public DrugProfile DrugsProfile
        {
            get { return _DrugsProfile; }
            set { _DrugsProfile = value; }
        }

        private bool _hasTranfusionReaction;
        public bool HasTransfusionReaction
        {
            get { return _hasTranfusionReaction; }
            set { _hasTranfusionReaction = value; }
        }

        private bool _immunoSuppressed;
        public bool ImmunoSuppressed
        {
            get { return _immunoSuppressed; }
            set { _immunoSuppressed = value; }
        }

        #endregion
        #region Constructors
        public BloodSystem()
        {
            Volume = _defaultBloodSystemVolume;
        }

        public BloodSystem(Blood bloodSetup) : base(bloodSetup.bloodType, bloodSetup.Volume, bloodSetup.FluidProfile)
        {

        }

        public BloodSystem(BloodType bloodType, FluidProfile fluidProfile, float bloodVolume) : base(bloodType, bloodVolume, fluidProfile)
        {

        }
        #endregion
    }
}
