﻿namespace PatientManagementSystem.Patients.PatientMental
{
    public enum Consciousness
    {
        Dead,
        Unresponsive,
        Semi_Responsive,
        Responsive
    }
    public enum MentalState
    {
        Dead,
        Normal,
        Absent,
        Confused,
        Agitated,
    }
    public class Mental
    {
        #region Props
        private Consciousness _consciousness;
        public Consciousness Consciousness
        {
            get { return _consciousness; }
            set { _consciousness = value; }
        }

        private MentalState _mentalState;
        public MentalState MentalState
        {
            get { return _mentalState; }
            set { _mentalState = value; }
        }

        private PainSeverity _overallPain; //May not need. Should be dynamically calculated by highest PainSeverity in BodyParts
        public PainSeverity OverallPain
        {
            get { return _overallPain; }
            set { _overallPain = value; }
        }
        #endregion

        public Mental()
        {

        }

        public Mental(Consciousness consciousness, MentalState mentalState, PainSeverity overallPain)
        {
            Consciousness = consciousness;
            MentalState = mentalState;
            OverallPain = overallPain;
        }
    } //LATER: Expand Mental Side of Patient management

}
