using c_sharp_apps_mark_kotlobay.TransportationApp.Items;
using c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.Storages
{
    public abstract class StorageStructure
    {
        protected string Country { get; set; }
        protected string City { get; set; }
        protected string Street { get; set; }
        protected int Number { get; set; }
        protected double CapacityWeight { get; set; }
        protected double CapacityVolume { get; set; }
        public double WeightStored { get; set; }
        public double VolumeStored { get; set; }
        public List<IContainable> Items { get; set; }
        public List<Container> Containers { get; private set; }

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
            Items = new List<IContainable>();
            Containers = new List<Container>();
        }

        public virtual void Load(List<IContainable> items)
        {
            if (LoadCheck(items) == true)
            {
                Items.AddRange(items);
            }
        }

        public void WeightUpdate()
        {
            foreach (var item in Items)
            {
                WeightStored += item.Weight;
            }
        }

        public bool LoadCheck(List<IContainable> items)
        {
            double totalWeight = items.Sum(item => item.Weight);
            double totalVolume = items.Sum(item => item.Volume);

            // Check if there is enough capacity to load the items
            if (WeightStored + totalWeight <= CapacityWeight && VolumeStored + totalVolume <= CapacityVolume)
            {
                WeightStored += totalWeight;
                VolumeStored += totalVolume;
                return true; // Items can be loaded
            }
            return false; // Not enough capacity to load items
        }
    }

}
