

## Architectural Goals
1. Prefer *interfaces* over *abstract classes*  to improve testability. 
2. Consolidate interfaces into as few projects as practical. This should help reduce dependencies on unit test projects.
3. Ensure that project **Astronomy.Data.EF** does not leak any **Entity Framework** abstractions. Utilizing **AutoMapper** to convert **Entity Framework** models into *Core Domain* objects simplifies this goal.
4. Leverage **Unity** IoC container in the **Astronomy.Api** project. 

