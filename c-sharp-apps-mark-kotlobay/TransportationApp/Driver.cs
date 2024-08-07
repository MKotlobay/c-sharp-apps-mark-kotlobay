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
        private string name;
        private string sureName;
        private string id;
        public DriverType VehicleType { get; private set; }
        public string? Destination { get; private set; }
        public bool IsOnWay { get; private set; }
        public string Located { get; set; }
        public CargoVehicle CargoVehicle {  get; }

        public Driver(string name, string sureName, string id, DriverType vehicleLicence, string locationNow)
        {
            this.name = name;
            this.sureName = sureName;
            this.id = id;
            VehicleType = vehicleLicence;
            Destination = null;
            IsOnWay = false;
            CargoVehicle = CreateVehicle(VehicleType);

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
        private CargoVehicle CreateVehicle(DriverType vehicleType)
        {
            switch (vehicleType)
            {
                case DriverType.CargoCar:
                    return new CargoCar(this, 1000, 500, new List<IPortable>(), "Parked Location", "Destination");

                case DriverType.FreightTrain:
                    return new FreightTrain(this, 10000, 5000, new List<IPortable>(), "Parked Location", "Destination");

                case DriverType.FreightPlane:
                    return new FreightPlane(this, 5000, 2500, new List<IPortable>(), "Parked Location", "Destination");

                case DriverType.CargoShip:
                    return new CargoShip(this, 20000, 10000, new List<IPortable>(), "Parked Location", "Destination");

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
                Console.WriteLine($"Driver {name} {sureName} approved. Next destination: {Destination}");

                // Start a timer to set IsOnWay to false after 1 minute + Updates location for destination
                await Task.Delay(TimeSpan.FromMinutes(1));
                IsOnWay = false;
                Located = destination;
                Console.WriteLine($"Driver {name} {sureName} has arrived at {destination}");
            }
            else
            {
                Console.WriteLine($"Driver {name} {sureName} cannot approve. Current destination: {Destination}");
            }
        }

        public bool OnWay()
        {
            if (IsOnWay)
            {
                Console.WriteLine($"{name} {sureName} is on the way to {Destination}");
                return true;
            }
            else
            {
                Console.WriteLine($"{name} {sureName} is free and waiting for a new destination");
                return false;
            }
        }

        public override string ToString()
        {
            return $"{name} {sureName} drives a {VehicleType} and located in {Located}";
        }
    }
}
