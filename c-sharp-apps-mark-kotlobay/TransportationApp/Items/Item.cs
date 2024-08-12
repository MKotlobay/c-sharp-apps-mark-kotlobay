using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp.Items
{
    public abstract class Item : IContainable
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Volume { get { return Length * Width * Height; } }
        public double Price { get; set; }
    }
    public class GeneralItem : Item
    {
        public GeneralItem(double length, double width, double height, double weight, double price)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
            Price = price;
        }
    }

    public class ElectricItem : Item
    {
        public double PowerConsumption { get; set; }

        public ElectricItem(double length, double width, double height, double weight, double price, double powerConsumption)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
            Price = price;
            PowerConsumption = powerConsumption;
        }
    }

    public class FurnitureItem : Item
    {
        public string Material { get; set; }

        public FurnitureItem(double length, double width, double height, double weight, double price, string material)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
            Price = price;
            Material = material;
        }
    }
}
