using PatientManagementSystem.Patients;

namespace PatientManagementSystem.Patients.PatientSocials
{
    public class Biography
    {
        #region Props
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        #endregion

        public Biography(string firstName = "John", string lastName = "Doe", Gender gender = Gender.Other)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
        }
    } 
    
    //LATER: Add Financials (Insurance) class
    //LATER: Add Societals(rename) (Patient Tier, factions) class
}
