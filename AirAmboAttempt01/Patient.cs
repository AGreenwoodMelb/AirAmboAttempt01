using System;
using System.Collections.Generic;

namespace AirAmboAttempt01
{
    public class Patient
    {
        public readonly string firstName;
        public readonly string lastName;
        public readonly int age;
        public readonly Gender gender;
        public bool isAlive = true;

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


        private Physical _physical;
        public Physical Body
        {
            get { return _physical; }
            private set { _physical = value; }
        }


        private Mental _mind;
        public Mental Mind
        {
            get { return _mind; }
            private set { _mind = value; }
        }

        //Conditions

        //LATER CONCERNS
        //Insurance
        //DNR bool readonly
    }

    public class Mental
    {
        public Consciousness Consciousness;
        public MentalState MentalState;
        public PainSeverity OverallPain; //May not need

        Dictionary<BodyRegion, PainSeverity> RegionPainful = new Dictionary<BodyRegion, PainSeverity>()
        {
            {BodyRegion.Head, PainSeverity.None},
            {BodyRegion.Chest, PainSeverity.None},
            {BodyRegion.Abdomen, PainSeverity.None},
            {BodyRegion.LeftArm, PainSeverity.None},
            {BodyRegion.RightArm, PainSeverity.None},
            {BodyRegion.LeftLeg, PainSeverity.None},
            {BodyRegion.RightLeg, PainSeverity.None}
        }; //Move to BodyPart
    }

    public class Physical
    {
        //public Skeleton skeleton;
        public OrganSystems organs;// Change this for Head, Chest, Abdo class
        public BloodSystem bloodSystem;

        Dictionary<BodyRegion, BleedingSeverity> RegionBleeding = new Dictionary<BodyRegion, BleedingSeverity>()//Move to BodyPart
        {
            {BodyRegion.Head, BleedingSeverity.None},
            {BodyRegion.Chest, BleedingSeverity.None},
            {BodyRegion.Abdomen, BleedingSeverity.None},
            {BodyRegion.LeftArm, BleedingSeverity.None},
            {BodyRegion.RightArm, BleedingSeverity.None},
            {BodyRegion.LeftLeg, BleedingSeverity.None},
            {BodyRegion.RightLeg, BleedingSeverity.None}
        };

        public Physical()
        {
            //skeleton = new Skeleton();
            organs = new OrganSystems(true);
            bloodSystem = new BloodSystem();
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



    }

    public class Body
    {
        #region Limbs
        #region Arms
        private Arm _leftArm = new Arm(true);

        public Arm LeftArm
        {
            get { return _leftArm; }
            set { _leftArm = value; }
        }

        private Arm _rightArm = new Arm(false);

        public Arm RightArm
        {
            get { return _rightArm; }
            set { _rightArm = value; }
        }
        #endregion
        #region Legs
        private Leg _leftLeg;

        public Leg LeftLeg
        {
            get { return _leftLeg; }
            set { _leftLeg = value; }
        }

        private Leg _rightLeg;

        public Leg RightLeg
        {
            get { return _rightLeg; }
            set { _rightLeg = value; }
        }

        #endregion
        #endregion

        #region Organs

        #endregion
    }


    public struct Bone
    {
        public readonly string name;

        public bool isBroken { get; set; }
        public bool isMisaligned { get; set; }
        public bool isImpingingVessel { get; set; }
        public bool isFused { get; set; } //May remove

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

    public class BodyPart
    {
        public BleedingSeverity SurfaceBleedingSeverity;
        public PainSeverity PainSeverity;
    }

    public class Head : BodyPart
    {
        private Brain _brain;

        public Brain Brain
        {
            get { return _brain; }
            set { _brain = value; }
        }

        public Head()
        {

        }


    }


    public class Limb : BodyPart
    {
        public BleedingSeverity LimbBleeding;
        public readonly bool isLeft;

        private Bone[] _bones;

        public Bone[] Bones
        {
            get { return _bones; }
            protected set { _bones = value; }
        }


        public Limb(bool isLeft)
        {
            this.isLeft = isLeft;
        }
    }

    public class Arm : Limb
    {
        public Arm(bool isLeft, Bone[] armBoneStructure = null) : base(isLeft)
        {
            if (armBoneStructure == null)
            {
                Bones = DefaultBoneStructures.DefaultArmBones;
            }
            else
            {
                Bones = armBoneStructure;
            }
        }
     
    }

    public class Leg : Limb
    {
        public Leg(bool isLeft) : base(isLeft)
        {

        }
    }

}
