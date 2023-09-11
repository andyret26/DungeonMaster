namespace DungeonMaster.classes;

public class HeroAttribute
{
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    
    public HeroAttribute(int strength, int dexterity, int intelligence) {
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
    }

    public int IncreaseAttributes(int strength, int dexterity, int intelligence) {
        Strength += strength;
        Dexterity += dexterity;
        Intelligence += intelligence;

        return Strength + Dexterity + Intelligence;
    }

    public int SumAttributes() {
         return Strength + Dexterity + Intelligence;
    }
}
