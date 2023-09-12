﻿using DungeonMaster.classes;
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

        [Fact]
        public void Equip_ValidWeapon_ShouldEquipWeapon()
        {
            //Arrange
            var archer = new Archer("name");
            var validWeapon = new Weapon("Bow", WeaponType.Bow, 1, 7);
            string expectedWeaponName = "Bow";
            WeaponType expectedWeaponType = WeaponType.Bow;

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

        [Fact]
        public void Equip_InvalidWeaponType_ShouldThrowInvalidWeaponException()
        {
            //Arrange
            var archer = new Archer("name");
            var invalidWeapon = new Weapon("Void Staff", WeaponType.Staff, 1, 7);
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

        [Fact]
        public void Equip_ValidArmor_ShouldEquipArmor()
        {
            //Arrange
            var archer = new Archer("name");
            var validArmor = new Armor("armorName", ArmorType.Leather, 1, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedArmorName = "armorName";
            ArmorType expectedArmorType = ArmorType.Leather;

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

        [Fact]
        public void Equip_InvalidArmorType_ShouldThrowInvalidArmorException()
        {
            //Arrange
            var archer = new Archer("name");
            var invalidArmor = new Armor("armorName", ArmorType.Plate, 1, Slot.Body, new HeroAttribute(1, 1, 2));
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



    }
}
