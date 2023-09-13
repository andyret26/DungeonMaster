using DungeonMaster.classes;
using DungeonMaster.classes.heroClasses;
using DungeonMaster.enums;

namespace DungeonMaster.Tests
{
    public class WizardTests
    {
        [Fact]
        public void Create_Wizard_Correct_NameLevelAttributes()
        {
            //Arrange
            var wizard = new Wizard("name1");
            string expectedName = "name1";
            int expectedLevel = 1;
            HeroAttribute expectedLevelAttrbutes = new HeroAttribute(1, 1, 8);

            //Act
            string actuallName = wizard.Name;
            int actuallLevel = wizard.Level;
            HeroAttribute actuallLevelAttrbutes = wizard.LevelAttributes;

            //Assert

            Assert.Equal(expectedName, actuallName);
            Assert.Equal(expectedLevel, actuallLevel);
            Assert.Equivalent(expectedLevelAttrbutes, actuallLevelAttrbutes);
        }

        [Fact]
        public void LevelUp_IncreaseAttributesCorrectly()
        {
            //Arrange
            var wizard = new Wizard("name1");
            int initialStrength = wizard.LevelAttributes.Strength;
            int initialDexterity = wizard.LevelAttributes.Dexterity;
            int initialIntelligence = wizard.LevelAttributes.Intelligence;
            int initialLevel = wizard.Level;

            //Act
            wizard.LevelUp();
            int actuallStrength = wizard.LevelAttributes.Strength;
            int actuallDexterity = wizard.LevelAttributes.Dexterity;
            int actuallIntelligence = wizard.LevelAttributes.Intelligence;
            int actuallLevel = wizard.Level;

            int expectedStrength = initialStrength + 1;
            int expectedDexterity = initialDexterity + 1;
            int expectedIntelligence = initialIntelligence + 5;
            int expectedLevel = initialLevel + 1;

            //Assert
            Assert.Equal(expectedStrength, actuallStrength);
            Assert.Equal(expectedDexterity, actuallDexterity);
            Assert.Equal(expectedIntelligence, actuallIntelligence);
            Assert.Equal(expectedLevel, actuallLevel);

        }

        [Theory]
        [InlineData(WeaponType.Staff)]
        [InlineData(WeaponType.Wand)]
        public void Equip_ValidWeapon_ShouldEquipWeapon(WeaponType weaponType)
        {
            //Arrange
            var wizard = new Wizard("name");
            var validWeapon = new Weapon("Void Staff", weaponType, 1, 7);
            string expectedWeaponName = "Void Staff";
            WeaponType expectedWeaponType = weaponType;

            //Act
            wizard.Equip(validWeapon);
            Weapon? actuallWeapon = wizard.Equipment[Slot.Weapon] as Weapon;
            string? actuallWeaponName = actuallWeapon?.Name;
            WeaponType? actuallWeaponType = actuallWeapon?.Type;

            //Assert
            Assert.Equal(expectedWeaponName, actuallWeaponName);
            Assert.Equal(expectedWeaponType, actuallWeaponType);
            Assert.Equal(validWeapon, actuallWeapon);
        }

        [Theory]
        [InlineData(WeaponType.Bow)]
        [InlineData(WeaponType.Dagger)]
        [InlineData(WeaponType.Sword)]
        [InlineData(WeaponType.Hatchet)]
        [InlineData(WeaponType.Mace)]
        public void Equip_InvalidWeaponType_ShouldThrowInvalidWeaponException(WeaponType weaponType)
        {
            //Arrange
            var wizard = new Wizard("name");
            var invalidWeapon = new Weapon("Void Staff", weaponType, 1, 7);
            string expectedMessage = "Can not equip this type of weapon";

            //Act
            var exeption = Assert.Throws<InvalidWeaponException>(() =>
            {
                wizard.Equip(invalidWeapon);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }

        [Theory]
        [InlineData(ArmorType.Cloth)]
        public void Equip_ValidArmor_ShouldEquipArmor(ArmorType armorType)
        {
            //Arrange
            var wizard = new Wizard("name");
            var validArmor = new Armor("FON", armorType, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedArmorName = "FON";
            ArmorType expectedArmorType = armorType;

            //Act
            wizard.Equip(validArmor);
            Armor? actuallArmor = wizard.Equipment[Slot.Body] as Armor;
            string? actuallArmorName = actuallArmor?.Name;
            ArmorType? actuallArmorType = actuallArmor?.Type;

            //Assert
            Assert.Equal(expectedArmorName, actuallArmorName);
            Assert.Equal(expectedArmorType, actuallArmorType);
            Assert.Equal(validArmor, actuallArmor);
        }

        [Theory]
        [InlineData(ArmorType.Leather)]
        [InlineData(ArmorType.Mail)]
        [InlineData(ArmorType.Plate)]
        public void Equip_InvalidArmorType_ShouldThrowInvalidArmorException(ArmorType armorType)
        {
            //Arrange
            var wizard = new Wizard("name");
            var invalidArmor = new Armor("FON", armorType, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedMessage = "Can not equip this type of armor";

            //Act
            var exeption = Assert.Throws<InvalidArmorException>(() =>
            {
                wizard.Equip(invalidArmor);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }

        [Fact]
        public void Damage_NoWeapon_CalculateCorrectly()
        {
            //Arrange
            var wizard = new Wizard("name");
            decimal expectedDamage = 1 * ((1 + 8) / 100m);

            //Act
            decimal actuallDamage = wizard.Damage();

            //Assert
            Assert.Equal(expectedDamage, actuallDamage);
        }

        [Fact]
        public void Damage_WithWeapon_CalculateCorrectly()
        {
            //Arrange
            var wizard = new Wizard("name");
            var staff = new Weapon("wName", WeaponType.Staff, 1, 7);
            wizard.Equip(staff);

            decimal expectedDamage = 7 * ((1 + 8) / 100m);

            //Act
            decimal actuallDamage = wizard.Damage();

            //Assert
            Assert.Equal(expectedDamage, actuallDamage);
        }


    }
}
