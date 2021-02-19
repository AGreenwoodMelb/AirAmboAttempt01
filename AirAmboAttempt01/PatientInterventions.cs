using System;
using PatientManagementSystem.Patients;
using PatientManagementSystem.Patients.PatientDrugs;
using PatientManagementSystem.Patients.PatientInfection;
using PatientManagementSystem.Patients.PatientAccessPoints;
using PatientManagementSystem.Patients.PatientDefaults;

namespace PatientManagementSystem.Patients.PatientInterventions
{
    public abstract class PatientIntervention
    {
        public float WasteProduced { get; protected set; }
        public abstract bool Intervene(Patient patient, out bool Succeeded);

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

        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            _patient = patient;
            bool output = DetermineTransfusion();
            Succeeded = false;
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
        }//Redo using IVAccess Object. This whole thing is spiralling

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

        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            _drug.Administer(patient);
            Succeeded = false;
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
            _target = target;
        }

        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            Succeeded = false;
            if (patient.AccessPoints.IVs[_target] != null) //Cant Insert
                return false;

            WasteProduced = (_target == IVTargetLocation.CentralLine) ? DefaultWasteProduction.InsertCentralLine : DefaultWasteProduction.InsertIV;
            float successThreshold = (_target == IVTargetLocation.CentralLine) ? DefaultPlayerStatsTEMP.InsertCentralLineSuccess : DefaultPlayerStatsTEMP.InsertIVSuccess;
            if (patient.MagicRandomSeed > successThreshold) //Failed to Insert
            {
                //LATER: Increase patient CurrentPain counter by DefaultPainCaused.InsertIV;
                if (patient.MagicRandomSeed > 100f) //TODO: Implement placeholder infection chance
                    patient.AccessPoints.IVs[_target].infection = new Infection(); //LATER: Create region and organ based look-up tables for to determine infection Type 

                patient.AccessPoints.IVs[_target] = new IVAccess();
                Succeeded = true;
            }
            else
            {
                //Additional pain caused in failure?
                WasteProduced += (_target == IVTargetLocation.CentralLine) ? DefaultWasteProduction.RemoveCentralLine : DefaultWasteProduction.RemoveIV; //This is because you have to throw away the used IV when you fail
            }
            return true;
        }
    }

    public class RemoveIV : PatientIntervention
    {
        private IVTargetLocation _target;

        public RemoveIV(IVTargetLocation target)
        {
            _target = target;
        }

        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            Succeeded = false;
            if (patient.AccessPoints.IVs[_target] == null)
                return false;

            WasteProduced = (_target == IVTargetLocation.CentralLine) ? DefaultWasteProduction.RemoveCentralLine : DefaultWasteProduction.RemoveIV;
            patient.AccessPoints.IVs[_target] = null;
            Succeeded = true;
            return true;
        }
    }
    #endregion

    #region Airways
    public class InsertArtificalAirway : PatientIntervention
    {
        private ArtificialAirway _artificialAirway;
        public InsertArtificalAirway(ArtificialAirway artificialAirway)
        {
            _artificialAirway = artificialAirway;
        }

        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            Succeeded = false;
            if (patient.AccessPoints.artificialAirway != ArtificialAirway.None) //Cant Insert
                return false;

            WasteProduced = DefaultWasteProduction.InsertAirway[_artificialAirway];
            if (patient.MagicRandomSeed > DefaultPlayerStatsTEMP.AirwayInsertionSuccess[_artificialAirway]) //Failed to Insert
            {
                patient.AccessPoints.artificialAirway = _artificialAirway;
                Succeeded = true;
            }
            else
            {
                WasteProduced += DefaultWasteProduction.RemoveAirway[_artificialAirway];
            }
            return true;
        }
    }

    public class RemoveArtificialAirway : PatientIntervention
    {
        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            Succeeded = false;
            if (patient.AccessPoints.artificialAirway == ArtificialAirway.None)
                return false;

            WasteProduced = DefaultWasteProduction.RemoveAirway[patient.AccessPoints.artificialAirway];
            patient.AccessPoints.artificialAirway = ArtificialAirway.None;
            Succeeded = true;
            return true;
        }
    }
    #endregion

    #region Catheter
    public class InsertUrinaryCatheter : PatientIntervention
    {
        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            Succeeded = false;
            if (patient.AccessPoints.HasUrinaryCatheter || patient.Body.Abdomen.UrinaryTract.Bladder.IsUrethraBlocked)//Cant insert
                return false;

            WasteProduced = DefaultWasteProduction.InsertUrinaryCatheter;
            if (patient.MagicRandomSeed >= DefaultPlayerStatsTEMP.InsertUrinaryCatheterSuccess) //Failed to insert
            {
                patient.AccessPoints.HasUrinaryCatheter = true;
                Succeeded = true;
            }
            else
            {
                WasteProduced += DefaultWasteProduction.RemoveUrinaryCatheter;
            }
            return true;
        }
    }

    public class RemoveUrinaryCatheter : PatientIntervention
    {
        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            Succeeded = false;
            if (!patient.AccessPoints.HasUrinaryCatheter)
                return false;

            WasteProduced += DefaultWasteProduction.RemoveUrinaryCatheter;
            patient.AccessPoints.HasUrinaryCatheter = false;
            Succeeded = true;
            return true;
        }
    }
    #endregion;

    #region CerebralShunt
    public class InsertCerebralShunt : PatientIntervention
    {
        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            Succeeded = false;
            if (patient.AccessPoints.CerebralShunt != null)
                return false;

            WasteProduced = DefaultWasteProduction.InsertCerebralShunt;
            if (patient.MagicRandomSeed > DefaultPlayerStatsTEMP.InsertCerebralShuntSuccess)
            {
                //Check to Infect
                //if (patient.MagicRandomSeed > 100f) // NOT DONE
                //patient.AccessPoints.CerebralShunt.infection = new Infection();

                Succeeded = true;
                patient.AccessPoints.CerebralShunt = new CerebralShunt();
            }
            else
            {
                WasteProduced += DefaultWasteProduction.RemoveCerebralShunt;
            }
            return true;
        }
    }

    public class RemoveCerebralShunt : PatientIntervention
    {
        public override bool Intervene(Patient patient, out bool Succeeded)
        {
            Succeeded = false;
            if (patient.AccessPoints.CerebralShunt == null)
                return false;

            WasteProduced = DefaultWasteProduction.RemoveCerebralShunt;
            patient.AccessPoints.CerebralShunt = null;
            Succeeded = true;
            return true;
        }
    }
    #endregion
    #endregion
}
