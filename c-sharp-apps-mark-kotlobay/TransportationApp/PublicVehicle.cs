using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class PublicVehicle
    {
        private int line = 0;
        private int id = 0;
        public int maxSpeed = 0;
        private int currentPassengers = 0;
        private int seats = 0;
        private bool hasRoom = true;
        private int rejectedPassengers = 0;

        public PublicVehicle() { }
        public PublicVehicle(int line, int id, int maxSpeed, int seats)
        {
            this.line = line;
            this.id = id;
            if (maxSpeed <= 40)
            {
                this.maxSpeed = maxSpeed;
            }
            this.seats = seats;
        }
        public PublicVehicle(int line, int id)
        {
            this.line = line;
            this.id = id;
        }

        public int Line { get => line; set => line = value; }
        public int Id { get => id; set => id = value; }
        public virtual int MaxSpeed { get => maxSpeed; set { if (value <= 40) maxSpeed = value; } }
        public int CurrentPassengers { get => currentPassengers; set { if (currentPassengers <= Seats) currentPassengers = value; } }
        public int Seats { get => seats; set => seats = value; }
        public bool HasRoom { get => hasRoom; set { if (currentPassengers < seats) hasRoom = true; else hasRoom = false; } }
        public int RejectedPassengers { get => rejectedPassengers; set => rejectedPassengers = value; }
        private int GetMaxPassengers() { return seats; }
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
        public virtual void UploadPassengers(int num)
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
        public virtual void ToString()
        {
            Console.WriteLine("Line: " + Line + " ,ID: " + Id + " ,Max speed: " + MaxSpeed + " ,Current passengers: " + CurrentPassengers + " ,Seats: " + Seats + " ,Has room: " + CalculateHasRoom());
        }
    }
}
