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
        protected DriverType VehicleType { get; private set; }
        public string? Destination { get; private set; }
        public bool IsOnWay { get; private set; }

        public Driver(double cargoLength, double cargoWidth, double cargoHeight, double cargoCarryingWeight, string name, string sureName, string id, DriverType vehicleLicence)
        {
            this.name = name;
            this.sureName = sureName;
            this.id = id;
            VehicleType = vehicleLicence;
            this.Destination = null;
            this.IsOnWay = false;
        }

        public void Approve(string destination)
        {
            if (VehicleType == DriverType.CargoCar && !IsOnWay)
            {
                Destination = destination;
                IsOnWay = true;
                Console.WriteLine($"Driver {this.name} {this.sureName} approved, next destination is: {Destination}");
            }
            else
            {
                Console.WriteLine($"Driver {this.name} {this.sureName} cannot approve that destination. Current destination: {Destination}");
            }
        }

        public void OnWay()
        {
            if (this.IsOnWay)
                Console.WriteLine($"{this.name} {this.sureName} is on the way to {this.Destination}");
            else
                Console.WriteLine($"{this.name} {this.sureName} is free and waiting for a new destination");
        }

        public override string ToString()
        {
            return $"{this.name} {this.sureName} drives a {VehicleType.GetType().Name} with type {VehicleType.GetType().Name}";
        }
    }
}
