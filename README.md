# PatientManagementSystem
This project is an attempt to create a Patient Management System component for a computer game. 
The aim is to provide a system for creating / examining / interacting with a virtual patient.

Currently this project is setup as a Console App as it is still very early in development but is intended to be a class library for use in another project.

### Side Note:
This project is primarily a C# learning experience and it contains examples of stunning bad coding because I truely did't know how to do it better.
I am constantly changing and reworking the entire code base and therefore this code should not be used or relied upon in any other personal or commercial projects as ALL functionality is subject to change.


## Getting Started
At the moment there is no good way of using this code out the box.
Running this program as a console app will get varied results (or errors) based on the current commit as the Program.cs:Main is used for testing and debugging purposes.
All usage other usage should be done using a PatientPod object as this is designed to be the only point of contact for the player, although depending on the current commit other functionality may be temporarily exposed.

### Usage
For now the best way of using this code is:

1. Create a new instance of PatientPod (Use default constructor)
2. Optionally create instances of any of the parameters of the Patient constructor: Physical, Mental, Biography. 
	This can be futher defined by creating instances of their sub-objects and passing them into the respective constructors
3. Create a new instance of Patient (passing in any previously defined appropriate arguments)
4. Perform Examinations and Interventions by using the PatientPod instance's .PerformIntervention() method passing in an instance of the Intervention / Examination you wish to perform as well as an out bool to store whether the action was performed successfully (The return bool is to indicate if the action was even possible).
5. Access the PatientPod instance's PatientResults object to see the information attained from any of the Interventions / Examinations performed.


(List of avaible Interventions / Examinations / Patient Setup Options to be completed)


## Where is the Unit Testing?
Initially I attempted to follow a TDD workflow but quickly found myself spending more time rewriting the entire test class once I discovered that my previous approach to a problem had failed.
This led me to abbandoning the Unit Testing and TDD approach fairly early on with only remanants of my previous attempt surviving.
It is my intention to return and setup appropriate Unit Tests once the code becomes more stable (arguably some parts are stable enough and I should setup tests for those).
