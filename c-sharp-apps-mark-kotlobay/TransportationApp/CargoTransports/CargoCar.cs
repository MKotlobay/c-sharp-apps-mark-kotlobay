using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports
{
    public class CargoCar : CargoVehicle
    {
        public CargoCar(Driver driver, double maxWeight, double maxVolume, List<IPortable> items, string storageStructureParked, string storageStructureToGo)
            : base(driver, maxWeight, maxVolume, items, storageStructureParked, storageStructureToGo)
        {
        }

        public void UnloadItems(StorageStructure destination)
        {
            // Simulate unloading items at the destination
            Console.WriteLine($"Unloading items at {destination}");

            // Unload items at the destination
            if (destination.Load(Items))
            {
                Items.Clear();
                CargoWeightCheck(); // Ensure weight check after unloading
                Console.WriteLine($"Items successfully unloaded at {destination}.");
            }
            else
            {
                Console.WriteLine($"Failed to unload items at {destination}.");
            }
        }
    }
}
