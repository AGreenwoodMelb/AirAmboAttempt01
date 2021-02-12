using System;
using PatientManagementSystem.Patients.PatientInterventions;

namespace PatientManagementSystem.Patients.PatientDrugs
{
    public struct DrugProfile
    {
        public bool IsStimulant;
        public bool IsSedative;
        public bool IsOpiod;
        public bool IsHallucinogen;
    }

    public abstract class Drug
    {
        public Patient Target { get; protected set; }
        public DrugProfile drugProfile;


        public virtual bool Administer(Patient target)
        {
            throw new NotImplementedException(message: "Drug::Administer not implements");
        }

        public void UpdatePatientDrugProfile()
        {
            DrugProfile targetProfile = Target.Body.Blood.DrugsProfile;

            targetProfile.IsStimulant = drugProfile.IsStimulant || targetProfile.IsStimulant;
            targetProfile.IsSedative = drugProfile.IsSedative || targetProfile.IsSedative;
            targetProfile.IsOpiod = drugProfile.IsOpiod || targetProfile.IsOpiod;
            targetProfile.IsHallucinogen = drugProfile.IsHallucinogen || targetProfile.IsHallucinogen;

            Target.Body.Blood.DrugsProfile = targetProfile;
        }

    }

    public class DrugStim1 : Drug
    {
        public DrugStim1()
        {
            drugProfile.IsStimulant = true;
        }


        public override bool Administer(Patient target)
        {
            Target = target;
            //Do the action of the drug
            UpdatePatientDrugProfile();
            return true;
        }
    }

    public class DrugDetoxer : Drug
    {
        public override bool Administer(Patient target)
        {
            Target = target;
            Target.Body.Blood.DrugsProfile = new DrugProfile();
            return true;
        }
    }
}
