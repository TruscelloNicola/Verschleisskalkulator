using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Verschleisskalkulator_M320.Classes.Interface;

namespace Verschleisskalkulator_M320.Classes.EngineParts
{
	public class WearPart: EnginePart, IWearer
	{
		private Dictionary<EnginePart, double> _WearAmount;

		public WearPart(string name, Dictionary<EnginePart, double> wearamount) : base(name) 
		{
			setWearAmount(wearamount);
		}

		public Dictionary<EnginePart, double> getWearAmount() { return _WearAmount; }
		public void setWearAmount(Dictionary<EnginePart, double> Dictionary) { _WearAmount = Dictionary; }
		public double getIndWearAmount(EnginePart enginePart) { if (!_WearAmount.ContainsKey(enginePart)) { return 1.0; } return _WearAmount[enginePart]; }
		public void setIndWearAmount(EnginePart enginePart, double WearAmount) { _WearAmount.Add(enginePart, WearAmount); }
	}
}
