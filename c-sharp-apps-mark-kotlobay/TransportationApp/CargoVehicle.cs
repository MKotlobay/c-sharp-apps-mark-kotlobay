using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations;
using c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;
using c_sharp_apps_mark_kotlobay.TransportationApp.Storages;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public abstract class CargoVehicle : IPortable
    {
        protected Driver Driver { get; set; }
        protected double MaxWeight { get; set; }
        protected double MaxVolume { get; set; }
        protected bool CanDrive { get; set; }
        protected bool IsOverWeight { get; set; }
        protected string? NextStorageStructure { get; set; }
        public List<IContainable> Items { get; set; }

        public List<Container> Containers = new List<Container>();
        protected double ExpectedToPayed { get; set; }
        protected string StorageStructureParked { get; set; }
        protected string StorageStructureToGo { get; set; }
        public int CurrentDriveID { get; private set; }
        public double CurrentItemsWeightInCargo { get; set; }

        protected CargoVehicle(Driver driver, double maxWeight, double maxVolume, List<IContainable> items, string storageStructureParked, string storageStructureToGo)
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

        public double WeightInCargoContainers()
        {
            foreach (var container in Containers)
            {
                foreach (var item in container.Items)
                {
                    CurrentItemsWeightInCargo += item.Weight;
                }
            }
            return CurrentItemsWeightInCargo;
        }

        public double VolumeInCargoContainers()
        {
            double tempVolume = 0;
            foreach (var container in Containers)
            {
                foreach (var item in container.Items)
                {
                    tempVolume += item.Volume;
                }
            }
            return tempVolume;
        }

        public void CargoWeightCheck()
        {
            double totalWeight = Items.Sum(c => c.Weight);
            IsOverWeight = totalWeight > MaxWeight;
            CanDrive = !IsOverWeight;
        }

        public double ToPayed()
        {
            int distance = 2000; // 2000 km
            double cost = 0.0;

            switch (Driver.VehicleType)
            {
                case DriverType.CargoCar:
                    cost = distance * VolumeInCargoContainers() * CurrentItemsWeightInCargo;
                    break;
                case DriverType.FreightTrain:
                    cost = 5 * distance * VolumeInCargoContainers() * CurrentItemsWeightInCargo;
                    break;
                case DriverType.CargoShip:
                    cost = 20 * distance * VolumeInCargoContainers() * CurrentItemsWeightInCargo;
                    break;
                case DriverType.FreightPlane:
                    cost = 50 * distance * VolumeInCargoContainers() * CurrentItemsWeightInCargo;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unsupported vehicle type");
            }
            return cost;
        }

        protected virtual bool CanLoad(IContainable item)
        {
            double currentWeight = Items.Sum(c => c.Weight);
            double currentVolume = Items.Sum(c => c.Volume);

            return (currentWeight + item.Weight <= MaxWeight) && (currentVolume + item.Volume <= MaxVolume);
        }

        public bool Load(IContainable item)
        {
            if (CanLoad(item))
            {
                Items.Add(item);
                CargoWeightCheck();
                return true;
            }
            return false;
        }

        public bool Load(List<IContainable> items)
        {
            bool allLoaded = true;
            foreach (var item in items)
            {
                if (!Load(item))
                {
                    allLoaded = false;
                }
            }
            return allLoaded;
        }

        public bool Unload(IContainable item)
        {
            if (Items.Remove(item))
            {
                CargoWeightCheck();
                return true;
            }
            return false;
        }

        public bool Unload(List<IContainable> items)
        {
            bool allRemoved = true;
            foreach (var item in items)
            {
                if (!Unload(item))
                {
                    allRemoved = false;
                }
            }
            return allRemoved;
        }

        public bool Load(Container container)
        {
            if (CanLoad(container))
            {
                Containers.Add(container);
                CargoWeightCheck();
                return true;
            }
            return false;
        }

        public bool Load(List<Container> containers)
        {
            bool allLoaded = true;
            foreach (var container in containers)
            {
                if (!Load(container))
                {
                    allLoaded = false;
                }
            }
            return allLoaded;
        }

        public bool Unload(Container container)
        {
            if (Containers.Remove(container))
            {
                CargoWeightCheck();
                return true;
            }
            return false;
        }

        public bool Unload(List<Container> containers)
        {
            bool allRemoved = true;
            foreach (var container in containers)
            {
                if (!Unload(container))
                {
                    allRemoved = false;
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
