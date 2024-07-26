using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.TransportationApp
{
    public class Crone
    {
        private readonly int rows, columns;

        public Crone(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }
        public Crone(Crone crone)
        {
            this.rows = crone.rows;
            this.columns = crone.columns;
        }
        public int GetSeats() { return this.rows * this.columns; }
        public int GetExtras() { return this.rows * 2; }
    }
}
