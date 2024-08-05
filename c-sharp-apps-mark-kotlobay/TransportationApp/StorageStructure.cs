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
    }
}
