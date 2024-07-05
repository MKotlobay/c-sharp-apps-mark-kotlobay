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

            // 10 tests;

            //test max speed

            //test uplod some passenger and the currentPassengers after.

            //cases that it's should be done. And not.
        }

        public void MyTest()
        {
            PublicVehicle tomCart = new PublicVehicle(1, 1, 35, 5); // First object

            PassengersAirplain IL3245 = new PassengersAirplain(4, 10, 100, 4, 5, 300); // Second object

            #region Train build
            Crone[] crones = new Crone[4]; // Third object
            for(int i = 0; i < crones.Length; i++)
            {
                Console.WriteLine("Enter Rows amount and columns amount");
                Crone crone = new Crone(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                crones[i] = crone;
            }
            PassengersTrain israelTrain = new PassengersTrain(crones, 4, 100, 535, 280); // Fourth object
            #endregion End train build

            Bus eged = new Bus(2, true, 792, 3, 110, 30); // Fifth object
        }
    }
}
