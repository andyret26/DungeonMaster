using DungeonMaster.classes;
using DungeonMaster.classes.heroClasses;
using DungeonMaster.enums;

namespace DungeonMaster.Tests
{
    public class HeroClassTests
    {
        [Fact]
        public void Template()
        {
            //Arrange


            //Act


            //Assert

        }

        [Fact]
        public void Armor_NoEquipment_CalculateArmorCorrectly()
        {
            //Arrange
            var wizard = new Wizard("name");
            int expectedTotalStr = 1;
            int expectedTotalDex = 1;
            int expectedTotalInt = 8;
            int expectedTotalAttributes = expectedTotalStr + expectedTotalDex + expectedTotalInt;

            //Act
            int actuallTtotalStr = wizard.TotalStrength();
            int actuallTtotalDex = wizard.TotalDexterity();
            int actuallTtotalInt = wizard.TotalIntelligence();
            int actuallTtotalAttributes = wizard.TotalAttributes();


            //Assert
            Assert.Equal(expectedTotalStr, actuallTtotalStr);
            Assert.Equal(expectedTotalDex, actuallTtotalDex);
            Assert.Equal(expectedTotalInt, actuallTtotalInt);
            Assert.Equal(expectedTotalAttributes, actuallTtotalAttributes);

        }

        [Fact]
        public void Armor_OnePiece_CalculateArmorCorrectly()
        {
            //Arrange
            var wizard = new Wizard("name");
            var helmet = new Armor("HelmName", ArmorType.Cloth, 1, Slot.Head, new HeroAttribute(1, 2, 3));
            wizard.Equip(helmet);

            int expectedTotalStr = 2;
            int expectedTotalDex = 3;
            int expectedTotalInt = 11;
            int expectedTotalAttributes = expectedTotalStr + expectedTotalDex + expectedTotalInt;

            //Act
            int actuallTtotalStr = wizard.TotalStrength();
            int actuallTtotalDex = wizard.TotalDexterity();
            int actuallTtotalInt = wizard.TotalIntelligence();
            int actuallTtotalAttributes = wizard.TotalAttributes();


            //Assert
            Assert.Equal(expectedTotalStr, actuallTtotalStr);
            Assert.Equal(expectedTotalDex, actuallTtotalDex);
            Assert.Equal(expectedTotalInt, actuallTtotalInt);
            Assert.Equal(expectedTotalAttributes, actuallTtotalAttributes);
        }

        [Fact]
        public void Armor_TwoPieces_CalculateArmorCorrectly()
        {
            //Arrange
            var wizard = new Wizard("name");
            var helmet = new Armor("HelmName", ArmorType.Cloth, 1, Slot.Head, new HeroAttribute(1, 2, 3));
            var chest = new Armor("Robe", ArmorType.Cloth, 1, Slot.Body, new HeroAttribute(3, 4, 5));
            wizard.Equip(helmet);
            wizard.Equip(chest);

            int expectedTotalStr = 5;
            int expectedTotalDex = 7;
            int expectedTotalInt = 16;
            int expectedTotalAttributes = expectedTotalStr + expectedTotalDex + expectedTotalInt;

            //Act
            int actuallTtotalStr = wizard.TotalStrength();
            int actuallTtotalDex = wizard.TotalDexterity();
            int actuallTtotalInt = wizard.TotalIntelligence();
            int actuallTtotalAttributes = wizard.TotalAttributes();


            //Assert
            Assert.Equal(expectedTotalStr, actuallTtotalStr);
            Assert.Equal(expectedTotalDex, actuallTtotalDex);
            Assert.Equal(expectedTotalInt, actuallTtotalInt);
            Assert.Equal(expectedTotalAttributes, actuallTtotalAttributes);
        }

        [Fact]
        public void Armor_RepleacePiece_CalculateArmorCorrectly()
        {
            //Arrange
            var wizard = new Wizard("name");
            var helmet = new Armor("HelmName", ArmorType.Cloth, 1, Slot.Head, new HeroAttribute(1, 2, 3));
            var betterHelmet = new Armor("UltraCap", ArmorType.Cloth, 1, Slot.Head, new HeroAttribute(3, 4, 5));
            wizard.Equip(betterHelmet);

            int expectedTotalStr = 4;
            int expectedTotalDex = 5;
            int expectedTotalInt = 13;
            int expectedTotalAttributes = expectedTotalStr + expectedTotalDex + expectedTotalInt;

            //Act
            int actuallTtotalStr = wizard.TotalStrength();
            int actuallTtotalDex = wizard.TotalDexterity();
            int actuallTtotalInt = wizard.TotalIntelligence();
            int actuallTtotalAttributes = wizard.TotalAttributes();


            //Assert
            Assert.Equal(expectedTotalStr, actuallTtotalStr);
            Assert.Equal(expectedTotalDex, actuallTtotalDex);
            Assert.Equal(expectedTotalInt, actuallTtotalInt);
            Assert.Equal(expectedTotalAttributes, actuallTtotalAttributes);
        }

        [Fact]
        public void Equip_InvalidArmorLevel_ShouldThrowInvalidLevelException()
        {
            //Arrange
            var wizard = new Wizard("name");
            var invalidArmor = new Armor("FON", ArmorType.Cloth, 2, Slot.Body, new HeroAttribute(1, 1, 2));
            string expectedMessage = "Not high enough level for this item";

            //Act
            var exeption = Assert.Throws<InvalidLevelException>(() =>
            {
                wizard.Equip(invalidArmor);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }

        [Fact]
        public void Equip_InvalidWeaponLevel_ShouldThrowInvalidLevelException()
        {
            //Arrange
            var wizard = new Wizard("name");
            var invalidWeapon = new Weapon("FON", WeaponType.Staff, 2, 7);
            string expectedMessage = "Not high enough level for this item";

            //Act
            var exeption = Assert.Throws<InvalidLevelException>(() =>
            {
                wizard.Equip(invalidWeapon);
            });
            string actuallMessage = exeption.Message;

            //Assert
            Assert.Equal(expectedMessage, actuallMessage);
        }
    }
}