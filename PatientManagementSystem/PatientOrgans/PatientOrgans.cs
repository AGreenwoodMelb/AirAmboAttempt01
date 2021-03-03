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
        Other, //For expansions?
    }
    public enum OrganPerfusionState
    {
        Normal,
        Hypoperfused,
        Ischaemic,
    }
    public enum OrganOxygenationState
    {
        Normal,
        Hypoxic,
        Anoxic, //Probably the wrong term tbh
    }

    public abstract class Organ
    {
        #region Props
        public float _organHealth = 1f; //Temporarily set accessor to public from protected

        private float _organEfficiency;
        public float OrganEfficiency
        {
            get
            {
                return _organHealth; //TEMP
                return _organEfficiency;
            }
            private set
            {
                _organEfficiency = value;
            }
        }//TODO: OrganEfficiency should be dynamically generated from _organHealth, Default file, Oxygenation...

        public bool IsPresent => !(OrganState == OrganState.Removed || OrganState == OrganState.None);
        public virtual OrganState OrganState
        {
            get
            {
                return LookupOrganState(_organHealth);
            }
        }
        protected OrganState LookupOrganState(float organHealth)
        {
            OrganState organState = OrganState.None;
            for (int i = DefaultOrgans.OrganStateLookup.Length - 1; i >= 0; i--)
            {
                if (organHealth <= DefaultOrgans.OrganStateLookup[i].Item2)
                    organState = DefaultOrgans.OrganStateLookup[i].Item1;
            }

            return organState;
        }//REVIEW: This seems to work by chance, not design.


        private readonly float _oxygenRequiredBase; //REVIEW: Should this be readonly and set in a parameterized constructor? The lung override of the prop may cause problems? This will be misery to setup the constructors again so wait to fix this until the design settles
        public virtual float OxygenRequirement
        {
            get
            {
                return _oxygenRequiredBase;
            }
            //protected set
            //{
            //    _oxygenRequiredBase = value;
            //}
        }

        public float _oxygenConsumed; //TODO: Finish implementing. Amount of Oxygen consumed(up to OrganOxygenRequired), Will need BloodSystem first here;
        public virtual float OxygenConsumed
        {
            get
            {
                return _oxygenConsumed;
            }
            set
            {
                _oxygenConsumed = value;
            }
        }

        public float Oxygenation => OxygenConsumed / OxygenRequirement;


        /* NOTES: Blood requirement
         * Is this necessary or will the Oxygen system coupled with RBC carrying capacity suffice? 
         * I think this is useful for localised areas of ischaemia when there is no Hypoxia
         */
        private readonly float _perfusionRequiredBase; //See _oxygenRequired REVIEW
        public virtual float PerfusionRequirement
        {
            get { return _perfusionRequiredBase; }
            //protected set { _bloodRequirementBase = value; }
        }

        private float _perfusionSupplied;
        public virtual float PerfusionSupplied
        {
            get { return _perfusionSupplied; }
            set { _perfusionSupplied = value; }
        }

        public float Perfusion => PerfusionSupplied / PerfusionRequirement;
        #endregion

        public Organ(float oxygenRequirement, float perfusionRequirement)
        {
            _oxygenRequiredBase = oxygenRequirement;
            _perfusionRequiredBase = perfusionRequirement;
        }

        public void RemoveOrgan()
        {
            _organEfficiency = 0f;
            _organHealth = 0f;
        }
        
        //TO BE REMOVED TO BLEEDING SYSTEM
        //private BleedingSeverity _isBleeding = BleedingSeverity.None;
        //public BleedingSeverity IsBleeding
        //{
        //    get { return _isBleeding; }
        //    protected set { _isBleeding = value; }
        //}
        //public readonly float BaseBloodLossRate;
        //public Organ(float bloodLossRate)
        //{
        //    BaseBloodLossRate = bloodLossRate;
        //}
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

        public Brain() : base(DefaultOrgans.DefaultBrain.OxygenRequirement, DefaultOrgans.DefaultBrain.PerfusionRequirement)
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

        public Heart(HeartStructures heartStructures = null, bool isBeating = true, bool isArrythmic = false, bool hasPacemaker = false, int? beatsPerMinute = null) : base(DefaultOrgans.DefaultHeart.OxygenRequirement, DefaultOrgans.DefaultHeart.PerfusionRequirement)
        {
            _heartStructures = heartStructures ?? new HeartStructures();
            _isBeating = isBeating;
            _isArrythmic = isArrythmic;
            _hasPacemaker = hasPacemaker;
            _beatsPerMinute = beatsPerMinute ?? DefaultOrgans.DefaultHeart.HeartRate;
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

        public Kidney() : base(DefaultOrgans.DefaultKidney.OxygenRequirement, DefaultOrgans.DefaultKidney.PerfusionRequirement)
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
        public Bladder() : base(DefaultOrgans.DefaultBladder.OxygenRequirement, DefaultOrgans.DefaultBladder.PerfusionRequirement)
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

        public Liver() : base(DefaultOrgans.DefaultLiver.OxygenRequirement, DefaultOrgans.DefaultLiver.PerfusionRequirement)
        {

        }
    }

    public class GastrointestinalTract : Organ
    {
        public GastrointestinalTract() : base(DefaultOrgans.DefaultGI.OxygenRequirement, DefaultOrgans.DefaultGI.PerfusionRequirement)
        {

        }
    }
    public class Spleen : Organ
    {
        public Spleen() : base(DefaultOrgans.DefaultSpleen.OxygenRequirement, DefaultOrgans.DefaultSpleen.PerfusionRequirement)
        {

        }
    }

    public class Pancreas : Organ
    {
        public Pancreas() : base(DefaultOrgans.DefaultPancreas.OxygenRequirement, DefaultOrgans.DefaultPancreas.PerfusionRequirement)
        {

        }
    }

    public abstract class Reproductive : Organ
    {
        public Reproductive(float oxygenRequirement, float perfusionRequirement) : base(oxygenRequirement, perfusionRequirement)
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

        public Reproductive_Male() : base(DefaultOrgans.DefaultReproductive_Male.OxygenRequirement, DefaultOrgans.DefaultReproductive_Male.PerfusionRequirement)
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
        public Reproductive_Female() : base(DefaultOrgans.DefaultReproductive_Female.OxygenRequirement, DefaultOrgans.DefaultReproductive_Female.PerfusionRequirement)
        {

        }
    }
    #endregion
    #endregion
}

