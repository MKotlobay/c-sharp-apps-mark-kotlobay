using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class Port : StorageStructure
    {
        protected string Name { get; set; }
        protected int NumWarehouse { get; set; }
        protected double MaxCapacityWeight { get; set; } // Possible to hold by weight
        protected double MaxCapacityVolume { get; set; } // Possible to hold by volume
        protected List<IPortable> InStorage { get; set; }

        public Port(string country, string city, string street, int number, double maxCapacityWeight, double maxCapacityVolume, string name, int numWarehouse, List<IPortable> itemsFromCargo)
            : base(country, city, street, number, maxCapacityWeight, maxCapacityVolume)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
            Name = name;
            NumWarehouse = numWarehouse;
            MaxCapacityWeight = maxCapacityWeight;
            MaxCapacityVolume = maxCapacityVolume;
            InStorage = new List<IPortable>();
            LoadItems(itemsFromCargo); // Stores list recived of items into InStorage list
        }

        public void LoadItems(List<IPortable> itemsFromCargo)
        {
            foreach (var item in itemsFromCargo)
            {
                if (WeightStored + item.Weight < MaxCapacityWeight && VolumeStored + item.Volume < MaxCapacityVolume)
                {
                    WeightStored += item.Weight;
                    VolumeStored += item.Volume;
                    InStorage.Add(item);
                    itemsFromCargo.Remove(item); // No returns for that list - possible to loose data
                }
                else
                    Console.WriteLine($"Cannot be stored more, have now weight stored:{WeightStored}, and volume:{VolumeStored} - max for weight{MaxCapacityWeight} and max for volume{MaxCapacityVolume}");
            }
        }
    }
}
