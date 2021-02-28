using PatientManagementSystem.Patients.PatientDefaults;
using System;
using System.Collections.Generic;

namespace PatientManagementSystem.Patients.PatientOrgans
{
    public enum LungBreathSounds
    {
        /* NOTES:
         * Consider redoing / expanding using the follow info: https://medlineplus.gov/ency/article/007535.htm
         */
        Unknown, //Player hasnt checked yet
        None,
        Normal,
        Wheezing, //Inflammation - Infection / other
        Bubbling, //Fluid - Bleeding / infection / Aspiration

    }
    public enum LungPrecussionSounds
    {
        /* NOTES: 
         * [1]: https://www.physio-pedia.com/Respiratory_Assessment-_Percussion
         */
        Unknown, //Player hasnt checked yet
        Normal,
        Dull, //"Likely indicating: atelectasis, tumour, plural effusion, lobar pneumonia" [1]
        Hyperresonant, //"Likely indicating: Emphysema or pneumothorax" [1]
    }
    public enum LungLobeLocation
    {
        Upper,
        Middle,
        Lower
    }

    public class LungLobe : Organ
    {
        #region Props
        private LungBreathSounds _breathSounds = LungBreathSounds.Normal;
        public LungBreathSounds BreathSounds
        {
            get { return _breathSounds; }
            set { _breathSounds = value; }
        }

        private LungPrecussionSounds _precussionSounds = LungPrecussionSounds.Normal;
        public LungPrecussionSounds PrecussionSounds
        {
            get { return _precussionSounds; }
            set { _precussionSounds = value; }
        }
        #endregion

        public LungLobe() : base(DefaultBloodLossBaseRates.Lung)
        {
        }
    }

    public abstract class Lung
    {
        public abstract Dictionary<LungLobeLocation, LungLobe> Lobes { get; }
        public abstract float GetLungEfficiency();
    }

    public class LeftLung : Lung
    {
        public override Dictionary<LungLobeLocation, LungLobe> Lobes { get; } = new Dictionary<LungLobeLocation, LungLobe>()
        {
            { LungLobeLocation.Upper, new LungLobe() },
            { LungLobeLocation.Middle, new LungLobe() },
            { LungLobeLocation.Lower, new LungLobe() },
        };

        public override float GetLungEfficiency()
        {
            float average = 0f;
            average += Lobes[LungLobeLocation.Upper].OrganEfficiency;
            average += Lobes[LungLobeLocation.Middle].OrganEfficiency;
            average += Lobes[LungLobeLocation.Lower].OrganEfficiency;
            return average / 3f;
        }
    }

    public class RightLung : Lung
    {
        public override Dictionary<LungLobeLocation, LungLobe> Lobes { get; } = new Dictionary<LungLobeLocation, LungLobe>()
        {
            { LungLobeLocation.Upper, new LungLobe() },
            { LungLobeLocation.Lower, new LungLobe() },
        };

        public override float GetLungEfficiency()
        {
            float average = 0f;
            average += Lobes[LungLobeLocation.Upper].OrganEfficiency;
            average += Lobes[LungLobeLocation.Lower].OrganEfficiency;
            return average / 2f;
        }
    }

    public class RespiratorySystem
    {
        #region Props
        private LeftLung _leftLung;
        public LeftLung LeftLung
        {
            get { return _leftLung; }
            private set { _leftLung = value; }
        }

        private RightLung _rightLung;
        public RightLung RightLung
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

        public RespiratorySystem(LeftLung leftLung = null, RightLung rightLung = null, int? respiratoryRate = null)
        {
            RespiratoryRate = respiratoryRate ?? DefaultLungs.RespirationRate;
            LeftLung = leftLung ?? new LeftLung();
            RightLung = rightLung ?? new RightLung();
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

        public bool RemoveLung(bool isTargetLeft, out Lung RemovedLung)
        {
            if (isTargetLeft && LeftLung != null)
            {
                RemovedLung = LeftLung;
                LeftLung = null;
                return true;
            }

            if (!isTargetLeft && RightLung != null)
            {
                RemovedLung = RightLung;
                RightLung = null;
                return true;
            }

            RemovedLung = null;
            return false;
        }

        public bool InsertLung(Lung newLung)
        {
            switch (newLung)
            {
                case LeftLung leftLung:
                    if (LeftLung == null)
                    {
                        LeftLung = leftLung;
                        return true;
                    }
                    break;
                case RightLung rightLung:
                    if (RightLung == null)
                    {
                        RightLung = rightLung;
                        return true;
                    }
                    break;
                default:
                    throw new ArgumentException(message: $"Unrecognised Lung Type: {newLung.GetType().Name}");
            }
            return false;
        }
    }
}
