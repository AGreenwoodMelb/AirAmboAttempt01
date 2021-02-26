using PatientManagementSystem.Patients.PatientPhysical;
using PatientManagementSystem.Patients.PatientMental;
using PatientManagementSystem.Patients.PatientAccessPoints;
using PatientManagementSystem.Patients.PatientSocials;

namespace PatientManagementSystem.Patients
{
    public class Patient
    {
        #region Props
        public int _randomSeed { get;} //UNITY: For Unity stuff
        public PatientFlags Flags { get; set; }

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

        private float _magicRandomSeed = 1f; //UNITY: Replace later with random using _randomSeed
        public float MagicRandomSeed
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

            Flags = new PatientFlags();
            //_randomSeed = MagicRandomStaticThingy;
        }
    }

    public class PatientFlags
    {
        public bool hasCSFSample;
    }
}
