using AirAmboAttempt01.Patients.PatientPhysical;
using AirAmboAttempt01.Patients.PatientMental;

namespace AirAmboAttempt01.Patients
{
    public class Patient
    {
        #region Props
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private bool _isAlive;
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
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
        #endregion
        public Patient()
        {
            firstName = "John";
            lastName = "Doe";
            age = 30;
            gender = Gender.Other;
        }

        public Patient(string firstName, string lastName, int age, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        public Patient(string firstName, string lastName, int age, Gender gender, Physical body, Mental mind) : this( firstName, lastName, age, gender)
        {
            _body = body;
            _mind = mind;
        }
    }
}
