using System;
using AirAmboAttempt01.Patients.PatientBlood;

namespace AirAmboAttempt01.Patients
{
    public class Fluid //Should this have been abstract?
    {
        #region DefaultFluidValues
        public static readonly float _defaultVolume = 1000;
        #endregion
        #region MaxMinFluidValues
        private readonly float _VolumeMax = 10000;
        private readonly float _VolumeMin = 0;
        private readonly float _HematocritMax = 1.0f; //Hematocrit is a percentage concentration of RBC in Blood
        private readonly float _HematocritMin = 0.0f; //Cant be negative
        private readonly float _ClottingFactorMax = 10.0f; //Arbitrary value. Clotting factor is a ratio of this sample against a standard sample of blood 
        private readonly float _ClottingFactorMin = 0.0f; //Cant be negative
        private readonly float _ElectrolytesMax = 10.0f; //Arbitrary value
        private readonly float _ElectrolytesMin = 0.0f; //Cant be negative
        #endregion

        private float _volume = _defaultVolume;
        public float Volume
        {
            get { return _volume; }
            protected set
            {
                _volume = Math.Clamp(value, _VolumeMin, _VolumeMax);
            }
        }
        private FluidProfile _fluidProfile = DefaultFluidProfiles.BaseFluid;
        public FluidProfile FluidProfile
        {
            get { return _fluidProfile; }
            protected set
            {
                _fluidProfile.Hematocrit = Math.Clamp(value.Hematocrit, _HematocritMin, _HematocritMax);
                _fluidProfile.ClottingFactor = Math.Clamp(value.ClottingFactor, _ClottingFactorMin, _ClottingFactorMax);
                _fluidProfile.Electrolytes = Math.Clamp(value.Electrolytes, _ElectrolytesMin, _ElectrolytesMax);
            }
        }

        #region Constructors
        public Fluid()
        {

        }
        public Fluid(float volume)
        {
            Volume = volume;
        }

        public Fluid(float volume, FluidProfile infusionFluidProfile)
        {
            Volume = volume;
            FluidProfile = infusionFluidProfile;
        }
        #endregion

        protected bool AddFluid(Fluid incFluid)
        {
            float newBloodVolume = _volume + incFluid.Volume;
            FluidProfile newFluidProfile = _fluidProfile;

            newFluidProfile.Hematocrit = ((incFluid.Volume * incFluid.FluidProfile.Hematocrit) + (_volume * _fluidProfile.Hematocrit)) / newBloodVolume;
            newFluidProfile.ClottingFactor = ((incFluid.Volume * incFluid.FluidProfile.ClottingFactor) + (_volume * _fluidProfile.ClottingFactor)) / newBloodVolume;
            newFluidProfile.Electrolytes = ((incFluid.Volume * incFluid.FluidProfile.Electrolytes) + (_volume * _fluidProfile.Electrolytes)) / newBloodVolume;

            _volume = newBloodVolume;
            _fluidProfile = newFluidProfile;

            return true;
        }
    }

    public class Blood : Fluid
    {
        #region DefaultBloodValues
        private new static readonly float _defaultVolume = 450;
        #endregion

        public readonly BloodType bloodType = new BloodType() { ABO = BloodABO.O, Rhesus = BloodRhesus.Negative };
       
        #region Constructors
        public Blood() : base(_defaultVolume, DefaultFluidProfiles.Blood)
        {

        }
        public Blood(BloodType bloodType) : base(_defaultVolume, DefaultFluidProfiles.Blood)
        {
            this.bloodType = bloodType;
        }
        public Blood(BloodType bloodType, float volume) : base(volume, DefaultFluidProfiles.Blood)
        {
            this.bloodType = bloodType;
        }
        public Blood(BloodType bloodType, float volume, FluidProfile bloodFluidProfile) : base(volume, bloodFluidProfile)
        {
            this.bloodType = bloodType;
        }
        #endregion

        protected bool AddFluid(Blood incBloodInfusion)
        {
            bool successFlag = false;
            successFlag = BloodTypeCompatibility(incBloodInfusion.bloodType);
            Console.WriteLine("BlooD");
            base.AddFluid(incBloodInfusion);
            return successFlag;
        }

        public bool BloodTypeCompatibility(BloodType incBloodType)
        {
            if (bloodType.Rhesus == BloodRhesus.Positive || incBloodType.Rhesus == BloodRhesus.Negative)
            {
                if ((incBloodType.ABO == BloodABO.A) && (bloodType.ABO == BloodABO.B))
                {
                    return false;
                }
                else
                {
                    return (bloodType.ABO >= incBloodType.ABO && (bloodType.Rhesus == BloodRhesus.Positive || incBloodType.Rhesus == BloodRhesus.Negative));
                }
            }
            else
            {
                return false;
            }

        }
    }

    public class Drug : Fluid //This may be stupid
    {
        #region DefaultDrugInfusionValues
        private new static readonly float _defaultVolume = 50;
        
        #endregion

        public readonly DrugType drugType = DrugType.None;

        #region Constructors
        public Drug() : base(_defaultVolume, DefaultFluidProfiles.Drug)
        {
        }

        public Drug(DrugType drugType) : base(_defaultVolume, DefaultFluidProfiles.Drug)
        {
            this.drugType = drugType;
        }
        public Drug(DrugType drugType, float volume) : base(volume, DefaultFluidProfiles.Drug)
        {
            this.drugType = drugType;
        }
        public Drug(DrugType drugType, float volume, FluidProfile drugFluidProfile) : base(volume, DefaultFluidProfiles.Drug)
        {
            this.drugType = drugType;
        }
        #endregion
    }
}