using Verschleisskalkulator_M320.Classes.EngineParts;
using Verschleisskalkulator_M320.Classes;
using NUnit.Framework;

namespace Test_Verschleisskalkulator
{
    [TestFixture]
    internal class GetCostTest
    {
        [Test]
        public void TestCostReturn()
        {

            // arrange 
            BreakableEnginePart Block = new BreakableEnginePart("Block", 1200, false);
            WearableEnginePart RockerShaft = new WearableEnginePart("Rocker shaft", 0.8, true, 729, false, 100);
            Dictionary<EnginePart, double> PistonsDictionary = new Dictionary<EnginePart, double>
            {
                { Block, 100 }
            };
            WearableWearerEnginePart Pistons = new WearableWearerEnginePart("Pistons", 1.0, true, false, 1396, 100, PistonsDictionary);

            Car Satsuma = new Car();

            Satsuma._CoolantLevel = 100;
            Satsuma._OilLevel = 100;
            Satsuma._RPM = 2500;
            Satsuma._DistanceDriven = 130;

            Satsuma.addWearablePart(Block);
            Satsuma.addWearablePart(RockerShaft);
            Satsuma.addWearableWearerPart(Pistons);

            // act
            double cost = Satsuma.startDrive();

            // assert
            Assert.That(cost, Is.EqualTo(2596));
        }
    }
}
