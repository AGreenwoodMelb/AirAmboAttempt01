using System;
using System.Collections.Generic;
using System.Text;

namespace AirAmboAttempt01
{

    //For handling events effecting the patient
    class PatientEventsManager
    {

        Patient currentPatient;

        public PatientEventsManager(Patient patient)
        {
            this.currentPatient = patient;
        }

        public void Loop()
        {
            currentPatient.Body.bloodSystem.BloodVolumeCheck();
        }
    }
}
