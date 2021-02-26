using System;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientOrgans;
using PatientManagementSystem.Patients.PatientPhysical;
using PatientManagementSystem.Patients.PatientDrugs;
using PatientManagementSystem.Patients.PatientInterventions;
using PatientManagementSystem.Patients.PatientExaminations;
using PatientManagementSystem.Patients.ExaminationResults;
using PatientManagementSystem.Patients.PatientAccessPoints;
using PatientManagementSystem.Patients.PatientInfection;

namespace PatientManagementSystem.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager Pod = new PatientManager();

            #region SetupPatient 
            Blood bs = new Blood(new BloodType() { ABO = BloodABO.AB, Rhesus = BloodRhesus.Positive });
            BloodSystem blood = new BloodSystem(bs);
            Abdomen abs = new Abdomen(reproductives: new Reproductive_Male());
            Physical body = new Physical(blood: blood, abdomen: abs);
            Patient pt = new Patient(body: body);
            #endregion //This sucks

            Pod.TryAddPatient(pt);

            Drug drug = new DrugStim1();
            drug.Administer(pt, AdministrationRoute.Intramuscular);
            Console.WriteLine(drug.WasteProduced);

            Console.ReadLine();
        }
    }
}
