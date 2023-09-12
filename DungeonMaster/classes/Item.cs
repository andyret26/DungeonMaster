using DungeonMaster.enums;

namespace DungeonMaster.classes;

public class Item
{
    public string Name { get; set; }
    public int RequiredLevel { get; set; }
    public Slot Slot { get; set; }
    
    public Item(string name, int requiredLevel) {
        Name = name;
        RequiredLevel = requiredLevel;
    }
    
    
}
