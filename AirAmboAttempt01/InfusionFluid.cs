
using System;

namespace AirAmboAttempt01
{
    public class InfusionFluid
    {
        #region DefaultInfusionValues
        public static readonly float _defaultVolume = 1000;
        public static readonly FluidProfile _defaultInfusionFluidProfile = new FluidProfile()
        {
            Hematocrit = 0.0f,
            ClottingFactor = 0.0f,
            Electrolytes = 0.0f
        };//Essentially ratios found in 1L of water
        #endregion
        #region MaxMinInfusionValues
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
        private FluidProfile _fluidProfile = _defaultInfusionFluidProfile;
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

        public InfusionFluid(float volume)
        {
            Volume = volume;
        }

        public InfusionFluid(float volume, FluidProfile infusionFluidProfile)
        {
            Volume = volume;
            FluidProfile = infusionFluidProfile;
        }
    }

    public class BloodInfusion : InfusionFluid
    {
        #region DefaultBloodValues
        private new static readonly float _defaultVolume = 450;
        private static readonly FluidProfile _defaultInfusionFluidProfile_Blood = new FluidProfile()
        {
            Hematocrit = 0.4f,
            ClottingFactor = 1.0f,
            Electrolytes = 1.0f
        };//Essentially ratios found in standard blood infusion
        #endregion

        private BloodType _bloodType = new BloodType() { ABO = BloodABO.O, Rhesus = BloodRhesus.Negative };
        public BloodType BloodType
        {
            get { return _bloodType; }
            protected set { _bloodType = value; }
        }

        public BloodInfusion(BloodType bloodType) : base(_defaultVolume, _defaultInfusionFluidProfile_Blood)
        {
            BloodType = bloodType;
        }

        public BloodInfusion(BloodType bloodType, float volume) : base(volume, _defaultInfusionFluidProfile_Blood)
        {
            BloodType = bloodType;
        }

        public BloodInfusion(BloodType bloodType, float volume, FluidProfile infusion) : base(volume, infusion)
        {
            BloodType = bloodType;
        }
    }
}