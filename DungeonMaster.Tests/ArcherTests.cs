using DungeonMaster.classes;
using DungeonMaster.classes.heroClasses;
using DungeonMaster.enums;

namespace DungeonMaster.Tests
{
    public class ArcherTests
    {
        [Fact]
        public void Create_Archer_Correct_NameLevelAttributes()
        {
            //Arrange
            var archer = new Archer("name1");
            string expectedName = "name1";
            int expectedLevel = 1;
            HeroAttribute expectedLevelAttrbutes = new HeroAttribute(1, 7, 1);

            //Act
            string actuallName = archer.Name;
            int actuallLevel = archer.Level;
            HeroAttribute actuallLevelAttrbutes = archer.LevelAttributes;

            //Assert

            Assert.Equal(expectedName, actuallName);
            Assert.Equal(expectedLevel, actuallLevel);
            Assert.Equivalent(expectedLevelAttrbutes, actuallLevelAttrbutes);
        }

        [Fact]
        public void LevelUp_IncreaseAttributesCorrectly()
        {
            //Arrange
            var archer = new Archer("name1");
            int initialStrength = archer.LevelAttributes.Strength;
            int initialDexterity = archer.LevelAttributes.Dexterity;
            int initialIntelligence = archer.LevelAttributes.Intelligence;
            int initialLevel = archer.Level;

            //Act
            archer.LevelUp();
            int actuallStrength = archer.LevelAttributes.Strength;
            int actuallDexterity = archer.LevelAttributes.Dexterity;
            int actuallIntelligence = archer.LevelAttributes.Intelligence;
            int actuallLevel = archer.Level;

            int expectedStrength = initialStrength + 1;
            int expectedDexterity = initialDexterity + 5;
            int expectedIntelligence = initialIntelligence + 1;
            int expectedLevel = initialLevel + 1;

            //Assert
            Assert.Equal(expectedStrength, actuallStrength);
            Assert.Equal(expectedDexterity, actuallDexterity);
            Assert.Equal(expectedIntelligence, actuallIntelligence);
            Assert.Equal(expectedLevel, actuallLevel);

        }

        [Theory]
        [InlineData(WeaponType.Bow)]
        public void Equip_ValidWeapon_ShouldEquipWeapon(WeaponType weaponType)
        {
            //Arrange
            var archer = new Archer("name");
            var validWeapon = new Weapon("Bow", weaponType, 1, 7);
            string expectedWeaponName = "Bow";
            WeaponType expectedWeaponType = weaponType;

            //Act
            archer.Equip(validWeapon);
            Weapon? actuallWeapon = archer.Equipment[Slot.Weapon] as Weapon;
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
        [InlineData(WeaponType.Dagger)]
        [InlineData(WeaponType.Sword)]
        [InlineData(WeaponType.Hatchet)]
        [InlineData(WeaponType.Mace)]
        public void Equip_InvalidWeaponType_ShouldThrowInvalidWeaponException(WeaponType weaponType)
        {
            //Arrange
            var archer = new Archer("name");
            var invalidWeapon = new Weapon("Void Staff", weaponType, 1, 7);
            string expectedMessage = "Can not equip this type of weapon";

            //Act
            var exeption = Assert.Throws<InvalidWeaponException>(() =>
            {
                archer.Equip(invalidWeapon);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }

        [Theory]
        [InlineData(ArmorType.Leather)]
        [InlineData(ArmorType.Mail)]
        public void Equip_ValidArmor_ShouldEquipArmor(ArmorType armorType)
        {
            //Arrange
            var archer = new Archer("name");
            var validArmor = new Armor("armorName", armorType, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedArmorName = "armorName";
            ArmorType expectedArmorType = armorType;

            //Act
            archer.Equip(validArmor);
            Armor? actuallArmor = archer.Equipment[Slot.Body] as Armor;
            string? actuallArmorName = actuallArmor?.Name;
            ArmorType? actuallArmorType = actuallArmor?.Type;

            //Assert
            Assert.Equal(expectedArmorName, actuallArmorName);
            Assert.Equal(expectedArmorType, actuallArmorType);
            Assert.Equal(validArmor, actuallArmor);
        }

        [Theory]
        [InlineData(ArmorType.Cloth)]
        [InlineData(ArmorType.Plate)]
        public void Equip_InvalidArmorType_ShouldThrowInvalidArmorException(ArmorType armorType)
        {
            //Arrange
            var archer = new Archer("name");
            var invalidArmor = new Armor("armorName", armorType, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedMessage = "Can not equip this type of armor";

            //Act
            var exeption = Assert.Throws<InvalidArmorException>(() =>
            {
                archer.Equip(invalidArmor);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }

        [Fact]
        public void Damage_NoWeapon_CalculateCorrectly()
        {
            //Arrange
            var archer = new Archer("name");
            decimal expectedDamage = 1 * ((1 + 7) / 100m);

            //Act
            decimal actuallDamage = archer.Damage();

            //Assert
            Assert.Equal(expectedDamage, actuallDamage);
        }

        [Fact]
        public void Damage_WithWeapon_CalculateCorrectly()
        {
            //Arrange
            var archer = new Archer("name");
            var staff = new Weapon("wName", WeaponType.Bow, 1, 7);
            archer.Equip(staff);

            decimal expectedDamage = 7 * ((1 + 7) / 100m);

            //Act
            decimal actuallDamage = archer.Damage();

            //Assert
            Assert.Equal(expectedDamage, actuallDamage);
        }

    }
}
