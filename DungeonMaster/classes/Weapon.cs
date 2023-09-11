using DungeonMaster.enums;

namespace DungeonMaster.classes;

public class Weapon : Item
{
    public WeaponType Type { get; set; }
    public int WeaponDamage { get; set; }
    
    
    public Weapon(string name, WeaponType type, int damage) : base(name) {
        Slot = Slot.Weapon;
        Type = type;
        WeaponDamage = damage;
    }
}
