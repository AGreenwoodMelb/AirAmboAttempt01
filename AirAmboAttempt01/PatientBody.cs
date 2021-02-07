using AirAmboAttempt01.PatientBlood;
using AirAmboAttempt01.PatientBones;

namespace AirAmboAttempt01.PatientBody
{

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

        #region BodyParts
        private Head _head; 

        public Head Head
        {
            get { return _head; }
            set { _head = value; }
        }

        #endregion
    }


    public abstract class BodyPart
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
        //public bool isMobile; //For later

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
