using c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations;
using c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;
using c_sharp_apps_mark_kotlobay.TransportationApp.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class MonitorTransportation
    {
        private List<Driver> Drivers;
        private List<Warehouse> Warehouses;
        private List<Port> Ports;
        private List<Crane> Cranes;
        private List<IContainable> Items;

        public void RunCargoTask()
        {
            BuildCargoApp();
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Choose num for action:");
                Console.WriteLine("1 – Choose destination for driver | 2 – All drivers in ports load it!");
                Console.WriteLine("3 – All drivers in warehouses load it! | 4 - All ports load to drivers ! | 5 - All warehouses load to drivers !");
                Console.WriteLine("6 - Full details of drivers | 7 - Shows all Containing in ports, warehouses, cargos - Great use for checking");
                Console.WriteLine("8 - Return to suppliers and remove from ports and warehouses - Use for clean start | 9 – Full details of all | 0 - Exit");
                Console.WriteLine("");
                if (!int.TryParse(Console.ReadLine(), out int num) || num < 0 || num > 9)
                {
                    Console.WriteLine("----------");
                    Console.WriteLine("Invalid input, please choose a valid action.");
                    continue;
                }

                if (num == 0)
                {
                    Console.WriteLine("----------");
                    Console.WriteLine("Exiting...");
                    break;
                }

                switch (num)
                {
                    case 1:
                        ChooseDestinationForDriver();
                        break;

                    case 2:
                        LoadItemsInPorts();
                        break;

                    case 3:
                        LoadItemsInWarehouses();
                        break;

                    case 4:
                        UnloadAllItemsFromPorts();
                        break;

                    case 5:
                        UnloadAllItemsFromWarehouses();
                        break;

                    case 6:
                        FullDetailsAllDrivers();
                        break;

                    case 7:
                        ShowAllContainersAndItems();
                        break;

                    case 8:
                        ReturnAllItemsToSuppliers();
                        break;

                    case 9:
                        ShowAllDetails();
                        break;
                }
            }
        }

        private void BuildCargoApp()
        {
            Items = new List<IContainable>();

            Drivers = new List<Driver>
            {
                new Driver("John", "Doe", "123", DriverType.CargoCar, "Main Warehouse", new List<IContainable>(GenerateRandomItemsForCars(Items))),
                new Driver("Jane", "Smith", "456", DriverType.FreightTrain, "Secondary Warehouse", new List<IContainable>(GenerateRandomItems(new List<IContainable>()))),
                new Driver("Jim", "Beam", "789", DriverType.FreightPlane, "Main Port", new List<IContainable>(GenerateRandomItems(new List<IContainable>()))),
                new Driver("Jack", "Daniels", "101", DriverType.CargoShip, "Secondary Port", new List<IContainable>(GenerateRandomItems(new List<IContainable>()))),
                new Driver("Johnny", "Walker", "102", DriverType.CargoCar, "Tertiary Port", new List<IContainable>()),
                new Driver("James", "Bond", "103", DriverType.FreightTrain, "Main Warehouse", new List<IContainable>(GenerateRandomItems(new List<IContainable>()))),
                new Driver("Tony", "Stark", "104", DriverType.FreightPlane, "Secondary Warehouse", new List<IContainable>()),
                new Driver("Steve", "Rogers", "105", DriverType.CargoShip, "Main Port", new List<IContainable>(GenerateRandomItems(new List<IContainable>()))),
                new Driver("Bruce", "Wayne", "106", DriverType.CargoCar, "Secondary Port", new List<IContainable>()),
                new Driver("Clark", "Kent", "107", DriverType.FreightTrain, "Tertiary Port", new List<IContainable>(GenerateRandomItems(new List<IContainable>())))
            };

            Warehouses = new List<Warehouse>
            {
                new Warehouse("USA", "New York", "5th Avenue", 1, 100000, 50000, "Main Warehouse", 101),
                new Warehouse("USA", "Chicago", "Michigan Avenue", 2, 150000, 60000, "Secondary Warehouse", 102)
            };

            Ports = new List<Port>
            {
                new Port("USA", "Los Angeles", "Port Street", 1, 200000, 100000, "Main Port", 201),
                new Port("USA", "San Francisco", "Bay Street", 2, 180000, 90000, "Secondary Port", 202),
                new Port("USA", "Houston", "Harbor Street", 3, 220000, 110000, "Tertiary Port", 203)
            };
        }

        private void ChooseDestinationForDriver()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Choose a free driver (1 to 10):");
            if (int.TryParse(Console.ReadLine(), out int driverNum) && driverNum > 0 && driverNum <= Drivers.Count)
            {
                Driver selectedDriver = Drivers[driverNum - 1];

                if (selectedDriver.IsOnWay == false)
                {
                    Console.WriteLine("----------");
                    Console.WriteLine("Choose a destination (1 - Port, 2 - Warehouse):");
                    if (int.TryParse(Console.ReadLine(), out int destinationType) && (destinationType == 1 || destinationType == 2))
                    {
                        if (destinationType == 1)
                        {
                            ChoosePort(selectedDriver);
                        }
                        else if (destinationType == 2)
                        {
                            ChooseWarehouse(selectedDriver);
                        }
                    }
                    else
                    {
                        Console.WriteLine("----------");
                        Console.WriteLine("Invalid destination type.");
                    }
                }
                else
                {
                    Console.WriteLine("----------");
                    Console.WriteLine("Driver is already on the way.");
                }
            }
            else
            {
                Console.WriteLine("----------");
                Console.WriteLine("Invalid driver number.");
            }
        }

        private void ChoosePort(Driver selectedDriver)
        {
            Console.WriteLine("----------");
            Console.WriteLine("Choose a port (1 to 3):");
            if (int.TryParse(Console.ReadLine(), out int portNum) && portNum > 0 && portNum <= Ports.Count)
            {
                Port selectedPort = Ports[portNum - 1];
                selectedDriver.Approve(selectedPort.Name);
                selectedDriver.OnWay();
                Console.WriteLine("----------");
                Console.WriteLine($"Driver {selectedDriver.ToString()} is now on the way to {selectedPort.Name}");
                selectedDriver.Located = selectedPort.Name;
            }
            else
            {
                Console.WriteLine("----------");
                Console.WriteLine("Invalid port number.");
            }
        }

        private void ChooseWarehouse(Driver selectedDriver)
        {
            Console.WriteLine("----------");
            Console.WriteLine("Choose a warehouse (1 to 2):");
            if (int.TryParse(Console.ReadLine(), out int warehouseNum) && warehouseNum > 0 && warehouseNum <= Warehouses.Count)
            {
                Warehouse selectedWarehouse = Warehouses[warehouseNum - 1];
                selectedDriver.Approve(selectedWarehouse.Name);
                selectedDriver.OnWay();
                Console.WriteLine("----------");
                Console.WriteLine($"Driver {selectedDriver.ToString()} is now on the way to {selectedWarehouse.Name}");
                selectedDriver.Located = selectedWarehouse.Name;
            }
            else
            {
                Console.WriteLine("----------");
                Console.WriteLine("Invalid warehouse number.");
            }
        }

        private void LoadItemsInPorts()
        {
            bool atLeastOnePortLoaded = false;

            foreach (var port in Ports)
            {
                foreach (var driver in Drivers)
                {
                    if (driver.Located == port.Name)
                    {
                        switch (driver.CargoVehicle)
                        {
                            case CargoShip cargoShip:
                                if (port.Crane.Load(cargoShip.Containers))
                                {
                                    port.UnpackItemsFromContainers(cargoShip.Containers);
                                    atLeastOnePortLoaded = true;
                                }
                                cargoShip.Containers.Clear();
                                cargoShip.CurrentItemsWeightInCargo = 0;
                                break;
                            case FreightTrain freightTrain:
                                if (port.Crane.Load(freightTrain.Containers))
                                {
                                    port.UnpackItemsFromContainers(freightTrain.Containers);
                                    atLeastOnePortLoaded = true;
                                }
                                freightTrain.Containers.Clear();
                                freightTrain.CurrentItemsWeightInCargo = 0;
                                break;
                            case FreightPlane freightPlane:
                                port.Load(freightPlane.Items);
                                atLeastOnePortLoaded = true;
                                freightPlane.Items.Clear();
                                freightPlane.CurrentItemsWeightInCargo = 0;
                                break;
                            case CargoCar cargoCar:
                                port.Load(cargoCar.Items);
                                atLeastOnePortLoaded = true;
                                cargoCar.Items.Clear();
                                cargoCar.CurrentItemsWeightInCargo = 0;
                                break;
                        }
                    }
                }
            }

            if (!atLeastOnePortLoaded)
            {
                Console.WriteLine("----------");
                Console.WriteLine("No available port could load the items.");
            }
            else
            {
                Console.WriteLine("----------");
                Console.WriteLine("Available ports has been loaded the items.");
            }
        }

        private void LoadItemsInWarehouses()
        {
            bool atLeastOneWarehouseLoaded = false;

            foreach (var warehouse in Warehouses)
            {
                foreach (var driver in Drivers)
                {
                    if (driver.Located == warehouse.Name)
                    {
                        switch (driver.CargoVehicle)
                        {
                            case CargoShip cargoShip:
                                if (warehouse.Crane.Load(cargoShip.Containers))
                                {
                                    warehouse.UnpackItemsFromContainers(cargoShip.Containers);
                                    atLeastOneWarehouseLoaded = true;
                                }
                                cargoShip.Containers.Clear();
                                cargoShip.CurrentItemsWeightInCargo = 0;
                                break;
                            case FreightTrain freightTrain:
                                if (warehouse.Crane.Load(freightTrain.Containers))
                                {
                                    warehouse.UnpackItemsFromContainers(freightTrain.Containers);
                                    atLeastOneWarehouseLoaded = true;
                                }
                                freightTrain.Containers.Clear();
                                freightTrain.CurrentItemsWeightInCargo = 0;
                                break;
                            case FreightPlane freightPlane:
                                warehouse.Load(freightPlane.Items);
                                atLeastOneWarehouseLoaded = true;
                                freightPlane.Items.Clear();
                                freightPlane.CurrentItemsWeightInCargo = 0;
                                break;
                            case CargoCar cargoCar:
                                warehouse.Load(cargoCar.Items);
                                atLeastOneWarehouseLoaded = true;
                                cargoCar.Items.Clear();
                                cargoCar.CurrentItemsWeightInCargo = 0;
                                break;
                        }
                    }
                }
            }

            if (!atLeastOneWarehouseLoaded)
            {
                Console.WriteLine("----------");
                Console.WriteLine("No available warehouse could load the items.");
            }
            else
            {
                Console.WriteLine("----------");
                Console.WriteLine("Available warehouse has been loaded the items.");
            }
        }

        private void UnloadAllItemsFromPorts()
        {
            bool atLeastOnePortUnloaded = false;

            foreach (var driver in Drivers)
            {
                foreach (var port in Ports)
                {
                    if (driver.Located == port.Name)
                    {
                        switch (driver.CargoVehicle)
                        {
                            case CargoShip cargoShip:
                                port.PackItemsToContainers(port.Items);
                                if (port.Crane.Unload(port.Containers))
                                {
                                    if (cargoShip.Load(port.Containers))
                                    {
                                        cargoShip.Containers = port.Containers;
                                        port.Containers = new List<Container>();
                                        atLeastOnePortUnloaded = true;
                                        Console.WriteLine("CargoShip loaded successfully.");
                                    }
                                }
                                break;

                            case FreightTrain freightTrain:
                                port.PackItemsToContainers(port.Items);
                                if (port.Crane.Unload(port.Containers))
                                {
                                    if (freightTrain.Load(port.Containers))
                                    {
                                        freightTrain.Containers = port.Containers;
                                        port.Containers = new List<Container>();
                                        atLeastOnePortUnloaded = true;
                                    }
                                }
                                break;

                            case CargoCar cargoCar:
                                foreach (var item in port.Items.ToList())
                                {
                                    cargoCar.LoadItemToStorage(item);
                                    port.WeightStored -= item.Weight;
                                    port.VolumeStored -= item.Volume;
                                    port.Items.Remove(item);
                                    atLeastOnePortUnloaded = true;
                                }
                                break;

                            case FreightPlane freightPlane:
                                foreach (var item in port.Items.ToList())
                                {
                                    freightPlane.LoadItemToStorage(item);
                                    port.WeightStored -= item.Weight;
                                    port.VolumeStored -= item.Volume;
                                    port.Items.Remove(item);
                                    atLeastOnePortUnloaded = true;
                                }
                                break;
                        }
                    }
                }
            }

            foreach (var port in Ports) { port.WeightStored = 0; port.VolumeStored = 0; }

            if (!atLeastOnePortUnloaded)
            {
                Console.WriteLine("----------");
                Console.WriteLine("No available port could unload the items.");
            }
            else
            {
                Console.WriteLine("----------");
                Console.WriteLine("Available ports has been unloaded the items.");
            }
        }

        private void UnloadAllItemsFromWarehouses()
        {
            bool atLeastOneWarehouseUnloaded = false;

            foreach (var driver in Drivers)
            {
                foreach (var warehouse in Warehouses)
                {
                    if (driver.Located == warehouse.Name)
                    {
                        switch (driver.CargoVehicle)
                        {
                            case CargoShip cargoShip:
                                warehouse.PackItemsToContainers(warehouse.Items);
                                if (warehouse.Crane.Unload(warehouse.Containers))
                                {
                                    if (cargoShip.Load(warehouse.Containers))
                                    {
                                        cargoShip.Containers = warehouse.Containers;
                                        warehouse.Containers = new List<Container>();
                                        atLeastOneWarehouseUnloaded = true;
                                    }
                                }
                                break;

                            case FreightTrain freightTrain:
                                warehouse.PackItemsToContainers(warehouse.Items);
                                if (warehouse.Crane.Unload(warehouse.Containers))
                                {
                                    if (freightTrain.Load(warehouse.Containers))
                                    {
                                        freightTrain.Containers = warehouse.Containers;
                                        warehouse.Containers = new List<Container>();
                                        atLeastOneWarehouseUnloaded = true;
                                    }
                                }
                                break;

                            case CargoCar cargoCar:
                                foreach (var item in warehouse.Items.ToList())
                                {
                                    cargoCar.LoadItemToStorage(item);
                                    warehouse.WeightStored -= item.Weight;
                                    warehouse.VolumeStored -= item.Volume;
                                    warehouse.Items.Remove(item);
                                    atLeastOneWarehouseUnloaded = true;
                                }
                                break;

                            case FreightPlane freightPlane:
                                foreach (var item in warehouse.Items.ToList())
                                {
                                    freightPlane.LoadItemToStorage(item);
                                    warehouse.WeightStored -= item.Weight;
                                    warehouse.VolumeStored -= item.Volume;
                                    warehouse.Items.Remove(item);
                                    atLeastOneWarehouseUnloaded = true;
                                }
                                break;
                        }
                    }
                }
            }

            foreach (var warehouse in Warehouses) { warehouse.WeightStored = 0; warehouse.VolumeStored = 0; }

            if (!atLeastOneWarehouseUnloaded)
            {
                Console.WriteLine("----------");
                Console.WriteLine("No available warehouse could unload the items.");
            }
            else
            {
                Console.WriteLine("----------");
                Console.WriteLine("Available warehouses has been unloaded the items.");
            }
        }

        private void ReturnAllItemsToSuppliers()
        {
            foreach (var driver in Drivers)
            {
                driver.CargoVehicle.Items.Clear();
                driver.CargoVehicle.Containers.Clear();
                driver.CargoVehicle.CurrentItemsWeightInCargo = 0;
            }
            foreach (var port in Ports)
            {
                port.Items.Clear();
                port.Containers.Clear();
                port.WeightStored = 0;
            }
            foreach (var warehouse in Warehouses)
            {
                warehouse.Items.Clear();
                warehouse.Containers.Clear();
                warehouse.WeightStored = 0;
            }
            Console.WriteLine("----------");
            Console.WriteLine("All items returned to suppliers");
        }

        private void ShowAllDetails()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Details of all drivers:");
            foreach (var driver in Drivers)
            {
                Console.WriteLine("");
                Console.WriteLine(driver.CargoVehicle.ToString());
                Console.WriteLine($"with current weight in cargo of {driver.CargoVehicle.CurrentItemsWeightInCargo}");
            }

            Console.WriteLine("----------");
            Console.WriteLine("Details of all warehouses:");
            foreach (var warehouse in Warehouses)
            {
                Console.WriteLine("");
                Console.WriteLine(warehouse.ToString());
            }

            Console.WriteLine("----------");
            Console.WriteLine("Details of all ports:");
            foreach (var port in Ports)
            {
                Console.WriteLine("");
                Console.WriteLine(port.ToString());
            }
        }

        private void ShowAllContainersAndItems()
        {
            foreach (var port in Ports)
            {
                Console.WriteLine($"Port: {port.Name}");
                Console.WriteLine("Items in this port:");

                foreach (var item in port.Items)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine();
            }
            foreach (var warehouse in Warehouses)
            {
                Console.WriteLine($"Port: {warehouse.Name}");
                Console.WriteLine("Items in this warehouse:");

                foreach (var item in warehouse.Items)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine();
            }

            foreach (var driver in Drivers)
            {
                Console.WriteLine($"Driver: {driver.Name}");
                Console.WriteLine($"Cargo Vehicle: {driver.CargoVehicle.GetType().Name}");
                Console.WriteLine("Items in this cargo vehicle:");

                foreach (var container in driver.CargoVehicle.Containers)
                {
                    Console.WriteLine($"  Container: {container}, Total Weight: {container.Weight}");

                    foreach (var item in container.Items)
                    {
                        Console.WriteLine($"    Item: {item.ToString()}");
                    }
                }

                Console.WriteLine();
            }
        }

        public void FullDetailsAllDrivers()
        {
            foreach (var driver in Drivers)
            {
                Console.WriteLine("Driver Details:");
                Console.WriteLine($"Name: {driver.Name} {driver.SureName}");
                Console.WriteLine($"ID: {driver.Id}");
                Console.WriteLine($"Vehicle Type: {driver.VehicleType}");
                Console.WriteLine($"Current Location: {driver.Located}");
                Console.WriteLine($"Destination: {driver.Destination ?? "Not Set"}");
                Console.WriteLine($"On the Way: {(driver.IsOnWay ? "Yes" : "No")}");

                var vehicle = driver.CargoVehicle;
                Console.WriteLine("Cargo Vehicle Details:");
                Console.WriteLine($"Vehicle Type: {vehicle.GetType().Name}");
                Console.WriteLine($"Current Weight in Cargo: {vehicle.CurrentItemsWeightInCargo} kg");

                // Calculate and display the expected payment for the cargo
                Console.WriteLine($"Expected Payment: {Math.Round(vehicle.ToPayed()):N0}$");

                // Include details specific to the vehicle type if needed
                switch (vehicle)
                {
                    case CargoShip cargoShip:
                        Console.WriteLine($"Number of Containers: {cargoShip.Containers.Count}");
                        break;
                    case CargoCar cargoCar:
                        Console.WriteLine($"Number of Items: {cargoCar.Items.Count}");
                        break;
                    case FreightPlane freightPlane:
                        Console.WriteLine($"Number of Items: {freightPlane.Items.Count}");
                        break;
                    case FreightTrain freightTrain:
                        Console.WriteLine($"Number of Containers: {freightTrain.Containers.Count}");
                        break;
                }

                Console.WriteLine(new string('-', 30));
            }
        }

        private List<IContainable> GenerateRandomItems(List<IContainable> existingItems)
        {
            Random rand = new Random();

            // Generate 20 GeneralItems
            for (int i = 0; i < 20; i++)
            {
                double length = rand.NextDouble() * 10;
                double width = rand.NextDouble() * 10;
                double height = rand.NextDouble() * 10;
                double weight = rand.NextDouble() * 100;
                double price = rand.NextDouble() * 1000;

                existingItems.Add(new GeneralItem(length, width, height, weight, price));
            }

            // Generate 20 ElectricItems
            for (int i = 0; i < 20; i++)
            {
                double length = rand.NextDouble() * 10;
                double width = rand.NextDouble() * 10;
                double height = rand.NextDouble() * 10;
                double weight = rand.NextDouble() * 100;
                double price = rand.NextDouble() * 1000;
                double powerConsumption = rand.NextDouble() * 500;

                existingItems.Add(new ElectricItem(length, width, height, weight, price, powerConsumption));
            }

            // Generate 20 FurnitureItems
            for (int i = 0; i < 20; i++)
            {
                double length = rand.NextDouble() * 10;
                double width = rand.NextDouble() * 10;
                double height = rand.NextDouble() * 10;
                double weight = rand.NextDouble() * 100;
                double price = rand.NextDouble() * 1000;
                string material = "Material" + rand.Next(1, 100); // Random material name

                existingItems.Add(new FurnitureItem(length, width, height, weight, price, material));
            }

            return existingItems;
        }

        private List<IContainable> GenerateRandomItemsForCars(List<IContainable> existingItems)
        {
            Random rand = new Random();

            // Generate 50 GeneralItems
            for (int i = 0; i < 5; i++)
            {
                double length = rand.NextDouble() * 10;
                double width = rand.NextDouble() * 10;
                double height = rand.NextDouble() * 10;
                double weight = rand.NextDouble() * 100;
                double price = rand.NextDouble() * 1000;

                existingItems.Add(new GeneralItem(length, width, height, weight, price));
            }

            // Generate 5 ElectricItems
            for (int i = 0; i < 5; i++)
            {
                double length = rand.NextDouble() * 10;
                double width = rand.NextDouble() * 10;
                double height = rand.NextDouble() * 10;
                double weight = rand.NextDouble() * 100;
                double price = rand.NextDouble() * 1000;
                double powerConsumption = rand.NextDouble() * 500;

                existingItems.Add(new ElectricItem(length, width, height, weight, price, powerConsumption));
            }

            // Generate 5 FurnitureItems
            for (int i = 0; i < 5; i++)
            {
                double length = rand.NextDouble() * 10;
                double width = rand.NextDouble() * 10;
                double height = rand.NextDouble() * 10;
                double weight = rand.NextDouble() * 100;
                double price = rand.NextDouble() * 1000;
                string material = "Material" + rand.Next(1, 100); // Random material name

                existingItems.Add(new FurnitureItem(length, width, height, weight, price, material));
            }

            return existingItems;
        }
    }
}
