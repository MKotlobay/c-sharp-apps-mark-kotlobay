using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;
using c_sharp_apps_mark_kotlobay.TransportationApp.Storages;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports
{
    public class FreightTrain : CargoVehicle
    {

        public FreightTrain(Driver driver, double maxWeight, double maxVolume, List<IPortable> items, string storageStructureParked, string storageStructureToGo)
            : base(driver, maxWeight, maxVolume, items, storageStructureParked, storageStructureToGo)
        {
            CreateContainerList(items);
            Items.Clear();
            CurrentItemsWeightInCargo = Containers.Sum(c => c.Items.Sum(i => i.Weight));
        }

        public void CreateContainerList(IPortable item)
        {
            bool itemAdded = false;

            foreach (var container in Containers)
            {
                if (container.CanAddItem(item) && CurrentItemsWeightInCargo + item.Weight <= MaxWeight)
                {
                    container.AddItem(item);
                    itemAdded = true;
                    CurrentItemsWeightInCargo += item.Weight;
                    break;
                }
            }

            if (!itemAdded)
            {
                var newContainer = new Container();
                newContainer.AddItem(item);
                Containers.Add(newContainer);
                CurrentItemsWeightInCargo += item.Weight;
            }
        }

        public void CreateContainerList(List<IPortable> items)
        {
            foreach (var item in items)
            {
                CreateContainerList(item);
            }
        }

        public List<IPortable> ContainersToItemsList()
        {
            List<IPortable> items = new List<IPortable>();
            foreach (var container in Containers)
            {
                items.AddRange(container.Items);
            }
            Containers.Clear();
            CurrentItemsWeightInCargo = 0; // Reset weight after clearing containers
            Console.WriteLine("All containers cleared. Current weight in cargo reset.");
            return items;
        }
    }
}
