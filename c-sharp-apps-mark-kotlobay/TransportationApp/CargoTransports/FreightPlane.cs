using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports
{
    public class FreightPlane : CargoVehicle
    {
        public FreightPlane(Driver driver, double maxWeight, double maxVolume, List<IPortable> items, string storageStructureParked, string storageStructureToGo)
            : base(driver, maxWeight, maxVolume, items, storageStructureParked, storageStructureToGo)
        {
        }

        public void UnloadItems(StorageStructure destination)
        {
            if (destination.Load(Items))
            {
                Items.Clear();
                CargoWeightCheck(); // Ensure weight check after unloading
            }
            else
            {
                Console.WriteLine("Failed to unload items.");
            }
        }
    }
}
