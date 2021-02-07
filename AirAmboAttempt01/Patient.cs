namespace AirAmboAttempt01.Patient
{
    public class Patient
    {
        public readonly string firstName;
        public readonly string lastName;
        public readonly int age;
        public readonly Gender gender;
        public bool isAlive = true;

        public Patient()
        {
            firstName = "John";
            lastName = "Doe";
            age = 30;
            gender = Gender.Other;
        }

        public Patient(string firstName, string lastName, int age, Gender gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
        }


        private Physical _physical;
        public Physical Body
        {
            get { return _physical; }
            private set { _physical = value; }
        }


        private Mental _mind;
        public Mental Mind
        {
            get { return _mind; }
            private set { _mind = value; }
        }

        //Conditions

        //LATER CONCERNS
        //Insurance
        //DNR bool readonly
    }

    public class Mental
    {
        public Consciousness Consciousness;
        public MentalState MentalState;
        public PainSeverity OverallPain; //May not need. Should be dynamically calculated by highest PainSeverity in BodyParts
    }

    public class Physical
    {
        public OrganSystems organs;// Change this for Head, Chest, Abdo class
        public BloodSystem bloodSystem;

        

        public Physical() //Replace with body again?
        {
            organs = new OrganSystems(true);
            bloodSystem = new BloodSystem();
        }
    }

}
