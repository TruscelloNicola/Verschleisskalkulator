namespace Verschleisskalkulator_M320.Classes.EngineParts
{
    public class EnginePart
	{
		public string _Name { get; set; }

		public EnginePart(string name) { _Name = name; }

		public EnginePart() { _Name = "Unknown"; }
	}
}
