using System;
using PatientManagementSystem.Patients;
using PatientManagementSystem.Patients.PatientDrugs;
using PatientManagementSystem.Patients.PatientInfection;
using PatientManagementSystem.Patients.PatientAccessPoints;

namespace PatientManagementSystem.Patients.PatientInterventions
{
    public abstract class PatientIntervention
    {
        public float WasteProduced { get; protected set; }
        public abstract bool Intervene(Patient patient);
        
    }

    #region Fluids?
    public class Transfuse : PatientIntervention
    {
        
        private Fluid _fluid;
        private Patient _patient;
        public Transfuse(Fluid incFluid)
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
            _fluid = incFluid;
        }

        public override bool Intervene(Patient patient)
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
    public class AdministerDrug : PatientIntervention //Maybe redo? Or Should this represent an IM or bolus via IVAccess
    {
        private Drug _drug;
        public AdministerDrug(Drug drug)
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
            _drug = drug;
        }

        public override bool Intervene(Patient patient)
        {
            _drug.Administer(patient);
            //throw new NotImplementedException(message: "AdministerDrug:: No Intervene method implemented");
            return true;
        }
    }
    #endregion

    #region ManageAccessPoints
    #region IVs
    public class InsertIV : PatientIntervention
    {
        private IVTargetLocation _target;

        public InsertIV(IVTargetLocation target)
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
            _target = target;
        }

        public override bool Intervene(Patient patient)
        {
            float successThreshold = (_target == IVTargetLocation.CentralLine) ? 0.7f : 0.0f; //UNITY: Replace with call to static player class IVInsertSuccess Stat or CentralLineIVSuccess
            if (patient.AccessPoints.IVs[_target] == null && (patient.MagicRandomSeed > successThreshold))
            {
                //Check to Infect
                if (patient.MagicRandomSeed > 100f) // NOT DONE
                    patient.AccessPoints.IVs[_target].infection = new Infection(); //TODO: Create region and organ based look-up tables for to determine infection Type 

                patient.AccessPoints.IVs[_target] = new IVAccess();
                return true;
            }
            return false;
        }
    }

    public class RemoveIV : PatientIntervention
    {
        private IVTargetLocation _target;

        public RemoveIV(IVTargetLocation target)
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
            _target = target;
        }

        public override bool Intervene(Patient patient)
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
    public class InsertArtificalAirway : PatientIntervention
    {
        private ArtificialAirway _artificialAirway;
        public InsertArtificalAirway(ArtificialAirway artificialAirway)
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
            _artificialAirway = artificialAirway;
        }

        public override bool Intervene(Patient patient)
        {
            float successThreshold = (_artificialAirway == ArtificialAirway.LaryngealMask) ? 0.7f : 0.5f; //UNITY: Replace with call to static player class AirwayInsertSuccess or LaryngealMaskSuccess stat
            if (patient.AccessPoints.artificialAirway == ArtificialAirway.None && (patient.MagicRandomSeed > successThreshold))
            {
                patient.AccessPoints.artificialAirway = _artificialAirway;
                return true;
            }

            return false;
        }
    }
    public class RemoveArtificialAirway : PatientIntervention
    {
        public RemoveArtificialAirway()
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
        }

        public override bool Intervene(Patient patient)
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
    public class InsertUrinaryCatheter : PatientIntervention
    {
        public InsertUrinaryCatheter()
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
        }
        public override bool Intervene(Patient patient)
        {
            float successThreshold = 0.75f; //UNITY: Replace with call to static player class UrinaryCatheterSuccess stat;
            if (patient.AccessPoints.HasUrinaryCatheter || patient.Body.Abdomen.UrinaryTract.Bladder.IsUrethraBlocked)
                return false;
            if (patient.MagicRandomSeed >= successThreshold)
            {
                patient.AccessPoints.HasUrinaryCatheter = true;
                return true;
            }

            return false;
        }
    }//TODO: Restructure Intervene to use single if statement

    public class RemoveUrinaryCatheter : PatientIntervention
    {
        public RemoveUrinaryCatheter()
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
        }

        public override bool Intervene(Patient patient)
        {
            if (!patient.AccessPoints.HasUrinaryCatheter)
                return false;

            patient.AccessPoints.HasUrinaryCatheter = false;
            return true;
        }
    }
    #endregion;

    #region CerebralShunt
    public class InsertCerebralShunt : PatientIntervention
    {
        public InsertCerebralShunt()
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
        }

        public override bool Intervene(Patient patient)
        {
            float successThreshold = 0.7f; //Replace with call to static player class CerebralShuntInsertSuccess
            if (patient.AccessPoints.CerebralShunt == null && (patient.MagicRandomSeed > successThreshold))
            {
                //Check to Infect
                //if (patient.MagicRandomSeed > 100f) // NOT DONE
                //patient.AccessPoints.CerebralShunt.infection = new Infection();
                patient.AccessPoints.CerebralShunt = new CerebralShunt();
                return true;
            }
            return false;
        }
    }

    public class RemoveCerebralShunt : PatientIntervention
    {
        public RemoveCerebralShunt()
        {
            WasteProduced = 0; //LATER: Replace with relevant value from a defaults file.
        }

        public override bool Intervene(Patient patient)
        {
            if (patient.AccessPoints.CerebralShunt != null)
            {
                patient.AccessPoints.CerebralShunt = null;
                return true;
            }
            return false;
        }
    }
    #endregion
    #endregion
}
