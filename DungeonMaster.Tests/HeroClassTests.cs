using DungeonMaster.classes;
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
            var helmet = new Armor("HelmName", ArmorType.Cloth, Slot.Head, new HeroAttribute(1, 2, 3));
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
    }
}