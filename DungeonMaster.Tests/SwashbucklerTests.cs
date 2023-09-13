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

        [Theory]
        [InlineData(WeaponType.Dagger)]
        [InlineData(WeaponType.Sword)]

        public void Equip_ValidWeapon_ShouldEquipWeapon(WeaponType weaponType)
        {
            //Arrange
            var buckler = new Swashbuckler("name");
            var validWeapon = new Weapon("WeaponName", weaponType, 1, 7);
            string expectedWeaponName = "WeaponName";
            WeaponType expectedWeaponType = weaponType;

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

        [Theory]
        [InlineData(WeaponType.Staff)]
        [InlineData(WeaponType.Wand)]
        [InlineData(WeaponType.Hatchet)]
        [InlineData(WeaponType.Mace)]
        [InlineData(WeaponType.Bow)]
        public void Equip_InvalidWeaponType_ShouldThrowInvalidWeaponException(WeaponType weaponType)
        {
            //Arrange
            var buckler = new Swashbuckler("name");
            var invalidWeapon = new Weapon("WeaponName", weaponType, 1, 7);
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

        [Theory]
        [InlineData(ArmorType.Mail)]
        [InlineData(ArmorType.Leather)]
        public void Equip_ValidArmor_ShouldEquipArmor(ArmorType armorType)
        {
            //Arrange
            var buckler = new Swashbuckler("name");
            var validArmor = new Armor("ArmorName", armorType, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedArmorName = "ArmorName";
            ArmorType expectedArmorType = armorType;

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

        [Theory]
        [InlineData(ArmorType.Plate)]
        [InlineData(ArmorType.Cloth)]
        public void Equip_InvalidArmorType_ShouldThrowInvalidArmorException(ArmorType armorType)
        {
            //Arrange
            var buckler = new Swashbuckler("name");
            var invalidArmor = new Armor("FON", armorType, 1, Slot.Body, new HeroAttribute(1, 1, 2));
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

        [Fact]
        public void Damage_NoWeapon_CalculateCorrectly()
        {
            //Arrange
            var buckelr = new Swashbuckler("name");
            decimal expectedDamage = 1 * ((1 + 6) / 100m);

            //Act
            decimal actuallDamage = buckelr.Damage();

            //Assert
            Assert.Equal(expectedDamage, actuallDamage);
        }

        [Fact]
        public void Damage_WithWeapon_CalculateCorrectly()
        {
            //Arrange
            var buckelr = new Swashbuckler("name");
            var staff = new Weapon("wName", WeaponType.Sword, 1, 7);
            buckelr.Equip(staff);

            decimal expectedDamage = 7 * ((1 + 6) / 100m);

            //Act
            decimal actuallDamage = buckelr.Damage();

            //Assert
            Assert.Equal(expectedDamage, actuallDamage);
        }


    }
}
