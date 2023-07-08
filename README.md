#Refactoring test

## Description
You are asked to refactor the `BasketService` class and its methods.
Assume that the code is right in terms of business logic,
however it "smells" bad code, so clean code principles have to be applied.

##Requirements
`Program.cs` in `OurApp.Consumer` is a simulation of part of greater 
system and cannot change at all! Any non-backward compatibilities will break the system.
Any change in this project will result in instant failing in this test.
Class `BasketsDataConnector` NEED to stay static.

All files in OurApp project can be changed EXCEPT classes simulating access to remote storages:
* `ProductService`
* `BasketDataAccess`
* `CustomerRepository`**
