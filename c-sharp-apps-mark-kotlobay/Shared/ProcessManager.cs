using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.Shared;

namespace c_sharp_apps_mark_kotlobay.Shared
{
    public class ProcessManager
    {
        public static void RunMainProcess()
        {
            Console.WriteLine("Choose one app: 1 – Bank App | 2 – Sport App | 3 – Transportation App | 4 – Draft App | 0 - Exit");
            int num = int.Parse(Console.ReadLine());

            while (num > 0 && num < 5)
            {
                switch (num)
                {
                    case 1:
                        BankApp.BankAppMain.MainEntry();
                        break;
                    case 2:
                        SportApp.SportAppMain.MainEntry();
                        break;
                    case 3:
                        TransportationApp.TransportationAppMain.MainEntry();
                        break;
                    case 4:
                        DraftApp.DraftAppMain.MainEntry();
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        return;
                }
                num = int.Parse(Console.ReadLine());
            }
        }
    }
}
