using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.SportApp
{
    public class Game
    {
        private Team groupA;
        private Team groupB;
        private int groupAGoals;
        private int groupBGoals;
        private TimeOnly nowTime;
        private bool gameIsOn;
        private string groupsInfo; // Information about groups
        private string addionalInfo; // Addional information

        public Game(Team groupA, Team groupB)
        {
            this.groupA = groupA;
            this.groupB = groupB;

            this.groupAGoals = 0;
            this.groupBGoals = 0;

            this.nowTime = new TimeOnly();
            this.gameIsOn = true;

            Console.WriteLine("Any group info ?");
            this.groupsInfo = Console.ReadLine();
            Console.WriteLine("Any addional info ?");
            this.addionalInfo = Console.ReadLine();
        }

        public void ScoreGoal()
        {
            Console.WriteLine("Write A or B for the team who scored the goal");
            string index = Console.ReadLine();

            if (index == "B")
                groupAGoals++;
            else if (index == "B")
                groupBGoals++;
        }

        public void FinishGame()
        {
            gameIsOn = false;
        }
    }
}
