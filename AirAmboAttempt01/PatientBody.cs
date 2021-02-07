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
        private Head _head = new Head();
        public Head Head
        {
            get { return _head; }
            set { _head = value; }
        }

        private Chest _chest = new Chest();
        public Chest Chest
        {
            get { return _chest; }
            set { _chest = value; }
        }

        private Abdomen _abdomen = new Abdomen(true);
        public Abdomen Abdomen
        {
            get { return _abdomen; }
            set { _abdomen = value; }
        }

        #endregion
    }

    public abstract class BodyPart
    {
        public BleedingSeverity SurfaceBleedingSeverity;
        public PainSeverity PainSeverity;

        private Bone[] _bones;

        public Bone[] Bones
        {
            get { return _bones; }
            protected set { _bones = value; }
        }

    }

    public class Head : BodyPart
    {
        private Brain _brain;
        public Brain Brain
        {
            get { return _brain; }
            set { _brain = value; }
        }

        public Head(Bone[] headBoneStructure = null)
        {
            if(headBoneStructure == null)
            {
                Bones = DefaultBoneStructures.DefaultHeadBones;
            }
            else
            {
                Bones = headBoneStructure;
            }
        }
    }

    public class Chest : BodyPart
    {
        private Heart _heart = new Heart();
        public Heart Heart
        {
            get { return _heart; }
            set { _heart = value; }
        }

        private Lung _leftLung = new Lung(true);
        public Lung LeftLung
        {
            get { return _leftLung; }
            set { _leftLung = value; }
        }

        private Lung _rightLung = new Lung(false);
        public Lung RightLung
        {
            get { return _rightLung; }
            set { _rightLung = value; }
        }
    }

    public class Abdomen
    {
        private GastrointestinalTract _gastrointestinalTract = new GastrointestinalTract();
        public GastrointestinalTract GastrointestinalTract
        {
            get { return _gastrointestinalTract; }
            set { _gastrointestinalTract = value; }
        }

        private Liver _liver = new Liver(); 
        public Liver Liver
        {
            get { return _liver; }
            set { _liver = value; }
        }

        private Pancreas _pancreas = new Pancreas();
        public Pancreas Pancreas
        {
            get { return _pancreas; }
            set { _pancreas = value; }
        }

        private Kidney _leftKidney = new Kidney(true);
        public Kidney LeftKidney
        {
            get { return _leftKidney; }
            set { _leftKidney = value; }
        }

        private Kidney _rightKidney = new Kidney(false);
        public Kidney RightKidney
        {
            get { return _rightKidney; }
            set { _rightKidney = value; }
        }

        private Spleen _spleen = new Spleen();
        public Spleen Spleen
        {
            get { return _spleen; }
            set { _spleen = value; }
        }

        private Reproductive _repoductives;
        public Reproductive Reproductives
        {
            get { return _repoductives; }
            set { _repoductives = value; }
        }

        public Abdomen(bool isMale)
        {
            if (isMale)
            {
                _repoductives = new Reproductive_Male();
            }
            else
            {
                _repoductives = new Reproductive_Female();
            }
        }
    }

    public class PairedBodyPart : BodyPart
    {
        public readonly bool isLeft;

        public PairedBodyPart(bool isLeft)
        {
            this.isLeft = isLeft;
        }
    }

    public class Limb : PairedBodyPart
    {
        //Bool isImmobile //For later

        public Limb(bool isLeft) : base(isLeft)
        {

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

    public class Leg : PairedBodyPart
    {
        public Leg(bool isLeft) : base(isLeft)
        {

        }
    }

}
