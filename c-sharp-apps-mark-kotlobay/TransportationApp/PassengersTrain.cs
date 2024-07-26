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
        public PassengersTrain(int line, int id, int maxSpeed, Crone crone, int cronesAmount) : base(line, id, maxSpeed, 0)
        {
            #region Crone builder
            crones = new Crone[cronesAmount];
            for (int i = 0; i < crones.Length; i++)
            {
                crones[i] = new Crone(crone);
            }
            #endregion End crone builder

            this.cronesAmount = cronesAmount;
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
            if (CalculateHasRoom() == true)
            {
                if (num + CurrentPassengers > GetMaxPassengers())
                {
                    RejectedPassengers = (num + CurrentPassengers) - GetMaxPassengers();
                    CurrentPassengers += num - RejectedPassengers;
                    CalculateHasRoom();
                }
                else
                {
                    CurrentPassengers += num;
                    CalculateHasRoom();
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