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

            PatientIntervention inter = new PerformLumbarPuncture();
            Pod.PerformIntervention(inter, out bool meow);
            PatientIntervention inter2 = new InsertIV(IVTargetLocation.ArmLeft);
            Pod.PerformIntervention(inter2, out meow);
            PatientExamination a = new ExamineBloodType();
            Pod.PerformIntervention(a, out meow);

            Console.WriteLine(meow);

            Console.ReadLine();
        }
    }
}
