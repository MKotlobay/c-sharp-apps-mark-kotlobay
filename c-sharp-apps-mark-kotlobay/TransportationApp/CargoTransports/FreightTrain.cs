using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports
{
    public class FreightTrain : CargoVehicle
    {
        public FreightTrain(Driver driver, double maxWeight, double maxVolume, List<IPortable> itemsFromCargo, string storageStructureParked, string storageStructureToGo)
            : base(driver, maxWeight, maxVolume, itemsFromCargo, storageStructureParked, storageStructureToGo)
        {
        }

        public void DriveAndUnload(StorageStructure destination)
        {
            // Simulate driving to the destination
            Console.WriteLine($"Driving to {destination}");

            // Unload items at the destination
            if (destination.Load(ItemsFromCargo))
            {
                ItemsFromCargo.Clear();
                CargoWeightCheck(); // Ensure weight check after unloading
            }
            else
            {
                Console.WriteLine("Failed to unload items.");
            }
        }
    }
}
