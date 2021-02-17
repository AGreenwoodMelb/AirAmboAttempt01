using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientBones;
using PatientManagementSystem.Patients.PatientInfection;
using System; //Only being used when throwing exception

namespace PatientManagementSystem.Patients.ExaminationResults
{
    public class PatientExamResults
    {
        public string tempOutput; //Default dumping variable
        public float latestBloodVolumeRatio; //TODO: Replace with blood pressure

        //General
        public PatientExamResultsBlood Blood = new PatientExamResultsBlood();
        public PatientExamResultsXRays XRays = new PatientExamResultsXRays();

        //Head
        public PatientExamResultsBrain Brain = new PatientExamResultsBrain();

        //Chest
        public PatientExamResultsLungs Lungs = new PatientExamResultsLungs();
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

        public Infection currentInfection; //Should this be allowed? Or should the player have to determine it from the CSF?
        public CSFProfile latestCSFResults;

        public float currentPressure;
    }

    public class CSFProfile //Perhaps invert this so that CSF is a part of the Infection or Brain Object or Fluid class? 
    {
        public Infection Infection { get; }
        public float Glucose { get; }
        public float Protein { get; }
        public float WhiteCellCount { get; }
        public float RedCellCount { get; }

        public CSFProfile(Infection infection)
        {
            Infection = infection;
            ConfigureValues();
        }

        private void ConfigureValues()
        {
            switch (Infection.infectionType)
            {
                case InfectionType.None:
                    break;
                case InfectionType.Bacterial:
                    break;
                case InfectionType.Viral:
                    break;
                case InfectionType.Prion:
                    break;
                case InfectionType.Other:
                    //TODO: Implement way of passing in CSFProfile values when InfectionType is Other
                    break;
                default:
                    throw new ArgumentException(
                         message: $"CSFProfile::ConfigureValues Unhandled infectionType: {nameof(Infection.infectionType)}"
                         );
            } //TODO: Finish implemented the configuration of CSF values
        }

    }
    #endregion

    #region HeartResults
    public class PatientExamResultsHeart
    {
        //ECG Results:
        public int BeatsPerMinute;
        public bool IsBeating = true;
        public bool IsArrythmic;
        public bool HasPacemaker;

        //Scan Results:
        public string Appearance;
    } //TODO: Expand to accomodate the results of the different heart scans
    #endregion

    #region LungsResults
    public class PatientExamResultsLungs
    {
        public float RespirationRate;
        public float OxygenSaturation;

        public PatientExamResultsLung LeftLung = new PatientExamResultsLung();
        public PatientExamResultsLung RightLung = new PatientExamResultsLung();

        public string tempSputumSample;

        #region Classes
        public class PatientExamResultsLung
        {
            public string tempAppearance;
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
        public bool HasUrinaryCatheter = false;
        public bool IsUreterLeftBlocked = false;
        public bool IsUreterRightBlocked = false;
        public bool IsUrethraBlocked;

        public PatientResultsKidney LeftKidney = new PatientResultsKidney();
        public PatientResultsKidney RightKidney = new PatientResultsKidney();

        public PatientResultsBladder Bladder = new PatientResultsBladder();

        #region Classes
        public class PatientResultsKidney
        {
            public string temp;
        }

        public class PatientResultsBladder
        {
            public float CurrentBladderVolume;
            public FluidUrine UrineSample;
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
}
