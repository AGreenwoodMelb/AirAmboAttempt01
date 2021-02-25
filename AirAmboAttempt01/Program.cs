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
            //PatientManager Pod = new PatientManager();

            //#region SetupPatient 
            //Blood bs = new Blood(new BloodType() { ABO = BloodABO.AB, Rhesus = BloodRhesus.Positive });
            //BloodSystem blood = new BloodSystem(bs);
            //Abdomen abs = new Abdomen(reproductives: new Reproductive_Male());
            //Physical body = new Physical(blood: blood, abdomen: abs);
            //Patient pt = new Patient(body: body);
            //#endregion //This sucks

            //Pod.TryAddPatient(pt);

            ////Pod.PerformIntervention(new InsertIV(IVTargetLocation.ArmLeft), out bool Succeeded); //This Succeeded thing is already starting to wear thin
            ////Console.WriteLine(Pod.TotalWasteProduced);
            ////Console.WriteLine(Pod.PatientResults.Blood.BloodType.ToString());

            //Console.WriteLine(pt.Body.Abdomen.Liver.OrganState);

            Infections infections = new Infections();

            Infection[] meh = infections.GetInfectionsArray();

            infections.TreatInfection(InfectionPathogenType.Bacterial);
            Console.ReadLine();
        }
    }
}
