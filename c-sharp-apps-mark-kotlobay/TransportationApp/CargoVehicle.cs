using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;
using c_sharp_apps_mark_kotlobay.TransportationApp.Storages;

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
            WeightInCargo();
        }

        public void WeightInCargo()
        {
            foreach (var item in Items)
            {
                CurrentItemsWeightInCargo += item.Weight;
                if (CurrentItemsWeightInCargo > MaxWeight)
                {
                    Console.WriteLine("Weight Issue !");
                }
            }
        }

        public void CargoWeightCheck()
        {
            double totalWeight = Items.Sum(c => c.Weight);
            IsOverWeight = totalWeight > MaxWeight;
            CanDrive = !IsOverWeight;
        }

        public double ToPayed()
        {
            double totalWeight = Items.Sum(c => c.Weight);
            double volume = Items.Sum(c => c.Volume);
            int distance = 2000; // 2000 km

            double cost = 0.0;

            switch (Driver.VehicleType)
            {
                case DriverType.CargoCar:
                    cost = distance * volume * totalWeight;
                    break;
                case DriverType.FreightTrain:
                    cost = 5 * distance * volume * totalWeight;
                    break;
                case DriverType.CargoShip:
                    cost = 20 * distance * volume * totalWeight;
                    break;
                case DriverType.FreightPlane:
                    cost = 50 * distance * volume * totalWeight;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unsupported vehicle type");
            }
            return cost;
        }

        protected virtual bool CanLoad(IPortable item)
        {
            double currentWeight = Items.Sum(c => c.Weight);
            double currentVolume = Items.Sum(c => c.Volume);

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
            if (Items.Remove(item))
            {
                CargoWeightCheck(); // Recalculate weight and volume after unloading
                return true;
            }
            return false;
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
