using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientDefaults;

namespace PatientManagementSystem.Patients.PatientOrgans
{
    public enum OrganState
    {
        None,
        Removed,
        Destroyed,
        Damaged,
        Impaired,
        Normal,
    }
    public enum OrganType //LATER: Implement for artificial organ stuff later
    {
        Original,
        Transplanted,
        Artificial,
    }
    public enum OrganName
    {
        None,
        Brain,
        Heart,
        LeftLung,
        RightLung,
        Liver,
        Pancreas,
        Spleen,
        GastrointestinalTract,
        LeftKidney,
        RightKidney,
        Bladder,
        Reproductives,
        Other //For expansions?
    }
    public class Organ
    {
        #region Props
        protected float _organHealth = 1f;

        private float _organEfficiency;
        public float OrganEfficiency
        {
            get
            {
                return _organEfficiency;
            }
            private set
            {
                _organEfficiency = value;
            }
        }//TODO: OrganEfficiency should be dynamically generated from _organHealth and Default file

        public OrganState OrganState //REVIEW: This seems to work by chance, not design.
        {
            get
            {
                OrganState organState = OrganState.None;
                for (int i = DefaultOrganStuff.OrganLookup.Length - 1; i >= 0; i--)
                {
                    if (_organHealth <= DefaultOrganStuff.OrganLookup[i].Item2)
                        organState = DefaultOrganStuff.OrganLookup[i].Item1;
                }
                return organState;
            }
        }

        private BleedingSeverity _isBleeding = BleedingSeverity.None;
        public BleedingSeverity IsBleeding
        {
            get { return _isBleeding; }
            protected set { _isBleeding = value; }
        }
        public readonly float BaseBloodLossRate;

        #endregion
        public Organ(float bloodLossRate)
        {
            BaseBloodLossRate = bloodLossRate;
        }
    }

    #region DerivedOrganClasses
    #region HeadOrgans
    public class Brain : Organ
    {
        #region Props
        private float _currentPressure;
        public float CurrentPressure
        {
            get { return _currentPressure; }
            set { _currentPressure = value; }
        }

        private bool _isSeizing;
        public bool IsSeizing
        {
            get { return _isSeizing; }
            set { _isSeizing = value; }
        }

        private bool _isIschaemic;
        public bool IsIschaemic
        {
            get { return _isIschaemic; }
            set { _isIschaemic = value; }
        }

        private bool _isBrainDead;
        public bool IsBrainDead
        {
            get { return _isBrainDead; }
            set { _isBrainDead = value; }
        }
        private CSFProfile _csf;

        public CSFProfile CSF
        {
            get { return _csf; }
            set { _csf = value; }
        }
        #endregion

        public Brain() : base(DefaultBloodLossBaseRates.Brain)
        {

        }

        public struct CSFProfile
        {
            public CSFAppearance Appearance;
            public RelativeLevel OpeningPressure;
            public RelativeLevel Glucose;
            public RelativeLevel Protein;
            public RelativeLevel WhiteBloodCells;
            public RelativeLevel RedBloodCells;

            public enum RelativeLevel
            {
                Normal,
                Low,
                High,
                VeryHigh,
            }
            public enum CSFAppearance
            {
                Clear,
                Cloudy,
                Bloody,
                Yellow,
            }
        }
    }
    #endregion
    #region ChestOrgans
    public class Heart : Organ
    {
        #region Props
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

        private HeartStructures _heartStructures;
        public HeartStructures HeartStructures
        {
            get { return _heartStructures; }
            set { _heartStructures = value; }
        }
        private OrganSize _heartSize;

        public OrganSize HeartSize
        {
            get { return _heartSize; }
            set { _heartSize = value; }
        }

        #endregion

        public Heart(HeartStructures heartStructures = null, bool isBeating = true, bool isArrythmic = false, bool hasPacemaker = false, int beatsPerMinute = 60) : base(DefaultBloodLossBaseRates.Heart)
        {
            _heartStructures = heartStructures ?? new HeartStructures();
            _isBeating = isBeating;
            _isArrythmic = isArrythmic;
            _hasPacemaker = hasPacemaker;
            _beatsPerMinute = beatsPerMinute;
        }
    }

    //Lungs in file://D:\Users\Alex\source\repos\GameDev\AirAmbo\AirAmboAttempt01\AirAmboAttempt01\PatientOrgans\PatientLungs.cs

    #endregion
    #region AbdomenOrgans
    public class Kidney : Organ
    {
        #region Props
        private bool _hasStone;
        public bool HasStone
        {
            get { return _hasStone; }
            set { _hasStone = value; }
        }

        private bool _isUreterBlocked;
        public bool IsUreterBlocked
        {
            get { return _isUreterBlocked; }
            set { _isUreterBlocked = value; }
        }
        #endregion

        public Kidney() : base(DefaultBloodLossBaseRates.Kidney)
        {

        }
    }
    public class Bladder : Organ
    {
        #region Props
        private float _maxVolume;
        public float MaxVolume
        {
            get { return _maxVolume; }
            set { _maxVolume = value; }
        }

        private float _currentVolume;
        public float CurrentVolume
        {
            get { return _currentVolume; }
            set { _currentVolume = value; }
        }

        private bool _hasStones;
        public bool HasStones
        {
            get { return _hasStones; }
            set { _hasStones = value; }
        }

        private bool _isUrethraBlocked;
        public bool IsUrethraBlocked
        {
            get { return _isUrethraBlocked; }
            set { _isUrethraBlocked = value; }
        }

        private FluidUrine _urine;

        public FluidUrine Urine
        {
            get { return _urine; }
            set { _urine = value; }
        }

        #endregion
        public Bladder() : base(DefaultBloodLossBaseRates.Bladder)
        {

        }

    }
    public class UrinaryTract
    {
        #region Props
        private Kidney _leftKidney = new Kidney();
        public Kidney LeftKidney
        {
            get { return _leftKidney; }
            set { _leftKidney = value; }
        }

        private Kidney _rightKidney = new Kidney();
        public Kidney RightKidney
        {
            get { return _rightKidney; }
            set { _rightKidney = value; }
        }

        private Bladder _bladder;
        public Bladder Bladder
        {
            get { return _bladder; }
            set { _bladder = value; }
        }
        #endregion

        public UrinaryTract(Kidney leftKidney = null, Kidney rightKidney = null, Bladder bladder = null)
        {
            LeftKidney = leftKidney ?? new Kidney();
            RightKidney = rightKidney ?? new Kidney();
            Bladder = bladder ?? new Bladder();
        }

    }

    public class Liver : Organ
    {
        #region Props
        private bool _hasStones;
        public bool HasStones
        {
            get { return _hasStones; }
            set { _hasStones = value; }
        }

        private bool _isBilliaryDuctBlocked;
        public bool IsBilliaryDuctBlocked
        {
            get { return _isBilliaryDuctBlocked; }
            set { _isBilliaryDuctBlocked = value; }
        }
        #endregion

        public Liver() : base(DefaultBloodLossBaseRates.Liver)
        {

        }
    }

    public class GastrointestinalTract : Organ
    {
        public GastrointestinalTract() : base(DefaultBloodLossBaseRates.GI)
        {

        }
    }
    public class Spleen : Organ
    {
        public Spleen() : base(DefaultBloodLossBaseRates.Spleen)
        {

        }
    }

    public class Pancreas : Organ
    {
        public Pancreas() : base(DefaultBloodLossBaseRates.Pancreas)
        {

        }
    }

    public abstract class Reproductive : Organ
    {
        public Reproductive(float bloodLossRate) : base(bloodLossRate)
        {

        }

        public abstract Gender GetOrgansSex();
    }

    public class Reproductive_Male : Reproductive
    {
        #region Props
        private float _psa;
        public float PSA
        {
            get { return _psa; }
            set { _psa = value; }
        }
        #endregion
        public override Gender GetOrgansSex() => Gender.Male;

        public Reproductive_Male() : base(DefaultBloodLossBaseRates.Reproductive_Male)
        {

        }
    }

    public class Reproductive_Female : Reproductive
    {
        #region Props
        private bool _isPregnant;
        public bool IsPregnant
        {
            get { return _isPregnant; }
            set { _isPregnant = value; }
        }

        private int _weeksGestation;
        public int WeeksGestation
        {
            get { return _weeksGestation; }
            set { _weeksGestation = value; }
        }

        private float _bHCG;
        public float bHCG
        {
            get { return _bHCG; }
            set { _bHCG = value; }
        }
        #endregion
        public override Gender GetOrgansSex() => Gender.Female;
        public Reproductive_Female() : base(DefaultBloodLossBaseRates.Reproductive_Female)
        {

        }
    }
    #endregion
    #endregion
}

