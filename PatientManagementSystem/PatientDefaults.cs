using PatientManagementSystem.Patients.PatientAccessPoints;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientBones;
using PatientManagementSystem.Patients.PatientOrgans;
using PatientManagementSystem.Patients.PatientInfection;
using PatientManagementSystem.Patients.PatientDrugs;
using System.Collections.Generic;
using System.Linq;
using System;
using PatientManagementSystem.Patients.Vascular;

namespace PatientManagementSystem.Patients.PatientDefaults
{
    public static class DefaultPatientMetrics
    {
        //Age (years)
        public static readonly int DefaultAge = 21;
        public static readonly int MinAge = 18;
        public static readonly int MaxAge = 200;


        //The below values are pretty much arbitrarily picked
        //Height (cm)
        public static readonly float DefaultHeight = 175;
        public static readonly float MinHeight = 134;
        public static readonly float MaxHeight = 200;

        //Weight (kgs)
        public static readonly float DefaultWeight = 70;
        public static readonly float MinWeight = 30;
        public static readonly float MaxWeight = 150;
    }

    public static class DefaultBloodLossBaseRates
    {
        public static readonly float Superficial = 1f;

        public static readonly Dictionary<BleedingSeverity, float> LookupBleedingSeverityMultiplier = new Dictionary<BleedingSeverity, float>()
        {
            { BleedingSeverity.None, 0},
            { BleedingSeverity.Mild, 0.5f},
            { BleedingSeverity.Moderate, 1f},
            { BleedingSeverity.Severe, 2f},
            { BleedingSeverity.Extreme, 2.5f}
        };
    }

    public static class DefaultOrgans
    {
        public static readonly (OrganState, float)[] OrganStateLookup = new (OrganState, float)[]
        {
            (OrganState.None,-1.0f),
            (OrganState.Removed,0.0f),
            (OrganState.Destroyed,0.10f),
            (OrganState.Damaged,0.30f),
            (OrganState.Impaired,0.70f),
            (OrganState.Normal,1.0f),
        };

        #region Head
        public static class DefaultBrain
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        #endregion

        #region Chest
        public static class DefaultRespiratorySystem
        {
            //Organ Specific
            public static readonly int RespirationRatePerMinute = 16;
            public static readonly float LobeOxygenProductionPerBreath = 100f;

            //Oxygen
            public static readonly float LobeOxygenRequirement = 1f;

            //Blood
            public static readonly float LobePerfusionRequirement = 1f;
            public static readonly float LobeBloodLossRate = 1f;
        }
        public static class DefaultHeart
        {
            //Organ Specific
            public static readonly int HeartRate = 60;
            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        #endregion

        #region Abdomen
        public static class DefaultGI
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        public static class DefaultKidney
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        public static class DefaultBladder
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        public static class DefaultLiver
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        public static class DefaultPancreas
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        public static class DefaultSpleen
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        public static class DefaultReproductive_Female
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        public static class DefaultReproductive_Male
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
        #endregion

        public static class DefaultCOPYPASTE
        {
            //Organ Specific

            //Oxygen
            public static readonly float OxygenRequirement = 1f;

            //Blood
            public static readonly float PerfusionRequirement = 1f;
            public static readonly float BloodLossRate = 1f;
        }
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
        public static readonly float PerformLumbarPuncture = 100f;
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

    public static class DefaulVascularSystem
    {
        public static readonly string OxygenatedSource = "AscendingAorta";
        public static readonly string DeoxygenatedSource = "PulmonaryTrunk";

        public static Dictionary<string, Vessel> SetupOxygenatedVessels()
        {
            #region LeftVentricle (Oxygenated) (28: (3 + 4 + 5 + 3 + 13))
            Vessel AscendingAorta = new Vessel(OxygenatedSource);

            #region Coronary (4)
            Vessel LeftCoronary = new Vessel("LeftCoronary", AscendingAorta);
            Vessel LeftAnteriorDescending = new Vessel("LeftAnteriorDescending", LeftCoronary);
            Vessel Circumflex = new Vessel("Circumflex", LeftCoronary);
            Vessel RightCoronary = new Vessel("RightCoronary", AscendingAorta);
            #endregion

            Vessel AorticArch = new Vessel("AorticArch", AscendingAorta);

            #region Brachiocephalic (5: (3 + 2))
            Vessel Brachiocephalic = new Vessel("Brachiocephalic", AorticArch);

            #region Head (3)
            Vessel RightCommonCarotid = new Vessel("RightCommonCarotid", Brachiocephalic);
            Vessel RightInternalCarotid = new Vessel("RightInternalCarotid", RightCommonCarotid); //Brain Supply
            Vessel RightExternalCarotid = new Vessel("RightExternalCarotid", RightCommonCarotid); //Face Supply
            #endregion

            Vessel RightSubclavian = new Vessel("RightSubclavian", Brachiocephalic);
            #endregion

            #region LeftCarotid (3)
            Vessel LeftCommonCarotid = new Vessel("LeftCommonCarotid", AorticArch);
            Vessel LeftInternalCarotid = new Vessel("LeftInternalCarotid", LeftCommonCarotid); //Brain Supply
            Vessel LeftExternalCarotid = new Vessel("LeftExternalCarotid", LeftCommonCarotid); //Face Supply
            #endregion

            Vessel LeftSubclavian = new Vessel("LeftSubclavian", AorticArch);

            #region DescendingAorta (13: (11 + 2))
            Vessel DescendingAorta = new Vessel("DescendingAorta", AorticArch);
            Vessel Bronchial = new Vessel("Bronchial", DescendingAorta);

            #region AbdominalAorta (11: (7 + 4))
            Vessel AbdominalAorta = new Vessel("AbdominalAorta", DescendingAorta);

            #region Celiac (4)
            Vessel Celiac = new Vessel("Celiac", AbdominalAorta);
            Vessel Gastric = new Vessel("Gastric", Celiac);
            Vessel Hepatic = new Vessel("Hepatic", Celiac);
            Vessel Splenic = new Vessel("Splenic", Celiac);
            #endregion
            Vessel SuperiorMesenteric = new Vessel("SuperiorMesenteric", AbdominalAorta);
            Vessel LeftRenal = new Vessel("LeftRenal", AbdominalAorta);
            Vessel RightRenal = new Vessel("RightRenal", AbdominalAorta);
            Vessel InferiorMesenteric = new Vessel("InferiorMesenteric", AbdominalAorta);

            Vessel LeftCommonIliac = new Vessel("LeftCommonIliac", AbdominalAorta);
            Vessel RightCommonIliac = new Vessel("RightCommonIliac", AbdominalAorta);
            #endregion
            #endregion
            #endregion

            return new Vessel[]
            {
                AscendingAorta,

                LeftCoronary,
                LeftAnteriorDescending,
                Circumflex,
                RightCoronary,

                AorticArch,

                Brachiocephalic,

                RightCommonCarotid,
                RightInternalCarotid,
                RightExternalCarotid,

                RightSubclavian,

                LeftCommonCarotid,
                LeftInternalCarotid,
                LeftExternalCarotid,

                LeftSubclavian,

                DescendingAorta,
                Bronchial,

                AbdominalAorta,

                Celiac,
                Gastric,
                Hepatic,
                Splenic,

                SuperiorMesenteric,
                LeftRenal,
                RightRenal,
                InferiorMesenteric,

                LeftCommonIliac,
                RightCommonIliac
            }.ToDictionary(vessel => vessel.Name);
        }

        public static Dictionary<string, Vessel> SetupDeoxygenatedVessels()
        {
            #region RightVentricle (Deoxygenated)
            Vessel PulmonaryTrunk = new Vessel(DeoxygenatedSource);

            Vessel RightCommonPulmonary = new Vessel("RightCommonPulmonary", PulmonaryTrunk);
            Vessel RightLobarUpper = new Vessel("RightLobarUpper", RightCommonPulmonary); //Truncus Anterior
            Vessel RightLobarMiddle = new Vessel("RightLobarMiddle", RightCommonPulmonary);
            Vessel RightLobarLower = new Vessel("RightLobarLower", RightCommonPulmonary);

            Vessel LeftCommonPulmonary = new Vessel("LeftCommonPulmonary", PulmonaryTrunk);
            Vessel LeftLobarUpper = new Vessel("LeftLobarUpper", LeftCommonPulmonary); //Truncus Anterior
            Vessel LeftLobarLower = new Vessel("LeftLobarLower", LeftCommonPulmonary);
            #endregion

            return new Vessel[] {
                PulmonaryTrunk,

                RightCommonPulmonary,
                RightLobarUpper,
                RightLobarMiddle,
                RightLobarLower,

                LeftCommonPulmonary,
                LeftLobarUpper,
                LeftLobarLower,
            }.ToDictionary(vessel => vessel.Name);

        }
    }

    public static class DefaultOrganStructure
    {
        #region Head
        public static readonly OrganStructure[] Brain =
        {
            new OrganStructure("LeftHemisphere","LeftInternalCarotid"),
            new OrganStructure("RightHemisphere","RightInternalCarotid"),
        };
        #endregion
        #region Chest
        public static readonly OrganStructure[] Heart = new OrganStructure[]
        {
            new OrganStructure("LeftAnteriorWall","LeftAnteriorDescending"), //Failure causes output problems
            new OrganStructure("LeftPosteriorWall","Circumflex"), //Failure cause Pulmonary Congestion
            new OrganStructure("SinoAtrialNode","RightCoronary"), //Failure causes Rythym problems
            new OrganStructure("RightVentrical","RightCoronary"), //Failure causes RightHeart Failure, Peripheral congestion and low 
        };
        public static readonly OrganStructure[] RightLung =
        {
            new OrganStructure("UpperLobe","Bronchial"),
            new OrganStructure("MiddleLobe","Bronchial"),
            new OrganStructure("LowerLobe","Bronchial"),
        };
        public static readonly OrganStructure[] LeftLung =
        {
            new OrganStructure("UpperLobe","Bronchial"),
            new OrganStructure("LowerLobe","Bronchial"),
        };
        #endregion
        #region Abdomen
        public static readonly OrganStructure[] GastrointestianlTract = new OrganStructure[]
        {
            new OrganStructure("Stomach","Gastric"),
            new OrganStructure("SmallIntestines","SuperiorMesenteric"),
            new OrganStructure("LargeIntestines", "InferiorMesenteric"),
        };
        public static readonly OrganStructure[] LeftKidney = new OrganStructure[]
        {
            new OrganStructure("Kidney","LeftRenal"),
        };
        public static readonly OrganStructure[] RightKidney = new OrganStructure[]
          {
            new OrganStructure("Kidney","RightRenal"),
          };
        public static readonly OrganStructure[] Liver = new OrganStructure[]
        {
            new OrganStructure("Liver","Hepatic")
        };
        public static readonly OrganStructure[] Spleen = new OrganStructure[]
        {
            new OrganStructure("Spleen","Splenic")
        };
        public static readonly OrganStructure[] Pancreas = new OrganStructure[]
        {
            new OrganStructure("Pancreas","Splenic")
        };
        public static readonly OrganStructure[] Bladder = new OrganStructure[]
        {
            new OrganStructure("Bladder", "LeftCommonIliac"),
            new OrganStructure("Bladder", "RightCommonIliac"),
        };
        public static readonly OrganStructure[] ReproductivesMale = new OrganStructure[]
        {
            new OrganStructure("ReproductivesMale", "LeftCommonIliac"),
            new OrganStructure("ReproductivesMale", "RightCommonIliac"),
        };
        public static readonly OrganStructure[] ReproductivesFemale = new OrganStructure[]
        {
            new OrganStructure("ReproductivesFemale", "LeftCommonIliac"),
            new OrganStructure("ReproductivesFemale", "RightCommonIliac"),
        };
        #endregion
    }
}