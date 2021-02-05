using System;
using System.Collections.Generic;
using System.Text;

namespace AirAmboAttempt01
{
    public static class BloodLossBaseRates
    {
        public static readonly float Superficial = 1f;

        public static readonly float Brain = 1f;

        public static readonly float Heart = 1f;
        public static readonly float Lung = 1f;

        public static readonly float GI = 1f;
        public static readonly float Kidney = 1f;
        public static readonly float Bladder = 1f;
        public static readonly float Liver = 1f;
        public static readonly float Pancreas = 1f;
        public static readonly float Spleen = 1f;
        public static readonly float Reproductive_Male = 1f;
        public static readonly float Reproductive_Female = 1f;

        public static readonly Dictionary<BleedingSeverity, float> BleedingSeverityMultiplier = new Dictionary<BleedingSeverity, float>()
        {
            { BleedingSeverity.None, 0},
            { BleedingSeverity.Mild, 0.5f},
            { BleedingSeverity.Moderate, 1f},
            { BleedingSeverity.Severe, 2f},
            { BleedingSeverity.Extreme, 2.5f}
        };
    }
}
