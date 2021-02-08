using AirAmboAttempt01.Patients.PatientBlood;
using AirAmboAttempt01.Patients.PatientInfection;

namespace AirAmboAttempt01.Patients.PatientOrgans
{
    public enum OrganState
    {
        None,
        Removed,
        Destroyed,
        Normal,
        Impaired,
        Damaged
    }

    #region BaseOrganClasses
    public class Organ
    {
        #region Props
        private OrganState _organState;
        public OrganState OrganState
        {
            get { return _organState; }
            set { _organState = value; }
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
            OrganState = OrganState.Normal;
        }
    }
    #endregion
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
        #endregion

        public Brain() : base(DefaultBloodLossBaseRates.Brain)
        {

        }
    }
    #endregion
    #region ChestOrgans
    public class Heart : Organ
    {
        #region Props
        private bool _isBeating;
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

        private bool hasPacemaker;
        public bool HasPaceMaker
        {
            get { return hasPacemaker; }
            set { hasPacemaker = value; }
        }

        private int _beatsPerMinute;
        public int BeatsPerMinute
        {
            get { return _beatsPerMinute; }
            set { _beatsPerMinute = value; }
        }
        #endregion

        public Heart() : base(DefaultBloodLossBaseRates.Heart)
        {

        }
    }
    public class Lung : Organ
    {
        #region Props
        private LungLobe _upperLobe = new LungLobe();
        public LungLobe UpperLobe
        {
            get { return _upperLobe; }
            set { _upperLobe = value; }
        }

        private LungLobe _middleLobe = new LungLobe();
        public LungLobe MiddleLobe
        {
            get { return _middleLobe; }
            set { _middleLobe = value; }
        }

        private LungLobe _lowerLobe = new LungLobe();
        public LungLobe LowerLobe
        {
            get { return _lowerLobe; }
            set { _lowerLobe = value; }
        }
        #endregion

        public Lung() : base(DefaultBloodLossBaseRates.Lung)
        {

        }

        public new OrganState OrganState
        {
            get
            {
                OrganState output = UpperLobe.LobeState;

                if (MiddleLobe != null && MiddleLobe.LobeState > output)
                    output = MiddleLobe.LobeState;

                if (LowerLobe.LobeState > output)
                    output = LowerLobe.LobeState;

                return output;
            }
        }
    }
    public class LungLobe
    {
        #region Props
        private Infection _infection;
        public Infection Infection
        {
            get { return _infection; }
            set { _infection = value; }
        }

        private OrganState _lobeState;

        public OrganState LobeState
        {
            get { return _lobeState; }
            set { _lobeState = value; }
        }

        #endregion
    }
    public class Lungs
    {
        #region Props
        private Lung _leftLung;
        public Lung LeftLung
        {
            get { return _leftLung; }
            set { _leftLung = value; }
        }

        private Lung _rightLung;
        public Lung RightLung
        {
            get { return _rightLung; }
            set { _rightLung = value; }
        }
        #endregion

        public Lungs(Lung leftLung = null, Lung rightLung = null)
        {
            LeftLung = (leftLung == null) ? new Lung() : leftLung;
            LeftLung.MiddleLobe = null;
            RightLung = (rightLung == null) ? new Lung() : rightLung;
        }
    }
    #endregion
    #region AbdomenOrgans
    public class Kidney : Organ
    {
        public Kidney() : base(DefaultBloodLossBaseRates.Kidney)
        {

        }
    }
    public class Kidneys
    {
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
    }

    public class Liver : Organ
    {
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
    }

    public class Reproductive_Male : Reproductive
    {
        public Reproductive_Male() : base(DefaultBloodLossBaseRates.Reproductive_Male)
        {

        }
    }

    public class Reproductive_Female : Reproductive
    {
        readonly bool isPregnant;
        public Reproductive_Female() : base(DefaultBloodLossBaseRates.Reproductive_Female)
        {

        }
    }
    #endregion
    #endregion
}

