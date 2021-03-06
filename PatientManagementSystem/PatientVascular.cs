using PatientManagementSystem.Patients.PatientDefaults;
using PatientManagementSystem.Patients.PatientOrgans;
using System;
using System.Collections.Generic;

namespace PatientManagementSystem.Patients.Vascular
{
    public enum VesselState
    {
        Unknown,
        Normal,
        Narrowed,
        Blocked,
    }
    public class Vessel
    {
        public readonly Vessel SupplyVessel;
        public readonly string Name;
        public float Patency = 1f;
        public VesselState VesselState => GetVesselState();
        private VesselState GetVesselState()
        {
            float NormalThreshold = 0.8f;
            float NarrowedThreshold = 0.4f;

            if (Patency > NormalThreshold)
                return VesselState.Normal;
            if (Patency > NarrowedThreshold)
                return VesselState.Narrowed;

            return VesselState.Blocked;
        }

        public Vessel(string vesselName, Vessel supplyVessel = null)
        {
            SupplyVessel = supplyVessel;
            Name = vesselName;
        }

        public Vessel GetLowestPatencyVessel()
        {
            Vessel lowest = this;
            if (SupplyVessel != null)
            {
                Vessel tmp = SupplyVessel.GetLowestPatencyVessel();
                lowest = (tmp.Patency < lowest.Patency) ? tmp : lowest;
            }
            return lowest;
        }

        public Vessel GetOrigin()
        {
            if (SupplyVessel != null)
            {
                return SupplyVessel.GetOrigin();
            }
            else
            {
                return this;
            }
        }
    }
    public class VascularSystem
    {
        public Dictionary<string, Vessel> OxygenatedVessels;
        public Dictionary<string, Vessel> DeoxygenatedVessels;

        public float BrainSupply;

        public VascularSystem()
        {
            OxygenatedVessels = DefaulVascularSystem.SetupOxygenatedVessels();
            DeoxygenatedVessels = DefaulVascularSystem.SetupDeoxygenatedVessels();
        }

        public float GetSupply(Organ organ)
        {
            float total = 0;
            int count = 0;

            foreach (OrganStructure organStructure in organ.Structures)
            {
                total += OxygenatedVessels[organStructure.SupplyVesselName].GetLowestPatencyVessel().Patency;
                count++;
            }

            return (count == 0) ? 0 : total / count;
        }
    }
}
