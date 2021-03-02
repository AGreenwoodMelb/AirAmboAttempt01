using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientOrgans;
using PatientManagementSystem.Patients.PatientPhysical;
using PatientManagementSystem.Patients.PatientProceedures;

namespace PatientManagementSystem.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientPod Pod = new PatientPod();

            #region SetupPatient 
            Blood bs = new Blood(new BloodType() { ABO = BloodABO.AB, Rhesus = BloodRhesus.Positive });
            BloodSystem blood = new BloodSystem(bs);
            Abdomen abs = new Abdomen(reproductives: new Reproductive_Male());
            Anthropometrics metrics = new Anthropometrics(21, 181, 120);
            Physical body = new Physical(blood: blood, abdomen: abs);
            Patient pt = new Patient(body: body);
            #endregion //This sucks
            Pod.TryAddPatient(pt);


            ////Console.WriteLine(pt.Body.Anthropometrics.BMI);
            //LeftLung left = new LeftLung();
            //RightLung right = new RightLung();

            //RespiratorySystem respiratorySystem = new RespiratorySystem(left, right);

            ////respiratorySystem.RemoveLung(true, out Lung temp);
            ////respiratorySystem.InsertLung(left);

            //PatientExamination exam = new ExamineLungsAuscultateLungs();
            //Pod.PerformProceedure(exam, out bool _);

            //exam = new ExamineLungsPrecussLungs();
            //Pod.PerformProceedure(exam, out bool _);


            //var t = pt.Body.Infections.Chest.GetInfections();

            //System.Console.WriteLine(Pod.PatientResults.RespiratorySystem.LeftLung.BreathSounds[LungLobeLocation.Upper]);
            System.Console.WriteLine(Pod.TotalWasteProduced);
            PatientProceedure intervention = new PerformLumbarPuncture();
            Pod.PerformProceedure(intervention, out bool _);
            System.Console.WriteLine(Pod.TotalWasteProduced);


            //Lung test = new RightLung();
            //test.Lobes[LungLobeLocation.Upper]._organHealth = 0.045f;
            //test.Lobes[LungLobeLocation.Lower]._organHealth = 0.065f;
            //OrganState t = test.OrganState;
            
            //System.Console.WriteLine(    test.OxygenRequirement);

            System.Console.WriteLine("FOR DEBUGGING");
        }
    }
}
