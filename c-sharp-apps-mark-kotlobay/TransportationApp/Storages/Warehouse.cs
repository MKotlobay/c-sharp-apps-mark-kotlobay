using System;
using System.Collections.Generic;
using System.Linq;
using c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.Storages
{
    public class Warehouse : StorageStructure
    {
        public string Name { get; set; }
        protected int NumWarehouse { get; set; }
        protected double MaxCapacityWeight { get; set; }
        protected double MaxCapacityVolume { get; set; }
        public List<IPortable> InStorage { get; set; }
        public Crane Crane { get; set; }

        public Warehouse(string country, string city, string street, int number, double maxCapacityWeight, double maxCapacityVolume, List<IPortable> items, string name, int numWarehouse)
            : base(country, city, street, number, maxCapacityWeight, maxCapacityVolume, items)
        {
            Name = name;
            NumWarehouse = numWarehouse;
            MaxCapacityWeight = maxCapacityWeight;
            MaxCapacityVolume = maxCapacityVolume;
            InStorage = new List<IPortable>();
            Crane = new Crane(maxCapacityWeight, maxCapacityVolume);
        }

        public void LoadItems(List<IPortable> itemsFromCargo)
        {
            foreach (var item in itemsFromCargo.ToList())
            {
                if (item is Container container)
                {
                    if (Crane.Load(container))
                    {
                        if (WeightStored + container.Weight <= MaxCapacityWeight && VolumeStored + container.Volume <= MaxCapacityVolume)
                        {
                            WeightStored += container.Weight;
                            VolumeStored += container.Volume;
                            InStorage.Add(container);
                            itemsFromCargo.Remove(item);
                        }
                        else
                        {
                            Crane.Unload(container);
                            Console.WriteLine($"Cannot store more items. Current weight: {WeightStored}, volume: {VolumeStored}, max weight: {MaxCapacityWeight}, max volume: {MaxCapacityVolume}");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Cannot load container. The container type is not suitable for this warehouse.");
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Warehouse Name: {Name}\n" +
                   $"Location: {Country}, {City}, {Street}, {Number}\n" +
                   $"Capacity: {MaxCapacityWeight}kg, {MaxCapacityVolume}m³\n" +
                   $"Stored Weight: {WeightStored}kg, Stored Volume: {VolumeStored}m³\n";
        }
    }
}
