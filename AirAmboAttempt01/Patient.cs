using System;
using System.Collections.Generic;

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
