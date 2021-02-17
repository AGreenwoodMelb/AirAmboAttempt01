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
    public enum ArtificialAirway
    {
        None,
        FaceMask,
        LaryngealMask
    }

    public class AccessPoints
    {
        public CerebralShunt CerebralShunt; //TODO: Finish implementing this
        public ArtificialAirway artificialAirway;
        public bool HasIVAccess => CheckForIVAccess();
        public bool HasUrinaryCatheter;
        public Dictionary<IVTargetLocation, IVAccess> IVs = new Dictionary<IVTargetLocation, IVAccess>()
        {
            {IVTargetLocation.ArmLeft, null },
            {IVTargetLocation.ArmRight, null },
            {IVTargetLocation.LegLeft, null },
            {IVTargetLocation.LegRight, null },
            {IVTargetLocation.CentralLine, null },
        };
        private bool CheckForIVAccess()
        {
            foreach (KeyValuePair<IVTargetLocation, IVAccess> IVPoint in IVs)
            {
                if (IVPoint.Value != null)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class IVAccess
    {
        public Infection infection;
        public bool IsBlocked;
        public Fluid CurrentFluid { get; set; }
        public float FlowRate { get; set; }
        public Drug AddedDrug { get; set; }
    }

    public class CerebralShunt
    {
        public Infection infection;
        public float OpeningCerebralPressure; //This is probably useless but is intended to be the cerebral pressure at which the drain opens. May actually have some use.
        public bool IsBlocked;
    }

   
}
