using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientInfection;
using System;
using System.Collections.Generic;

namespace PatientManagementSystem.Patients.PatientOrgans
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

    public static class DefaultLungs
    {
        public static readonly Dictionary<OrganState, float> LungFunctionValues = new Dictionary<OrganState, float>()
        {
            {OrganState.None, 0f },
            {OrganState.Removed, 0f },
            {OrganState.Destroyed, 0.1f },
            {OrganState.Normal, 1f },
            {OrganState.Impaired, 0.75f },
            {OrganState.Damaged, 0.5f },
        };

        public static readonly float OxygenSaturation = 100f;
        public static readonly int RespirationRate = 16;
    }

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

        private Infection _currentInfection;
        public Infection CurrentInfection
        {
            get { return _currentInfection; }
            set { _currentInfection = value; }
        }

        #endregion
        public Organ(float bloodLossRate)
        {
            BaseBloodLossRate = bloodLossRate;
            OrganState = OrganState.Normal;
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

    public class LungLobe
    {
        #region Props
        private Infection _infection;
        public Infection Infection
        {
            get { return _infection; }
            set { _infection = value; }
        }

        private OrganState _lobeState = OrganState.Normal;
        public OrganState LobeState
        {
            get { return _lobeState; }
            set { _lobeState = value; }
        }

        #endregion
    }
    public class Lung : Organ
    {
        public readonly bool IsLeft;
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
            set { _middleLobe = IsLeft ? null : value; }
        }

        private LungLobe _lowerLobe = new LungLobe();
        public LungLobe LowerLobe
        {
            get { return _lowerLobe; }
            set { _lowerLobe = value; }
        }
        #endregion

        public Lung(bool isLeft) : base(DefaultBloodLossBaseRates.Lung)
        {
            IsLeft = isLeft;
            if (IsLeft)
                MiddleLobe = null;
        }

        public float GetLungEfficiency()
        {
            float average = 0f;
            average += DefaultLungs.LungFunctionValues[UpperLobe.LobeState];
            average += DefaultLungs.LungFunctionValues[LowerLobe.LobeState];
            if (IsLeft)
            {
                return average / 2f;
            }
            else
            {
                average += DefaultLungs.LungFunctionValues[MiddleLobe.LobeState];
                return average / 3f;
            }
        }

    }
    public class Lungs
    {
        #region Props
        private Lung _leftLung ;
        public Lung LeftLung
        {
            get { return _leftLung; }
            private set { _leftLung = value.IsLeft ? value : _leftLung; }
        }

        private Lung _rightLung;
        public Lung RightLung
        {
            get { return _rightLung; }
            private set { _rightLung = value; }
        }

        private int _respiratoryRate ;
        public int RespiratoryRate
        {
            get { return _respiratoryRate; }
            set { _respiratoryRate = value; }
        }

        public float OxygenSaturation
        {
            get
            {
                return GetLungFunction() * ((float)RespiratoryRate / DefaultLungs.RespirationRate) * DefaultLungs.OxygenSaturation; //Don't clamp here as over-saturation will be used as indicator to reduce RespRate in Patient manager
            }
        }
        #endregion

        public Lungs(Lung leftLung = null, Lung rightLung = null, int? respiratoryRate = null)
        {
            RespiratoryRate = respiratoryRate ?? DefaultLungs.RespirationRate;
            if (leftLung == null || !leftLung.IsLeft)
            {
                LeftLung = new Lung(true);
            }
            else
            {
                LeftLung = leftLung;
            }

            if (rightLung == null || rightLung.IsLeft)
            {
                RightLung = new Lung(false);
            }
            else
            {
                RightLung = rightLung;
            }
        }

        public float GetLungFunction()
        {
            float average = 0;
            if (LeftLung != null)
                average += LeftLung.GetLungEfficiency();
            if (RightLung != null)
                average += RightLung.GetLungEfficiency();

            return average / 2;
        }

        public bool RemoveLung(bool isTargetLeft)
        {
            if (isTargetLeft && LeftLung != null)
            {
                LeftLung = null;
                return true;
            }

            if (!isTargetLeft && RightLung != null)
            {
                RightLung = null;
                return true;
            }

            return false;
        }

        public bool InsertLung(Lung newLung)
        {
            if ((newLung.IsLeft && LeftLung != null) || (!newLung.IsLeft && RightLung != null)) //There is a lung in target location or you are trying to assign a lung to the wrong side
                return false;

            if (newLung.IsLeft)
            {
                LeftLung = newLung;
            }
            else
            {
                RightLung = newLung;
            }

            return true;
        }
    }
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

