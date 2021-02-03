using System;
using System.Collections.Generic;
using System.Text;

namespace AirAmboAttempt01
{
    public class InfusionFluid
    {
        readonly float Volume;
        readonly float Hematocrit;
        readonly float ClottingFactor;
        readonly float Electrolytes;

        protected InfusionFluid(float volume, float hematocrit, float clottingFactor, float electrolytes)
        {
            Volume = volume;
            Hematocrit = hematocrit;
            ClottingFactor = clottingFactor;
            Electrolytes = electrolytes;
        }

    }

    class Toaster
    {
        InfusionFluid InfusionFluids;



    }

    class BloodInfusion : InfusionFluid
    {
        BloodInfusion() :base(100,100,100,100)
        {

        }
    }
}
