using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class TransportationAppMain
    {
        public static void MainEntry()
        {
            Console.WriteLine("TransportationApp");

            MonitorTransportation monitor = new MonitorTransportation();
            //monitor.Test1();
            monitor.CargoTask();
        }
    }
}
