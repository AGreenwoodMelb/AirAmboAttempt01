using System;
using System.Collections.Generic;
using System.Text;

namespace AirAmboAttempt01
{

    public class Organs
    {
        readonly bool isPregnant;

        Dictionary<BodyRegion, Organ[]> organs = new Dictionary<BodyRegion, Organ[]>()
        {
            {
                BodyRegion.Head, new Organ[]
                {
                    new Brain(),
                }
            },

            {
                BodyRegion.Chest, new Organ[]
                {
                    new Heart(),
                    new Lung(true),
                    new Lung(false),
                }
            },

            {
                BodyRegion.Abdomen, new Organ[]
                {
                    //GI
                    //Kidney Left, Right
                    //Liver
                    //Pancreas
                    //Spleen
                    //Reproductive
                }
            }
        };

        public abstract class Organ
        {
            private BleedingSeverity _isBleeding = BleedingSeverity.None;
            public BleedingSeverity IsBleeding
            {
                get { return _isBleeding; }
                protected set { _isBleeding = value; }
            }

            public readonly float BloodLossRate;
            public Infection CurrentInfection = new Infection();


            public Organ(float bloodLossRate)
            {
                BloodLossRate = bloodLossRate;
            }

            public void InfectOrgan(Infection infection)
            {
                CurrentInfection = infection;
            }
        }

        public class Brain : Organ
        {
            private float _currentPressure = 0f;
            private bool _isSeizing;

            public Brain() : base(BloodLossBaseRates.Brain)
            {

            }

        }

        public class Heart : Organ
        {
            private bool _isBeating;
            private bool _isArrythmic;

            private int _beatsPerMinute;

            public Heart() : base(BloodLossBaseRates.Heart)
            {

            }
        }

        public class Lung : Organ
        {
            public readonly bool isLeft;

            //private LungLobe[] Lobes;

            private Dictionary<LungLobeLocation, LungLobe> Lobes;

            public Lung(bool isLeft) : base(BloodLossBaseRates.Lung)
            {
                if (isLeft)
                {
                    Lobes = new Dictionary<LungLobeLocation, LungLobe>()
                    {
                        { LungLobeLocation.Upper, new LungLobe()},
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
                        message: $"{lobeLocation} not found in Lung (Left Lung: {isLeft})"
                        );

                }
            }
        }
    }

}
