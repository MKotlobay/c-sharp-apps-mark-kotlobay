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

        public Game(Team groupA, Team groupB)
        {
            this.groupA = groupA;
            this.groupB = groupB;

            this.groupAGoals = 0;
            this.groupBGoals = 0;

            this.nowTime = new TimeOnly();
            this.gameIsOn = true;
        }

        public void ScoreGoal(Team x)
        {
            int xGoals = x.GetGoals();
            x.SetGoals(xGoals);
        }

        public void FinishGame()
        {
            gameIsOn = false;
        }
    }
}
