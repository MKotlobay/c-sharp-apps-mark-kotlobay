using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.Items
{
    public interface IContainable
    {
        double Length { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        double Weight { get; set; }
        double Volume { get; }
        double Price { get; set; }
    }
}
