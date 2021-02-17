namespace PatientManagementSystem.Patients.PatientBlood
{
    public struct FluidProfile
    {
        public float Hematocrit;
        public float ClottingFactor;
        public float Electrolytes;
    }

    public static class DefaultFluidProfiles
    {
        public static readonly FluidProfile Drug = new FluidProfile()
        {
            Hematocrit = 0.0f,
            ClottingFactor = 0.0f,
            Electrolytes = 0.0f
        };//Essentially ratios found in standard drug infusion //TBC

        public static readonly FluidProfile Blood = new FluidProfile()
        {
            Hematocrit = 0.4f,
            ClottingFactor = 1.0f,
            Electrolytes = 1.0f
        };//Essentially ratios found in standard blood

        public static readonly FluidProfile BaseFluid = new FluidProfile()
        {
            Hematocrit = 0.0f,
            ClottingFactor = 0.0f,
            Electrolytes = 0.0f
        };//Essentially ratios found in 1L of water
    }
}
