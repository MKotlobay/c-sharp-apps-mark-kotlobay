using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.SportApp
{
    public class Team
    {
        public static void Teams()
        {

        }

        private string name;
        private string city;
        private string league; // Check if it by numbers the leagues or should it be as string
        private int overAllGames; // Include future games
        private int playedGames;
        private int wonGames;
        private int lostGames;
        private int drawGames;
        private int points;
        private int goalsMandatory; // Goals for - Been made by the team
        private int goalsConceded; // Goals against - Goals that been lost
        private int goalsDifferential;

        public Team(string name, string city)
        {
            this.name = name;
            this.city = city;
            this.goalsMandatory = 0; // Goals for - Been made by the team
            this.goalsConceded = 0;
            //this.goalsDifferential = Math.Abs(goalsMandatory- goalsConceded);
        }

        public int GetGoals()
        {
            return this.goalsMandatory;
        }
        public int SetGoals(int goals)
        {
            return this.goalsMandatory = goals;
        }

        public void ToString()
        {
            Console.WriteLine("Name of team: " + this.name + " Has Amount of points: " + this.points);
        }

        public string GetName()
        {
            return this.name;
        }
    }

}
