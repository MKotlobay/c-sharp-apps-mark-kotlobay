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
                Console.WriteLine("Choose num for action: 1 – Choose destination for driver | 2 – All drivers in ports load it! | 3 – All drivers in warehouses load it! | 4 - Unload all items in ports | 5 - Unload all items in warehouses | 9 – Full details of all | 0 - Exit");
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
                new Driver("John", "Doe", "123", DriverType.CargoCar, "Main Warehouse"),
                new Driver("Jane", "Smith", "456", DriverType.FreightTrain, "Secondary Warehouse"),
                new Driver("Jim", "Beam", "789", DriverType.FreightPlane, "Main Port"),
                new Driver("Jack", "Daniels", "101", DriverType.CargoShip, "Secondary Port"),
                new Driver("Johnny", "Walker", "102", DriverType.CargoCar, "Tertiary Port"),
                new Driver("James", "Bond", "103", DriverType.FreightTrain, "Main Warehouse"),
                new Driver("Tony", "Stark", "104", DriverType.FreightPlane, "Secondary Warehouse"),
                new Driver("Steve", "Rogers", "105", DriverType.CargoShip, "Main Port"),
                new Driver("Bruce", "Wayne", "106", DriverType.CargoCar, "Secondary Port"),
                new Driver("Clark", "Kent", "107", DriverType.FreightTrain, "Tertiary Port")
            };

            Warehouses = new List<Warehouse>
            {
                new Warehouse("USA", "New York", "5th Avenue", 1, 100000, 50000, GenerateRandomItems(Items), "Main Warehouse", 101),
                new Warehouse("USA", "Chicago", "Michigan Avenue", 2, 150000, 60000,GenerateRandomItems(Items), "Secondary Warehouse", 102)
            };

            Ports = new List<Port>
            {
                new Port("USA", "Los Angeles", "Port Street", 1, 200000,GenerateRandomItems(Items), 100000, "Main Port", 201),
                new Port("USA", "San Francisco", "Bay Street", 2, 180000,GenerateRandomItems(Items), 90000, "Secondary Port", 202),
                new Port("USA", "Houston", "Harbor Street", 3, 220000, GenerateRandomItems(Items), 110000, "Tertiary Port", 203)
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
                if (!driver.OnWay() && (driver.Located == "Main Port" || driver.Located == "Secondary Port" || driver.Located == "Tertiary Port"))
                {
                    foreach (var port in Ports)
                    {
                        // Check if the driver's location matches the port's name
                        if (driver.Located == port.Name)
                        {
                            bool allLoaded = port.Load(driver.CargoVehicle.Items);

                            if (allLoaded)
                            {
                                driver.CargoVehicle.Items.Clear(); // Clear items from driver's cargo after loading
                                atLeastOnePortLoaded = true;
                                Console.WriteLine("----------");
                                Console.WriteLine($"Driver {driver.ToString()} has successfully loaded all items into {port.Name}");
                            }
                            else
                            {
                                Console.WriteLine("----------");
                                Console.WriteLine($"Driver {driver.ToString()} could not load all items into {port.Name} because the port is full");
                            }

                            // Stop checking further ports for this driver if at least one port was successfully loaded
                            break;
                        }
                    }
                }
            }

            if (!atLeastOnePortLoaded)
            {
                Console.WriteLine("----------");
                Console.WriteLine("No available ports could load the items.");
            }
        }

        private void LoadItemsInWarehouses()
        {
            bool atLeastOneWarehouseLoaded = false;

            foreach (var driver in Drivers)
            {
                if (!driver.OnWay() && (driver.Located == "Main Warehouse" || driver.Located == "Secondary Warehouse"))
                {
                    foreach (var warehouse in Warehouses)
                    {
                        // Check if the driver's location matches the warehouse's name
                        if (driver.Located == warehouse.Name)
                        {
                            // Ensure CargoVehicle and Items are not null
                            if (driver.CargoVehicle != null)
                            {
                                var items = driver.CargoVehicle.Items; // Access the Items from CargoVehicle

                                bool allLoaded = warehouse.Load(items);

                                if (allLoaded)
                                {
                                    driver.CargoVehicle.Items.Clear(); // Clear items from driver's cargo after loading
                                    atLeastOneWarehouseLoaded = true;
                                    Console.WriteLine("----------");
                                    Console.WriteLine($"Driver {driver.ToString()} has successfully loaded all items into {warehouse.Name}");
                                }
                                else
                                {
                                    Console.WriteLine("----------");
                                    Console.WriteLine($"Driver {driver.ToString()} could not load all items into {warehouse.Name} because the warehouse is full");
                                }
                            }
                            else
                            {
                                Console.WriteLine("----------");
                                Console.WriteLine($"Driver {driver.ToString()} does not have a CargoVehicle assigned.");
                            }

                            // Stop checking further warehouses for this driver if at least one warehouse was successfully loaded
                            break;
                        }
                    }
                }
            }

            if (!atLeastOneWarehouseLoaded)
            {
                Console.WriteLine("----------");
                Console.WriteLine("No available warehouses could load the items.");
            }
        }


        private void ShowAllDetails()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Details of all drivers:");
            foreach (var driver in Drivers)
            {
                Console.WriteLine(driver.CargoVehicle.ToString());
            }

            Console.WriteLine("----------");
            Console.WriteLine("Details of all warehouses:");
            foreach (var warehouse in Warehouses)
            {
                Console.WriteLine(warehouse.ToString());
            }

            Console.WriteLine("----------");
            Console.WriteLine("Details of all ports:");
            foreach (var port in Ports)
            {
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
