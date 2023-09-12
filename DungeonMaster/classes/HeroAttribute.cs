namespace DungeonMaster.classes;

public class HeroAttribute
{
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    
    /// <summary>
    /// Creats a hero atribute with strength dexterity and intelligence and sets the given parameters
    /// </summary>
    /// <param name="strength"></param>
    /// <param name="dexterity"></param>
    /// <param name="intelligence"></param>
    public HeroAttribute(int strength, int dexterity, int intelligence) {
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
    }

    /// <summary>
    /// Increases the Atributes by a specific amount for each type
    /// </summary>
    /// <param name="strength">Amount of strength you want to increase</param>
    /// <param name="dexterity">Amount of dexterity you want to increase</param>
    /// <param name="intelligence">Amount of intelligence you want to increase</param>
    /// <returns>New Total atributes</returns>
    public int IncreaseAttributes(int strength, int dexterity, int intelligence) {
        Strength += strength;
        Dexterity += dexterity;
        Intelligence += intelligence;

        return Strength + Dexterity + Intelligence;
    }

    /// <summary>
    /// Adds all the atributes together and returns the sum
    /// </summary>
    /// <returns>Sum of current attributes</returns>
    public int SumAttributes() {
         return Strength + Dexterity + Intelligence;
    }
}
