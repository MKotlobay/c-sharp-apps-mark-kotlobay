using c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;

public class Crane : IContainable
{
    public double MaxCapacityWeight { get; private set; } // Maximum weight crane can handle
    public double MaxCapacityVolume { get; private set; } // Maximum volume crane can handle
    public double CurrentWeight { get; private set; } // Current weight being carried by crane
    public double CurrentVolume { get; private set; } // Current volume being carried by crane
    public List<Container> Containers { get; private set; }

    public Crane(double maxCapacityWeight, double maxCapacityVolume)
    {
        MaxCapacityWeight = maxCapacityWeight;
        MaxCapacityVolume = maxCapacityVolume;
        CurrentWeight = 0;
        CurrentVolume = 0;
        Containers = new List<Container>();
    }

    public bool Load(IPortable item)
    {
        if (item is Container container)
        {
            if (CurrentWeight + container.Weight <= MaxCapacityWeight &&
                CurrentVolume + container.Volume <= MaxCapacityVolume)
            {
                Containers.Add(container);
                CurrentWeight += container.Weight;
                CurrentVolume += container.Volume;
                return true;
            }
            Console.WriteLine($"Cannot load container. Exceeds crane capacity. Current weight: {CurrentWeight}, volume: {CurrentVolume}, max weight: {MaxCapacityWeight}, max volume: {MaxCapacityVolume}");
        }
        return false;
    }

    public bool Load(List<IPortable> items)
    {
        foreach (var item in items)
        {
            if (item is Container container)
            {
                if (!Load(container)) // Use the single item Load method
                {
                    // If loading fails, stop the process and return false
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Item {item} is not a valid container.");
                return false;
            }
        }
        return true;
    }

    public bool Unload(IPortable item)
    {
        if (item is Container container && Containers.Contains(container))
        {
            Containers.Remove(container);
            CurrentWeight -= container.Weight;
            CurrentVolume -= container.Volume;
            return true;
        }
        return false;
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

    public bool IsReadyToTravel()
    {
        return Containers.Count > 0 && IsCraneOperational();
    }

    private bool IsCraneOperational()
    {
        return true;
    }
}
