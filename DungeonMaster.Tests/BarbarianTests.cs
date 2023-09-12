using DungeonMaster.classes;
using DungeonMaster.classes.heroClasses;
using DungeonMaster.enums;

namespace DungeonMaster.Tests
{
    public class BarbarianTests
    {
        [Fact]
        public void Create_Barbarian_Correct_NameLevelAttributes()
        {
            //Arrange
            var barbarian = new Barbarian("name1");
            string expectedName = "name1";
            int expectedLevel = 1;
            HeroAttribute expectedLevelAttrbutes = new HeroAttribute(5, 2, 1);

            //Act
            string actuallName = barbarian.Name;
            int actuallLevel = barbarian.Level;
            HeroAttribute actuallLevelAttrbutes = barbarian.LevelAttributes;

            //Assert

            Assert.Equal(expectedName, actuallName);
            Assert.Equal(expectedLevel, actuallLevel);
            Assert.Equivalent(expectedLevelAttrbutes, actuallLevelAttrbutes);
        }

        [Fact]
        public void LevelUp_IncreaseAttributesCorrectly()
        {
            //Arrange
            var barbarian = new Barbarian("name1");
            int initialStrength = barbarian.LevelAttributes.Strength;
            int initialDexterity = barbarian.LevelAttributes.Dexterity;
            int initialIntelligence = barbarian.LevelAttributes.Intelligence;
            int initialLevel = barbarian.Level;

            //Act
            barbarian.LevelUp();
            int actuallStrength = barbarian.LevelAttributes.Strength;
            int actuallDexterity = barbarian.LevelAttributes.Dexterity;
            int actuallIntelligence = barbarian.LevelAttributes.Intelligence;
            int actuallLevel = barbarian.Level;

            int expectedStrength = initialStrength + 3;
            int expectedDexterity = initialDexterity + 2;
            int expectedIntelligence = initialIntelligence + 1;
            int expectedLevel = initialLevel + 1;

            //Assert
            Assert.Equal(expectedStrength, actuallStrength);
            Assert.Equal(expectedDexterity, actuallDexterity);
            Assert.Equal(expectedIntelligence, actuallIntelligence);
            Assert.Equal(expectedLevel, actuallLevel);

        }

        [Fact]
        public void Equip_ValidWeapon_ShouldEquipWeapon()
        {
            //Arrange
            var barbarian = new Barbarian("name");
            var validWeapon = new Weapon("Sword", WeaponType.Sword, 1, 7);
            string expectedWeaponName = "Sword";
            WeaponType expectedWeaponType = WeaponType.Sword;

            //Act
            barbarian.Equip(validWeapon);
            Weapon? actuallWeapon = barbarian.Equipment[Slot.Weapon] as Weapon;
            string? actuallWeaponName = actuallWeapon?.Name;
            WeaponType? actuallWeaponType = actuallWeapon?.Type;

            //Assert
            Assert.Equal(expectedWeaponName, actuallWeaponName);
            Assert.Equal(expectedWeaponType, actuallWeaponType);
            Assert.Equal(validWeapon, actuallWeapon);
        }

        [Fact]
        public void Equip_InvalidWeaponType_ShouldThrowInvalidWeaponException()
        {
            //Arrange
            var barbarian = new Barbarian("name");
            var invalidWeapon = new Weapon("Bow", WeaponType.Bow, 1, 7);
            string expectedMessage = "Can not equip this type of weapon";

            //Act
            var exeption = Assert.Throws<InvalidWeaponException>(() =>
            {
                barbarian.Equip(invalidWeapon);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }

        [Fact]
        public void Equip_ValidArmor_ShouldEquipArmor()
        {
            //Arrange
            var barbarian = new Barbarian("name");
            var validArmor = new Armor("ArmorName", ArmorType.Plate, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedArmorName = "ArmorName";
            ArmorType expectedArmorType = ArmorType.Plate;

            //Act
            barbarian.Equip(validArmor);
            Armor? actuallArmor = barbarian.Equipment[Slot.Body] as Armor;
            string? actuallArmorName = actuallArmor?.Name;
            ArmorType? actuallArmorType = actuallArmor?.Type;

            //Assert
            Assert.Equal(expectedArmorName, actuallArmorName);
            Assert.Equal(expectedArmorType, actuallArmorType);
            Assert.Equal(validArmor, actuallArmor);
        }

        [Fact]
        public void Equip_InvalidArmorType_ShouldThrowInvalidArmorException()
        {
            //Arrange
            var barbarian = new Barbarian("name");
            var invalidArmor = new Armor("FON", ArmorType.Cloth, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedMessage = "Can not equip this type of armor";

            //Act
            var exeption = Assert.Throws<InvalidArmorException>(() =>
            {
                barbarian.Equip(invalidArmor);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }



    }
}
