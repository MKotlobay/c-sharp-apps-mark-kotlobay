using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations
{
    public interface IPortable
    {
        bool Load(IContainable item);
        bool Load(Container container);
        bool Load(List<IContainable> items);
        bool Load(List<Container> containers);
        bool Unload(IContainable item);
        bool Unload(Container container);
        bool Unload(List<IContainable> items);
        bool Unload(List<Container> containers);
        bool IsReadyToTravel();
    }
}
