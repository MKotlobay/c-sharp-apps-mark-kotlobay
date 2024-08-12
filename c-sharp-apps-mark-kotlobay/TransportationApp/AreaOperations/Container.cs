using c_sharp_apps_mark_kotlobay.TransportationApp.CargoTransports;
using c_sharp_apps_mark_kotlobay.TransportationApp.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.AreaOperations
{
    public class Container : IPortable
    {
        public int Number { get; private set; }
        public string ContainerType { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double MaxVolume { get; }
        public double Volume { get; set; }
        public List<IPortable> Items { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }

        public Container()
        {
            Length = 12.19;
            Width = 2.44;
            Height = 2.59;
            MaxVolume = Length * Width * Height;
            Volume = 0;
            Items = new List<IPortable>();
            Weight = 0;
        }

        public bool CanAddItem(IPortable item)
        {
            return (Weight + item.Weight <= 30000) && (Volume + item.Volume < MaxVolume);
        }

        public void PriceConatiningItems()
        {
            foreach (var item in Items)
            {
                Price = item.Price;
            }
            Console.WriteLine($"Container with containing items price of it is {Price}");
        }

        public void AddItem(IPortable item)
        {
            if (CanAddItem(item))
            {
                Items.Add(item);
                Volume += item.Volume;
                Weight += item.Weight;
            }
        }

        public void CalculateWeight()
        {
            Weight = 0;
            foreach (var item in Items)
            {
                Weight += item.Weight;
            }
        }

        public bool RemoveItem(IPortable item)
        {
            bool removed = Items.Remove(item);
            if (removed)
            {
                Weight -= item.Weight;
            }
            return removed;
        }

        public void ClearItems()
        {
            Items.Clear();
            Weight = 0;
        }

        public override string ToString()
        {
            return $"Container {Number} [Volume: {Volume}, Weight: {Weight}]";
        }
    }
}
