#region URGENTS
//URGENT: Redo the Example section to use the new PatientProceedure class and Pod.PerformProceedure() 
//URGENT: Created new Bleeding System / Rebuild the Bleeding system to mirror the infections system?
#endregion

#region TODOS
//TODO: (Started?) Rebuild OrganState enum, perhaps use a float to indicate organ health? another float for OrganFunctionEffectiveness (nice short variable name there) 
//TODO: (Started) Reorganise files and class locations
//TODO: (Started) Finish building Lung System
//TODO: Cleanup the arrangement of the members in the Organ base class (its getting chaotic in there)
#endregion

#region REVIEWS
//REVIEW: Consider scrapping that awful HeartStructures / HeartVessels crap
//REVIEW: Should the Organ class take the BloodRequirement, OxygenConsumption values as parameters and make those fields readonly?
#endregion

#region LATERS
//LATER: Implement Pain System
//LATER: Rebuild the Fluid system to be based on quantities and not ratios (unless appropriate) That PatientFluid.cs is looking thinner than a russian supermodel. Oh look a struct, lets see how long that lasts...
//LATER: Implement all the blood tests and background variables
//LATER: Break Vessels(Arteries?) into its own System mirroring Infections
//LATER: Rebuild the Bones System to mirror the Infections system
//LATER: Add Pod Atmosphere System
//LATER: Add Pod IV poles and fluid transfusions systems
//LATER: Unfuck the PatientDrug classes and fix (and rename) the PatientPharmacology nightmare
#endregion

#region ONGOINGs
//ONGOING: Continue to add to the README.md and try to provide Implementation details on stable classes as well as code snippets.
#endregion

#region LUXURYs
//LUXURY: Create Item System for organs and drugs and fluid bags
#endregion

#region UNITYs
//UNITY: Create a Patient Builder system
//UNITY: Database Creation
#endregion

#region Tag_

#endregion