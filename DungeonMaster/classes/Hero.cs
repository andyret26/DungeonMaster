using System.Runtime.InteropServices;
using DungeonMaster.enums;

namespace DungeonMaster.classes;

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

    public abstract void LevelUp();
    public abstract int Damage();
    public abstract void Display();
    
    public void Equip(Armor Armor) {
        Equipment[Armor.Slot] = Armor;
    }
    public void Equip(Weapon weapon) {
        Equipment[Slot.Weapon] = weapon;
    }

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
