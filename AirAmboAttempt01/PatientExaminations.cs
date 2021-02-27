using System;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientInfection;
using PatientManagementSystem.Patients.PatientBones;
using PatientManagementSystem.Patients.PatientInterventions;
using PatientManagementSystem.Patients.PatientOrgans;
using PatientManagementSystem.Patients.ExaminationResults;
using PatientManagementSystem.Patients.PatientAccessPoints;
using PatientManagementSystem.Patients.PatientDefaults;

namespace PatientManagementSystem.Patients.PatientExaminations
{
    public abstract class PatientExamination : PatientIntervention
    {
        //public float WasteProduced { get; protected set; }
        public abstract bool Examine(Patient patient, PatientExamResults results);
        public override bool Intervene(Patient patient, PatientExamResults results, out bool Succeed)
        {
            Succeed = true;
            return Examine(patient, results);
        }
    }

    public class ExamineBloodVolumeRatio : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            results.Vitals.BloodPressure = patient.Body.Blood.Volume / patient.Body.Blood._defaultBloodSystemVolume;
            return true;
        }
    } //TODO: Replace with Blood Pressure Examination calc

    #region GeneralExams
    public class ExamineSkeleton : PatientExamination
    {
        private BodyRegion _target;
        private Patient _patient;
        private PatientExamResults _results;

        public ExamineSkeleton(BodyRegion target)
        {
            _target = target;
        }

        public override bool Examine(Patient patient, PatientExamResults results)
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
        }

        private void XRayHead()
        {
            _results.XRays.Head.bones = (Bone[])_patient.Body.Head.Bones.Clone();
        }

        private void XRayChest()
        {
            _results.XRays.Chest.bones = (Bone[])_patient.Body.Chest.Bones.Clone();
            _results.XRays.Chest.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.CentralLine].IsInserted;
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
                    _results.XRays.LeftArm.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.ArmLeft].IsInserted;
                    break;
                case BodyRegion.RightArm:
                    _results.XRays.RightArm.bones = (Bone[])_patient.Body.Limbs.Arms.RightArm.Bones.Clone();
                    _results.XRays.RightArm.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.ArmRight].IsInserted;
                    break;
                case BodyRegion.LeftLeg:
                    _results.XRays.LeftLeg.bones = (Bone[])_patient.Body.Limbs.Legs.LeftLeg.Bones.Clone();
                    _results.XRays.LeftLeg.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.LegLeft].IsInserted;
                    break;
                case BodyRegion.RightLeg:
                    _results.XRays.RightLeg.bones = (Bone[])_patient.Body.Limbs.Legs.RightLeg.Bones.Clone();
                    _results.XRays.RightLeg.HasIV = _patient.AccessPoints.IVs[IVTargetLocation.LegRight].IsInserted;
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

    public class ExamineOrgan : PatientExamination
    {
        private OrganName _organ;
        private Patient _patient;
        private PatientExamResults _results;

        public ExamineOrgan(OrganName organ)
        {
            _organ = organ;
        }

        public override bool Examine(Patient patient, PatientExamResults results)
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
                    //LUXURY: For adding custom organs? Execute some kind of event to which custom organ examination have been added? 
                    break;
                default:
                    throw new ArgumentException(message: $"ExamineOrgan::Examine: Unhandled OrganName: {_organ}");
            }

            return true;
        }
        #region SpecificExamineFunctions
        #region Head
        private void ExamineBrain()
        {
            //TODO: Expand this to check Brain related Variables
            /*Brain:
             * Vessels: Blockages (Cerebral Angiogram)
             * Intracranial Pressure:
             * Haemorrhage:
             * Inflammation
             */
        }
        #endregion
        #region Chest
        private void ExamineHeart()
        {
            //TODO: Expand this to Check Heart related variables 
            /* Heart:
             * Vessels: Narrowings or occulsions (Coronary Angiogram)
             * Walls: Ischaemia (signs of previous Myocardial Infarctions) (Echocardiogram)
             * Size: (Heart Failure)
             * Inflammation
             */

            //POOOOOOOOO
        }

        private void ExamineLung(bool isLeft) //LATER: Update once Lung reworked
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
            _results.UrinaryTract.Bladder.CurrentBladderVolume = _patient.Body.Abdomen.UrinaryTract.Bladder.CurrentVolume;
            //Should show stones too
        }

        private void ExamineReproductives()
        {
            _results.Reproductives.SexOrgans = _patient.Body.Abdomen.Reproductives.GetOrgansSex();
        }
        #endregion
        #endregion
    } //TODO: Slowly break each OrganExamination into specific Examinations of that particular part of the organ with the end goal of removing this method entirely.
    #endregion

    #region HeadExams
    public class ExamineBrainEEG : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            results.Brain.isBrainDead = patient.Body.Head.Brain.IsBrainDead;
            results.Brain.isSeizing = patient.Body.Head.Brain.IsSeizing;
            return true;
        }
    } //Checks for brain death or seizures

    public class ExamineBrainCT : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            results.Brain.isIschaemic = patient.Body.Head.Brain.IsIschaemic; //Eventually replace with Vessels related stuff
            results.Brain.isBleeding = patient.Body.Head.Brain.IsBleeding;
            results.Brain.currentPressure = patient.Body.Head.Brain.CurrentPressure;
            results.Brain.currentInfection.InfectionLevel = patient.Body.Infections.Head.Brain.InfectionLevel;
            return true;
        }
    } //Checks for Hyper/hypo perfused areas as well as extravascular blood, also shows inflammation

    public class ExamineCSF : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!patient.Flags.hasCSFSample)
                return false;

            results.Brain.CSF = patient.Body.Head.Brain.CSF;
            return true;
        }
    }
    #endregion

    #region HeartExams
    public class ExamineHeartRate : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            results.Vitals.HeartRate = patient.Body.Chest.Heart.BeatsPerMinute;
            return true;
        }
    }

    public class ExamineHeartECG : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            results.Heart.BeatsPerMinute = patient.Body.Chest.Heart.BeatsPerMinute;
            results.Heart.HasPacemaker = patient.Body.Chest.Heart.HasPaceMaker;
            results.Heart.IsArrythmic = patient.Body.Chest.Heart.IsArrythmic;
            results.Heart.IsBeating = patient.Body.Chest.Heart.IsBeating;

            return true;
        }
    }

    public class ExamineHeartCoronaryAngiogram : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            //Left Coronary Arteries
            results.Heart.CoronaryAngiogram.LCA = patient.Body.Chest.Heart.HeartStructures.Vessels.LCA;
            results.Heart.CoronaryAngiogram.LAD = patient.Body.Chest.Heart.HeartStructures.Vessels.LAD;
            results.Heart.CoronaryAngiogram.LCircA = patient.Body.Chest.Heart.HeartStructures.Vessels.LCircA;

            //Right Coronary Arteries
            results.Heart.CoronaryAngiogram.RCA = patient.Body.Chest.Heart.HeartStructures.Vessels.RCA;
            results.Heart.CoronaryAngiogram.PDA = patient.Body.Chest.Heart.HeartStructures.Vessels.PDA;
            results.Heart.CoronaryAngiogram.RMA = patient.Body.Chest.Heart.HeartStructures.Vessels.RMA;

            return true;
        }
    }//This is coupled into an intervention to allow for stenting and ballooning

    public class ExamineHeartEchocardiogram : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            results.Heart.Echocardiogram.Septum = patient.Body.Chest.Heart.HeartStructures.Tissues.Septum;
            results.Heart.Echocardiogram.LeftAnteriorWall = patient.Body.Chest.Heart.HeartStructures.Tissues.LeftAnteriorWall;
            results.Heart.Echocardiogram.LeftPosteriorInferiorWall = patient.Body.Chest.Heart.HeartStructures.Tissues.LeftPosteriorInferiorWall;
            results.Heart.Echocardiogram.FreeWall = patient.Body.Chest.Heart.HeartStructures.Tissues.FreeWall;
            results.Heart.Echocardiogram.RightVentricle = patient.Body.Chest.Heart.HeartStructures.Tissues.RightVentricle;

            results.Heart.HeartSize = patient.Body.Chest.Heart.HeartSize;

            return true;
        }
    }//This is the basic scan done quickly and without Pain, Chance of Infection, requiring intervention
    #endregion

    #region LungsExams
    public class ExamineRespiratoryRate : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            results.Vitals.RespiratoryRate = patient.Body.Chest.Lungs.RespiratoryRate;
            return true;
        }
    }

    public class ExamineOxygenSaturation : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            results.Vitals.OxygenSaturation = patient.Body.Chest.Lungs.OxygenSaturation;
            return true;
        }
    }

    public class ExamineSputumSample : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            //This should return an average picture of the lungs infection state
            throw new NotImplementedException();
        }
    }//TODO: Implement all the required background fields

    public class ExamineBronchoscopySample : PatientExamination
    {
        private bool _targetLeftLung;
        private string _targetLobeLocation; //TODO: Replace type with appropriate enum?
        public ExamineBronchoscopySample(bool targetLeftLung, string temp_targetLobeLocation)
        {
            _targetLeftLung = targetLeftLung;
            _targetLobeLocation = temp_targetLobeLocation;
        }

        public override bool Examine(Patient patient, PatientExamResults results)
        {
            //This should return a picture of the specific target lobe's infection state
            throw new NotImplementedException();
        }
    } //TODO: Implement all the required bacground field and appropriate enum for _targetLobeLocation


    #region Auscultation
    public class ExamineLungsAuscultateLungs : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            new ExamineLungsAuscultateLung(true);
            new ExamineLungsAuscultateLung(false);
            return true;
        }
    }

    public class ExamineLungsAuscultateLung : PatientExamination
    {
        private bool _targetLeftLung;

        public ExamineLungsAuscultateLung(bool targetLeftLung)
        {
            _targetLeftLung = targetLeftLung;
        }

        public override bool Examine(Patient patient, PatientExamResults results)
        {
            new ExamineLungsAuscultateLungLobe(_targetLeftLung, "UpperLobe").Examine(patient, results);
            if (_targetLeftLung)
                new ExamineLungsAuscultateLungLobe(_targetLeftLung, "MiddleLobe").Examine(patient, results);
            new ExamineLungsAuscultateLungLobe(_targetLeftLung, "LowerLobe").Examine(patient, results);

            return true;
        }
    }

    public class ExamineLungsAuscultateLungLobe : PatientExamination
    {
        private bool _targetLeftLung;
        private string _targetLobe; //Replace string with appropriate enum?

        public ExamineLungsAuscultateLungLobe(bool targetLeftLung, string targetLobe) //Replace string with appropriate enum?
        {
            _targetLeftLung = targetLeftLung;
            _targetLobe = targetLobe;
        }

        public override bool Examine(Patient patient, PatientExamResults results)
        {
            //results.Lungs.targetLung.targetLobe = patient.Body.Chest.Lungs.targetLung.targetLobe.GetBreathSounds()
            //return true;
            throw new NotImplementedException();
        }
    } //TODO: Finish Implementing ExamineLungAuscultateLungLobe once Lung has been reworked and PatientExamResultsLungs updated
    #endregion


    #endregion

    #region TEMPNAME-LiverPancreas
    public class ExamineHepatobiliaryTree : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            //Check Liver and Pancreas for stones
            return true;
        }
    }
    #endregion

    #region UrinaryTractExams
    public class ExamineKidneyScan : PatientExamination
    {
        private bool _isLeft;

        public ExamineKidneyScan(bool isLeft)
        {
            _isLeft = isLeft;
        }

        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (_isLeft)
            {
                if (patient.Body.Abdomen.UrinaryTract.LeftKidney.OrganState == OrganState.Removed)
                {
                    results.UrinaryTract.LeftKidney.IsRemoved = true;
                    return true;
                }

                results.UrinaryTract.LeftKidney.IsRemoved = false;
                results.UrinaryTract.LeftKidney.HasStones = patient.Body.Abdomen.UrinaryTract.LeftKidney.HasStone;
                results.UrinaryTract.LeftKidney.IsUreterBlocked = patient.Body.Abdomen.UrinaryTract.LeftKidney.IsUreterBlocked;
                results.UrinaryTract.LeftKidney.Infection = patient.Body.Infections.Abdomen.LeftKidney.Severity;

            }
            else
            {
                if (patient.Body.Abdomen.UrinaryTract.RightKidney.OrganState == OrganState.Removed)
                {
                    results.UrinaryTract.RightKidney.IsRemoved = true;
                    return true;
                }

                results.UrinaryTract.RightKidney.IsRemoved = false;
                results.UrinaryTract.RightKidney.HasStones = patient.Body.Abdomen.UrinaryTract.RightKidney.HasStone;
                results.UrinaryTract.RightKidney.IsUreterBlocked = patient.Body.Abdomen.UrinaryTract.RightKidney.IsUreterBlocked;
                results.UrinaryTract.RightKidney.Infection = patient.Body.Infections.Abdomen.RightKidney.Severity;
            }
            return true;
        }//REVIEW: There is probably a more succinct way of doing this
    }
    public class ExamineBladderScan : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            results.UrinaryTract.Bladder.CurrentBladderVolume = patient.Body.Abdomen.UrinaryTract.Bladder.CurrentVolume;
            results.UrinaryTract.Bladder.HasStones = patient.Body.Abdomen.UrinaryTract.Bladder.HasStones;
            results.UrinaryTract.Bladder.IsUrethraBlocked = patient.Body.Abdomen.UrinaryTract.Bladder.IsUrethraBlocked;
            results.AccessPoints.UrinaryCatheter.IsInserted = patient.AccessPoints.UrinaryCatheter.IsInserted;
            //REVIEW: Does BladderScane need anything else?
            return true;
        }
    } //TODO: Handle WasteProduction

    public class Urinalysis : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!patient.AccessPoints.UrinaryCatheter.IsInserted || patient.Body.Abdomen.UrinaryTract.Bladder.IsUrethraBlocked)
                return false;
            //Update results a urine sample result
            return true;
        }
    }//TODO: Create UrinalysisResult and assigin it to results;
    #endregion

    #region BloodExams

    public abstract class ExamineBlood : PatientExamination
    {
        public bool CheckForIVAccess(Patient patient)
        {
            return patient.AccessPoints.HasIVAccess;
        }
    }
    public class ExamineBloodType : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            results.Blood.BloodType = patient.Body.Blood.bloodType;
            return true;
        }
    }

    public class ExamineBloodClottingFactors : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            results.Blood.ClottingFactors = patient.Body.Blood.FluidProfile.ClottingFactor;
            return true;
        }
    }

    public class ExamineBloodLiverFunctions : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

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

    public class ExamineBloodCardiacMarkers : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodPSA : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodBetaHCG : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodBloodSugarLevel : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodCRP : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodCultures : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodElectrolytes : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodIllicitDrugScreen : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodKidneyFunctions : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;
            throw new NotImplementedException();
        }
    }

    #region CopyPastey
    public class TEMP_ExamineBlood : ExamineBlood
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!CheckForIVAccess(patient))
                return false;
            throw new NotImplementedException();
        }
    }
    #endregion
    #endregion

    #region AccessPointsExams
    public class ExamineIV : PatientExamination
    {
        private IVTargetLocation _target;

        public ExamineIV(IVTargetLocation target)
        {
            _target = target;
        }

        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!patient.AccessPoints.IVs[_target].IsInserted)
                return false;

            results.AccessPoints.IVs[_target].IsBlocked = patient.AccessPoints.IVs[_target].IsBlocked;
            results.AccessPoints.IVs[_target].Infection = patient.Body.Infections.AccessPoints.IVs[_target].Severity;
            return true;
        }
    }
    public class ExamineUrinaryCatheter : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!patient.AccessPoints.UrinaryCatheter.IsInserted)
                return false;

            results.AccessPoints.UrinaryCatheter.IsBlocked = patient.AccessPoints.UrinaryCatheter.IsBlocked;
            results.AccessPoints.UrinaryCatheter.Infection = patient.Body.Infections.AccessPoints.UrinaryCatheter.Severity;
            return true;
        }
    }
    public class ExamineCerebralShunt : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!patient.AccessPoints.CerebralShunt.IsInserted)
                return false;

            results.AccessPoints.CerebralShunt.IsBlocked = patient.AccessPoints.CerebralShunt.IsBlocked;
            results.AccessPoints.CerebralShunt.Infection = patient.Body.Infections.AccessPoints.CerebralShunt.Severity;
            return true;
        }
    }
    public class ExamineArtificialAirway : PatientExamination
    {
        public override bool Examine(Patient patient, PatientExamResults results)
        {
            if (!patient.AccessPoints.ArtificialAirway.IsInserted)
                return false;

            results.AccessPoints.ArtificialAirway.IsBlocked = patient.AccessPoints.ArtificialAirway.IsBlocked;
            results.AccessPoints.ArtificialAirway.Infection = patient.Body.Infections.AccessPoints.ArtificialAirway.Severity;
            return true;
        }
    }

    #endregion
}