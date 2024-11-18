using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Verschleisskalkulator_M320.Classes;
using Verschleisskalkulator_M320.Classes.EngineParts;
using Verschleisskalkulator_M320.Classes.Interface;

namespace Verschleisskalkulator_M320
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			
			List<string> IntakeList = new List<string>() { 
				"Stock intake",
				"GT intake",
				"Racing intake"
			};
            List<string> HeadersList = new List<string>() {  
				"Stock headers",
                "No headers",
                "Racing headers"
            };

			IntakeCombo.ItemsSource = IntakeList;
			HeadersCombo.ItemsSource = HeadersList;
        }

		private void StartWearing(object sender, RoutedEventArgs e)
		{
			/// Logis is as follows: With every calculation, broken parts are repaired and added to the total cost. Their condition
			/// will be reset to 100% with the assumption that new parts are bought, not repaired.


			//Create all breakable parts with according conditions.
			BreakableEnginePart Block = new BreakableEnginePart("Block", 1200, false);

			WearableEnginePart ClutchDisk = new WearableEnginePart("Clutch disk", 0.1, false, 375, false, IIf(ClutchInt.Text));
			WearableEnginePart Crankshaft = new WearableEnginePart("Crankshaft", 0.3, true, 915, false, IIf(CrankShaftInt.Text));
			WearableEnginePart FuelPump = new WearableEnginePart("Fuel pump", 0.2, false, 320, false, IIf(FuelPumpInt.Text));
			WearableEnginePart Gearbox = new WearableEnginePart("Gearbox", 0.3, false, 1950, false, IIf(GearBoxInt.Text));
			WearableEnginePart HeadGasket = new WearableEnginePart("Head gasket", 0.7, true, 329, false, IIf(HeadGasketInt.Text));
			BreakableEnginePart OilPan = new BreakableEnginePart("Oil pan", 520, false);
			WearableEnginePart Starter = new WearableEnginePart("Starter", 0.05, false, 295, false, IIf(StarterInt.Text));
			WearableEnginePart Alternator = new WearableEnginePart("Alternator", 1, false, 425, false, IIf(AlternatorInt.Text));
			WearableEnginePart RockerShaft = new WearableEnginePart("Rocker shaft", 0.8, true, 729, false, IIf(RockerShaftInt.Text));
			Dictionary<EnginePart, double> PistonsDictionary = new Dictionary<EnginePart, double>
			{
				{ Block, 100 },
				{ OilPan, 100 },
				{ Crankshaft, 100 },
				{ RockerShaft, 100 }
			};
			WearableWearerEnginePart Pistons = new WearableWearerEnginePart("Pistons", 1.0, true, false, 1396, IIf(PistonsInt.Text), PistonsDictionary);
			Dictionary<EnginePart, double> WaterPumpDictionary = new Dictionary<EnginePart, double>
			{
				{ Block, 2 },
				{ Pistons, 2 },
				{ HeadGasket, 2 }
			};
			WearableWearerEnginePart WaterPump = new WearableWearerEnginePart("Water pump",0.7, true, false, 350, IIf(WaterPumpInt.Text), WaterPumpDictionary);



            Car Satsuma = new Car();

			//Defaults are redundant, but I kept it in for future error handling.
            switch (IntakeCombo.SelectedIndex)
			{
				case (0):
                    Dictionary<EnginePart, double> StockIntakeDictionary = new Dictionary<EnginePart, double>
						{
							{ RockerShaft, 1 },
							{ HeadGasket, 1},
							{ Pistons, 1 }
						};
                    WearPart StockIntake = new WearPart("Stock intake", StockIntakeDictionary);
                    Satsuma.addWearerPart(StockIntake);
                    break;
                case (1):
                    Dictionary<EnginePart, double> GTIntakeDictionary = new Dictionary<EnginePart, double>
						{
							{ RockerShaft, 1.01 },
							{ HeadGasket, 1.07 },
							{ Pistons, 1.01 }
						};
                    WearPart GTIntake = new WearPart("GT intake", GTIntakeDictionary);
                    Satsuma.addWearerPart(GTIntake);
                    break;
                case (2):
                    Dictionary<EnginePart, double> RacingIntakeDictionary = new Dictionary<EnginePart, double>
						{
							{ RockerShaft, 1.1 },
							{ HeadGasket, 1.3 },
							{ Pistons, 1.1 }
						};
                    WearPart RacingIntake = new WearPart("Racing intake", RacingIntakeDictionary);
                    Satsuma.addWearerPart(RacingIntake);
                    break;
				default:
                    Dictionary<EnginePart, double> DefaultIntakeDictionary = new Dictionary<EnginePart, double>
                        {
                            { RockerShaft, 1 },
                            { HeadGasket, 1},
                            { Pistons, 1 }
                        };
                    WearPart DefaultIntake = new WearPart("Stock intake", DefaultIntakeDictionary);
                    Satsuma.addWearerPart(DefaultIntake);
                    break;
            }
            switch (HeadersCombo.SelectedItem)
            {
                case (0):
                    Dictionary<EnginePart, double> StockHeadersDictionary = new Dictionary<EnginePart, double>
						{
							{ RockerShaft, 1 },
							{ HeadGasket, 1},
							{ Pistons, 1 }
						};
                    WearPart StockHeaders = new WearPart("Stock headers", StockHeadersDictionary);
                    Satsuma.addWearerPart(StockHeaders);
                    break;
                case (1):
                    Dictionary<EnginePart, double> NoHeadersDictionary = new Dictionary<EnginePart, double>
						{
							{ RockerShaft, 1.01 },
							{ HeadGasket, 1.07 },
							{ Pistons, 1.01 }
						};
                    WearPart NoHeaders = new WearPart("No headers", NoHeadersDictionary);
                    Satsuma.addWearerPart(NoHeaders);
                    break;
                case (2):
                    Dictionary<EnginePart, double> RacingHeadersDictionary = new Dictionary<EnginePart, double>
						{
							{ RockerShaft, 1.05 },
							{ HeadGasket, 1.07 },
							{ Pistons, 1.05 }
						};
                    WearPart RacingHeaders = new WearPart("Racing headers", RacingHeadersDictionary);
                    Satsuma.addWearerPart(RacingHeaders);
                    break;
				default:
                    Dictionary<EnginePart, double> DefaultHeadersDictionary = new Dictionary<EnginePart, double>
                        {
                            { RockerShaft, 1 },
                            { HeadGasket, 1},
                            { Pistons, 1 }
                        };
                    WearPart DefaultHeaders = new WearPart("Stock headers", DefaultHeadersDictionary);
                    Satsuma.addWearerPart(DefaultHeaders);
                    break;
            }

			Satsuma._CoolantLevel = IIf(CoolantLevelInt.Text);
			Satsuma._OilLevel = IIf(OilLevelInt.Text);
			Satsuma._RPM = IIf_Int(RPMInt.Text);
			Satsuma._DistanceDriven = IIf_Int(DistanceDrivenInt.Text);

			Satsuma.addWearablePart(Block);
			Satsuma.addWearablePart(ClutchDisk);
			Satsuma.addWearablePart(Crankshaft);
			Satsuma.addWearablePart(FuelPump);
			Satsuma.addWearablePart(Gearbox);
			Satsuma.addWearablePart(HeadGasket);
			Satsuma.addWearablePart(OilPan);
			Satsuma.addWearablePart(Starter);
			Satsuma.addWearablePart(Alternator);
			Satsuma.addWearablePart(RockerShaft);

			Satsuma.addWearableWearerPart(Pistons);
			Satsuma.addWearableWearerPart(WaterPump);

            CostBox.Text = Convert.ToString(Convert.ToDouble(CostBox.Text) + Satsuma.startDrive());

            ClutchInt.Text = Convert.ToString(ClutchDisk._Condition);
			IsBrokenShow(ClutchIsBroken, ClutchDisk);
			CrankShaftInt.Text = Convert.ToString(Crankshaft._Condition);
			IsBrokenShow(CrankShaftIsBroken, Crankshaft);
			FuelPumpInt.Text = Convert.ToString(FuelPump._Condition);
			IsBrokenShow(FuelPumpIsBroken, FuelPump);
			GearBoxInt.Text = Convert.ToString(Gearbox._Condition);
			IsBrokenShow(GearBoxIsBroken, Gearbox);
			HeadGasketInt.Text = Convert.ToString(HeadGasket._Condition);
			IsBrokenShow(HeadGasketIsBroken, HeadGasket);
			StarterInt.Text = Convert.ToString(Starter._Condition);
			IsBrokenShow(StarterIsBroken, Starter);
			AlternatorInt.Text = Convert.ToString(Alternator._Condition);
			IsBrokenShow(AlternatorIsBroken, Alternator);
			RockerShaftInt.Text = Convert.ToString(RockerShaft._Condition);
			IsBrokenShow(RockerShaftIsBroken, RockerShaft);
			PistonsInt.Text = Convert.ToString(Pistons._Condition);
			IsBrokenShow(PistonsIsBroken, Pistons);
			WaterPumpInt.Text = Convert.ToString(WaterPump._Condition);
			IsBrokenShow(WaterPumpIsBroken, WaterPump);
			IsBrokenShow(BlockIsBroken, Block);
			IsBrokenShow(OilPanIsBroken, OilPan);

			void IsBrokenShow(Label label, BreakableEnginePart part)
			{
				if (part._IsBroken)
				{
					label.Visibility = Visibility.Visible;
				}
				else
				{
                    label.Visibility = Visibility.Hidden;
                }
			}
		}

        private void ResetCost(object sender, RoutedEventArgs e)
        {
			CostBox.Text = "0";
        }
        public static byte IIf(string input)
        {
			if (byte.TryParse(input, out byte result))
			{
				return result;
			}
			else return 100;
        }

        public static int IIf_Int(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else return 100;
        }
    }
}
