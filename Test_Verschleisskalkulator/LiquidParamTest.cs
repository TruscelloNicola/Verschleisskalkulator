using NUnit.Framework;
using Verschleisskalkulator_M320.Classes;
using Verschleisskalkulator_M320.Classes.EngineParts;

namespace Test_Verschleisskalkulator
{
    [TestFixture]
    class LiquidParamTest
    {
        [Test]
        public void TestLiquidParamInfluenceTrue()
        {
            // arrange
            WearableEnginePart part = new WearableEnginePart("test", 1, true, 1, false, 100);

            Car Satsuma = new Car();

            Satsuma._CoolantLevel = 50;
            Satsuma._OilLevel = 75;
            Satsuma._RPM = 2500;
            Satsuma._DistanceDriven = 50;


            // act
            part.StartWear(Satsuma);

            // assert
            Assert.That(part._Condition, Is.EqualTo(0));

        }
        [Test]
        public void TestLiquidParamInfluenceFalse()
        {
            // arrange
            WearableEnginePart part = new WearableEnginePart("test", 1, false, 1, false, 100);

            Car Satsuma = new Car();

            Satsuma._CoolantLevel = 50;
            Satsuma._OilLevel = 75;
            Satsuma._RPM = 2500;
            Satsuma._DistanceDriven = 50;

            
            // act
            part.StartWear(Satsuma);

            // assert
            Assert.That(part._Condition, Is.EqualTo(57));

        }

    }
}
