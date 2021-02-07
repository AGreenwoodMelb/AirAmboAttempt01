﻿using AirAmboAttempt01.PatientBlood;
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
