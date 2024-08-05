using c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class MonitorTransportation
    {
        public void Test1()
        {
            //TODO: 

            //some tests:
            // public PublicVehicle(int line, int id, int maxSpeed, int seats)
            PublicVehicle p1 = new PublicVehicle(18, 8099065, 50, 80);
            Bus bus = new Bus(1, 2033355, 110, 50, 3);//int line, int id, int maxSpeed, int seats, int doors
            //int line, int id, int enginesNum, int wingLength, int rows, int columns
            PassengersAirplain passengersAirplain1 = new PassengersAirplain(605, 987653, 4, 10, 60, 6);

            Crone crone1 = new Crone(20, 5);
            PassengersTrain passengersTrain1 = new PassengersTrain(65, 9998774, 250, crone1, 5);
            bool allPassed = true;

            //test max speed
            if (p1.MaxSpeed != 0)
            {
                Console.WriteLine("Test 1 Error - Max Speed should be {0} but actual is {1}", 0, p1.MaxSpeed);
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 1 Passed ");

            }

            if (bus.MaxSpeed != 110)
            {
                Console.WriteLine("Test 2 Error - Max Speed should be {0} but actual is {1}", 110, bus.MaxSpeed);
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 2 Passed ");

            }
            bus.MaxSpeed = 200;

            if (bus.MaxSpeed != 110)
            {
                Console.WriteLine("Test 3 Error - Max Speed should be {0} but actual is {1}", 110, bus.MaxSpeed);
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 3 Passed ");

            }

            //test uplod some passenger and the currentPassengers after. 

            //cases that it's should be done. And not. 


            passengersAirplain1.CurrentPassengers = 300;

            passengersAirplain1.UploadPassengers(100);

            if (passengersAirplain1.CurrentPassengers == 353 && passengersAirplain1.RejectedPassengers == 47)
            {
                Console.WriteLine("Test 4 Passed ");

            }
            else
            {

                Console.WriteLine("Test 4 Error - CurrentPassengers should be {0} but actual is {1} \n" +
                    "And rejected should be {2} but actual is {3} ", 353, passengersAirplain1.CurrentPassengers,
                    47, passengersAirplain1.RejectedPassengers);
                allPassed = false;

            }

            bus.UploadPassengers(40);
            bus.UploadPassengers(20);


            if (bus.CurrentPassengers == 55 && bus.RejectedPassengers == 5)
            {
                Console.WriteLine("Test 5 Passed ");

            }
            else
            {

                Console.WriteLine("Test 5 Error - CurrentPassengers should be {0} but actual is {1} \n" +
                  "And rejected should be {2} but actual is {3} ", 55, bus.CurrentPassengers,
                  15, bus.RejectedPassengers);
                allPassed = false;

            }


            if (passengersTrain1.Id == 9998774)
            {
                Console.WriteLine("Test 6 Passed ");

            }
            else
            {

                Console.WriteLine("Test 6 Error - id  should be {0} but actual is {1} "
                   , 987653, passengersTrain1.Id);
                allPassed = false;

            }

            passengersTrain1.UploadPassengers(300);

            passengersTrain1.UploadPassengers(134);


            if (passengersTrain1.CurrentPassengers == 434 && passengersTrain1.RejectedPassengers == 0)
            {
                Console.WriteLine("Test 7 Passed ");

            }
            else
            {

                Console.WriteLine("Test 7 Error - CurrentPassengers should be {0} but actual is {1} \n" +
                  "And rejected should be {2} but actual is {3} ", 434, passengersTrain1.CurrentPassengers,
                  0, passengersTrain1.RejectedPassengers);
                allPassed = false;

            }

            passengersTrain1.UploadPassengers(405);


            if (passengersTrain1.CurrentPassengers == 700 && passengersTrain1.RejectedPassengers == 139
                && !passengersTrain1.HasRoom)
            {
                Console.WriteLine("Test 8 Passed ");

            }
            else
            {

                Console.WriteLine("Test 8 Error - CurrentPassengers should be {0} but actual is {1} \n" +
                  "And rejected should be {2} but actual is {3} and HasRoom should be False, but actual is {4}", 700, passengersTrain1.CurrentPassengers,
                  139, passengersTrain1.RejectedPassengers, passengersTrain1.HasRoom);
                allPassed = false;

            }


            //Check that each crone is a different object...


            if (passengersTrain1.Crones[0].Equals(passengersTrain1.Crones[1]))
            {
                Console.WriteLine("Test 9 Error - each crone of the train should be different instance. ");
                allPassed = false;


            }
            else
            {

                Console.WriteLine("Test 9 Passed");

            }



            Console.WriteLine("\n*********************************\n");


            if (allPassed)
            {
                Console.WriteLine("All TEST PASSED - WELL DONE!! \n" +
                    "Yet it's not saying that everything work well. You should test yourself a little bit, also.");
            }
            else
            {
                Console.WriteLine("YOU HAVE FAILURES AT THE TESTS :( - SEE ABOVE");

            }
            Console.WriteLine("\n*********************************\n");
        }

        public void MyTest()
        {
            PublicVehicle tomCart = new PublicVehicle(1, 1, 35, 5); // First object

            PassengersAirplain IL3245 = new PassengersAirplain(4, 10, 100, 4, 5, 300); // Second object

            #region Train build
            Crone crone = new Crone(50, 4);
            PassengersTrain a = new PassengersTrain(100, 4, 280, crone, 4);
            #endregion End train build

            Bus eged = new Bus(792, 3, 110, 40, 2); // Fifth object
        }

        private List<Driver> drivers;
        private List<Warehouse> warehouses;
        private List<Port> ports;
        private List<IPortable> items;

        public MonitorTransportation()
        {
            BuildCargoApp();
        }

        public void RunCargoTask()
        {
            while (true)
            {
                Console.WriteLine("Choose num for action: 1 – Choose destination for driver | 2 – All drivers in ports load it! | 3 – All drivers in warehouses load it! | 9 – Full details of all | 0 - Exit");
                if (!int.TryParse(Console.ReadLine(), out int num) || num < 0 || num > 9)
                {
                    Console.WriteLine("Invalid input, please choose a valid action.");
                    continue;
                }

                if (num == 0)
                {
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
                        Console.WriteLine("Draft App functionality is not implemented yet.");
                        break;

                    case 9:
                        ShowAllDetails();
                        break;
                }
            }
        }

        private void BuildCargoApp()
        {
            drivers = new List<Driver>
            {
                new Driver("John", "Doe", "123", DriverType.CargoCar),
                new Driver("Jane", "Smith", "456", DriverType.FreightTrain),
                new Driver("Jim", "Beam", "789", DriverType.FreightPlane),
                new Driver("Jack", "Daniels", "101", DriverType.CargoShip),
                new Driver("Johnny", "Walker", "102", DriverType.CargoCar),
                new Driver("James", "Bond", "103", DriverType.FreightTrain),
                new Driver("Tony", "Stark", "104", DriverType.FreightPlane),
                new Driver("Steve", "Rogers", "105", DriverType.CargoShip),
                new Driver("Bruce", "Wayne", "106", DriverType.CargoCar),
                new Driver("Clark", "Kent", "107", DriverType.FreightTrain)
            };

            warehouses = new List<Warehouse>
            {
                new Warehouse("USA", "New York", "5th Avenue", 1, 100000, 50000, "Main Warehouse", 101),
                new Warehouse("USA", "Chicago", "Michigan Avenue", 2, 150000, 60000, "Secondary Warehouse", 102)
            };

            ports = new List<Port>
            {
                new Port("USA", "Los Angeles", "Port Street", 1, 200000, 100000, "Main Port", 201),
                new Port("USA", "San Francisco", "Bay Street", 2, 180000, 90000, "Secondary Port", 202),
                new Port("USA", "Houston", "Harbor Street", 3, 220000, 110000, "Tertiary Port", 203)
            };

            items = new List<IPortable>(); // Initialize with IPortable items if needed
        }

        private void ChooseDestinationForDriver()
        {
            Console.WriteLine("Choose a free driver (1 to 10):");
            if (int.TryParse(Console.ReadLine(), out int driverNum) && driverNum > 0 && driverNum <= drivers.Count)
            {
                Driver selectedDriver = drivers[driverNum - 1];

                if (!selectedDriver.OnWay())
                {
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
                        Console.WriteLine("Invalid destination type.");
                    }
                }
                else
                {
                    Console.WriteLine("Driver is already on the way.");
                }
            }
            else
            {
                Console.WriteLine("Invalid driver number.");
            }
        }

        private void ChoosePort(Driver selectedDriver)
        {
            Console.WriteLine("Choose a port (1 to 3):");
            if (int.TryParse(Console.ReadLine(), out int portNum) && portNum > 0 && portNum <= ports.Count)
            {
                Port selectedPort = ports[portNum - 1];
                selectedDriver.Approve(selectedPort.Name);
                selectedDriver.OnWay();
                Console.WriteLine($"Driver {selectedDriver.ToString()} is now on the way to {selectedPort.Name}");
            }
            else
            {
                Console.WriteLine("Invalid port number.");
            }
        }

        private void ChooseWarehouse(Driver selectedDriver)
        {
            Console.WriteLine("Choose a warehouse (1 to 2):");
            if (int.TryParse(Console.ReadLine(), out int warehouseNum) && warehouseNum > 0 && warehouseNum <= warehouses.Count)
            {
                Warehouse selectedWarehouse = warehouses[warehouseNum - 1];
                selectedDriver.Approve(selectedWarehouse.Name);
                selectedDriver.OnWay();
                Console.WriteLine($"Driver {selectedDriver.ToString()} is now on the way to {selectedWarehouse.Name}");
            }
            else
            {
                Console.WriteLine("Invalid warehouse number.");
            }
        }

        private void LoadItemsInPorts()
        {
            foreach (var driver in drivers)
            {
                if (driver.VehicleType == DriverType.CargoShip)
                {
                    foreach (var port in ports)
                    {
                        driver.Approve(port.Name);
                        // Assuming LoadItems() is implemented or handle the loading in a different way
                        Console.WriteLine($"Driver {driver.ToString()} has loaded items into {port.Name}");
                    }
                }
            }
        }

        private void LoadItemsInWarehouses()
        {
            foreach (var driver in drivers)
            {
                if (driver.VehicleType == DriverType.CargoCar)
                {
                    foreach (var warehouse in warehouses)
                    {
                        driver.Approve(warehouse.Name);
                        // Assuming LoadItems() is implemented or handle the loading in a different way
                        Console.WriteLine($"Driver {driver.ToString()} has loaded items into {warehouse.Name}");
                    }
                }
            }
        }

        private void ShowAllDetails()
        {
            Console.WriteLine("Details of all drivers:");
            foreach (var driver in drivers)
            {
                Console.WriteLine(driver.ToString());
            }

            Console.WriteLine("Details of all warehouses:");
            foreach (var warehouse in warehouses)
            {
                Console.WriteLine(warehouse.ToString());
            }

            Console.WriteLine("Details of all ports:");
            foreach (var port in ports)
            {
                Console.WriteLine(port.ToString());
            }
        }
    }
}
