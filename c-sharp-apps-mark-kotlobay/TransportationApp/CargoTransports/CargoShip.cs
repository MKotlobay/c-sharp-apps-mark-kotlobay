using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports
{
    public class CargoShip : CargoVehicle
    {
        public CargoShip(Driver driver, double maxWeight, double maxVolume, List<IPortable> itemsFromCargo, string storageStructureParked, string storageStructureToGo)
            : base(driver, maxWeight, maxVolume, itemsFromCargo, storageStructureParked, storageStructureToGo)
        {
        }

        public void UnloadItems(StorageStructure destination)
        {
            if (IsReadyToTravel())
            {
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
            else
            {
                Console.WriteLine("Cargo ship is not ready to travel.");
            }
        }
    }
}