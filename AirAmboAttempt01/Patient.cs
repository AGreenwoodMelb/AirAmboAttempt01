using AirAmboAttempt01.Patients.PatientPhysical;
using AirAmboAttempt01.Patients.PatientMental;

namespace AirAmboAttempt01.Patients
{
    public class Patient
    {
        public readonly string firstName;
        public readonly string lastName;
        public readonly int age;
        public readonly Gender gender;
        public bool isAlive = true;

        public Patient()
        {
            firstName = "John";
            lastName = "Doe";
            age = 30;
            gender = Gender.Other;
        }

        public Patient(string firstName, string lastName, int age, Gender gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
        }

       

        private Physical _body = new Physical(false);
        public Physical Body
        {
            get { return _body; }
            private set { _body = value; }
        }

        private Mental _mind = new Mental();
        public Mental Mind
        {
            get { return _mind; }
            private set { _mind = value; }
        }
        
    }

 

}
