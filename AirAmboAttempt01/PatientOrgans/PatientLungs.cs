using PatientManagementSystem.Patients.PatientDefaults;
using PatientManagementSystem.Patients.PatientInfection;
using System;

namespace PatientManagementSystem.Patients.PatientOrgans
{
    public enum BreathSounds
    {
        None,
        Normal,
        Wheezing,
        Bubbling
    } // if RespRate = 0 then BreathSounds = none

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
            //float average = 0f;
            //average += DefaultLungs.LungFunctionValues[UpperLobe.LobeState];
            //average += DefaultLungs.LungFunctionValues[LowerLobe.LobeState];
            //if (IsLeft)
            //{
            //    return average / 2f;
            //}
            //else
            //{
            //    average += DefaultLungs.LungFunctionValues[MiddleLobe.LobeState];
            //    return average / 3f;
            //}
            return 0;
        }

    }
    public class Lungs
    {
        #region Props
        private Lung _leftLung;
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

        private int _respiratoryRate;
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
}
