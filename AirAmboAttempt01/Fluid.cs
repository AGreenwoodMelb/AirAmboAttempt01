using System;
using System.Collections.Generic;

namespace AirAmboAttempt01
{
    public class Fluid
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

        public void AddFluid(Fluid incFluid)
        {
            float newBloodVolume = _volume + incFluid.Volume;
            FluidProfile newFluidProfile = _fluidProfile;

            newFluidProfile.Hematocrit = ((incFluid.Volume * incFluid.FluidProfile.Hematocrit) + (_volume * _fluidProfile.Hematocrit)) / newBloodVolume;
            newFluidProfile.ClottingFactor = ((incFluid.Volume * incFluid.FluidProfile.ClottingFactor) + (_volume * _fluidProfile.ClottingFactor)) / newBloodVolume;
            newFluidProfile.Electrolytes = ((incFluid.Volume * incFluid.FluidProfile.Electrolytes) + (_volume * _fluidProfile.Electrolytes)) / newBloodVolume;

            _volume = newBloodVolume;
            _fluidProfile = newFluidProfile;
        }
    }

    public class BloodInfusion : Fluid
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

        public readonly BloodType bloodType = new BloodType() { ABO = BloodABO.O, Rhesus = BloodRhesus.Negative };

        public BloodInfusion()
        {

        }
        public BloodInfusion(BloodType bloodType) : base(_defaultVolume, _defaultInfusionFluidProfile_Blood)
        {
            this.bloodType = bloodType;
        }
        public BloodInfusion(BloodType bloodType, float volume) : base(volume, _defaultInfusionFluidProfile_Blood)
        {
            this.bloodType = bloodType;
        }
        public BloodInfusion(BloodType bloodType, float volume, FluidProfile bloodFluidProfile) : base(volume, bloodFluidProfile)
        {
            this.bloodType = bloodType;
        }

        public void AddFluid(BloodInfusion incBloodInfusion)
        {

        }
        private bool BloodTypeCompatibility(BloodType incBloodType)
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

    public class Blood : Fluid
    {
        #region DefaultValues
        readonly float _normalBloodVolume = 6000f; //mL
        static readonly FluidProfile _normalBloodProfile = new FluidProfile()
        {
            Hematocrit = 0.4f,
            ClottingFactor = 1f,
            Electrolytes = 1f
        };
        readonly Dictionary<BleedingSeverity, float> _bloodLossDefaults = new Dictionary<BleedingSeverity, float>()
        {
            { BleedingSeverity.None, 0},
            { BleedingSeverity.Minor, 0.5f},
            { BleedingSeverity.Moderate, 1},
            { BleedingSeverity.Severe, 2}
        };
        #endregion

        public readonly BloodType bloodType = new BloodType() { ABO = BloodABO.AB, Rhesus = BloodRhesus.Positive };

        Dictionary<BodyRegion, BleedingSeverity> isRegionBleeding = new Dictionary<BodyRegion, BleedingSeverity>()
        {
            {BodyRegion.Head, BleedingSeverity.None},
            {BodyRegion.Chest, BleedingSeverity.None},
            {BodyRegion.Abdomen, BleedingSeverity.None},
            {BodyRegion.LeftArm, BleedingSeverity.None},
            {BodyRegion.RightArm, BleedingSeverity.None},
            {BodyRegion.LeftLeg, BleedingSeverity.None},
            {BodyRegion.RightLeg, BleedingSeverity.None}
        };

        //public float CurrentBloodVolume { get; private set; }
        private FluidProfile _bloodProfile = _normalBloodProfile;
        public FluidProfile BloodProfile
        {
            get { return _bloodProfile; }
        }
        private IllilcitDrugsProfile illictDrugsProfile;
        public IllilcitDrugsProfile IllilcitDrugsProfile
        {
            get { return illictDrugsProfile; }
        }

        public Blood()
        {
        }
        public Blood(BloodType bloodType)
        {
            this.bloodType = bloodType;
        }
        public Blood(BloodType bloodType, FluidProfile bloodProfile) : this(bloodType)
        {
            _bloodProfile = bloodProfile;
        }

        //public bool BloodTranfusion(BloodInfusion incBlood)
        //{
        //    //AddVolume(incBlood);
        //    if (BloodTypeCompatibility(incBlood.bloodType))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false; //Trigger Transfusion reaction
        //    }
        //}


        public bool FluidTransfusion(Fluid incFluid)
        {
            bool successFlag = false;
            switch (incFluid)//Maybe just an if would do? Depends on how many unique handlers are needed
            {
                case BloodInfusion incBlood:
                    successFlag = BloodTranfusion(incBlood);
                    break;
                case DrugInfusion incDrug:

                    break;
                case Fluid incInfusionFluid:
                    break;
                default:
                    throw new ArgumentException(
                        message: "InfusionFluid is not a recognised transfusion fluid",
                        paramName: nameof(incFluid)
                        );
            }

            //AddVolume(incFluid);

            return successFlag;
        }



        private void BloodChecks()
        {
            BloodVolumeCheck();
        }

        private void BloodVolumeCheck()
        {
            float BloodVolumeRatio = CurrentBloodVolume / _normalBloodVolume;
            Console.WriteLine(BloodVolumeRatio);
        }

    }
    public class DrugInfusion : Fluid
    {
        #region DefaultDrugInfusionValues
        private new static readonly float _defaultVolume = 50;
        private static readonly FluidProfile _defaultInfusionFluidProfile_Drug = new FluidProfile()
        {
            Hematocrit = 0.0f,
            ClottingFactor = 0.0f,
            Electrolytes = 0.0f
        };//Essentially ratios found in standard blood infusion
        #endregion

        public readonly DrugType drugType = DrugType.None;


        public DrugInfusion()
        {

        }
        public DrugInfusion(DrugType drugType) : base(_defaultVolume, _defaultInfusionFluidProfile_Drug)
        {
            this.drugType = drugType;
        }
        public DrugInfusion(DrugType drugType, float volume) : base(volume, _defaultInfusionFluidProfile_Drug)
        {
            this.drugType = drugType;
        }
        public DrugInfusion(DrugType drugType, float volume, FluidProfile drugFluidProfile) : base(volume, _defaultInfusionFluidProfile_Drug)
        {
            this.drugType = drugType;
        }

    }
}