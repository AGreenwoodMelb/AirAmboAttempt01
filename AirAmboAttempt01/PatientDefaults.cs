﻿using PatientManagementSystem.Patients.PatientAccessPoints;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientBones;
using PatientManagementSystem.Patients.PatientOrgans; //Hopefully this wont last
using PatientManagementSystem.Patients.PatientInfection;
using PatientManagementSystem.Patients.PatientDrugs;
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
        #region Interventions
        #region IVs
        public static readonly float InsertIV = 10f;
        public static readonly float RemoveIV = 0f;

        public static readonly float InsertCentralLine = 0f;
        public static readonly float RemoveCentralLine = 0f;
        #endregion

        #region Airways
        public static readonly Dictionary<ArtificialAirwayType, float> InsertAirway = new Dictionary<ArtificialAirwayType, float>()
        {
            {ArtificialAirwayType.FaceMask, 0f },
            {ArtificialAirwayType.LaryngealMask, 0f },
        };

        public static readonly Dictionary<ArtificialAirwayType, float> RemoveAirway = new Dictionary<ArtificialAirwayType, float>()
        {
            {ArtificialAirwayType.FaceMask, 0f },
            {ArtificialAirwayType.LaryngealMask, 0f },
        };
        #endregion

        #region UrinaryCatheter
        public static readonly float InsertUrinaryCatheter = 0f;
        public static readonly float RemoveUrinaryCatheter = 0f;
        #endregion

        #region CerebralShunt
        public static readonly float InsertCerebralShunt = 0f;
        public static readonly float RemoveCerebralShunt = 0f;
        public static readonly float SampleShuntCSF = 0f;
        #endregion

        #region General
        public static readonly float PerformLumbarPuncture = 0f;
        #endregion

        #region DrugAdministration
        public static readonly Dictionary<AdministrationRoute, float> AdministerRoute = new Dictionary<AdministrationRoute, float>()
        {
            {AdministrationRoute.None, 0f },
            {AdministrationRoute.Intramuscular, 2f },
            {AdministrationRoute.Oral, 1f },
            {AdministrationRoute.IV, 2f },
            {AdministrationRoute.Inhaled, 1f },
            {AdministrationRoute.Other, 1f },
        };

        public static readonly Dictionary<string, float> AdministerDrug = new Dictionary<string, float>() //Careful when adding new drugs that the string = TargetDrugClass.GetName;
        {
            { "DrugStim1", 10f},
        };
        #endregion
        #endregion
    }

    public static class DefaultPlayerStatsTEMP
    {
        #region IVs
        public static float InsertIVSuccess = 0f;
        public static float InsertCentralLineSuccess = 0f;
        #endregion
        #region Airways
        public static readonly Dictionary<ArtificialAirwayType, float> AirwayInsertionSuccess = new Dictionary<ArtificialAirwayType, float>()
        {
            {ArtificialAirwayType.FaceMask, 1f },
            {ArtificialAirwayType.LaryngealMask,0f },
        };
        #endregion
        #region UrinaryCatheter
        public static float InsertUrinaryCatheterSuccess = 0f;
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

    public static class DefaultInfectionValues
    {
        public static readonly (InfectionSeverity, float)[] SeverityLookup = new (InfectionSeverity, float)[]
        {
            (InfectionSeverity.None, 0f),
            (InfectionSeverity.Mild, 0.1f),
            (InfectionSeverity.Moderate, 0.3f),
            (InfectionSeverity.Severe, 0.6f),
            (InfectionSeverity.Extreme, 0.9f),
        };

        public static readonly (InfectionTreatmentResistance, float)[] ResitanceLookup = new (InfectionTreatmentResistance, float)[]
        {
            (InfectionTreatmentResistance.None, 1f),
            (InfectionTreatmentResistance.Susceptible, 0.75f),
            (InfectionTreatmentResistance.Stardard, 0.5f),
            (InfectionTreatmentResistance.Resistant, 0.25f),
            (InfectionTreatmentResistance.Immune, 0f),
        };

        public static readonly (InfectionSeverity, float)[] SepticaemiaChanceLookup = new (InfectionSeverity, float)[]
        {
            (InfectionSeverity.None, 0f),
            (InfectionSeverity.Mild, 0.1f),
            (InfectionSeverity.Moderate, 0.3f),
            (InfectionSeverity.Severe, 0.6f),
            (InfectionSeverity.Extreme, 0.9f),
        };

        //Cant remember the other values needed;
        #region Interventions
        public static readonly float InsertIV = 0f;
        public static readonly float InsertCentralLine = 0f;

        public static readonly Dictionary<ArtificialAirwayType, float> InsertAirway = new Dictionary<ArtificialAirwayType, float>()
        {
            {ArtificialAirwayType.FaceMask, 0f },
            {ArtificialAirwayType.LaryngealMask, 0f },
        };

        public static readonly float InsertUrinaryCatheter = 0f;
        public static readonly float InsertCerebralShunt = 0f;
        public static readonly float SampleShuntCSF = 0f;
        public static readonly float PerformLumbarPuncture = 0f;
        #endregion
    }
}
