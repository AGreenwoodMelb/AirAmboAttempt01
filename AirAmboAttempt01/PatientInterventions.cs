using System;
using System.Collections.Generic;
using PatientManagementSystem.Patients;
using PatientManagementSystem.Patients.PatientDrugs;
using PatientManagementSystem.Patients.PatientInfection;

namespace PatientManagementSystem.Patients.PatientInterventions
{
    public class AccessPoints
    {
        public Dictionary<IVTargetLocation, IVAccess> IVs = new Dictionary<IVTargetLocation, IVAccess>()
        {
            {IVTargetLocation.ArmLeft, null },
            {IVTargetLocation.ArmRight, null },
            {IVTargetLocation.LegLeft, null },
            {IVTargetLocation.LegRight, null },
            {IVTargetLocation.CentralLine, null },
        };

        public ArtificialAirway artificialAirway;
        public bool HasUrinaryCatheter;
    }

    public enum ArtificialAirway
    {
        None,
        FaceMask,
        LaryngealMask
    }

    public class IVAccess
    {
        public Infection infection;
        public Fluid CurrentFluid { get; set; }
        public float FlowRate { get; set; }
        public Drug AddedDrug { get; set; }
    }

    public enum IVTargetLocation
    {
        None,
        ArmLeft,
        ArmRight,
        LegLeft,
        LegRight,
        CentralLine
    }

    public interface IPatientIntervention
    {
        public virtual bool Intervene(Patient patient)
        {
            throw new NotImplementedException(message: "IIntervention:: No Intervene method implemented");
        }
    }

    #region Fluids?
    public class Transfuse : IPatientIntervention
    {
        private Fluid _fluid;
        private Patient _patient;
        public Transfuse(Fluid incFluid)
        {
            _fluid = incFluid;
        }

        public bool Intervene(Patient patient)
        {
            _patient = patient;
            bool output = DetermineTransfusion();
            return output;
        }

        private bool DetermineTransfusion()
        {
            switch (_fluid)
            {
                case Blood _:
                    return TranfuseBlood();
                case Fluid _:
                    return false;
                default:
                    throw new ArgumentException(
                         message: $"BloodSystem::Transfuse Unhandled Subtype of Fluid: {nameof(_fluid)}"
                         );
            }
        }//Redo using IVAccess Object

        private bool TranfuseBlood()
        {
            Blood incBlood = (Blood)_fluid;

            if (_patient.Body.Blood.BloodTypeCompatibility(incBlood.bloodType))
            {
                Console.WriteLine("Blood Transfusion Compatible"); //Temp
            }
            else
            {
                //Handle Transfusion reaction here
                _patient.Body.Blood.HasTransfusionReaction = true;
                Console.WriteLine("Blood Transfusion Incompatible");
            }
            return _patient.Body.Blood.AddFluid(_fluid);
        }
    }
    public class AdministerDrug : IPatientIntervention //Maybe redo? Or Should this represent an IM or bolus via IVAccess
    {
        private Drug _drug;
        public AdministerDrug(Drug drug)
        {
            _drug = drug;
        }

        public bool Intervene(Patient patient)
        {
            _drug.Administer(patient);
            //throw new NotImplementedException(message: "AdministerDrug:: No Intervene method implemented");
            return true;
        }
    }
    #endregion

    #region IVs
    public class InsertIV : IPatientIntervention
    {
        private IVTargetLocation _target;

        public InsertIV(IVTargetLocation target)
        {
            _target = target;
        }

        public bool Intervene(Patient patient)
        {
            float successThreshold = (_target == IVTargetLocation.CentralLine) ? 0.7f : 0.0f; //Replace with call to static player class IVInsertSuccess Stat or CentralLineIVSuccess
            if (patient.AccessPoints.IVs[_target] == null && (patient.MagicRandomSeed > successThreshold))
            {
                //Check to Infect
                if (patient.MagicRandomSeed > 100f) // NOT DONE
                    patient.AccessPoints.IVs[_target].infection = new Infection(); //TODO: (LATER) Create region and organ based look-up tables for to determine infection Type 

                patient.AccessPoints.IVs[_target] = new IVAccess();
                return true;
            }
            return false;
        }
    }

    public class RemoveIV : IPatientIntervention
    {
        private IVTargetLocation _target;

        public RemoveIV(IVTargetLocation target)
        {
            _target = target;
        }

        public bool Intervene(Patient patient)
        {
            if (patient.AccessPoints.IVs[_target] != null)
            {
                patient.AccessPoints.IVs[_target] = null;
                return true;
            }
            return false;
        }
    }
    #endregion

    #region Airways
    public class InsertArtificalAirway : IPatientIntervention
    {
        private ArtificialAirway _artificialAirway;
        public InsertArtificalAirway(ArtificialAirway artificialAirway)
        {
            _artificialAirway = artificialAirway;
        }

        public bool Intervene(Patient patient)
        {
            float successThreshold = (_artificialAirway == ArtificialAirway.LaryngealMask) ? 0.7f : 0.5f; //Replace with call to static player class AirwayInsertSuccess or LaryngealMaskSuccess stat
            if (patient.AccessPoints.artificialAirway == ArtificialAirway.None && (patient.MagicRandomSeed > successThreshold))
            {
                patient.AccessPoints.artificialAirway = _artificialAirway;
                return true;
            }

            return false;
        }
    }
    public class RemoveArtificialAirway : IPatientIntervention
    {
        public bool Intervene(Patient patient)
        {
            if (patient.AccessPoints.artificialAirway != ArtificialAirway.None)
            {
                patient.AccessPoints.artificialAirway = ArtificialAirway.None;
                return true;
            }

            return false;
        }
    }
    #endregion

    #region Catheter
    public class InsertUrinaryCatheter : IPatientIntervention
    {
        public bool Intervene(Patient patient)
        {
            float successThreshold = 0.75f; //Replace with call to static player class UrinaryCatheterSuccess stat;
            if (patient.AccessPoints.HasUrinaryCatheter || patient.Body.Abdomen.UrinaryTract.Bladder.IsUrethraBlocked)
                return false;
            if(patient.MagicRandomSeed >= successThreshold)
            {
                patient.AccessPoints.HasUrinaryCatheter = true;
                return true;
            }

            return false;
        }
    }//TODO: Restructure Intervene to use single if statement

    public class RemoveUrinaryCatheter : IPatientIntervention
    {
        public bool Intervene (Patient patient)
        {
            if (!patient.AccessPoints.HasUrinaryCatheter)
                return false;

            patient.AccessPoints.HasUrinaryCatheter = false;
            return true;
        }
    }
    #endregion;
}
