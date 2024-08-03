using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public interface IPortable
    {
        double Length { get; }
        double Width { get; }
        double Height { get; }
        double Weight { get; }
        double Volume { get; }
        double Price { get; }
    }
}
