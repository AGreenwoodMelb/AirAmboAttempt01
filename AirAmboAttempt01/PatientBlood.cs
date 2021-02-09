using System;
using System.Collections.Generic;

namespace AirAmboAttempt01.Patients.PatientBlood
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
    public struct BloodType
    {
        public BloodABO ABO;
        public BloodRhesus Rhesus;

        public string GetBloodType => $"{ABO} {Rhesus}";
    }
    public enum BleedingSeverity
    {
        None,
        Mild,
        Moderate,
        Severe,
        Extreme
    }
    public static class DefaultBloodLossBaseRates
    {
        public static readonly float Superficial = 1f;

        public static readonly float Brain = 1f;

        public static readonly float Heart = 1f;
        public static readonly float Lung = 1f;

        public static readonly float GI = 1f;
        public static readonly float Kidney = 1f;
        public static readonly float Bladder = 1f;
        public static readonly float Liver = 1f;
        public static readonly float Pancreas = 1f;
        public static readonly float Spleen = 1f;
        public static readonly float Reproductive_Male = 1f;
        public static readonly float Reproductive_Female = 1f;

        public static readonly Dictionary<BleedingSeverity, float> BleedingSeverityMultiplier = new Dictionary<BleedingSeverity, float>()
        {
            { BleedingSeverity.None, 0},
            { BleedingSeverity.Mild, 0.5f},
            { BleedingSeverity.Moderate, 1f},
            { BleedingSeverity.Severe, 2f},
            { BleedingSeverity.Extreme, 2.5f}
        };


    }
    public class BloodSystem : Blood //Do I need this?
    {
        #region DefaultValues
        public readonly float _defaultBloodSystemVolume = 6000f; //mL
        #endregion

        #region Props
        private IllilcitDrugsProfile _illicitDrugsProfile;
        public IllilcitDrugsProfile IllilcitDrugsProfile
        {
            get { return _illicitDrugsProfile; }
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
