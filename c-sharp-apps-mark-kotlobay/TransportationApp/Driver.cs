using c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public enum DriverType
    {
        CargoCar,
        FreightTrain,
        FreightPlane,
        CargoShip
    }

    public class Driver
    {
        public string Name { get; }
        public string SureName { get; }
        protected string Id { get; }
        public DriverType VehicleType { get; private set; }
        public string? Destination { get; private set; }
        public bool IsOnWay { get; private set; }
        public string Located { get; set; }
        public CargoVehicle CargoVehicle { get; }

        public Driver(string name, string sureName, string id, DriverType vehicleLicence, string locationNow, List<IPortable> items)
        {
            Name = name;
            SureName = sureName;
            Id = id;
            VehicleType = vehicleLicence;
            Destination = null;
            IsOnWay = false;
            CargoVehicle = CreateVehicle(VehicleType, items);

            switch (locationNow)
            {
                case "Main Warehouse":
                    Located = locationNow;
                    break;
                case "Secondary Warehouse":
                    Located = locationNow;
                    break;
                case "Main Port":
                    Located = locationNow;
                    break;
                case "Secondary Port":
                    Located = locationNow;
                    break;
                case "Tertiary Port":
                    Located = locationNow;
                    break;
            }
        }
        private CargoVehicle CreateVehicle(DriverType vehicleType, List<IPortable> items)
        {
            switch (vehicleType)
            {
                case DriverType.CargoCar:
                    return new CargoCar(this, 1000, 500, items, "Parked Location", "Destination");

                case DriverType.FreightTrain:
                    return new FreightTrain(this, 10000, 5000, items, "Parked Location", "Destination");

                case DriverType.FreightPlane:
                    return new FreightPlane(this, 5000, 2500, items, "Parked Location", "Destination");

                case DriverType.CargoShip:
                    return new CargoShip(this, 20000, 10000, items, "Parked Location", "Destination");

                default:
                    throw new ArgumentException("Unknown vehicle type");
            }
        }
        public async void Approve(string destination)
        {
            if (!IsOnWay)
            {
                Destination = destination;
                IsOnWay = true;
                Console.WriteLine($"Driver {Name} {SureName} approved. Next destination: {Destination}");
            }
            else
            {
                Console.WriteLine($"Driver {Name} {SureName} cannot approve. Current destination: {Destination}");
            }
        }

        public bool OnWay()
        {
            if (Located != Destination)
            {
                Console.WriteLine($"{Name} {SureName} is on the way to {Destination}");
                return true;
            }
            else
            {
                Console.WriteLine($"{Name} {SureName} is free and waiting for a new destination");
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Name} {SureName} drives a {VehicleType} and located in {Located}";
        }
    }
}
