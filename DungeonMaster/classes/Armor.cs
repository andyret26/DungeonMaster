using DungeonMaster.enums;

namespace DungeonMaster.classes;

public class Armor : Item
{
    public ArmorType Type { get; set; }
    public HeroAttribute ArmorAttribute { get; set; }    
    
    
    public Armor(string name, ArmorType type, int requiredLevel, Slot slot, HeroAttribute armorAttribute) : base(name, requiredLevel) {
        Type = type;
        Slot = slot;
        ArmorAttribute = armorAttribute;
    }
}
