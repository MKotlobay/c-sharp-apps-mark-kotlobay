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

        public bool LoadItemToStorage(IPortable item)
        {
            if (CurrentItemsWeightInCargo + item.Weight <= MaxWeight)
            {
                Items.Add(item);
                CurrentItemsWeightInCargo += item.Weight;
                return true;
            }
            return false;
        }

        public void LoadItemsToStorage(List<IPortable> newItems)
        {
            foreach (var item in newItems)
            {
                LoadItemToStorage(item);
            }
        }
    }
}
