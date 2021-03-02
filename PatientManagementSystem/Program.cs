using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientExaminations;
using PatientManagementSystem.Patients.PatientOrgans;
using PatientManagementSystem.Patients.PatientPhysical;

namespace PatientManagementSystem.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            //PatientPod Pod = new PatientPod();

            //#region SetupPatient 
            //Blood bs = new Blood(new BloodType() { ABO = BloodABO.AB, Rhesus = BloodRhesus.Positive });
            //BloodSystem blood = new BloodSystem(bs);
            //Abdomen abs = new Abdomen(reproductives: new Reproductive_Male());
            //Anthropometrics metrics = new Anthropometrics(21,181,120);
            //Physical body = new Physical(blood: blood, abdomen: abs);
            //Patient pt = new Patient(body: body);
            //#endregion //This sucks
            //Pod.TryAddPatient(pt);


            ////Console.WriteLine(pt.Body.Anthropometrics.BMI);
            //LeftLung left = new LeftLung();
            //RightLung right = new RightLung();

            //RespiratorySystem respiratorySystem = new RespiratorySystem(left, right);

            ////respiratorySystem.RemoveLung(true, out Lung temp);
            ////respiratorySystem.InsertLung(left);

            //PatientExamination exam = new ExamineLungsAuscultateLungs();
            //Pod.PerformIntervention(exam, out bool _);

            //exam = new ExamineLungsPrecussLungs();
            //Pod.PerformIntervention(exam, out bool _);


            //var t = pt.Body.Infections.Chest.GetInfections();

            //System.Console.WriteLine(Pod.PatientResults.RespiratorySystem.LeftLung.BreathSounds[LungLobeLocation.Upper]);


            //1. Create new instance of PatientPod
            PatientPod patientPod = new PatientPod();

            //2. Optionally create instances of any of the parameters of the Patient 
            Blood blood = new Blood(new BloodType() { ABO = BloodABO.AB, Rhesus = BloodRhesus.Positive });
            BloodSystem bloodSystem = new BloodSystem(blood);
            Abdomen abs = new Abdomen(reproductives: new Reproductive_Male());
            Anthropometrics metrics = new Anthropometrics(21, 181, 120);
            Physical body = new Physical(blood: bloodSystem, abdomen: abs);

            //3. Create a new instance of Patient (passing in any previously defined appropriate arguments)
            Patient patient = new Patient(body: body);

            //4. Use Pod.TryAddPatient() passing it the newly created Patient object as a parameter. 
            patientPod.TryAddPatient(patient);


            //5. Perform Examinations and Interventions by using the PatientPod instance's .PerformIntervention()
            patientPod.PerformIntervention(new ExamineLungsAuscultateLungs(), out bool _);

            //6. Access the PatientPod instance's PatientResults object to see the information obtained from any of the Interventions / Examinations performed.
            System.Console.WriteLine(patientPod.PatientResults.RespiratorySystem.LeftLung.BreathSounds[LungLobeLocation.Upper]);
           
            bool FOR_DEBUGGING = true;
        }
    }
}
