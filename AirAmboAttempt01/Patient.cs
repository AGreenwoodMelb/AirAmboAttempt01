using System;
using System.Collections.Generic;
using System.Text;

namespace AirAmboAttempt01
{
    public enum BloodType
    {
        ONeg,
        OPos,
        ANeg,
        APos,
        BNeg,
        BPos,
        ABNeg,
        ABPos
    }
    public enum Gender
    {
        Other,
        Male,
        Female
    }
    public enum BodyRegion
    {
        Head,
        Chest,
        Abdomen,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
        Other //?
    }

    class Patient
    {
        readonly string name;
        readonly int age;
        readonly Gender gender;

        Body body;

        //Conditions

        //LATER CONCERNS
        //Insurance
        //DNR bool readonly
    }

    class Body
    {
        readonly BloodType bloodType;
        readonly bool isPregnant;

        public bool isConscious;
        public bool isAlive = true;

        public Skeleton skeleton;

        //GCS - Eyes(1-4), Verb(1-5), Motor(1-6) //This should probably be just Consciousness-bool maybe enum?
        Dictionary<string, int> GCS = new Dictionary<string, int>() //Already hating this idea
        {
            {"Eyes", 1},
            {"Verbal", 1},
            {"Motor", 1},
        };

        public Body()
        {
            skeleton = new Skeleton();
        }

        //BloodVolume ?float ?int



        //Head - Bones (Skull, Spine, Jaw, Facial), Organs (Face, Brain), Vessels, Nerves
        //Chest - Bones (Ribs, Spine, Shoulder), Organs (Lungs, Heart), Vessels, Nerves
        //Abdomen - Bones(Spine, Pelvis), Organs ( GI(Stomach, Bowels, Appendyx), UT(Kidneys, Ureters, Bladder), Other(Pancreas, Liver, Spleen, Reproductives)), Vessels, Nerves
        //Arms (L,R) - Bones( Humerus, Radius, Ulnar, Hand), Vessels, Nerves
        //Legs (L,R) - Bones(Femur, Patella, Tibius, Fibula, Foot), Vessels, Nerves

        //Bloods
        //Electrolytes
        //Drugs - Stimulants, Sedetives, Opiods, Hallucinogens
        //Cardiac
        //Coags

    }

    public class Bone
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

    public class Skeleton
    {
        //Bone[] bones;

        public Skeleton()
        {

        }

        Dictionary<BodyRegion, Bone[]> Bones1 = new Dictionary<BodyRegion, Bone[]>()
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

        //these should be in interventions
        public bool AlignBone(string name, BodyRegion bodyRegion)
        {
            Bone target = GetBone(name, bodyRegion);

            if (target != null && !target.isFused) //Cant align fused bone, must rebreak bone first
            {
                target.AlignBone();
                return !target.isMisaligned;
            }
            return false;
        }

        private Bone GetBone(string name, BodyRegion br)
        {
            Bone[] regionBones = Bones1[br];

            for (int i = 0; i < regionBones.Length; i++)
            {
                if (regionBones[i].name == name)
                    return regionBones[i];
            }
            return null;
        }


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
 */