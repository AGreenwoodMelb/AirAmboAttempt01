using PatientManagementSystem.Patients.PatientDefaults;

namespace PatientManagementSystem.Patients.PatientOrgans
{
    public class Heart : Organ
    {
        #region Props
        public override OrganStructure[] Structures => DefaultOrganStructure.Heart;

        private bool _isBeating = true;
        public bool IsBeating
        {
            get { return _isBeating; }
            set { _isBeating = value; }
        }

        private bool _isArrythmic;
        public bool IsArrythmic
        {
            get { return _isArrythmic; }
            set { _isArrythmic = value; }
        }

        private bool _hasPacemaker;
        public bool HasPaceMaker
        {
            get { return _hasPacemaker; }
            set { _hasPacemaker = value; }
        }

        private int _beatsPerMinute;
        public int BeatsPerMinute
        {
            get { return _beatsPerMinute; }
            set { _beatsPerMinute = value; }
        }

        private OrganSize _heartSize;

        public OrganSize HeartSize
        {
            get { return _heartSize; }
            set { _heartSize = value; }
        }

        #endregion
        #region Contructors
        public Heart(bool isBeating = true, bool isArrythmic = false, bool hasPacemaker = false, int? beatsPerMinute = null) : base(DefaultOrgans.DefaultHeart.OxygenRequirement, DefaultOrgans.DefaultHeart.PerfusionRequirement)
        {
            _isBeating = isBeating;
            _isArrythmic = isArrythmic;
            _hasPacemaker = hasPacemaker;
            _beatsPerMinute = beatsPerMinute ?? DefaultOrgans.DefaultHeart.HeartRate;
        }
        #endregion
        #region Functions
        #endregion
    }
}
