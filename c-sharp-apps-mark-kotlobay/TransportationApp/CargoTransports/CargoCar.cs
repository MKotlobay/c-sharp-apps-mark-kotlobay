using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports
{
    public class CargoCar : CargoVehicle
    {
        public CargoCar(Driver driver, double maxWeight, double maxVolume, List<IPortable> itemsFromCargo, string storageStructureParked, string storageStructureToGo)
            : base(driver, maxWeight, maxVolume, itemsFromCargo, storageStructureParked, storageStructureToGo)
        {
        }
    }
}
