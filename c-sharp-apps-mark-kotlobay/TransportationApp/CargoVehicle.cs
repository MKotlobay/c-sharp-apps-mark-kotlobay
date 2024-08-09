using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public abstract class CargoVehicle : IContainable
    {
        protected Driver Driver { get; set; }
        protected double MaxWeight { get; set; }
        protected double MaxVolume { get; set; }
        protected bool CanDrive { get; set; }
        protected bool IsOverWeight { get; set; }
        protected string? NextStorageStructure { get; set; }
        public List<IPortable> Items { get; set; }
        protected double ExpectedToPayed { get; set; }
        protected string StorageStructureParked { get; set; }
        protected string StorageStructureToGo { get; set; }
        protected int CurrentDriveID { get; private set; }
        public double CurrentItemsWeightInCargo { get; set; }

        protected CargoVehicle(Driver driver, double maxWeight, double maxVolume, List<IPortable> items, string storageStructureParked, string storageStructureToGo)
        {
            Driver = driver;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
            StorageStructureParked = storageStructureParked; // Located now
            StorageStructureToGo = storageStructureToGo; // Next location to drive
            Items = items;
            CargoWeightCheck();
            NextStorageStructure = null;
            CurrentDriveID = new Random().Next(1000, 10000);
            ExpectedToPayed = ToPayed();
            CalculateWeightCargo(items);
        }
        public void UnloadItems(StorageStructure destination)
        {
            if (destination.Load(Items))
            {
                Items.Clear();
                CargoWeightCheck(); // Ensure weight check after unloading
                Console.WriteLine($"Items successfully unloaded at {destination}.");
            }
            else
            {
                Console.WriteLine($"Failed to unload items at {destination}.");
            }
        }
        public void CalculateWeightCargo(List<IPortable> items)
        {
            foreach (var item in items)
            {
                CurrentItemsWeightInCargo += item.Weight;
            }
        }

        public void ClearWeightCargo()
        {
            CurrentItemsWeightInCargo = 0;
        }

        public void CargoWeightCheck()
        {
            double totalWeight = 0;
            foreach (var item in Items)
            {
                totalWeight += item.Weight;
            }
            IsOverWeight = totalWeight > MaxWeight;
            CanDrive = !IsOverWeight;
        }

        public double ToPayed()
        {
            double totalWeight = 0;
            double volume = 0;
            foreach (var item in Items)
            {
                totalWeight += item.Weight;
                volume += item.Volume;
            }
            int distance = 2000; // 2000 km
            return 1.2 * (distance * totalWeight * volume);
        }

        protected virtual bool CanLoad(IPortable item)
        {
            double currentWeight = Items.Sum(i => i.Weight);
            double currentVolume = Items.Sum(i => i.Volume);

            return (currentWeight + item.Weight <= MaxWeight) && (currentVolume + item.Volume <= MaxVolume);
        }

        public bool Load(IPortable item)
        {
            if (CanLoad(item))
            {
                Items.Add(item);
                CargoWeightCheck(); // Recalculate weight and volume after loading
                return true;
            }
            return false;
        }

        public bool Load(List<IPortable> items)
        {
            bool allLoaded = true;
            foreach (var item in items)
            {
                if (!Load(item))
                {
                    allLoaded = false; // If any item cannot be loaded, return false
                }
            }
            return allLoaded;
        }

        public bool Unload(IPortable item)
        {
            bool removed = Items.Remove(item);
            if (removed)
            {
                CargoWeightCheck(); // Recalculate weight and volume after unloading
            }
            return removed;
        }

        public bool Unload(List<IPortable> items)
        {
            bool allRemoved = true;
            foreach (var item in items)
            {
                if (!Unload(item))
                {
                    allRemoved = false; // If any item cannot be unloaded, return false
                }
            }
            return allRemoved;
        }

        public bool IsReadyToTravel()
        {
            return Items.Count > 0 && !IsOverWeight;
        }

        public override string ToString()
        {
            return $"{Driver} is in charge of {Driver.VehicleType} with {CurrentDriveID} ID";
        }
    }
}
