using DungeonMaster.enums;

namespace DungeonMaster.classes.heroClasses;

public abstract class Hero
{
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public abstract string Class { get; set; }
    public abstract HeroAttribute LevelAttributes { get; set; }
    public Dictionary<Slot, Item?> Equipment { get; set; }
    public abstract List<WeaponType> ValidWeaponTypes { get; set; }
    public abstract List<ArmorType> ValidArmorTypes { get; set; }



    public Hero(string name) {
        Name = name;

        Equipment = new Dictionary<Slot, Item?>{
            {Slot.Weapon, null},
            {Slot.Head, null},
            {Slot.Body, null},
            {Slot.Legs, null},
        };
    }

    /// <summary>
    /// Level up the hero and increases the attributes.<br/>
    /// Different classes have different attributes increases
    /// </summary>
    public abstract void LevelUp();

    /// <summary>
    /// Calculates how much damage you deal. <br/>
    /// Different Classes deals damage based on different attributes
    /// </summary>
    /// <returns>Damage as a decimal</returns>
    public abstract decimal Damage();

    /// <summary>
    /// Writes the hero information in the console
    /// </summary>
    public abstract void Display();

    /// <summary>
    /// Equips an armor piece. <br/>
    /// Different class can equip different types of armor
    /// </summary>
    /// <param name="Armor">Armor you want to equip</param>
    public abstract void Equip(Armor Armor);

    /// <summary>
    /// Equips a Weapon piece. <br/>
    /// Different class can equip different types of armor
    /// </summary>
    /// <param name="weapon">Weapon you want to equip</param>
    public abstract void Equip(Weapon weapon);

    /// <summary>
    /// Calculates the total attributes by summing the attributes of the character's level
    /// and equipped armor items.
    /// </summary>
    /// <returns>The total attributes value as an integer.</returns>
    public int TotalAttributes() {
        int total = 0;

        total += LevelAttributes.SumAttributes();

        foreach (var item in Equipment)
        {
            if(item.Value is Armor armor){
                total += armor.ArmorAttribute.SumAttributes();
            };
        }

        return total;
    }

    /// <summary>
    /// Calculates total strength attribute based on level and armor
    /// </summary>
    /// <returns>Total strength attribute as an integer</returns>
    public int TotalStrength(){
        int total = 0;
        total += LevelAttributes.Strength;

        foreach (var item in Equipment)
        {
            if(item.Value is Armor armor){
                total += armor.ArmorAttribute.Strength;
            };
        }
        return total;
    }
    
    /// <summary>
    /// Calculates the total dexterity based on level attribuete and armor
    /// </summary>
    /// <returns>Total dexterity as an integer</returns>
    public int TotalDexterity(){
        int total = 0;
        total += LevelAttributes.Dexterity;

        foreach (var item in Equipment)
        {
            if(item.Value is Armor armor){
                total += armor.ArmorAttribute.Dexterity;
            };
        }
        return total;
    }

    /// <summary>
    /// Calculates total intelligence attribute based on level and armor
    /// </summary>
    /// <returns>Total intelligence attribute as an integer</returns>
    public int TotalIntelligence(){
        int total = 0;
        total += LevelAttributes.Intelligence;

        foreach (var item in Equipment)
        {
            if(item.Value is Armor armor){
                total += armor.ArmorAttribute.Intelligence;
            };
        }
        return total;
    }
}
