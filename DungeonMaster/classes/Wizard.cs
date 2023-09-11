﻿using System.Runtime.InteropServices;
using DungeonMaster.classes;
using DungeonMaster.enums;

namespace DungeonMaster.classes;

public class Wizard: Hero
{
    public override List<WeaponType> ValidWeaponTypes { get; set; }
    public override List<ArmorType> ValidArmorTypes { get; set; }
    public override HeroAttribute LevelAttributes { get; set; }
    public override string Class { get; set; }

    public Wizard(string name) : base(name){
        Class = "Wizard";
        LevelAttributes = new HeroAttribute(1, 1, 8);
        ValidWeaponTypes = new List<WeaponType>{WeaponType.Wand, WeaponType.Staff};
        ValidArmorTypes = new List<ArmorType>{ArmorType.Cloth};
        
    }


    public override void LevelUp()
    {
        Level += 1;
        LevelAttributes.IncreaseAttributes(1, 1, 5);
    }

    public override int Damage()
    {
        if(Equipment[Slot.Weapon] is Weapon weapon){
            return weapon.WeaponDamage + LevelAttributes.Intelligence;
        } else {
            return LevelAttributes.Intelligence;
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