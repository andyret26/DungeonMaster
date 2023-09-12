using DungeonMaster.enums;

namespace DungeonMaster.classes.heroClasses;

public class Barbarian: Hero
{
    public override List<WeaponType> ValidWeaponTypes { get; set; }
    public override List<ArmorType> ValidArmorTypes { get; set; }
    public override HeroAttribute LevelAttributes { get; set; }
    public override string Class { get; set; }

    public Barbarian(string name) : base(name){
        Class = "Barbarian";
        LevelAttributes = new HeroAttribute(5, 2, 1);
        ValidWeaponTypes = new List<WeaponType>{WeaponType.Hatchet, WeaponType.Mace, WeaponType.Sword};
        ValidArmorTypes = new List<ArmorType>{ArmorType.Mail, ArmorType.Plate};
        
    }


    public override void LevelUp()
    {
        Level += 1;
        LevelAttributes.IncreaseAttributes(3, 2, 1);
    }
    public override void Equip(Armor armor)
    {
        if(armor.RequiredLevel > Level)
        {
            throw new InvalidLevelException("Not high enough level for this item");
        }

        if(ValidArmorTypes.Contains(armor.Type))
        {
            Equipment[armor.Slot] = armor;
        } else
        {
            throw new InvalidArmorException("Can not equip this type of armor");
        }
    }

    public override void Equip(Weapon weapon)
    {
        if (weapon.RequiredLevel > Level)
        {
            throw new InvalidLevelException("Not high enough level for this item");
        }

        if (ValidWeaponTypes.Contains(weapon.Type))
        {
            Equipment[Slot.Weapon] = weapon;
        }
        else
        {
            throw new InvalidWeaponException("Can not equip this type of weapon");
        }
    }

    public override decimal Damage()
    {
        if(Equipment[Slot.Weapon] is Weapon weapon){
            return weapon.WeaponDamage * ((1 + LevelAttributes.Strength) / 100m);
        } else {
            return 1 * ((1 + LevelAttributes.Strength) / 100m);
        }
    }

    public override void Display()
    {
        Console.WriteLine(
            $"Name: {Name}.\n" +
            $"Class: {Class}.\n" +
            $"Level: {Level}.\n" +
            $"Strength: {TotalStrength()}.\n" +
            $"Dexterity: {TotalDexterity()}.\n" +
            $"Intelligence: {TotalIntelligence()}.\n" +
            $"Damage: {Damage()}.\n"
        );
    }

}
