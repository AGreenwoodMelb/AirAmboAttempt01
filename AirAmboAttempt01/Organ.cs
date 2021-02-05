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

            //public Infection CurrentInfection
            //{
            //    get { return _currentInfection; }
            //    set { _currentInfection = value; }
            //}

            //public void IncreaseInfection()
            //{
            //    _currentInfection.IncreaseInfection();
            //}

            //public void DecreaseInfection()
            //{
            //    _currentInfection.DecreaseInfection();
            //}

            //public void CureInfection()
            //{
            //    _currentInfection.CureInfection();
            //}
        }

        public class Brain : Organ
        {
            private float _currentPressure = 0f;
            private bool _isSeizing;

            public Brain() : base(BloodLossBaseRates.Brain)
            {

            }
            public void Haemorrhage()
            {
                IsBleeding = BleedingSeverity.Extreme;
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

            private LungLobe[] Lobes;

            public Lung(bool isLeft) : base(BloodLossBaseRates.Lung)
            {
                if (isLeft)
                {
                    Lobes = new LungLobe[]
                    {
                        new LungLobe()
                        {
                            lobeLocation = LobeLocation.Upper,
                            infection = new Infection()
                        },
                        new LungLobe()
                        {
                            lobeLocation = LobeLocation.Lower,
                            infection = new Infection()
                        },
                    };
                }
                else
                {
                    Lobes = new LungLobe[]
                    {
                        new LungLobe()
                        {
                            lobeLocation = LobeLocation.Upper,
                            infection = new Infection()
                        },
                         new LungLobe()
                        {
                            lobeLocation = LobeLocation.Middle,
                            infection = new Infection()
                        },
                        new LungLobe()
                        {
                            lobeLocation = LobeLocation.Lower,
                            infection = new Infection()
                        },
                    };
                }
            }
        }
    }

}
