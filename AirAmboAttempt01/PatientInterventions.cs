using System;
using AirAmboAttempt01.Patients;
using System.Collections.Generic;
using AirAmboAttempt01.Patients.PatientDrugs;
using AirAmboAttempt01.Patients.PatientInfection;

namespace AirAmboAttempt01.Patients.PatientInterventions
{
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

    public class Transfuse : IPatientIntervention //Redo using IVAccess Object
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
            Console.WriteLine(_patient.BloodVolumeCheck()); //Temp: Will remove all monitoring to a PatientMonitoring system.
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
        }

        private bool TranfuseBlood()
        {
            Blood incBlood = (Blood)_fluid;

            if (_patient.Body.Blood.BloodTypeCompatibility(incBlood.bloodType))
            {
                //Handle Transfusion reaction here
                Console.WriteLine("Blood Transfusion Compatible"); //Temp
            }
            else
            {
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

    public class InsertIV : IPatientIntervention
    {
        private IVTargetLocation _target;
        private Patient _patient;

        public InsertIV(IVTargetLocation target)
        {
            _target = target;
        }

        public bool Intervene(Patient patient)
        {
            _patient = patient;
            if (_patient.AccessPoints.IVs[_target] == null && IsInstallSuccessful())
            {
                //Check to Infect
                if (_patient.MagicRandomSeed > 100f) // NOT DONE
                    _patient.AccessPoints.IVs[_target].infection = new Infection();

                _patient.AccessPoints.IVs[_target] = new IVAccess();
                return true;
            }
            return false;
        }

        private bool IsInstallSuccessful()
        {
            if (_patient.MagicRandomSeed > 0.5f) //NOT DONE
                return true;

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

        public bool HasUrinaryCatheter;
    }

    public class IVAccess
    {
        public Infection infection;
        public Fluid CurrentFluid { get; set; }
        public float FlowRate { get; set; }
        public Drug AddedDrug { get; set; }
    }
}
