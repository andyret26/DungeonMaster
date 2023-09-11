﻿using DungeonMaster.classes;
using DungeonMaster.enums;

namespace DungeonMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Armor head1 = new Armor("HelmName", enums.ArmorType.Cloth, enums.Slot.Head, new HeroAttribute(1, 1, 1));
            Weapon staff1 = new Weapon("StaffName", enums.WeaponType.Staff, 13);
            Console.WriteLine("Hello, Hero!");
            Wizard wizard1 = new Wizard("Andy");
            wizard1.Equip(head1);
            wizard1.Equip(staff1);

            wizard1.Display();
            Console.WriteLine(wizard1.TotalStrength());



        }
    }
}