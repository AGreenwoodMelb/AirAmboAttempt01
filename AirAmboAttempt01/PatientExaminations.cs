using System;
using System.Collections.Generic;
using System.Text;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientInfection;
using PatientManagementSystem.Patients.PatientBones;

namespace PatientManagementSystem.Patients.PatientExaminations
{
    public class PatientExamResults
    {
        public string tempOutput; //Default dumping variable
        public float latestBloodVolumeRatio; //TODO: Replace with blood pressure

        public PatientExamResultsBrain Brain = new PatientExamResultsBrain();
        public PatientExamResultsLungs Lungs = new PatientExamResultsLungs();

        public PatientExamResultsXRays XRays = new PatientExamResultsXRays();
    }

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
        }
        public class PatientXRayAbdomen : PatientXRays
        {
            public bool hasKidneyStonesLeft;
            public bool hasKidneyStonesRight;
            //Insert Other relevant XRay details here
        }
        public class PatientXRayArm : PatientXRays
        {

        }
        public class PatientXRayLeg : PatientXRays
        {

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
    
    public class CSFProfile
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

    #region LungsResults
    public class PatientExamResultsLungs
    {
        public float RespirationRate;
        public float OxygenSaturation;

        public PatientExamResultLung LeftLung = new PatientExamResultLung();
        public PatientExamResultLung RighttLung = new PatientExamResultLung();


        #region Classes
        public class PatientExamResultLung
        {

        }
        #endregion
    }//TODO: INCOMPLETE
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
    }//TODO: Replace with Blood Pressure Examination

    public class GetRespiratoryRate : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.tempOutput = patient.Body.Chest.Lungs.RespiratoryRate.ToString();
            return true;
        }
    }

    public class GetO2Sats : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.tempOutput = patient.Body.Chest.Lungs.OxygenSaturation.ToString();
            return true;
        }
    }

    public class GetXRay : IPatientExamination
    {
        private BodyRegion _target;

        public GetXRay(BodyRegion target)
        {
            _target = target;
        }

        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            switch (_target)
            {
                case BodyRegion.None:
                    return false;
                case BodyRegion.Head:
                    results.XRays.Head.bones = (Bone[])patient.Body.Head.Bones.Clone(); //Does this solve my pass by reference problem?
                    break;
                case BodyRegion.Chest:
                    results.XRays.Chest.bones = (Bone[])patient.Body.Chest.Bones.Clone();
                    break;
                case BodyRegion.Abdomen:
                    results.XRays.Abdomen.bones = (Bone[])patient.Body.Abdomen.Bones.Clone();
                    break;
                case BodyRegion.LeftArm:
                    results.XRays.LeftArm.bones = (Bone[])patient.Body.Limbs.Arms.LeftArm.Bones.Clone();
                    break;
                case BodyRegion.RightArm:
                    results.XRays.RightArm.bones = (Bone[])patient.Body.Limbs.Arms.RightArm.Bones.Clone();
                    break;
                case BodyRegion.LeftLeg:
                    results.XRays.LeftLeg.bones = (Bone[])patient.Body.Limbs.Legs.LeftLeg.Bones.Clone();
                    break;
                case BodyRegion.RightLeg:
                    results.XRays.RightLeg.bones = (Bone[])patient.Body.Limbs.Legs.RightLeg.Bones.Clone();
                    break;
                default:
                    throw new ArgumentException($"GetXRay::Examine Unhandled BodyRegion: {nameof(_target)}");
            }
            return true;
        } //TODO: Fix Examine so it no longer passes a reference. SOLVED?


    }
    
    #region HeadExams
    public class GetBrainEEG : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Brain.isBrainDead = patient.Body.Head.Brain.IsBrainDead;
            results.Brain.isSeizing = patient.Body.Head.Brain.IsSeizing;
            return true;
        }
    }//Checks for brain death or seizures

    public class GetBrainCT : IPatientExamination
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

    public class GetCerebrospinalFluid : IPatientExamination
    {
        public bool Examine(Patient patient, ref PatientExamResults results)
        {
            results.Brain.latestCSFResults = new CSFProfile(patient.Body.Blood.FluidProfile, patient.Body.Head.Brain.CurrentInfection);
            return true;
        }
    }//Gets the exact nature of any infections that may be present. Does not show blood in csf at the moment 
    #endregion
    #endregion
}
