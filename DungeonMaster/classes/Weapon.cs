using DungeonMaster.enums;

namespace DungeonMaster.classes;

public class Weapon : Item
{
    public WeaponType Type { get; set; }
    public int WeaponDamage { get; set; }
    
    
    public Weapon(string name, WeaponType type, int requiredLevel, int damage) : base(name, requiredLevel) {
        Slot = Slot.Weapon;
        Type = type;
        WeaponDamage = damage;
    }
}
