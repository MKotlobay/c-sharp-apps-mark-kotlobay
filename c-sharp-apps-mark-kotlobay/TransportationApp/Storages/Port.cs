using System;
using System.Collections.Generic;
using System.Linq;
using c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.Storages
{
    public class Port : StorageStructure
    {
        public string Name { get; set; }
        protected int NumWarehouse { get; set; }
        protected double MaxCapacityWeight { get; set; }
        protected double MaxCapacityVolume { get; set; }
        public Crane Crane { get; set; }
        public List<Container> Containers { get; set; }

        public Port(string country, string city, string street, int number, double maxCapacityWeight, double maxCapacityVolume, string name, int numWarehouse)
            : base(country, city, street, number, maxCapacityWeight, maxCapacityVolume)
        {
            Name = name;
            NumWarehouse = numWarehouse;
            MaxCapacityWeight = maxCapacityWeight;
            MaxCapacityVolume = maxCapacityVolume;
            Crane = new Crane(maxCapacityWeight, maxCapacityVolume);
            Containers = new List<Container>();
        }

        public List<Container> LoadItemsToContainers()
        {
            List<Container> containers = new List<Container>();

            foreach (var item in Items.ToList())
            {
                bool itemAdded = false;

                foreach (var container in containers)
                {
                    if (container.Volume + item.Volume <= container.MaxVolume)
                    {
                        container.AddItem(item);
                        UpdateStorage(item.Weight, item.Volume);
                        itemAdded = true;
                        break;
                    }
                }

                if (!itemAdded)
                {
                    Container newContainer = new Container();
                    newContainer.AddItem(item);
                    UpdateStorage(item.Weight, item.Volume);
                    containers.Add(newContainer);
                }
            }
            return containers;
        }

        public void UnpackItemsFromContainers(List<Container> containers)
        {
            foreach (var container in containers)
            {
                // Directly add the items from the container to the port's Items list
                Items.AddRange(container.Items);

                // Clear the items in the container after unpacking
                container.ClearItems();
            }

            Console.WriteLine("Items have been unpacked from containers to the port.");
        }

        public void UpdateStorage(double weight, double volume)
        {
            WeightStored -= weight;
            VolumeStored -= volume;
        }

        public override string ToString()
        {
            return $"Port Name: {Name}\n" +
                   $"Location: {Country}, {City}, {Street}, {Number}\n" +
                   $"Capacity: {MaxCapacityWeight}kg, {MaxCapacityVolume}m³\n" +
                   $"Stored Weight: {WeightStored}kg, Stored Volume: {VolumeStored}m³\n";
        }
    }
}
