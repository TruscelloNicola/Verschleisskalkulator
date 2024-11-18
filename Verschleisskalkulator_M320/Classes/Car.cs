using System.Collections.Generic;
using Verschleisskalkulator_M320.Classes.EngineParts;
using Verschleisskalkulator_M320.Classes.Interface;

namespace Verschleisskalkulator_M320.Classes
{
	public class Car
	{
		public List<IWearer> _WearerEngineParts = new List<IWearer>();
		public List<IStartWear> _WearableEngineParts = new List<IStartWear>();
		public List<WearableWearerEnginePart> _WearableWearerEngineParts = new List<WearableWearerEnginePart>();

		public byte _OilLevel { get; set; }
		public byte _CoolantLevel { get; set; }
		public int _RPM { get; set; }
		public int _DistanceDriven { get; set; }
		public void addWearablePart(IStartWear wearablePart)
		{
			_WearableEngineParts.Add(wearablePart);
		}
		public void addWearerPart(IWearer addWearerPart)
		{
			_WearerEngineParts.Add(addWearerPart);
		}
		public void addWearableWearerPart(WearableWearerEnginePart addWearerPart)
		{
			_WearableWearerEngineParts.Add(addWearerPart);
		}

        public double startDrive() {

            double FinalCost = 0;

            foreach (IStartWear wear in _WearableWearerEngineParts)
            {
                // Replace with new parts
                if (((WearableEnginePart)wear)._Condition == 0)
                {
                    ((WearableEnginePart)wear)._Condition = 100;
                }
                // Only then start wearing it down
                wear.StartWear(this);

                if (((BreakableEnginePart)wear)._IsBroken)
                {
                    FinalCost += ((BreakableEnginePart)wear)._Cost;
                }
            }

            foreach (IStartWear wear in _WearableEngineParts)
            {
                // Replace with new parts
                if (wear is WearableEnginePart && ((WearableEnginePart)wear)._Condition == 0)
                {
                    ((WearableEnginePart)wear)._Condition = 100;
                }
                // Only then start wearing it down
                wear.StartWear(this);

                if (((BreakableEnginePart)wear)._IsBroken)
                {
                    FinalCost += ((BreakableEnginePart)wear)._Cost;
                }
            }

            return FinalCost;
        
        }

	}
}
