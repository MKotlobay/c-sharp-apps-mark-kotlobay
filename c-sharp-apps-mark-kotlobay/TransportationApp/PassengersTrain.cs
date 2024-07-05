using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class PassengersTrain : PublicVehicle
    {
        private Crone[] crones = null;
        private int cronesAmount = 0;

        public PassengersTrain() { }
        public PassengersTrain(Crone[] crones, int cronesAmount, int line, int id, int maxSpeed) : base(line, id, maxSpeed, 0)
        {
            this.crones = crones;
            this.cronesAmount = cronesAmount;
            Line = line;
            Id = id;
            MaxSpeed = maxSpeed;
            Seats = GetMaxPassengers();
        }
        public Crone[] Crones { get => crones; set => crones = value; }
        public int CronesAmount { get => cronesAmount; set => cronesAmount = value; }
        public override int MaxSpeed { get => maxSpeed; set { if (value <= 300) maxSpeed = value; } }
        private int GetMaxPassengers()
        {
            int counter = 0;
            for (int i = 0; i < crones.Length; i++)
            {
                counter += crones[i].GetSeats() + crones[i].GetExtras();
            }
            return counter;
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
            int rejectedPassengers;
            if (CalculateHasRoom() == true)
            {
                if (num + CurrentPassengers > GetMaxPassengers())
                {
                    int temp = GetMaxPassengers() - CurrentPassengers;
                    rejectedPassengers = num - temp;
                    CurrentPassengers = GetMaxPassengers();
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
            Console.WriteLine("Line: " + Line + " ,ID: " + Id + " ,Max speed: " + MaxSpeed + " ,Current passengers: " + CurrentPassengers + " ,Seats: " + Seats + " ,Has room: " + CalculateHasRoom() + " ,Crones amount: " + CronesAmount);
        }
    }
}