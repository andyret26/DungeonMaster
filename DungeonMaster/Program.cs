using DungeonMaster.classes;
using DungeonMaster.classes.heroClasses;
using DungeonMaster.enums;

namespace DungeonMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Armor head1 = new Armor("HelmName", ArmorType.Cloth, 1, Slot.Head, new HeroAttribute(1, 1, 1));
            Weapon staff1 = new Weapon("StaffName", WeaponType.Staff, 1, 13);
            Console.WriteLine("Hello, Hero!");
            Wizard wizard1 = new Wizard("Andy");
            wizard1.Equip(head1);
            wizard1.Equip(staff1);

            wizard1.Display();


            Console.WriteLine($"Helmet name: {wizard1.Equipment[Slot.Head]?.Name}");
            wizard1.RemoveEquipment(Slot.Head);
            Console.WriteLine("Removed Head item");
            wizard1.Display();    

            Console.WriteLine();
            wizard1.LevelUp();
            Console.WriteLine("LEVELD UP!!");
            wizard1.Display();

            Console.WriteLine();
            wizard1.LevelUp();
            Console.WriteLine("LEVELD UP!!");
            wizard1.Display();


        }
    }
}