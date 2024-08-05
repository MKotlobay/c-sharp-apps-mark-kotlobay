﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class Port : StorageStructure
    {
        public string Name { get; set; }
        protected int NumWarehouse { get; set; }
        protected double MaxCapacityWeight { get; set; }
        protected double MaxCapacityVolume { get; set; }
        protected List<IPortable> InStorage { get; set; }

        public Port(string country, string city, string street, int number, double maxCapacityWeight, double maxCapacityVolume, string name, int numWarehouse)
            : base(country, city, street, number, maxCapacityWeight, maxCapacityVolume)
        {
            Name = name;
            NumWarehouse = numWarehouse;
            MaxCapacityWeight = maxCapacityWeight;
            MaxCapacityVolume = maxCapacityVolume;
            InStorage = new List<IPortable>();
        }

        public void LoadItems(List<IPortable> itemsFromCargo)
        {
            foreach (var item in itemsFromCargo.ToList())
            {
                if (WeightStored + item.Weight < MaxCapacityWeight && VolumeStored + item.Volume < MaxCapacityVolume)
                {
                    WeightStored += item.Weight;
                    VolumeStored += item.Volume;
                    InStorage.Add(item);
                    itemsFromCargo.Remove(item);
                }
                else
                    Console.WriteLine($"Cannot store more items. Current weight: {WeightStored}, volume: {VolumeStored}, max weight: {MaxCapacityWeight}, max volume: {MaxCapacityVolume}");
            }
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
