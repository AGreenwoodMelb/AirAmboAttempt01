using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientBones;
using PatientManagementSystem.Patients.PatientInfection;
using PatientManagementSystem.Patients.PatientAccessPoints;
using PatientManagementSystem.Patients.PatientOrgans;
using System.Collections.Generic;
using PatientManagementSystem.Patients.PatientPhysical;

namespace PatientManagementSystem.Patients.ExaminationResults
{
    public class PatientExamResults
    {
        public object tempOutput; //Default dumping variable

        //General
        public Anthropometrics Anthropometrics;
        public PatientExamResultsVitals Vitals = new PatientExamResultsVitals();
        public PatientExamResultsBlood Blood = new PatientExamResultsBlood();
        public PatientExamResultsAccessPoints AccessPoints = new PatientExamResultsAccessPoints();

        //Skeletal
        public PatientExamResultsXRays XRays = new PatientExamResultsXRays();

        //Head
        public PatientExamResultsBrain Brain = new PatientExamResultsBrain();

        //Chest
        public PatientExamResultsRespiratorySystem RespiratorySystem = new PatientExamResultsRespiratorySystem();
        public PatientExamResultsHeart Heart = new PatientExamResultsHeart();

        //Abdo
        public PatientExamResultsLiver Liver = new PatientExamResultsLiver();
        public PatientExamResultsPancreas Pancreas = new PatientExamResultsPancreas();
        public PatientExamResultsSpleen Spleen = new PatientExamResultsSpleen();
        public PatientExamResultsGastrointestinalTract GastrointestinalTract = new PatientExamResultsGastrointestinalTract();
        public PatientExamResultsUrinaryTract UrinaryTract = new PatientExamResultsUrinaryTract();
        public PatientExamResultsReproductives Reproductives = new PatientExamResultsReproductives();
    } //TODO: Expand and complete all OrganResult classes


    #region XRaysResults
    public class PatientExamResultsXRays
    {
        public PatientXRayHead Head = new PatientXRayHead();
        public PatientXRayChest Chest = new PatientXRayChest();
        public PatientXRayAbdomen Abdomen = new PatientXRayAbdomen();
        public PatientXRayArm LeftArm = new PatientXRayArm();
        public PatientXRayArm RightArm = new PatientXRayArm();
        public PatientXRayLeg LeftLeg = new PatientXRayLeg();
        public PatientXRayLeg RightLeg = new PatientXRayLeg();

        #region Classes
        public abstract class PatientXRays
        {
            public Bone[] bones;
        }
        public class PatientXRayHead : PatientXRays
        {

            //Insert Other relevant Xray details here 
        }
        public class PatientXRayChest : PatientXRays
        {
            //Insert other relevant XRay details here
            public bool HasIV;
        }
        public class PatientXRayAbdomen : PatientXRays
        {
            //Insert Other relevant XRay details here
        }
        public class PatientXRayArm : PatientXRays
        {
            public bool HasIV;
        }
        public class PatientXRayLeg : PatientXRays
        {
            public bool HasIV;
        }
        #endregion
    }
    #endregion

    #region BrainResults
    public class PatientExamResultsBrain
    {
        public bool isBrainDead;
        public bool isSeizing;
        public bool isIschaemic;
        public BleedingSeverity isBleeding;

        public Brain.CSFProfile CSF;
        public Brain.CSFProfile latestCSFResults;
        public bool hasCSFSample;

        public Infection currentInfection; //Should this be allowed? Or should the player have to determine it from the CSF?
        public float currentPressure;
    }


    #endregion

    #region HeartResults
    public class PatientExamResultsHeart
    {
        //ECG Results:
        public int BeatsPerMinute; //Should this be moved to a Vitals object?
        public bool IsBeating = true;
        public bool IsArrythmic;
        public bool HasPacemaker;
        public OrganSize HeartSize;


        public HeartTissues Echocardiogram;
        public HeartVessels CoronaryAngiogram;

    } //TODO: Expand to accomodate the results of the different heart scans
    #endregion

    #region LungsResults
    public class PatientExamResultsRespiratorySystem
    {
        public PatientExamResultLeftLung LeftLung = new PatientExamResultLeftLung();
        public PatientExamResultRightLung RightLung = new PatientExamResultRightLung();

        public string tempSputumSample;

        #region Classes
        public abstract class PatientExamResultsLung
        {
            //infection stuff //This should be in a base PatientExamResultsOrgan class
            //Bleeding stuff? //This should be in a base PatientExamResultsOrgan class
        }

        public class PatientExamResultLeftLung : PatientExamResultsLung
        {
            public Dictionary<LungLobeLocation, LungBreathSounds> BreathSounds = new Dictionary<LungLobeLocation, LungBreathSounds>()
            {
                {LungLobeLocation.Upper,LungBreathSounds.Unknown },
                {LungLobeLocation.Middle,LungBreathSounds.Unknown },
                {LungLobeLocation.Lower,LungBreathSounds.Unknown },
            };
            public Dictionary<LungLobeLocation, LungPrecussionSounds> PrecussionSounds = new Dictionary<LungLobeLocation, LungPrecussionSounds>()
            {
                {LungLobeLocation.Upper,LungPrecussionSounds.Unknown },
                {LungLobeLocation.Middle,LungPrecussionSounds.Unknown },
                {LungLobeLocation.Lower,LungPrecussionSounds.Unknown },
            };
        }

        public class PatientExamResultRightLung : PatientExamResultsLung
        {
            public Dictionary<LungLobeLocation, LungBreathSounds> BreathSounds = new Dictionary<LungLobeLocation, LungBreathSounds>()
            {
                {LungLobeLocation.Upper,LungBreathSounds.Unknown },
                {LungLobeLocation.Lower,LungBreathSounds.Unknown },
            };

            public Dictionary<LungLobeLocation, LungPrecussionSounds> PrecussionSounds = new Dictionary<LungLobeLocation, LungPrecussionSounds>()
            {
                {LungLobeLocation.Upper,LungPrecussionSounds.Unknown },
                {LungLobeLocation.Lower,LungPrecussionSounds.Unknown },
            };
        }
        #endregion
    }
    #endregion

    #region LiverResults
    public class PatientExamResultsLiver
    {

    }
    #endregion

    #region PancreasResults
    public class PatientExamResultsPancreas
    {

    }
    #endregion

    #region SpleenResults
    public class PatientExamResultsSpleen
    {

    }
    #endregion

    #region GITractResults
    public class PatientExamResultsGastrointestinalTract
    {

    }
    #endregion

    #region UrinaryTractResults
    public class PatientExamResultsUrinaryTract 
    {
        public PatientResultsKidney LeftKidney = new PatientResultsKidney();
        public PatientResultsKidney RightKidney = new PatientResultsKidney();

        public PatientResultsBladder Bladder = new PatientResultsBladder();

        #region Classes


        public class PatientResultsKidney : StoneForming
        {
            public bool IsUreterBlocked;
            public bool IsRemoved;
        }

        public class PatientResultsBladder : StoneForming
        {
            public float CurrentBladderVolume;
            public bool IsUrethraBlocked;
            public FluidUrine UrineSample; //Dont know about how to solve this one yet
        }
        #endregion
    }
    #endregion

    #region ReproductivesResults
    public class PatientExamResultsReproductives
    {
        public Gender SexOrgans;
    }
    #endregion

    #region BloodResults
    public class PatientExamResultsBlood
    {
        public BloodType BloodType;
        public float ClottingFactors;
    }
    #endregion

    #region GeneralResults
    public class PatientExamResultsVitals
    {
        public float? RespiratoryRate = null;
        public float? OxygenSaturation = null;
        public float? HeartRate = null;
        public float? BloodPressure = null;
        public float? BodyTemperature = null;
    } //REVIEW: What am I doing with nullable floats?
    #endregion

    #region AccesPoints
    public class PatientExamResultsAccessPoints
    {
        public PatientExamResultsCerebralShunt CerebralShunt = new PatientExamResultsCerebralShunt();
        public PatientExamResultsArtificialAirway ArtificialAirway = new PatientExamResultsArtificialAirway();
        public Dictionary<IVTargetLocation, PatientExamResultsIV> IVs = new Dictionary<IVTargetLocation, PatientExamResultsIV>()
            {
                {IVTargetLocation.ArmLeft, new PatientExamResultsIV() },
                {IVTargetLocation.ArmRight, new PatientExamResultsIV() },
                {IVTargetLocation.LegLeft, new PatientExamResultsIV() },
                {IVTargetLocation.LegRight, new PatientExamResultsIV() },
                {IVTargetLocation.CentralLine, new PatientExamResultsIV() },
            };
        public PatientExamResultsUrinaryCatheter UrinaryCatheter = new PatientExamResultsUrinaryCatheter();

        public abstract class PatientExamResultsAccessPoint
        {
            public bool IsInserted;
            public bool IsBlocked;

            public InfectionSeverity Infection;
        }

        public class PatientExamResultsCerebralShunt : PatientExamResultsAccessPoint
        {

        }
        public class PatientExamResultsArtificialAirway : PatientExamResultsAccessPoint
        {

        }
        public class PatientExamResultsIV : PatientExamResultsAccessPoint
        {

        }
        public class PatientExamResultsUrinaryCatheter : PatientExamResultsAccessPoint
        {

        }
    }
    #endregion

    #region Abstracts
    //Pancreas, Liver, Kidney, Bladder, ??
    public abstract class StoneForming
    {
        public bool HasStones;
        public InfectionSeverity Infection; //May end up changing these to full infection objects later
    }
    #endregion
}
