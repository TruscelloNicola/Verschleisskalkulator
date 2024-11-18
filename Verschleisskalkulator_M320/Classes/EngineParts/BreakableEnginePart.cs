using Verschleisskalkulator_M320.Classes.Interface;

namespace Verschleisskalkulator_M320.Classes.EngineParts
{
    public class BreakableEnginePart: EnginePart, IStartWear
	{
		public bool _IsBroken { get; set; }
		public double _Cost { get; set; }

		public BreakableEnginePart (string name, double cost, bool isbroken): base(name)
		{
			_IsBroken = isbroken;
			_Cost = cost;
		}
		public BreakableEnginePart()
		{
			_IsBroken = false;
			_Cost = 0;
		}

		public void StartWear(Car Satsuma)
		{
			foreach(IWearer wearablewearer in Satsuma._WearableWearerEngineParts)
			{
				double cache = wearablewearer.getIndWearAmount(this);

				if (cache != 1)
				{
					_IsBroken = true;
					return;
				}
			}
		}
	}
}
