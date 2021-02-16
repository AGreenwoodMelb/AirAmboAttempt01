using PatientManagementSystem.Patients.PatientPhysical;
using PatientManagementSystem.Patients.PatientMental;
using PatientManagementSystem.Patients.PatientDrugs;
using PatientManagementSystem.Patients.PatientInterventions;
using PatientManagementSystem.Patients.PatientAccessPoints;

namespace PatientManagementSystem.Patients
{
    public class Patient
    {
        #region Props
        //public int _randomSeed { get;} //For Unity stuff
        private Biography _biography;
        public Biography Biography
        {
            get { return _biography; }
            set { _biography = value; }
        }

        private bool _isAlive = true;
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        private Physical _body;
        public Physical Body
        {
            get { return _body; }
            private set { _body = value; }
        }

        private Mental _mind;
        public Mental Mind
        {
            get { return _mind; }
            private set { _mind = value; }
        }

        private AccessPoints _accessPoints;
        public AccessPoints AccessPoints
        {
            get { return _accessPoints; }
            set { _accessPoints = value; }
        }

        private int _magicRandomSeed = 1;
        public int MagicRandomSeed
        {
            get { return _magicRandomSeed; }
            set { _magicRandomSeed = value; }
        }

        #endregion

        public Patient(Biography biography = null, Physical body = null, Mental mind = null)
        {
            Biography = biography ?? new Biography();
            Body = body ?? new Physical();
            Mind = mind ?? new Mental();
            AccessPoints = new AccessPoints();
            //_randomSeed = MagicRandomStaticThingy;
        }
    }
  
    public class Biography
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
        #endregion

        public Biography(string firstName = "John", string lastName = "Doe", int age = 30, Gender gender = Gender.Other)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }
    }
}
