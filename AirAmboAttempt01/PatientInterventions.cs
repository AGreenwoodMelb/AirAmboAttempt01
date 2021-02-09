using System;
using AirAmboAttempt01.Patients;
using AirAmboAttempt01.Patients.PatientDrugs;

namespace AirAmboAttempt01.Patients.PatientInterventions
{
    public interface IPatientIntervention
    {
        public virtual bool Intervene(Patient target)
        {
            throw new NotImplementedException(message: "IIntervention:: No Intervene method implemented");
        }
    }

    public class Transfuse : IPatientIntervention
    {
        private Fluid _fluid;
        private Patient _target;
        public Transfuse(Fluid incFluid)
        {
            _fluid = incFluid;
        }

        public bool Intervene(Patient target)
        {
            _target = target;
            bool output = DetermineTransfusion();
            Console.WriteLine(_target.BloodVolumeCheck());
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

            if (_target.Body.Blood.BloodTypeCompatibility(incBlood.bloodType))
            {
                Console.WriteLine("Blood Transfusion Compatible"); //Temp
            }
            else
            {
                Console.WriteLine("Blood Transfusion Incompatible");
            }
            return _target.Body.Blood.AddFluid(_fluid);
        }
    }


    public class AdministerDrug : IPatientIntervention
    {
        private Drug _drug;
        public AdministerDrug(Drug drug)
        {
            _drug = drug;
        }

        public bool Intervene(Patient target)
        {
            _drug.Administer(target);
            //throw new NotImplementedException(message: "AdministerDrug:: No Intervene method implemented");
            return true;
        }
    }
}
