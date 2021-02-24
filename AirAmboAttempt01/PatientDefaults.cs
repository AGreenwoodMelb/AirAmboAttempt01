using PatientManagementSystem.Patients.PatientAccessPoints;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientBones;
using PatientManagementSystem.Patients.PatientOrgans; //Hopefully this wont last

using System.Collections.Generic;

namespace PatientManagementSystem.Patients.PatientDefaults
{
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

    public static class DefaultBoneStructures
    {
        public static readonly Bone[] DefaultHeadBones = new Bone[]
        {
            new Bone("Skull"),
            new Bone("Spine"),
            new Bone("Facial")
        };

        public static readonly Bone[] DefaultArmBones = new Bone[]
        {
            new Bone("Humerus"),
            new Bone("Radius/Ulnar"),
            new Bone("Hand")
        };

        public static readonly Bone[] DefaultChestBones = new Bone[]
        {
            new Bone("Ribs"),
            new Bone("Spine")
        };

        public static readonly Bone[] DefaultAbdomenBones = new Bone[]
        {
            new Bone("Spine"),
            new Bone("Pelvis")
        };

        public static readonly Bone[] DefaultLegBones = new Bone[]
        {
            new Bone("Femur"),
            new Bone("Patella"),
            new Bone("Tibia/Fibula"),
            new Bone("Foot")
        };

    }

    public static class DefaultFluidProfiles
    {
        public static readonly FluidProfile Drug = new FluidProfile()
        {
            Hematocrit = 0.0f,
            ClottingFactor = 0.0f,
            Electrolytes = 0.0f
        };//Essentially ratios found in standard drug infusion //TBC

        public static readonly FluidProfile Blood = new FluidProfile()
        {
            Hematocrit = 0.4f,
            ClottingFactor = 1.0f,
            Electrolytes = 1.0f
        };//Essentially ratios found in standard blood

        public static readonly FluidProfile BaseFluid = new FluidProfile()
        {
            Hematocrit = 0.0f,
            ClottingFactor = 0.0f,
            Electrolytes = 0.0f
        };//Essentially ratios found in 1L of water
    }

    public static class DefaultLungs
    {
        public static readonly float OxygenSaturation = 100f;
        public static readonly int RespirationRate = 16;
    }

    public static class DefaultWasteProduction
    {
        #region IVs
        public static readonly float InsertIV = 10f;
        public static readonly float RemoveIV = 0f;

        public static readonly float InsertCentralLine = 0f;
        public static readonly float RemoveCentralLine = 0f;
        #endregion

        #region Airways
        public static readonly Dictionary<ArtificialAirway, float> InsertAirway = new Dictionary<ArtificialAirway, float>()
        {
            {ArtificialAirway.FaceMask, 0f },
            {ArtificialAirway.LaryngealMask, 0f },
        };

        public static readonly Dictionary<ArtificialAirway, float> RemoveAirway = new Dictionary<ArtificialAirway, float>()
        {
            {ArtificialAirway.FaceMask, 0f },
            {ArtificialAirway.LaryngealMask, 0f },
        };
        #endregion

        #region UrinaryCatheter
        public static float InsertUrinaryCatheter = 0f;
        public static float RemoveUrinaryCatheter = 0f;
        #endregion

        #region CerebralShunt
        public static float InsertCerebralShunt = 0f;
        public static float RemoveCerebralShunt = 0f;
        #endregion

        public static float PerformLumbarPuncture = 0f;
    }

    public static class DefaultPlayerStatsTEMP
    {
        #region IVs
        public static float InsertIVSuccess = 100f;
        public static float InsertCentralLineSuccess = 100f;
        #endregion
        #region Airways
        public static readonly Dictionary<ArtificialAirway, float> AirwayInsertionSuccess = new Dictionary<ArtificialAirway, float>()
        {
            {ArtificialAirway.FaceMask, 1f },
            {ArtificialAirway.LaryngealMask,0f },
        };
        #endregion
        #region UrinaryCatheter
        public static float InsertUrinaryCatheterSuccess = 100f;
        #endregion

        #region CerebralShunt
        public static float InsertCerebralShuntSuccess = 0f;
        #endregion

        public static float PerformLumbarPunctureSuccess = 0f;
    }

    public static class DefaultOrganStuff
    {
        public static readonly (OrganState, float)[] OrganLookup = new (OrganState, float)[]
        {
            (OrganState.None,-1.0f),
            (OrganState.Removed,0.0f),
            (OrganState.Destroyed,0.10f),
            (OrganState.Damaged,0.30f),
            (OrganState.Impaired,0.70f),
            (OrganState.Normal,1.0f),
        };
    }
}
