using System;
using AirAmboAttempt01.Patients;
using AirAmboAttempt01.Patients.PatientDrugs;

namespace AirAmboAttempt01.Patients.PatientInterventions
{
    public interface IPatientIntervention
    {
        public virtual bool Intervene(Patient patient)
        {
            throw new NotImplementedException(message: "IIntervention:: No Intervene method implemented");
        }
    }

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


    public class AdministerDrug : IPatientIntervention
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
}
