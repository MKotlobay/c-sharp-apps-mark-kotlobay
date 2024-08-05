using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public abstract class CargoVehicle
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
            ItemsFromCargo = itemsFromCargo;
            CargoWeightCheck(ItemsFromCargo);
            NextStorageStructure = null;
            CurrentDriveID = new Random().Next(1000, 10000);
            ExpectedToPayed = ToPayed(itemsFromCargo);
        }

        public void CargoWeightCheck(List<IPortable> itemsFromCargo)
        {
            double totalWeight = 0;
            foreach (var item in itemsFromCargo)
            {
                totalWeight += item.Weight;
            }
            IsOverWeight = totalWeight > MaxWeight;
            CanDrive = !IsOverWeight;
        }

        public double ToPayed(List<IPortable> itemsFromCargo)
        {
            double totalWeight = 0;
            double volume = 0;
            foreach (var item in itemsFromCargo)
            {
                totalWeight += item.Weight;
                volume += item.Volume;
            }
            int distance = 2000; // 2000 km
            return 1.2 * (distance * totalWeight * volume);
        }

        protected virtual bool CanLoad(IPortable item)
        {
            return item.Weight <= MaxWeight && item.Volume <= MaxVolume;
        }
    }
}
