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
        protected List<Container> Containers = new List<Container>();
        public FreightTrain(Driver driver, double maxWeight, double maxVolume, List<IPortable> items, string storageStructureParked, string storageStructureToGo)
            : base(driver, maxWeight, maxVolume, items, storageStructureParked, storageStructureToGo)
        {
            CreateContainerList(items);
        }

        public void CreateContainerList(List<IPortable> items)
        {
            foreach (var item in items)
            {
                bool itemAdded = false;

                foreach (var container in Containers)
                {
                    if (container.CanAddItem(item))
                    {
                        container.AddItem(item);
                        itemAdded = true;
                        break; // Exit the loop as the item has been added
                    }
                }

                if (!itemAdded)
                {
                    // Create a new container and add the item to this new container
                    var newContainer = new Container(); // Assuming a default constructor
                    newContainer.AddItem(item);
                    Containers.Add(newContainer);
                }
            }
        }
    }
}
