using NUnit.Framework;
using Verschleisskalkulator_M320.Classes;
using Verschleisskalkulator_M320.Classes.EngineParts;

namespace Test_Verschleisskalkulator
{
    [TestFixture]
    public class BreakBlockWithPistonTest
    {
        [Test]
        public void TestBreakingBlockWithPistons()
        {
            // arrange
            BreakableEnginePart Block = new BreakableEnginePart("Block", 1200, false);

            Dictionary<EnginePart, double> PistonsDictionary = new Dictionary<EnginePart, double>
            {
                { Block, 100 }
            };
            WearableWearerEnginePart Pistons = new WearableWearerEnginePart("Pistons", 1.0, true, false, 1396, 100, PistonsDictionary);

            Car Satsuma = new Car();

            Satsuma._CoolantLevel = 100;
            Satsuma._OilLevel = 100;
            Satsuma._RPM = 6000;
            Satsuma._DistanceDriven = 300;

            Satsuma.addWearablePart(Block);
            Satsuma.addWearableWearerPart(Pistons);

            // act
            Pistons.StartWear(Satsuma);
            Block.StartWear(Satsuma);

            // assert
            Assert.That(Block._IsBroken, Is.EqualTo(true));
        }

    }
}
