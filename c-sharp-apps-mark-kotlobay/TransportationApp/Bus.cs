using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class Bus : PublicVehicle
    {
        private readonly int doors;
        private bool bellStop = false;

        public Bus() { }
        public Bus(int line, int id, int maxSpeed, int seats,int doors) : base(line, id, maxSpeed, seats)
        {
            Line = line;
            Id = id;
            MaxSpeed = maxSpeed;
            Seats = seats;
            this.doors = doors;
        }
        public int Doors { get => doors; }
        public bool BellStop { get => bellStop; set => bellStop = value; }

        public override int MaxSpeed { get => maxSpeed; set { if (value <= 120) maxSpeed = value; } }

        private int GetMaxPassengers()
        {
            return (int)Math.Round(Seats * 1.1);
        }
        private bool CalculateHasRoom()
        {
            if (CurrentPassengers < GetMaxPassengers())
            {
                HasRoom = true;
                return true;
            }
            HasRoom = false;
            return false;
        }
        public override void UploadPassengers(int num)
        {
            if (CalculateHasRoom() == true)
            {
                if (num + CurrentPassengers > GetMaxPassengers())
                {
                    RejectedPassengers = (num + CurrentPassengers) - GetMaxPassengers();
                    CurrentPassengers += num - RejectedPassengers;
                }
                else
                {
                    CurrentPassengers += num;
                }
            }
            else
            {
                return;
            }
        }
        public override void ToString()
        {
            Console.WriteLine("Line: " + Line + " ,ID: " + Id + " ,Max speed: " + MaxSpeed + " ,Current passengers: " + CurrentPassengers + " ,Seats: " + Seats + " ,Has room: " + CalculateHasRoom() + " ,Doors: " + Doors + " ,Bellstop: " + BellStop);
        }
    }
}
