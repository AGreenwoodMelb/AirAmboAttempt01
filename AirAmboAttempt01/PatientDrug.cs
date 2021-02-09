using System;
using AirAmboAttempt01.Patients.PatientInterventions;

namespace AirAmboAttempt01.Patients.PatientDrugs
{



    public struct DrugProfile
    {
        public bool IsStimulant;
        public bool IsSedative;
        public bool IsOpiod;
        public bool IsHallucinogen;
    }

    public abstract class Drug
    {
        public Patient Target { get; protected set; }
        public DrugProfile drugProfile;


        public virtual bool Administer(Patient target)
        {
            throw new NotImplementedException(message: "Drug::Administer not implements");
        }

        public void UpdatePatientDrugProfile()
        {
            DrugProfile targetProfile = Target.Body.Blood.DrugsProfile;

            targetProfile.IsStimulant = drugProfile.IsStimulant || targetProfile.IsStimulant;
            targetProfile.IsSedative = drugProfile.IsSedative || targetProfile.IsSedative;
            targetProfile.IsOpiod = drugProfile.IsOpiod || targetProfile.IsOpiod;
            targetProfile.IsHallucinogen = drugProfile.IsHallucinogen || targetProfile.IsHallucinogen;

            Target.Body.Blood.DrugsProfile = targetProfile;
        }

    }


    public class DrugStim1 : Drug
    {
        public DrugStim1()
        {
            drugProfile.IsStimulant = true;
        }


        public override bool Administer(Patient target)
        {
            Target = target;
            //Do the action of the drug
            UpdatePatientDrugProfile();
            return true;
        }
    }

    public class DrugDetoxer : Drug
    {
        public override bool Administer(Patient target)
        {
            Target = target;
            Target.Body.Blood.DrugsProfile = new DrugProfile();
            return true;
        }
    }

    //public class oDrug : Fluid //This may be stupid
    //{
    //    #region DefaultDrugInfusionValues
    //    private new static readonly float _defaultVolume = 50;

    //    #endregion

    //    public readonly DrugType drugType = DrugType.None;

    //    #region Constructors
    //    public oDrug() : base(_defaultVolume, DefaultFluidProfiles.Drug)
    //    {
    //    }

    //    public oDrug(DrugType drugType) : base(_defaultVolume, DefaultFluidProfiles.Drug)
    //    {
    //        this.drugType = drugType;
    //    }
    //    public oDrug(DrugType drugType, float volume) : base(volume, DefaultFluidProfiles.Drug)
    //    {
    //        this.drugType = drugType;
    //    }
    //    public oDrug(DrugType drugType, float volume, FluidProfile drugFluidProfile) : base(volume, DefaultFluidProfiles.Drug)
    //    {
    //        this.drugType = drugType;
    //    }
    //    #endregion
    //}
}
