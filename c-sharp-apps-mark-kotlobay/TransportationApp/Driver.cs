using c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports;

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

        public Driver(string name, string sureName, string id, DriverType vehicleLicence)
        {
            this.name = name;
            this.sureName = sureName;
            this.id = id;
            VehicleType = vehicleLicence;
            Destination = null;
            IsOnWay = false;
        }

        public void Approve(string destination)
        {
            if (!IsOnWay)
            {
                Destination = destination;
                IsOnWay = true;
                Console.WriteLine($"Driver {name} {sureName} approved. Next destination: {Destination}");
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
            return $"{name} {sureName} drives a {VehicleType}";
        }
    }
}
