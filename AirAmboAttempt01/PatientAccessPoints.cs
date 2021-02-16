using PatientManagementSystem.Patients.PatientDrugs;
using PatientManagementSystem.Patients.PatientInfection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagementSystem.Patients.PatientAccessPoints
{
    public class AccessPoints
    {
        public Dictionary<IVTargetLocation, IVAccess> IVs = new Dictionary<IVTargetLocation, IVAccess>()
        {
            {IVTargetLocation.ArmLeft, null },
            {IVTargetLocation.ArmRight, null },
            {IVTargetLocation.LegLeft, null },
            {IVTargetLocation.LegRight, null },
            {IVTargetLocation.CentralLine, null },
        };

        public ArtificialAirway artificialAirway;
        public bool HasUrinaryCatheter;
        public bool HasIVAccess => CheckForIVAccess();
        public bool HasCerebralShunt; //TODO: Temp, replace with CerebralShunt object to allow for isBlocked, isInfected bool etc;
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
        public Fluid CurrentFluid { get; set; }
        public float FlowRate { get; set; }
        public Drug AddedDrug { get; set; }
    }

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
}
