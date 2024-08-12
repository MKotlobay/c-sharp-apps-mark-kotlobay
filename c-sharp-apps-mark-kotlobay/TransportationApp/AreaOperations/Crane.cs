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
        if (item is Container container)
        {
            return LoadContainer(container);
        }
        Console.WriteLine("Item is not a valid container.");
        return false;
    }

    public bool Load(Container container)
    {
        return LoadContainer(container);
    }

    public bool Load(List<IPortable> items)
    {
        foreach (var item in items)
        {
            if (!Load(item))
            {
                return false;
            }
        }
        return true;
    }

    public bool Load(List<Container> containers)
    {
        foreach (var container in containers)
        {
            if (!LoadContainer(container))
            {
                return false;
            }
        }
        return true;
    }

    public bool Unload(IPortable item)
    {
        if (item is Container container)
        {
            return UnloadContainer(container);
        }
        Console.WriteLine("Item is not a valid container.");
        return false;
    }

    public bool Unload(Container container)
    {
        return UnloadContainer(container);
    }

    public bool Unload(List<IPortable> items)
    {
        foreach (var item in items)
        {
            if (!Unload(item))
            {
                return false;
            }
        }
        return true;
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

    private bool LoadContainer(Container container)
    {
        CurrentWeight = container.Weight;
        if (CurrentWeight <= MaxCapacityWeight)
        {
            CurrentWeight += container.Weight;
            CurrentVolume += container.Volume;
            return true;
        }
        else
        {
            Console.WriteLine("Cannot load container. Exceeds crane capacity.");
            return false;
        }
    }

    private bool UnloadContainer(Container container)
    {
        if (CurrentWeight - container.Weight >= 0 &&
            CurrentVolume - container.Volume >= 0)
        {
            CurrentWeight -= container.Weight;
            CurrentVolume -= container.Volume;
            return true;
        }
        else
        {
            Console.WriteLine("Cannot unload container. Exceeds crane capacity.");
            return false;
        }
    }

    public bool IsReadyToTravel()
    {
        return CurrentWeight > 0 && CurrentVolume > 0 && IsCraneOperational();
    }

    private bool IsCraneOperational()
    {
        return true;
    }
}
