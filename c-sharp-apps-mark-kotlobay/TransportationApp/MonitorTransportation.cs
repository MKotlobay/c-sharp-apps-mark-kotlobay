using c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;
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
        private List<IPortable> Items;

        public void RunCargoTask()
        {
            BuildCargoApp();
            while (true)
            {
                Console.WriteLine("Choose num for action: 1 – Choose destination for driver | 2 – All drivers in ports load it! | 3 – All drivers in warehouses load it! | 4 - All ports load to drivers ! | 5 - All warehouses load to drivers ! | 9 – Full details of all | 0 - Exit");
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

                    case 9:
                        ShowAllDetails();
                        break;
                }
            }
        }

        private void BuildCargoApp()
        {
            Items = new List<IPortable>();

            Drivers = new List<Driver>
            {
                new Driver("John", "Doe", "123", DriverType.CargoCar, "Main Warehouse", new List<IPortable>()),
                new Driver("Jane", "Smith", "456", DriverType.FreightTrain, "Secondary Warehouse", new List<IPortable>()),
                new Driver("Jim", "Beam", "789", DriverType.FreightPlane, "Main Port", new List<IPortable>(GenerateRandomItems(new List<IPortable>()))),
                new Driver("Jack", "Daniels", "101", DriverType.CargoShip, "Secondary Port", new List<IPortable>(GenerateRandomItems(new List<IPortable>()))),
                new Driver("Johnny", "Walker", "102", DriverType.CargoCar, "Tertiary Port", new List<IPortable>()),
                new Driver("James", "Bond", "103", DriverType.FreightTrain, "Main Warehouse", new List<IPortable>()),
                new Driver("Tony", "Stark", "104", DriverType.FreightPlane, "Secondary Warehouse", new List<IPortable>(GenerateRandomItems(new List<IPortable>()))),
                new Driver("Steve", "Rogers", "105", DriverType.CargoShip, "Main Port", new List<IPortable>(GenerateRandomItems(new List<IPortable>()))),
                new Driver("Bruce", "Wayne", "106", DriverType.CargoCar, "Secondary Port", new List<IPortable>()),
                new Driver("Clark", "Kent", "107", DriverType.FreightTrain, "Tertiary Port", new List<IPortable>())
            };

            Warehouses = new List<Warehouse>
            {
                new Warehouse("USA", "New York", "5th Avenue", 1, 100000, 50000, new List<IPortable>(GenerateRandomItems(new List<IPortable>())), "Main Warehouse", 101),
                new Warehouse("USA", "Chicago", "Michigan Avenue", 2, 150000, 60000,new List<IPortable>(GenerateRandomItems(new List<IPortable>())), "Secondary Warehouse", 102)
            };

            Ports = new List<Port>
            {
                new Port("USA", "Los Angeles", "Port Street", 1, 200000,new List<IPortable>(GenerateRandomItems(new List<IPortable>())), 100000, "Main Port", 201),
                new Port("USA", "San Francisco", "Bay Street", 2, 180000,new List<IPortable>(GenerateRandomItems(new List<IPortable>())), 90000, "Secondary Port", 202),
                new Port("USA", "Houston", "Harbor Street", 3, 220000, new List<IPortable>(GenerateRandomItems(new List<IPortable>())), 110000, "Tertiary Port", 203)
            };

            Items = GenerateRandomItems(Items);
        }

        private void ChooseDestinationForDriver()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Choose a free driver (1 to 10):");
            if (int.TryParse(Console.ReadLine(), out int driverNum) && driverNum > 0 && driverNum <= Drivers.Count)
            {
                Driver selectedDriver = Drivers[driverNum - 1];

                if (!selectedDriver.OnWay())
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

            foreach (var driver in Drivers)
            {
                if (driver.Located == "Main Port" || driver.Located == "Secondary Port" || driver.Located == "Tertiary Port")
                {
                    foreach (var port in Ports)
                    {
                        if (driver.Located == port.Name)
                        {
                            port.Load(driver.CargoVehicle.Items);
                            atLeastOnePortLoaded = true;
                            driver.CargoVehicle.Items.Clear();
                            driver.CargoVehicle.ClearWeightCargo();
                            if (driver.CargoVehicle is CargoShip || driver.CargoVehicle is FreightPlane)
                            {
                                driver.CargoVehicle.Items = new List<IPortable>(GenerateRandomItems(new List<IPortable>())); // Used for resuply planes and ships
                                driver.CargoVehicle.CalculateWeightCargo(driver.CargoVehicle.Items);
                            }
                            Console.WriteLine("----------");
                            Console.WriteLine($"Driver {driver.ToString()} has successfully loaded all items into {port.Name}");
                        }
                    }
                }
            }
            if (!atLeastOnePortLoaded)
            {
                Console.WriteLine("----------");
                Console.WriteLine("No available warehouse could load the items.");
            }
        }

        private void LoadItemsInWarehouses()
        {
            bool atLeastOneWarehouseLoaded = false;

            foreach (var driver in Drivers)
            {
                if (driver.Located == "Main Warehouse" || driver.Located == "Secondary Warehouse")
                {
                    foreach (var warehouse in Warehouses)
                    {
                        if (driver.Located == warehouse.Name)
                        {
                            warehouse.Load(driver.CargoVehicle.Items);
                            atLeastOneWarehouseLoaded = true;
                            driver.CargoVehicle.Items.Clear();
                            driver.CargoVehicle.ClearWeightCargo();
                            if (driver.CargoVehicle is CargoShip || driver.CargoVehicle is FreightPlane)
                            {
                                driver.CargoVehicle.Items = new List<IPortable>(GenerateRandomItems(new List<IPortable>())); // Used for resuply planes and ships
                                driver.CargoVehicle.CalculateWeightCargo(driver.CargoVehicle.Items);
                            }
                            Console.WriteLine("----------");
                            Console.WriteLine($"Driver {driver.ToString()} has successfully loaded all items into {warehouse.Name}");
                        }
                    }
                }
            }
            if (!atLeastOneWarehouseLoaded)
            {
                Console.WriteLine("----------");
                Console.WriteLine("No available warehouse could load the items.");
            }
        }

        private void UnloadAllItemsFromPorts()// Repair it
        {
            bool atLeastOnePortUnLoaded = false;

            foreach (var driver in Drivers)
            {
                if (driver.Located == "Main Port" || driver.Located == "Secondary Port" || driver.Located == "Tertiary Port")
                {
                    foreach (var port in Ports)
                    {
                        if (driver.Located == port.Name)
                        {
                            driver.CargoVehicle.UnloadItems(port);
                            atLeastOnePortUnLoaded = true;
                            driver.CargoVehicle.Items.Clear();
                            Console.WriteLine("----------");
                            Console.WriteLine($"Driver {driver.ToString()} has successfully Unloaded all items from {port.Name}");
                        }
                    }
                }
            }
            if (!atLeastOnePortUnLoaded)
            {
                Console.WriteLine("No items were unloaded.");
            }
        }


        private void ShowAllDetails()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Details of all drivers:");
            foreach (var driver in Drivers)
            {
                Console.WriteLine("");
                Console.WriteLine(driver.CargoVehicle.ToString() + " with current weight in cargo of " + driver.CargoVehicle.CurrentItemsWeightInCargo);
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

        private List<IPortable> GenerateRandomItems(List<IPortable> existingItems)
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
    }
}
