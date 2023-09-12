# DungeonMaster
## Description
This is a c# .NET 6 console application where you have variou hero classes that inherits form a base hero class.
All calsses can level up and have attributes that goes up when you level up.
Attributes increases differently based on the hero class.
Different classes can equip different types of weapons and armor.
When you equip armor the total attributes increase and weapon increases the total damage you can deal.

There is also written various tests for this application.

The different hero types does not have to much comment/documentataion since hey inherit from the hero class where most of the comments/documentation are.

## Usage
When you `run` the program you will execute the code that is in the program.cs file.

```cs
git clone git@github.com:andyret26/DungeonMaster.git
cd DungeonMaster

// run main program.cs
dotnet run --project ./DungeonMaster/DungeonMaster.csproj

// run tests
dotnet test ./DungeonMaster.Tests
```
## Structure
Main file structure

- `DungeonMaster/` - Main folder
  - `DungeonMaster/` - Contains the main application code
    -  `classes/` - Contains C# classes
       - `heroClasses/` - Different types of hero classes (Wizard, Archer, etc..)
    - `enums/` - Contains C# enums
  - `DungeonMaster.Tests/` - Tests folder