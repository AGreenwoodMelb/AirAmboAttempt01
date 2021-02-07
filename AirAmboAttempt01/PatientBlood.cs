using System;
using System.Collections.Generic;

namespace AirAmboAttempt01.PatientBlood
{
    public enum BloodABO
    {
        O,
        A,
        B,
        AB
    }
    public enum BloodRhesus
    {
        Negative,
        Positive
    }
    public struct BloodType
    {
        public BloodABO ABO;
        public BloodRhesus Rhesus;
    }
    public enum BleedingSeverity
    {
        None,
        Mild,
        Moderate,
        Severe,
        Extreme
    }
    public static class DefaultBloodLossBaseRates
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
