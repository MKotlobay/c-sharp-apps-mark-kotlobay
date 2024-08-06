using c_sharp_apps_mark_kotlobay.TransportationApp.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public abstract class StorageStructure
    {
        protected string Country { get; set; }
        protected string City { get; set; }
        protected string Street { get; set; }
        protected int Number { get; set; }
        protected double CapacityWeight { get; set; }
        protected double CapacityVolume { get; set; }
        protected double WeightStored { get; set; }
        protected double VolumeStored { get; set; }

        protected StorageStructure(string country, string city, string street, int number, double capacityWeight, double capacityVolume)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
            CapacityWeight = capacityWeight;
            CapacityVolume = capacityVolume;
            WeightStored = 0;
            VolumeStored = 0;
        }

        // Method to load items into the storage structure
        public bool Load(List<IPortable> items)
        {
            double totalWeight = items.Sum(item => item.Weight);
            double totalVolume = items.Sum(item => item.Volume);

            // Check if there is enough capacity to load the items
            if ((WeightStored + totalWeight <= CapacityWeight) && (VolumeStored + totalVolume <= CapacityVolume))
            {
                WeightStored += totalWeight;
                VolumeStored += totalVolume;
                return true; // Items loaded successfully
            }

            return false; // Not enough capacity to load items
        }

        // Optional: Method to unload items from the storage structure
        public bool Unload(List<IPortable> items)
        {
            double totalWeight = items.Sum(item => item.Weight);
            double totalVolume = items.Sum(item => item.Volume);

            // Check if the items are already in the storage
            if ((WeightStored - totalWeight >= 0) && (VolumeStored - totalVolume >= 0))
            {
                WeightStored -= totalWeight;
                VolumeStored -= totalVolume;
                return true; // Items unloaded successfully
            }

            return false; // Items not found or other issue
        }
    }

}
