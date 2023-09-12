using DungeonMaster.classes;
using DungeonMaster.classes.heroClasses;
using DungeonMaster.enums;

namespace DungeonMaster.Tests
{
    public class SwashbucklerTests
    {
        [Fact]
        public void Create_Swashbuckler_Correct_NameLevelAttributes()
        {
            //Arrange
            var buckler = new Swashbuckler("name1");
            string expectedName = "name1";
            int expectedLevel = 1;
            HeroAttribute expectedLevelAttrbutes = new HeroAttribute(2, 6, 1);

            //Act
            string actuallName = buckler.Name;
            int actuallLevel = buckler.Level;
            HeroAttribute actuallLevelAttrbutes = buckler.LevelAttributes;

            //Assert

            Assert.Equal(expectedName, actuallName);
            Assert.Equal(expectedLevel, actuallLevel);
            Assert.Equivalent(expectedLevelAttrbutes, actuallLevelAttrbutes);
        }

        [Fact]
        public void LevelUp_IncreaseAttributesCorrectly()
        {
            //Arrange
            var buckler = new Swashbuckler("name1");
            int initialStrength = buckler.LevelAttributes.Strength;
            int initialDexterity = buckler.LevelAttributes.Dexterity;
            int initialIntelligence = buckler.LevelAttributes.Intelligence;
            int initialLevel = buckler.Level;

            //Act
            buckler.LevelUp();
            int actuallStrength = buckler.LevelAttributes.Strength;
            int actuallDexterity = buckler.LevelAttributes.Dexterity;
            int actuallIntelligence = buckler.LevelAttributes.Intelligence;
            int actuallLevel = buckler.Level;

            int expectedStrength = initialStrength + 1;
            int expectedDexterity = initialDexterity + 4;
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
            var buckler = new Swashbuckler("name");
            var validWeapon = new Weapon("WeaponName", WeaponType.Dagger, 1, 7);
            string expectedWeaponName = "WeaponName";
            WeaponType expectedWeaponType = WeaponType.Dagger;

            //Act
            buckler.Equip(validWeapon);
            Weapon? actuallWeapon = buckler.Equipment[Slot.Weapon] as Weapon;
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
            var buckler = new Swashbuckler("name");
            var invalidWeapon = new Weapon("WeaponName", WeaponType.Mace, 1, 7);
            string expectedMessage = "Can not equip this type of weapon";

            //Act
            var exeption = Assert.Throws<InvalidWeaponException>(() =>
            {
                buckler.Equip(invalidWeapon);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }

        [Fact]
        public void Equip_ValidArmor_ShouldEquipArmor()
        {
            //Arrange
            var buckler = new Swashbuckler("name");
            var validArmor = new Armor("ArmorName", ArmorType.Mail, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedArmorName = "ArmorName";
            ArmorType expectedArmorType = ArmorType.Mail;

            //Act
            buckler.Equip(validArmor);
            Armor? actuallArmor = buckler.Equipment[Slot.Body] as Armor;
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
            var buckler = new Swashbuckler("name");
            var invalidArmor = new Armor("FON", ArmorType.Cloth, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedMessage = "Can not equip this type of armor";

            //Act
            var exeption = Assert.Throws<InvalidArmorException>(() =>
            {
                buckler.Equip(invalidArmor);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }



    }
}
