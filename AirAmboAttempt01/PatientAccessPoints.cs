using PatientManagementSystem.Patients.PatientDrugs;
using PatientManagementSystem.Patients.PatientInfection;
using System.Collections.Generic;

namespace PatientManagementSystem.Patients.PatientAccessPoints
{
    public enum IVTargetLocation
    {
        None,
        ArmLeft,
        ArmRight,
        LegLeft,
        LegRight,
        CentralLine
    }
    public enum ArtificialAirwayType
    {
        None,
        FaceMask,
        LaryngealMask
    }

    public class AccessPoints
    {
        public CerebralShunt CerebralShunt; 
        public ArtificialAirway ArtificialAirway;
        public UrinaryCatheter UrinaryCatheter;

        public bool HasIVAccess => CheckForIVAccess();
        
        public Dictionary<IVTargetLocation, IV> IVs = new Dictionary<IVTargetLocation, IV>()
        {
            {IVTargetLocation.ArmLeft, new IV() },
            {IVTargetLocation.ArmRight, new IV()},
            {IVTargetLocation.LegLeft, new IV() },
            {IVTargetLocation.LegRight, new IV() },
            {IVTargetLocation.CentralLine, new IV() },
        };

        private bool CheckForIVAccess()
        {
            foreach (KeyValuePair<IVTargetLocation, IV> IVPoint in IVs)
            {
                if (IVPoint.Value.IsInserted)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public abstract class AccessPoint
    {
        public bool IsInserted;
        public bool IsBlocked;

        public virtual void Remove()
        {
            IsInserted = false;
            IsBlocked = false;
        }
    }
    public class IV : AccessPoint
    {
        //public Infection infection; //Should remove to Infections class
        //public Fluid CurrentFluid { get; set; } //Move to IVPole system?
        //public float FlowRate { get; set; } //Move to IVPole system?
        //public Drug AddedDrug { get; set; } //Move to IVPole system?
    }

    public class CerebralShunt : AccessPoint
    {
        public float OpeningCerebralPressure; //This is probably useless but is intended to be the cerebral pressure at which the drain opens. May actually have some use.
        public override void Remove()
        {
            base.Remove();
            OpeningCerebralPressure = -1f;
        }
    }

    public class UrinaryCatheter : AccessPoint
    {

    }

    public class ArtificialAirway : AccessPoint
    {
        public ArtificialAirwayType AirwayType { get; private set; }

        public override void Remove()
        {
            base.Remove();
            AirwayType = ArtificialAirwayType.None;
        }

        public void Insert(ArtificialAirwayType artificialAirwayType)
        {
            AirwayType = artificialAirwayType;
        }
    }
   
}
