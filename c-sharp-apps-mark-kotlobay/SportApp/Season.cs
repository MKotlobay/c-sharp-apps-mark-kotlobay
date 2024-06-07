using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.SportApp
{
    public class Season
    {
        private int year;
        private string sortSport; // Sort of sport
        private string league;
        private Team[] teams;
        //private int roundsAmount;
        //private Round nextRound;
        // Not finished

        public Season(int year, string sportType, string league, Team[] teams)
        {
            this .year = year;
            this.sortSport = sportType;
            this.league = league;
            this.teams = teams;
        }

        public void DisplayTable()
        {
            for (int i = 0; i < teams.Length; i++)
            {
                this.teams[i].ToString();
            }
        }
    }
}
