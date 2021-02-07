using System;
using System.Collections.Generic;
using AirAmboAttempt01.PatientBlood;
using AirAmboAttempt01.PatientInfection;

namespace AirAmboAttempt01
{
    #region BaseOrganClasses
    public class Organ
    {
        private BleedingSeverity _isBleeding = BleedingSeverity.None;
        public BleedingSeverity IsBleeding
        {
            get { return _isBleeding; }
            protected set { _isBleeding = value; }
        }
        public readonly float BloodLossRate;

        public Organ(float bloodLossRate)
        {
            BloodLossRate = bloodLossRate;
        }
    }

    //public class PairedOrgan : Organ
    //{
    //    public readonly bool isLeft;

    //    public PairedOrgan(float bloodLossBaseRate, bool isLeft) : base(bloodLossBaseRate)
    //    {
    //        this.isLeft = isLeft;
    //    }
    //}
    #endregion
    #region PracticalOrganClasses
    #region HeadOrgans
    public class Brain : Organ
    {
        private float _currentPressure = 0f;
        private bool _isSeizing;

        public Brain() : base(DefaultBloodLossBaseRates.Brain)
        {

        }

    }
    #endregion
    #region ChestOrgans
    public class Heart : Organ
    {
        private bool _isBeating;
        private bool _isArrythmic;
        private bool _hasPaceMaker;

        private int _beatsPerMinute;

        public Heart() : base(DefaultBloodLossBaseRates.Heart)
        {

        }
    }
   
    public enum LungLobeLocation
    {
        Upper,
        Middle,
        Lower
    }

    public class Lung : Organ
    {
        private Dictionary<LungLobeLocation, LungLobe> Lobes;

        public Lung(bool isLeft) : base(DefaultBloodLossBaseRates.Lung)
        {
            if (isLeft)
            {
                Lobes = new Dictionary<LungLobeLocation, LungLobe>()
                    {
                        { LungLobeLocation.Upper, new LungLobe()},
                        { LungLobeLocation.Middle, null},

                        { LungLobeLocation.Lower, new LungLobe()}
                    };
            }
            else
            {
                Lobes = new Dictionary<LungLobeLocation, LungLobe>()
                    {
                        { LungLobeLocation.Upper, new LungLobe()},
                        { LungLobeLocation.Middle, new LungLobe()},
                        { LungLobeLocation.Lower, new LungLobe()}
                    };
            }
        }

        private LungLobe GetLungLobe(LungLobeLocation lobeLocation)
        {
            if (Lobes.ContainsKey(lobeLocation))
            {
                return Lobes[lobeLocation];
            }
            else
            {
                throw new KeyNotFoundException(
                    message: $"{lobeLocation} not found in Lung (Left Lung: )"
                    );
            }
        }
    }
    public class LungLobe
    {
        public Infection infection;
        public bool isDestroyed;
    }
    public class Lungs
    {

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
        private Kidney _leftKidney;

        public Kidney LeftKidney
        {
            get { return _leftKidney; }
            set { _leftKidney = value; }
        }

        private Kidney _rightKidney;

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

