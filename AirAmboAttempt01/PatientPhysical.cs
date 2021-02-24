using PatientManagementSystem.Patients.PatientBlood;
using PatientManagementSystem.Patients.PatientBones;
using PatientManagementSystem.Patients.PatientOrgans;
using PatientManagementSystem.Patients.PatientDefaults;

namespace PatientManagementSystem.Patients.PatientPhysical
{
    /*This class should eventually hold all the calculation based results (e.g GetINR()) as access to all components is available here
     * 
     */

    public class Physical
    {
        #region Props
        private BloodSystem _blood;
        public BloodSystem Blood
        {
            get { return _blood; }
            set { _blood = value; }
        }

        private Limbs _limbs;
        public Limbs Limbs
        {
            get { return _limbs; }
            set { _limbs = value; }
        }

        private Head _head;
        public Head Head
        {
            get { return _head; }
            set { _head = value; }
        }

        private Chest _chest;
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

        public Physical(Head head = null, Chest chest = null, Abdomen abdomen = null, BloodSystem blood = null, Limbs limbs = null)
        {
            Head = (head == null) ? new Head() : head;
            Chest = (chest == null) ? new Chest() : chest;
            Abdomen = (abdomen == null) ? new Abdomen() : abdomen;
            Blood = (blood == null) ? new BloodSystem() : blood;
            Limbs = (limbs == null) ? new Limbs() : limbs;
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
        #region Props
        private Brain _brain;
        public Brain Brain
        {
            get { return _brain; }
            set { _brain = value; }
        }
        #endregion

        public Head(Bone[] headBoneStructure = null, Brain brain = null)
        {
            Bones = headBoneStructure ?? DefaultBoneStructures.DefaultHeadBones;
            Brain = brain ?? new Brain();
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
            Bones = chestBoneStructure ?? DefaultBoneStructures.DefaultChestBones;
            Heart = heart ?? new Heart();
            Lungs = lungs ?? new Lungs();
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

        private UrinaryTract _kidneys;
        public UrinaryTract UrinaryTract
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

        public Abdomen(Bone[] abdomenBoneStructure = null, GastrointestinalTract gastrointestinalTract = null, Liver liver = null, Pancreas pancreas = null, UrinaryTract urinaryTract = null, Spleen spleen = null, Reproductive reproductives = null)
        {
            Bones = abdomenBoneStructure ?? DefaultBoneStructures.DefaultAbdomenBones;
            GastrointestinalTract = gastrointestinalTract ?? new GastrointestinalTract();
            Liver = liver ?? new Liver();
            Pancreas = pancreas ?? new Pancreas();
            UrinaryTract = urinaryTract ?? new UrinaryTract();
            Spleen = spleen ?? new Spleen();
            Reproductives = reproductives ?? new Reproductive_Female();
        }
    }

    //What am I doing with this? Fractures? Infections? Stuff????
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
            LeftArm = leftArm ?? new Arm();
            RightArm = rightArm ?? new Arm();
        }
    }
    public class Arm : Limb
    {
        public Arm(Bone[] armBoneStructure = null)
        {
            Bones = armBoneStructure ?? DefaultBoneStructures.DefaultArmBones;
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

        public Legs(Leg leftLeg = null, Leg rightLeg = null)
        {
            LeftLeg = leftLeg ?? new Leg();
            RightLeg = rightLeg ?? new Leg();
        }
    }
    public class Leg : Limb
    {
        public Leg(Bone[] legBoneStructure = null)
        {
            Bones = legBoneStructure ?? DefaultBoneStructures.DefaultLegBones;
        }
    }
    #endregion
}
