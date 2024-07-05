using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class PassengersAirplain : PublicVehicle
    {
        private int enginesNum;
        private int wingLength;
        private int rows;
        private int columns;

        public PassengersAirplain() { }
        public PassengersAirplain(int enginesNum, int wingLength, int rows, int columns, int line, int id) : base(line, id)
        {
            this.enginesNum = enginesNum;
            this.wingLength = wingLength;
            this.rows = rows;
            this.columns = columns;
            Line = line;
            Id = id;
            Seats = Rows * Columns;
        }
        public int EnginesNum { get => enginesNum; set => enginesNum = value; }
        public int WingLength { get => wingLength; set => wingLength = value; }
        public int Rows { get => rows; set => rows = value; }
        public int Columns { get => columns; set => columns = value; }
        public override int MaxSpeed { get => maxSpeed; set { if (value <= 1000) maxSpeed = value; } }
        private int GetMaxPassengers() { return Seats - 7; }
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
            Console.WriteLine("Line: " + Line + " ,ID: " + Id + " ,Max speed: " + MaxSpeed + " ,Current passengers: " + CurrentPassengers + " ,Seats: " + Seats + " ,Has room: " + CalculateHasRoom() + " ,Engines num: " + EnginesNum + " ,Wing length: " + WingLength + " ,Rows: " + Rows + " ,Columns: " + Columns);
        }
    }
}
