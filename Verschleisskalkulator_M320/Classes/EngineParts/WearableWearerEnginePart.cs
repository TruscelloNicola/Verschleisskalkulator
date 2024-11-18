using System;
using System.Collections.Generic;
using Verschleisskalkulator_M320.Classes.Interface;

namespace Verschleisskalkulator_M320.Classes.EngineParts
{
    public class WearableWearerEnginePart: WearableEnginePart, IStartWear, IWearer
	{
		private Dictionary<EnginePart, double> _WearAmount;

        public WearableWearerEnginePart(string name, double wearfactor, bool liquidseffect, bool isbroken, double cost, byte condition, Dictionary<EnginePart, double> wearamount) : base(name, wearfactor, liquidseffect, cost, isbroken, condition)
        {
            setWearAmount(wearamount);
        }
		public WearableWearerEnginePart()
		{
			_WearAmount = new Dictionary<EnginePart, double>();
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

			finalAmountwear = Math.Round(finalAmountwear * factor, 0);

			if (finalAmountwear >= 100 || _Condition - finalAmountwear <= 0)
			{
				_IsBroken = true;
				_Condition = 0;
			}
			else _Condition -= finalAmountwear;
		}
		public Dictionary<EnginePart, double> getWearAmount() { return _WearAmount; }
		public void setWearAmount(Dictionary<EnginePart, double> Dictionary) { _WearAmount = Dictionary; }
		public double getIndWearAmount(EnginePart enginePart) {

			if (!_WearAmount.ContainsKey(enginePart)) { return 1.0; }
			else if (_IsBroken == true)
			{
				return _WearAmount[enginePart];
			}
			else return 1;
		}
		public void setIndWearAmount(EnginePart enginePart, double WearAmount) { _WearAmount.Add(enginePart, WearAmount); }

	}
}
