
using Xunit;
using PatientManagementSystem;
using PatientManagementSystem.Patients;
using PatientManagementSystem.Patients.PatientInterventions;


namespace PatientManagementSystemTest
{
    public class PatientInterventionsTest
    {
        [Fact]
        public void CheckPatientIV()
        {
            PatientManager pod = new PatientManager();
            pod.TryAddPatient(new Patient());

            Patient patient = pod.TEMP_GetPatient();

            Assert.Null(patient.AccessPoints.IVs[IVTargetLocation.ArmLeft]);
        }

        [Fact]
        public void InsertIValid()
        {
            PatientManager pod = new PatientManager();
            pod.TryAddPatient(new Patient());

            Assert.True(pod.PerformIntervention(new InsertIV(IVTargetLocation.ArmLeft)));
        }
    }
}
