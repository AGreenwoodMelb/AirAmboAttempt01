using System;
using System.Collections.Generic;
using System.Text;

namespace AirAmboAttempt01
{
    public class Patient
    {
        readonly string firstName;
        readonly string lastName;
        readonly int age;
        readonly Gender gender;

        public Patient()
        {
            firstName = "John";
            lastName = "Doe";
            age = 30;
            gender = Gender.Other;
        }

        public Patient(string firstName, string lastName, int age, Gender gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
        }

        Body body;

        //Conditions

        //LATER CONCERNS
        //Insurance
        //DNR bool readonly
    }

    class Body
    {
        public Consciousness consciousness;
        public bool isAlive = true;

        public Skeleton skeleton;
        public Organs organs;
        public Blood blood;

        public Body()
        {
            skeleton = new Skeleton();
            organs = new Organs();
            blood = new Blood();
        }
    }

    public class Organs
    {
        readonly bool isPregnant;

        Dictionary<BodyRegion, Organ[]> organs = new Dictionary<BodyRegion, Organ[]>()
        {
            {
                BodyRegion.Head, new Organ[]
                {
                    new Organ("Brain"),
                }
            },

            {
                BodyRegion.Chest, new Organ[]
                {
                    new Organ("Heart"),
                    new Organ("Left Lung"),
                    new Organ("Right Lung"),
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


        private struct Organ
        {
            readonly string name;

            public Organ(string name)
            {
                this.name = name;
            }
        }
    }

    public class Blood
    {
        #region DefaultValues
        readonly float _normalBloodVolume = 6000f; //mL
        static readonly FluidProfile _normalBloodProfile = new FluidProfile()
        {
            Hematocrit = 0.4f,
            ClottingFactor = 1f,
            Electrolytes = 1f
        };
        readonly Dictionary<BleedingSeverity, float> _bloodLossDefaults = new Dictionary<BleedingSeverity, float>()
        {
            { BleedingSeverity.None, 0},
            { BleedingSeverity.Minor, 0.5f},
            { BleedingSeverity.Moderate, 1},
            { BleedingSeverity.Severe, 2}
        };
        #endregion
        
        public readonly BloodType bloodType = new BloodType() { ABO = BloodABO.AB, Rhesus = BloodRhesus.Positive };
        
        Dictionary<BodyRegion, BleedingSeverity> isRegionBleeding = new Dictionary<BodyRegion, BleedingSeverity>()
        {
            {BodyRegion.Head, BleedingSeverity.None},
            {BodyRegion.Chest, BleedingSeverity.None},
            {BodyRegion.Abdomen, BleedingSeverity.None},
            {BodyRegion.LeftArm, BleedingSeverity.None},
            {BodyRegion.RightArm, BleedingSeverity.None},
            {BodyRegion.LeftLeg, BleedingSeverity.None},
            {BodyRegion.RightLeg, BleedingSeverity.None}
        };

        public float CurrentBloodVolume { get; private set; }
        private FluidProfile _bloodProfile = _normalBloodProfile;
        public FluidProfile BloodProfile
        {
            get { return _bloodProfile; }
        }
     
        public bool BloodTranfusion(BloodInfusion incBlood)
        {
            AddVolume(incBlood);
            if (BloodTypeCompatibility(incBlood.BloodType))
            {
                return true;
            }
            else
            {
                return false; //Trigger Transfusion reaction
            }
        }

        private bool BloodTypeCompatibility(BloodType incBloodType)
        {
            if (bloodType.Rhesus == BloodRhesus.Positive || incBloodType.Rhesus == BloodRhesus.Negative)
            {
                if ((incBloodType.ABO == BloodABO.A) && (bloodType.ABO == BloodABO.B))
                {
                    return false;
                }
                else
                {
                    return (bloodType.ABO >= incBloodType.ABO && (bloodType.Rhesus == BloodRhesus.Positive || incBloodType.Rhesus == BloodRhesus.Negative));
                }
            }
            else
            {
                return false;
            }

        }

        public bool FluidTransfusion(InfusionFluid incFluid)//Need this? probably not
        {
            AddVolume(incFluid);

            return true;
        }

        private void AddVolume(InfusionFluid incFluid)
        {
            float newBloodVolume = CurrentBloodVolume + incFluid.Volume;

            //CardiacEnzymes = CardiacEnzymes * (CurrentBloodVolume / newBloodVolume);
            _bloodProfile.Hematocrit = ((incFluid.Volume * incFluid.FluidProfile.Hematocrit) + (CurrentBloodVolume * _bloodProfile.Hematocrit)) / newBloodVolume;


            CurrentBloodVolume = newBloodVolume;
            BloodChecks();
        }

        private void BloodChecks()
        {
            BloodVolumeCheck();
        }

        private void BloodVolumeCheck()
        {
            float BloodVolumeRatio = CurrentBloodVolume / _normalBloodVolume;
            Console.WriteLine(BloodVolumeRatio);
        }



       

        public Blood()
        {
           // illictDrugs = new IllictDrugs();
        }

        public Blood(BloodType bloodType) : this()
        {
            this.bloodType = bloodType;
        }

        public Blood(float hematocrit) : this()
        {
            _bloodProfile.Hematocrit = hematocrit;
        }

        /* Implement this later
        public struct IllictDrugs
        {
            public bool stimulants;
            public bool sedetives;
            public bool opiods;
            public bool hallucinogens;
        }

        private IllictDrugs illictDrugs;

        public IllictDrugs DrugScreen()
        {
            return illictDrugs;
        }
        */

    }

    public class Skeleton
    {
        private Dictionary<BodyRegion, Bone[]> Bones = new Dictionary<BodyRegion, Bone[]>()
        {
            {
                BodyRegion.Head, new Bone[]
                {
                new Bone("Skull"),
                new Bone("Spine"),
                new Bone("Jaw"),
                new Bone("Facial")
                }
            },

            {
                BodyRegion.Chest, new Bone[]
                {
                new Bone("Ribs"),
                new Bone("Spine"),
                new Bone("Shoulder")
                }
            },

            {
                BodyRegion.Abdomen, new Bone[]
                {
                new Bone("Spine"),
                new Bone("Pelvis")
                }
            },

            {
                BodyRegion.LeftArm, new Bone[]
                {
                new Bone("Humerus"),
                new Bone("Radius"),
                new Bone("Ulnar"),
                new Bone("Hand")
                }
            },

            {
                BodyRegion.RightArm, new Bone[]
                {
                new Bone("Humerus"),
                new Bone("Radius"),
                new Bone("Ulnar"),
                new Bone("Hand")
                }
            },

            {
                BodyRegion.LeftLeg, new Bone[]
                {
                new Bone("Femur"),
                new Bone("Tibia"),
                new Bone("Fibula"),
                new Bone("Foot")
                }
            },

            {
                BodyRegion.RightLeg, new Bone[]
                {
                new Bone("Femur"),
                new Bone("Tibia"),
                new Bone("Fibula"),
                new Bone("Foot")
                }
            }
        };

        public bool AlignBone(string name, BodyRegion br)
        {
            Bone target = GetBone(name, br);

            if (!target.isFused) //Cant align fused bone, must rebreak bone first
            {
                target.isMisaligned = false;
                target.isImpingingVessel = false;
                return !target.isMisaligned;
            }
            return false;
        }
        public void BreakBone(string name, BodyRegion br, bool isMisaligned, bool isImpingingVessel)
        {
            Bone targetBone = GetBone(name, br);
            targetBone.isBroken = true;
            targetBone.isMisaligned = isMisaligned;
            targetBone.isImpingingVessel = isImpingingVessel;
        }
        public void FuseBone(string name, BodyRegion br)
        {
            Bone targetBone = GetBone(name, br);
            targetBone.isFused = true;
        }
        public string GetDescription(string name, BodyRegion br, int scanLevel)
        {
            Bone targetBone = GetBone(name, br);
            string broken = targetBone.isBroken ? "" : "not ";
            string aligned = targetBone.isMisaligned ? "" : "not ";
            string impingingVessel = targetBone.isImpingingVessel ? "" : "not ";
            string fused = targetBone.isFused ? "" : "not ";

            return $"The {name} in {br} is {broken} broken, {aligned} aligned, " +
                $"{impingingVessel} impinging a vessel, {fused} fused.";
        }
        private Bone GetBone(string name, BodyRegion br)
        {
            for (int i = 0; i < Bones[br].Length; i++)
            {
                if (Bones[br][i].name == name)
                    return Bones[br][i];
            }
            return new Bone("Error"); //This may be a mistake (no error checking)
        }
        private struct Bone
        {
            public readonly string name;

            public bool isBroken { get; set; }
            public bool isMisaligned { get; set; }
            public bool isImpingingVessel { get; set; }
            public bool isFused { get; set; }

            public Bone(string name)
            {
                this.name = name;
                isBroken = false;
                isMisaligned = false;
                isImpingingVessel = false;
                isFused = false;
            }
            public Bone(string name, bool isBroken, bool isMisaligned, bool isImpingingVessel, bool isFused)
            {
                this.name = name;
                this.isBroken = isBroken;
                this.isMisaligned = isMisaligned;
                this.isImpingingVessel = isMisaligned ? isImpingingVessel : false; //Vessel can only be impinged if bone is misaligned
                this.isFused = isFused;
            }
        }
    }
}


/*
 * bones = new Bone[]
            {
                //Head
                new Bone("Skull",BodyRegion.Head),
                new Bone("Spine",BodyRegion.Head),
                new Bone("Jaw",BodyRegion.Head),
                new Bone("Facial",BodyRegion.Head),

                //Chest
                new Bone("Ribs",BodyRegion.Chest),
                new Bone("Spine",BodyRegion.Chest),
                new Bone("Shoulder",BodyRegion.Chest),

                //Abdomen
                new Bone("Spine",BodyRegion.Abdomen),
                new Bone("Pelvis",BodyRegion.Abdomen),

                //LeftArm
                new Bone("Humerus",BodyRegion.LeftArm),
                new Bone("Radius",BodyRegion.LeftArm),
                new Bone("Ulnar",BodyRegion.LeftArm),
                new Bone("Hand",BodyRegion.LeftArm),

                //RightArm
                new Bone("Humerus",BodyRegion.RightArm),
                new Bone("Radius",BodyRegion.RightArm),
                new Bone("Ulnar",BodyRegion.RightArm),
                new Bone("Hand",BodyRegion.RightArm),

                //LeftLeg
                new Bone("Femur",BodyRegion.LeftLeg),
                new Bone("Patella",BodyRegion.LeftLeg),
                new Bone("Tibea",BodyRegion.LeftLeg),
                new Bone("Fibula",BodyRegion.LeftLeg),
                new Bone("Foot",BodyRegion.LeftLeg),
            };

   //public bool AlignBone(Bone targetBone)
        //{
        //    return AlignBone(targetBone.name, targetBone.bodyRegion);
        //}

        //public Bone GetBone(string name, BodyRegion bodyRegion)
        //{
        //    for (int i = 0; i < bones.Length; i++)
        //    {
        //        if (bones[i].name == name && bones[i].bodyRegion == bodyRegion)
        //            return bones[i];
        //    }

        //    return null;
        //}
        //Bone[] bones;

private class Bone
    {
        public readonly string name;

        public bool isBroken { get; private set; }
        public bool isMisaligned { get; private set; }
        public bool isImpingingVessel { get; private set; }
        public bool isFused { get; private set; }

        public Bone(string name)
        {
            this.name = name;
            isBroken = false;
            isMisaligned = false;
            isImpingingVessel = false;
            isFused = false;
        }

        public Bone(string name, bool isBroken, bool isMisaligned, bool isImpingingVessel, bool isFused)
        {
            this.name = name;
            this.isBroken = isBroken;
            this.isMisaligned = isMisaligned;
            this.isImpingingVessel = isMisaligned ? isImpingingVessel : false; //Vessel can only be impinged if bone is misaligned
            this.isFused = isFused;
        }

        public void AlignBone()
        {
            isMisaligned = false;
            isImpingingVessel = false;
        }

        public void BreakBone(bool isMisaligned, bool isImpingingVessel)
        {
            isBroken = true;
            this.isMisaligned = isMisaligned;
            this.isImpingingVessel = isImpingingVessel;
        }

        public void FuseBone() => isFused = true;

        public string GetDescription(int scanLevel)
        {
            string broken = isBroken ? "" : "not ";
            string aligned = isMisaligned ? "" : "not ";
            string impingingVessel = isImpingingVessel ? "" : "not ";
            string fused = isFused ? "" : "not ";

            return $"The {name} is {broken} broken, {aligned} aligned, " +
                $"{impingingVessel} impinging a vessel, {fused} fused.";
        }
    }
 */