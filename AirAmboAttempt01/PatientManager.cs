using System;
using System.Collections.Generic;
using System.Text;
using AirAmboAttempt01.Patients;

namespace AirAmboAttempt01
{
    public class PatientManager
    {
        #region Props
        protected Patient CurrentPatient { get; private set; }//This should be protected to prevent direct access and manipulation of the patient.
        #endregion

        public bool TryAddPatient(Patient newPatient)
        {
            if (CurrentPatient == null)
            {
                CurrentPatient = newPatient;
                return true;
            }
            return false;
        }
        public bool TryRemovePatient()
        {
            if (CurrentPatient != null)
            {
                CurrentPatient = null;
                return true;
            }
            return false;
        }

        public string GetPatientBio()
        {
            if (CurrentPatient == null)
            {
                return "No Patient Found in Pod";
            }

            string title = "";
            switch (CurrentPatient.Biography.Gender)
            {
                case Gender.Other:
                    title = "Mx.";
                    break;
                case Gender.Male:
                    title = "Mr.";
                    break;
                case Gender.Female:
                    title = "Ms. ";
                    break;
            }
            return $"{title} {CurrentPatient.Biography.LastName}, {CurrentPatient.Biography.FirstName} ({CurrentPatient.Biography.Age})";
        }
        public string GetPatientHead()
        {
            return "";
        }

        public Patient TEMP_GetPatient()
        {
            return CurrentPatient;
        }

        public bool PerformIntervention(IIntervention i)
        {
            return i.Intervene(CurrentPatient);
        }
    }

    public interface IIntervention
    {
        public virtual bool Intervene(Patient target)
        {
            throw new NotImplementedException(message: "No Intervene method implemented");
        }
    }

    public class Transfuse : IIntervention
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
            return DetermineTransfusion();
        }

        private bool DetermineTransfusion()
        {
            switch (_fluid)
            {
                case Blood _:
                    return TranfuseBlood();
                default:
                    break;
            }
            return false;
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

    public class Tester : IIntervention
    {

    }

    /*
     * 
     * 
        public bool Transfuse(Fluid incFluid) //This Shouldnt be here //Make this An IIntervention
        {
            switch (incFluid)
            {
                case Blood incBlood:
                    return AddFluid(incBlood);
                case Drug incDrug:
                    return DoingDrugs(incDrug);
                case Fluid incBaseFluid:
                    return AddFluid(incBaseFluid);
                default:
                    throw new ArgumentException(
                        message: "BloodSystem::Transfuse Unhandled Subtype of Fluid",
                        paramName: nameof(incFluid)
                        );
            }
        }

        private bool DoingDrugs(Drug incDrug)//THis Shouldnt be here //Make this An IIntervention
        {
            switch (incDrug.drugType)
            {

                case DrugType.Stimulant:
                    _illicitDrugsProfile.stimulants = true;
                    break;
                case DrugType.Sedative:
                    _illicitDrugsProfile.sedetives = true;
                    break;
                case DrugType.Opiods:
                    _illicitDrugsProfile.opiods = true;
                    break;
                case DrugType.Hallucinogens:
                    _illicitDrugsProfile.hallucinogens = true;
                    break;
                case DrugType.Detoxer:
                    _illicitDrugsProfile = new IllilcitDrugsProfile(); //Bool default is false
                    break;
                case DrugType.None:
                default:
                    break;
            }

            return true;
        }

        public float BloodVolumeCheck()
        {
            float bloodVolumeRatio = Volume / _defaultBloodSystemVolume;
            Console.WriteLine(bloodVolumeRatio);
            return bloodVolumeRatio;
        }//Probably not needed here //Put In condition / event Manager
     * 
     */
}
