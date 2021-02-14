using System;
using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientOrgans;
using PatientManagementSystem.Patients.PatientPhysical;
using PatientManagementSystem.Patients.PatientDrugs;
using PatientManagementSystem.Patients.PatientInterventions;
using PatientManagementSystem.Patients.PatientExaminations;

namespace PatientManagementSystem.Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager Pod = new PatientManager();
            Pod.TryAddPatient(new Patient());
            Patient temp = Pod.TEMP_GetPatient();

        }
    }
}
