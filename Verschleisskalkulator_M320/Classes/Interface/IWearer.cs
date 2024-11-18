using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verschleisskalkulator_M320.Classes.EngineParts;

namespace Verschleisskalkulator_M320.Classes.Interface
{
    public interface IWearer
	{
		public Dictionary<EnginePart, double> getWearAmount();
		public void setWearAmount(Dictionary<EnginePart, double> Dictionary);
		public double getIndWearAmount(EnginePart enginePart);
		public void setIndWearAmount(EnginePart enginePart, double WearAmount);
	}
}
