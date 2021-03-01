# PatientManagementSystem
This project is an attempt to create a Patient Management System component for a computer game. 
The aim is to provide a system for creating / examining / interacting with a virtual patient.

Currently this project is set up as a Console App as it is still very early in development but is intended to be a class library for use in another project.

#### Side Note:
This project is primarily a C# learning experience and it contains examples of stunningly bad coding because I truly didn't know how to do it better.

I am constantly changing and reworking the entire code base and therefore this code should not be used or relied upon in any other personal or commercial projects as ALL functionality is subject to change.


## Getting Started
At the moment there is no good way of using this code out the box.

Running this program as a console app will get varied results (or errors) based on the current commit as the Program.cs:Main is used for testing and debugging purposes.

All usage other usage should be done using a PatientPod object as this is designed to be the only point of contact for the player, although depending on the current commit other functionality may be temporarily exposed.

### Usage
For now the best way of using this code is:

1. Create a new instance of PatientPod (Use default constructor)
2. Optionally create instances of any of the parameters of the Patient constructor: Physical, Mental, Biography. 
	This can be further defined by creating instances of their sub-objects and passing them into the respective constructors
3. Create a new instance of Patient (passing in any previously defined appropriate arguments)
4. Use Pod.TryAddPatient() passing it the newly created Patient object as a parameter.
5. Perform Examinations and Interventions by using the PatientPod instance's .PerformIntervention() method passing in an instance of the Intervention / Examination you wish to perform as well as an out bool to store whether the action was performed successfully (The return bool is to indicate if the action was even possible).
6. Access the PatientPod instance's PatientResults object to see the information obtained from any of the Interventions / Examinations performed.

```cs

//1. Create new instance of PatientPod
PatientPod patientPod = new PatientPod();

//2. Optionally create instances of any of the parameters of the Patient 
Blood blood= new Blood(new BloodType() { ABO = BloodABO.AB, Rhesus = BloodRhesus.Positive });
BloodSystem bloodSystem = new BloodSystem(blood);
Abdomen abs = new Abdomen(reproductives: new Reproductive_Male());
Anthropometrics metrics = new Anthropometrics(21,181,120);
Physical body = new Physical(blood: bloodSystem, abdomen: abs);

//3. Create a new instance of Patient (passing in any previously defined appropriate arguments)
Patient patient = new Patient(body: body);

//4. Use Pod.TryAddPatient() passing it the newly created Patient object as a parameter. 
patientPod.TryAddPatient(patient);


//5. Perform Examinations and Interventions by using the PatientPod instance's .PerformIntervention()
patientPod.PerformIntervention( new ExamineLungsAuscultateLungs(), out bool _);

//6. Access the PatientPod instance's PatientResults object to see the information obtained from any of the Interventions / Examinations performed.
System.Console.WriteLine(patientPod.PatientResults.RespiratorySystem.LeftLung.BreathSounds[LungLobeLocation.Upper]); //Not the best example but currently works.

```

(List of available Interventions / Examinations / Patient Setup Options to be completed)


## Where is the Unit Testing?
Initially I attempted to follow a TDD workflow but quickly found myself spending more time rewriting the entire test class once I discovered that my previous approach to a problem had failed.

This led me to abandoning the Unit Testing and TDD approach fairly early on with only remnants of my previous attempt surviving.

It is my intention to return and set up appropriate Unit Tests once the code becomes more stable (arguably some parts are stable enough and I should set up tests for those).


## To Be Done
### Short Term
- ~~Rename AirAmboAttempt01 and AirAmboAttempt01Test folder to more appropriate name~~ (Kinda works)
- Create and implement relevant fields and functionality for Organ classes.
- Rebuild BloodSystem class with appropriate fields and calculations.
- Rebuild Bleeding functionality.
- Review and possibly rebuild Skeleton system.
- Rebuild Fluids classes and dervied systems.
- Rebuild Transfuse Intervention
- Figure out what I was doing with the Drug and PatientPharmacology (RENAME THIS) systems
- Expand the Infections system to have Region / Organ specific Infection Profile (InfectionType, InfectionTreatment Resistance, etc..) probabilty tables.
- Add Gases system for Oxygen and Inhaled substances systems.
- Expand this list with //TODO:'s and things from the CherryTree file

### Medium Term
- Improve the "Usage" section of the README file to give a better explination of how to set up and use this project, including important class constructor break down with code snippets.
- Re-implement Unit Testing (Especially for the more stable classes and systems).

### Long Term
- Build PatientBuilder system for ease of PatientCreation.
- Create Database integration for storing Patient / Patient related object prefabs