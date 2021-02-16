using System;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientInfection;
using PatientManagementSystem.Patients.PatientBones;
using PatientManagementSystem.Patients.PatientInterventions;
using PatientManagementSystem.Patients.PatientOrgans;
using PatientManagementSystem.Patients.ExaminationResults;
using PatientManagementSystem.Patients.PatientAccessPoints;

namespace PatientManagementSystem.Patients.PatientExaminations
{
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

    #region GeneralExams
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
        } 

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

    } //Rename to BoneScan? That way I dont have to report gallstones or other organ abnormalities commonly found on XRays

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
        #region SpecificExamineFunctions
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
        }

        private void ExamineReproductives()
        {
            _results.Reproductives.SexOrgans = _patient.Body.Abdomen.Reproductives.GetOrgansSex();
        }
        #endregion
        #endregion
    } //TODO: Expand Examine[Organ] methods to return important information regarding that organ.
    #endregion

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
            results.Brain.latestCSFResults = new CSFProfile(patient.Body.Head.Brain.CurrentInfection);
            return true;
        }
    } //Gets the exact nature of any infections that may be present in the brain. Does not show blood in csf at the moment 
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

    public class ExamineOxygenSaturation : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Lungs.OxygenSaturation = patient.Body.Chest.Lungs.OxygenSaturation;
            return true;
        }
    }

    public class ExamineSputumSample : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            //This should return an average picture of the lungs infection state
            throw new NotImplementedException();
        }
    }//TODO: Implement all the required background fields

    public class ExamineBronchoscopySample : IPatientExamination
    {
        private bool _targetLeftLung;
        private string _targetLobeLocation; //TODO: Replace type with appropriate enum?
        public ExamineBronchoscopySample(bool targetLeftLung, string temp_targetLobeLocation)
        {
            _targetLeftLung = targetLeftLung;
            _targetLobeLocation = temp_targetLobeLocation;
        }

        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            //This should return a picture of the specific target lobe's infection state
            throw new NotImplementedException();
        }
    } //TODO: Implement all the required bacground field and appropriate enum for _targetLobeLocation
    #endregion

    #region UrinaryTractExams
    public class Urinalysis : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (!patient.AccessPoints.HasUrinaryCatheter || patient.Body.Abdomen.UrinaryTract.Bladder.IsUrethraBlocked)
                return false;
            //Update results a urine sample result
            return true;
        }
    }//TODO: Create UrinalysisResult and assigin it to results;
    #endregion

    #region BloodTests

    public abstract class ExamineBlood : IPatientExamination
    {
        public bool Examine(Patient patient)
        {
            return patient.AccessPoints.HasIVAccess;
        }
    }
    public class ExamineBloodType : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            results.Blood.BloodType = patient.Body.Blood.bloodType;
            return true;
        }
    }

    public class ExamineBloodClottingFactors : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            results.Blood.ClottingFactors = patient.Body.Blood.FluidProfile.ClottingFactor;
            return true;
        }
    }

    public class ExamineBloodLiverFunctions : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
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

    public class ExamineBloodCardiacMarkers : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodPSA : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodBetaHCG : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodBloodSugarLevel : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodCRP : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodCultures : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodElectrolytes : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodIllicitDrugScreen : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;

            throw new NotImplementedException();
        }
    }

    public class ExamineBloodKidneyFunctions : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;
            throw new NotImplementedException();
        }
    }

    #region CopyPastey
    public class TEMP_ExamineBlood : ExamineBlood, IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            if (Examine(patient))
                return false;
            throw new NotImplementedException();
        }
    }
    #endregion
    #endregion

}