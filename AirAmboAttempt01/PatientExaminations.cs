using System;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientInfection;
using PatientManagementSystem.Patients.PatientBones;
using PatientManagementSystem.Patients.PatientInterventions;
using PatientManagementSystem.Patients.PatientOrgans;

namespace PatientManagementSystem.Patients.PatientExaminations
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
    }
    //TODO: Expand and complete all OrganResult classes
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
            public bool hasKidneyStonesLeft;
            public bool hasKidneyStonesRight;
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
        public Infection currentInfection;
        public CSFProfile latestCSFResults;

        public float currentPressure;
    }

    public class CSFProfile //Perhaps invert this so that CSF is a part of the infection object? But that doesnt handle brain haemorrhage
    {
        public Infection Infection { get; }
        public float Glucose { get; }
        public float Protein { get; }
        public float WhiteCellCount { get; }
        public float RedCellCount { get; }

        public CSFProfile(FluidProfile systemBlood, Infection infection)
        {
            Infection = infection;
            ConfigureValues(systemBlood);
        }

        private void ConfigureValues(FluidProfile systemBlood)
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
    }
    #endregion

    #region LungsResults
    public class PatientExamResultsLungs
    {
        public float RespirationRate;
        public float OxygenSaturation;

        public PatientExamResultsLung LeftLung = new PatientExamResultsLung();
        public PatientExamResultsLung RightLung = new PatientExamResultsLung();

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

    #region IPatientExamintaions

    public interface IPatientExamination
    {
        public virtual bool Examine(Patient patient, ref PatientExamResults results)
        {
            throw new NotImplementedException(message: "IPatientExamination::Examine is not implemented");
        }
    }

    public class ExamineBloodVolumeRatio : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.latestBloodVolumeRatio = patient.Body.Blood.Volume / patient.Body.Blood._defaultBloodSystemVolume;
            return true;
        }
    } //TODO: Replace with Blood Pressure Examination

    public class ExamineXRay : IPatientExamination
    {
        private BodyRegion _target;
        private Patient _patient;
        private PatientExamResults _results;

        public ExamineXRay(BodyRegion target)
        {
            _target = target;
        }

        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            _patient = patient;
            _results = results;

            switch (_target)
            {
                case BodyRegion.None:
                    return false;
                case BodyRegion.Head:
                    XRayHead();
                    break;
                case BodyRegion.Chest:
                    XRayChest();
                    break;
                case BodyRegion.Abdomen:
                    XRayAbdomen();
                    break;
                case BodyRegion.LeftArm:
                case BodyRegion.RightArm:
                case BodyRegion.LeftLeg:
                case BodyRegion.RightLeg:
                    XRayLimb(_target);
                    break;
                default:
                    throw new ArgumentException($"GetXRay::Examine Unhandled BodyRegion: {nameof(_target)}");
            }
            return true;
        } //Rename to BoneScan? That way I dont have to report gallstones or other organ abnormalities commonly found on XRays

        private void XRayHead()
        {
            _results.XRays.Head.bones = (Bone[])_patient.Body.Head.Bones.Clone();
        }

        private void XRayChest()
        {
            _results.XRays.Chest.bones = (Bone[])_patient.Body.Chest.Bones.Clone();
            _results.XRays.Chest.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.CentralLine] != null;
        }

        private void XRayAbdomen()
        {
            _results.XRays.Abdomen.bones = (Bone[])_patient.Body.Abdomen.Bones.Clone();
        }

        private void XRayLimb(BodyRegion target)
        {
            switch (target)
            {
                case BodyRegion.LeftArm:
                    _results.XRays.LeftArm.bones = (Bone[])_patient.Body.Limbs.Arms.LeftArm.Bones.Clone();
                    _results.XRays.LeftArm.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.ArmLeft] != null;
                    break;
                case BodyRegion.RightArm:
                    _results.XRays.RightArm.bones = (Bone[])_patient.Body.Limbs.Arms.RightArm.Bones.Clone();
                    _results.XRays.RightArm.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.ArmRight] != null;
                    break;
                case BodyRegion.LeftLeg:
                    _results.XRays.LeftLeg.bones = (Bone[])_patient.Body.Limbs.Legs.LeftLeg.Bones.Clone();
                    _results.XRays.LeftLeg.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.LegLeft] != null;
                    break;
                case BodyRegion.RightLeg:
                    _results.XRays.RightLeg.bones = (Bone[])_patient.Body.Limbs.Legs.RightLeg.Bones.Clone();
                    _results.XRays.RightLeg.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.LegRight] != null;
                    break;
                case BodyRegion.None:
                case BodyRegion.Head:
                case BodyRegion.Chest:
                case BodyRegion.Abdomen:
                default:
                    return;
            }
        }

    }

    public class ExamineOrgan : IPatientExamination
    {
        private OrganName _organ;
        private Patient _patient;
        private PatientExamResults _results;

        public ExamineOrgan(OrganName organ)
        {
            _organ = organ;
        }

        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            _patient = patient;
            _results = results;

            switch (_organ)
            {
                case OrganName.None:
                    return false;
                case OrganName.Brain:
                    ExamineBrain();
                    break;
                case OrganName.Heart:
                    ExamineHeart();
                    break;
                case OrganName.LeftLung:
                    ExamineLung(true);
                    break;
                case OrganName.RightLung:
                    ExamineLung(false);
                    break;
                case OrganName.Liver:
                    ExamineLiver();
                    break;
                case OrganName.Pancreas:
                    ExaminePancreas();
                    break;
                case OrganName.Spleen:
                    ExamineSpleen();
                    break;
                case OrganName.GastrointestinalTract:
                    ExamineGastrointestinalTract();
                    break;
                case OrganName.LeftKidney:
                    ExamineKidney(true);
                    break;
                case OrganName.RightKidney:
                    ExamineKidney(false);
                    break;
                case OrganName.Bladder:
                    ExamineBladder();
                    break;
                case OrganName.Reproductives:
                    ExamineReproductives();
                    break;
                case OrganName.Other:
                    //TODO: (LUXURY CONSIDERATION) For adding custom organs? Execute some kind of event to which custom organ examination have been added? 
                    break;
                default:
                    throw new ArgumentException(message: $"ExamineOrgan::Examine: Unhandled OrganName: {_organ}");
            }

            return true;
        }

        #region Head
        private void ExamineBrain()
        {

        }
        #endregion
        #region Chest
        private void ExamineHeart()
        {
            _results.Heart.Appearance = _patient.Body.Chest.Heart.CurrentInfection.infectionSeverity.ToString(); //Temp return until proper way to describe is found
        }

        private void ExamineLung(bool isLeft)
        {
            if (isLeft)
            {
                _results.Lungs.LeftLung.tempAppearance = _patient.Body.Chest.Lungs.LeftLung.UpperLobe.ToString(); //Temp return until proper way to describe is found
            }
            else
            {
                _results.Lungs.RightLung.tempAppearance = _patient.Body.Chest.Lungs.RightLung.UpperLobe.ToString(); //Temp return until proper way to describe is found
            }
        }
        #endregion
        #region Abdomen
        private void ExamineLiver()
        {
            //Get Liver Results
        }

        private void ExamineGastrointestinalTract()
        {

        }

        private void ExaminePancreas()
        {

        }

        private void ExamineSpleen()
        {

        }

        private void ExamineKidney(bool isLeft)
        {

        }

        private void ExamineBladder()
        {

        }

        private void ExamineReproductives()
        {
            _results.Reproductives.SexOrgans = _patient.Body.Abdomen.Reproductives.GetOrgansSex();
        }
        #endregion
    }

    #region HeadExams
    public class ExamineBrainEEG : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Brain.isBrainDead = patient.Body.Head.Brain.IsBrainDead;
            results.Brain.isSeizing = patient.Body.Head.Brain.IsSeizing;
            return true;
        }
    } //Checks for brain death or seizures

    public class ExamineBrainCT : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Brain.isIschaemic = patient.Body.Head.Brain.IsIschaemic;
            results.Brain.isBleeding = patient.Body.Head.Brain.IsBleeding;
            results.Brain.currentPressure = patient.Body.Head.Brain.CurrentPressure;
            results.Brain.currentInfection.infectionSeverity = patient.Body.Head.Brain.CurrentInfection.infectionSeverity;
            return true;
        }
    } //Checks for Hyper/hypo perfused areas as well as extravascular blood, also shows inflammation

    public class ExamineCerebrospinalFluid : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Brain.latestCSFResults = new CSFProfile(patient.Body.Blood.FluidProfile, patient.Body.Head.Brain.CurrentInfection);
            return true;
        }
    } //Gets the exact nature of any infections that may be present. Does not show blood in csf at the moment 
    #endregion

    #region HeartExams
    public class ExamineHeartRate : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Heart.BeatsPerMinute = patient.Body.Chest.Heart.BeatsPerMinute;
            return true;
        }
    }

    public class ExamineHeartECG : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Heart.BeatsPerMinute = patient.Body.Chest.Heart.BeatsPerMinute;
            results.Heart.HasPacemaker = patient.Body.Chest.Heart.HasPaceMaker;
            results.Heart.IsArrythmic = patient.Body.Chest.Heart.IsArrythmic;
            results.Heart.IsBeating = patient.Body.Chest.Heart.IsBeating;

            return true;
        }
    }
    #endregion

    #region LungsExams
    public class ExamineRespiratoryRate : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Lungs.RespirationRate = patient.Body.Chest.Lungs.RespiratoryRate;
            return true;
        }
    }

    public class ExamineO2Sats : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Lungs.OxygenSaturation = patient.Body.Chest.Lungs.OxygenSaturation;
            return true;
        }
    }

    #endregion

    #region BloodTests
    public class ExamineBloodType : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {

            results.Blood.BloodType = patient.Body.Blood.bloodType;
            return true;
        }
    }

    public class ExamineBloodClottingFactors : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Blood.ClottingFactors = patient.Body.Blood.FluidProfile.ClottingFactor;
            return true;
        }
    }

    public class ExamineBloodLiverFunctions : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            //LIVER DAMAGE MARKERS:
            //ALT - Liver Inflammation (Infection marker)
            //ALP - Bile duct (Gallstones causing blockage)
            //AST - May not bother with this one
            //GGT - Bile Duct related (Probably not needed)

            //LIVER SYNTHETIC FUNCTIONING
            //Albumin - Blood Protein Levels
            //Billirubin
            //Prothrombin Time

            return true;
        }
    }
    #endregion

    #endregion
}