using System;
using Verschleisskalkulator_M320.Classes.Interface;

namespace Verschleisskalkulator_M320.Classes.EngineParts
{
    public class WearableEnginePart: BreakableEnginePart, IStartWear
	{
		public double _Condition { get; set; }

		public double _WearFactor { get; set; }

		public bool _LiquidsEffect { get; set; }
		public WearableEnginePart(string name, double wearfactor, bool liquidseffect, double cost, bool isbroken, double condition) : base(name, cost, isbroken)
		{ 
			_Condition = condition;
			_WearFactor = wearfactor;
			_LiquidsEffect = liquidseffect;
		}

		public WearableEnginePart()
		{
			_Condition = 100.0;
			_WearFactor = 1.0;
			_LiquidsEffect = true;
		}
		public void StartWear(Car Satsuma)
		{
			// Generic distance and RPM formula.
			double finalAmountwear = ((Satsuma._DistanceDriven / 10) * Math.Pow(1.09, (Satsuma._RPM / 100))) * _WearFactor;
			// Modifiers for the Oil and coolant level.
			if (_LiquidsEffect) finalAmountwear = finalAmountwear / ((Satsuma._OilLevel / 100) * (Satsuma._CoolantLevel / 100));
			// Pull all factors from dictionary to make final adjustment to final wear amount to part.
			double factor = 1;
			foreach (IWearer wearerwearable in Satsuma._WearableWearerEngineParts)
			{
				factor = factor * wearerwearable.getIndWearAmount(this);
			}
			foreach (IWearer wearer in Satsuma._WearerEngineParts)
			{
				factor = factor * wearer.getIndWearAmount(this);
			}

			finalAmountwear = Math.Round((finalAmountwear * factor), 0);

			if (finalAmountwear >= 100 || _Condition - finalAmountwear <= 0 )
			{
				_IsBroken = true;
				_Condition = 0;
			}
			else _Condition -= finalAmountwear;
		}

	}
}
