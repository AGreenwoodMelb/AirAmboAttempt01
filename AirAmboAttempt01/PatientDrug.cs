using AirAmboAttempt01.Patients.PatientBlood;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirAmboAttempt01.Patients.PatientDrugs
{
    public enum DrugType //For later use
    {
        None,
        Stimulant,
        Sedative,
        Opiods,
        Hallucinogens,
        Detoxer
    }
    

    public struct DrugProfile
    {
        public bool IsStimulant;
        public bool IsSedative;
        public bool IsOpiod;
        public bool IsHallucinogen;
    }

    public interface Drug
    {
        public virtual bool Administer(Patient target)
        {
            throw new NotImplementedException(message: "Drug:: No implementation for Administer()");
        }
    }


    public class oDrug : Fluid //This may be stupid
    {
        #region DefaultDrugInfusionValues
        private new static readonly float _defaultVolume = 50;

        #endregion

        public readonly DrugType drugType = DrugType.None;

        #region Constructors
        public oDrug() : base(_defaultVolume, DefaultFluidProfiles.Drug)
        {
        }

        public oDrug(DrugType drugType) : base(_defaultVolume, DefaultFluidProfiles.Drug)
        {
            this.drugType = drugType;
        }
        public oDrug(DrugType drugType, float volume) : base(volume, DefaultFluidProfiles.Drug)
        {
            this.drugType = drugType;
        }
        public oDrug(DrugType drugType, float volume, FluidProfile drugFluidProfile) : base(volume, DefaultFluidProfiles.Drug)
        {
            this.drugType = drugType;
        }
        #endregion
    }
}
