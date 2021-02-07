using AirAmboAttempt01.Patients.PatientBlood;
using AirAmboAttempt01.Patients.PatientBones;
using AirAmboAttempt01.Patients.PatientOrgans;

namespace AirAmboAttempt01.Patients.PatientPhysical
{

    public class Physical
    {
        #region Props
        private BloodSystem _blood = new BloodSystem();
        public BloodSystem Blood
        {
            get { return _blood; }
            set { _blood = value; }
        }

        private Limbs _limbs = new Limbs();
        public Limbs Limbs
        {
            get { return _limbs; }
            set { _limbs = value; }
        }

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

        private Abdomen _abdomen;
        public Abdomen Abdomen
        {
            get { return _abdomen; }
            set { _abdomen = value; }
        }
        #endregion

        public Physical(bool isMale = false)
        {
            Abdomen = new Abdomen(isMale);
        }

        public Physical(Head head = null, Chest chest = null, Abdomen abdomen = null, BloodSystem blood = null, Limbs limbs = null)
        {
            if (head != null)
                _head = head;

            if (chest != null)
                _chest = chest;

            if (abdomen != null)
                _abdomen = abdomen;

            if (blood != null)
                _blood = blood;

            if (limbs != null)
                _limbs = limbs;
        }
    }

    public abstract class PhysicalPart
    {
        public BleedingSeverity SurfaceBleedingSeverity;
        public PainSeverity PainSeverity;

        private Bone[] _bones;

        public Bone[] Bones
        {
            get { return _bones; }
            protected set { _bones = value; }
        }

        public bool AnyBonesBroken()
        {
            foreach (Bone bone in Bones)
            {
                if (bone.isBroken)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Head : PhysicalPart
    {
        private Brain _brain;
        public Brain Brain
        {
            get { return _brain; }
            set { _brain = value; }
        }

        public Head(Bone[] headBoneStructure = null, Brain brain = null)
        {
            Bones = (headBoneStructure == null) ? DefaultBoneStructures.DefaultHeadBones : headBoneStructure;
            Brain = (brain == null) ? new Brain() : brain;
        }
    }

    public class Chest : PhysicalPart
    {
        #region Props
        private Heart _heart;
        public Heart Heart
        {
            get { return _heart; }
            set { _heart = value; }
        }

        private Lungs _lungs;
        public Lungs Lungs
        {
            get { return _lungs; }
            set { _lungs = value; }
        }
        #endregion

        public Chest(Bone[] chestBoneStructure = null, Heart heart = null, Lungs lungs = null)
        {
            Bones = (chestBoneStructure == null) ? DefaultBoneStructures.DefaultChestBones : chestBoneStructure;
            Heart = (heart == null) ? new Heart() : heart;
            Lungs = (lungs == null) ? new Lungs() : lungs;
        }
    }

    public class Abdomen : PhysicalPart
    {
        #region Props
        private GastrointestinalTract _gastrointestinalTract;
        public GastrointestinalTract GastrointestinalTract
        {
            get { return _gastrointestinalTract; }
            set { _gastrointestinalTract = value; }
        }

        private Liver _liver;
        public Liver Liver
        {
            get { return _liver; }
            set { _liver = value; }
        }

        private Pancreas _pancreas;
        public Pancreas Pancreas
        {
            get { return _pancreas; }
            set { _pancreas = value; }
        }

        private Kidneys _kidneys;
        public Kidneys Kidneys
        {
            get { return _kidneys; }
            set { _kidneys = value; }
        }

        private Spleen _spleen;
        public Spleen Spleen
        {
            get { return _spleen; }
            set { _spleen = value; }
        }

        private Reproductive _reproductives;
        public Reproductive Reproductives
        {
            get { return _reproductives; }
            set { _reproductives = value; }
        }
        #endregion

        public Abdomen(Bone[] abdomenBoneStructure = null, GastrointestinalTract gastrointestinalTract = null, Liver liver = null, Pancreas pancreas = null, Kidneys kidneys = null, Spleen spleen = null, Reproductive reproductives = null)
        {
            Bones = (abdomenBoneStructure == null) ? DefaultBoneStructures.DefaultAbdomenBones : abdomenBoneStructure;
            GastrointestinalTract = (gastrointestinalTract == null) ? new GastrointestinalTract() : gastrointestinalTract;
            Liver = (liver == null) ? new Liver() : liver;
            Pancreas = (pancreas == null) ? new Pancreas() : pancreas;
            Kidneys = (kidneys == null) ? new Kidneys() : kidneys;
            Spleen = (spleen == null) ? new Spleen() : spleen;
            Reproductives = (reproductives == null) ? new Reproductive_Female() : reproductives;
        }

        public Organ[] GetOrgans()
        {
            return new Organ[]
            {
                GastrointestinalTract,
                Kidneys.LeftKidney,
                Kidneys.RightKidney,
                Liver,
                Pancreas,
                Spleen,
                Reproductives
            };
        }
    }

    #region LimbRelatedClasses
    public class Limbs
    {
        private Arms _arms = new Arms();

        public Arms Arms
        {
            get { return _arms; }
            set { _arms = value; }
        }

        private Legs _legs = new Legs();

        public Legs Legs
        {
            get { return _legs; }
            set { _legs = value; }
        }
    }
    public class Limb : PhysicalPart
    {
        //Bool isImmobile //For later
    }

    public class Arms
    {
        #region Props
        private Arm _leftArm;
        public Arm LeftArm
        {
            get { return _leftArm; }
            set { _leftArm = value; }
        }

        private Arm _rightArm;
        public Arm RightArm
        {
            get { return _rightArm; }
            set { _rightArm = value; }
        }
        #endregion

        public Arms(Arm leftArm = null, Arm rightArm = null)
        {
            LeftArm = (leftArm == null) ? new Arm() : leftArm;
            RightArm = (rightArm == null) ? new Arm() : rightArm;
        }
    }
    public class Arm : Limb
    {
        public Arm(Bone[] armBoneStructure = null)
        {
            Bones = (armBoneStructure == null) ? DefaultBoneStructures.DefaultArmBones : armBoneStructure;
        }
    }

    public class Legs
    {
        #region Props
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

        public Legs(Leg leftLeg = null,  Leg rightLeg = null)
        {
            LeftLeg = (leftLeg == null) ? new Leg() : leftLeg;
            RightLeg = (rightLeg == null) ? new Leg() : rightLeg;
        }
    }
    public class Leg : Limb
    {
        public Leg(Bone[] legBoneStructure = null)
        {
            Bones = (legBoneStructure == null) ? DefaultBoneStructures.DefaultLegBones : legBoneStructure;
        }
    }
    #endregion
}
