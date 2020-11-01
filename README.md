
------------------ DTO ------------------
DTO (Data Transfer objects) is a data container for moving data between layers. They are also termed as transfer objects. DTO is only used to pass data and does not contain any business logic. They only have simple setters and getters.


------------------ POCO ------------------
So What’s a POCO?

A POCO is not a DTO.  POCO stands for Plain Old CLR Object, or Plain Old C# Object.  It’s basically the .Net version of a POJO, Plain Old Java Object.  A POCO is your Business Object.  It has data, validation, and any other business logic that you want to put in there.  But there’s one thing a POCO does not have, and that’s what makes it a POCO.  POCOs do not have persistence methods.  If you have a POCO of type Person, you can’t have a Person.GetPersonById() method, or a Person.Save() method.  POCOs contain only data and domain logic, no persistence logic of any kind.  The term you’ll hear for this concept is Persistence Ignorance (PI).  POCOs are Persistence Ignorant. 
