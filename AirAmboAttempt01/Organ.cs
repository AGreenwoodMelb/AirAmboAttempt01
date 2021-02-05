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
                    new Lung(),
                    new Lung(),
                }
            },

            {
                BodyRegion.Abdomen, new Organ[]
                {
                    new Organ("Gastrointestinal Tract"),
                    new Organ("Urinary Tract"),
                    new Organ("Liver"),
                    new Organ("Pancreas"),
                    new Organ("Spleen"),
                    new Organ("Reproductive"),
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

            private Infection _currentInfection;
            public Infection CurrentInfection
            {
                get { return _currentInfection; }
                private set { _currentInfection = value; }
            }
        }

        public class Brain : Organ
        {
            private float _currentPressure = 0f;
            private bool _isSeizing;

            public void Haemorrhage()
            {
                IsBleeding = BleedingSeverity.Extreme;
            }
            
        }

        public class Heart : Organ
        {
            private bool _isBeating;
            private bool _isArrythmic;

            private int rate;
        }

        public class Lung : Organ
        {
            
        }
    }



}
