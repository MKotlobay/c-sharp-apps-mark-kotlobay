using System;
using System.Collections.Generic;
using c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

public class Crane : IContainable
{
    public double MaxCapacityWeight { get; private set; }
    public double MaxCapacityVolume { get; private set; }
    public double CurrentWeight { get; private set; }
    public double CurrentVolume { get; private set; }

    public Crane(double maxCapacityWeight, double maxCapacityVolume)
    {
        MaxCapacityWeight = maxCapacityWeight; // Max Weight can lift in once
        MaxCapacityVolume = maxCapacityVolume; // Max Volume can lift in once
        CurrentWeight = 0; // Current weight for container
        CurrentVolume = 0; // Current volume for container
    }

    public bool Load(IPortable item)
    {
        return false;
    }

    public bool Load(List<IPortable> items)
    {
        return false;
    }

    public bool Load(Container container)
    {
        return LoadContainer(container);
    }

    public bool Load(List<Container> containers)
    {
        foreach (var container in containers)
        {
            if (LoadContainer(container) == false)
            {
                return false;
            }
        }
        return true;
    }

    public bool Unload(IPortable item)
    {
        Console.WriteLine("Item is not a valid container.");
        return false;
    }

    public bool Unload(Container container)
    {
        return UnloadContainer(container);
    }

    public bool Unload(List<IPortable> items)
    {
        Console.WriteLine("Item is not a valid container.");
        return false;
    }

    private bool LoadContainer(Container container)
    {
        if (container.Weight <= MaxCapacityWeight)
            return true;
        return false;
    }


    public bool Unload(List<Container> containers)
    {
        foreach (var container in containers)
        {
            if (!UnloadContainer(container))
            {
                return false;
            }
        }
        return true;
    }

    private bool UnloadContainer(Container container)
    {
        if (container.Weight <= MaxCapacityWeight)
            return true;
        return false;
    }

    public bool IsReadyToTravel()
    {
        return true;
    }

    private bool IsCraneOperational()
    {
        return true;
    }
}
