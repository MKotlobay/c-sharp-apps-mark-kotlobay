using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.SportApp
{
    public class Round
    {
        private Game[] games;

        public Round(int gamesAmount)
        {
            this.games = new Game[gamesAmount];
        }
    }
}
