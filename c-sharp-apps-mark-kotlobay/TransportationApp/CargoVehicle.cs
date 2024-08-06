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
        protected List<IPortable> ItemsFromCargo { get; set; }
        protected double ExpectedToPayed { get; set; }
        protected string StorageStructureParked { get; set; }
        protected string StorageStructureToGo { get; set; }
        protected int CurrentDriveID { get; private set; }

        protected CargoVehicle(Driver driver, double maxWeight, double maxVolume, List<IPortable> itemsFromCargo, string storageStructureParked, string storageStructureToGo)
        {
            Driver = driver;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
            StorageStructureParked = storageStructureParked;
            StorageStructureToGo = storageStructureToGo;
            ItemsFromCargo = itemsFromCargo ?? new List<IPortable>();
            CargoWeightCheck();
            NextStorageStructure = null;
            CurrentDriveID = new Random().Next(1000, 10000);
            ExpectedToPayed = ToPayed();
        }

        public void CargoWeightCheck()
        {
            double totalWeight = 0;
            foreach (var item in ItemsFromCargo)
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
            foreach (var item in ItemsFromCargo)
            {
                totalWeight += item.Weight;
                volume += item.Volume;
            }
            int distance = 2000; // 2000 km
            return 1.2 * (distance * totalWeight * volume);
        }

        protected virtual bool CanLoad(IPortable item)
        {
            double currentWeight = ItemsFromCargo.Sum(i => i.Weight);
            double currentVolume = ItemsFromCargo.Sum(i => i.Volume);

            return (currentWeight + item.Weight <= MaxWeight) && (currentVolume + item.Volume <= MaxVolume);
        }

        public bool Load(IPortable item)
        {
            if (CanLoad(item))
            {
                ItemsFromCargo.Add(item);
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
            bool removed = ItemsFromCargo.Remove(item);
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
            return ItemsFromCargo.Count > 0 && !IsOverWeight;
        }
    }
}
