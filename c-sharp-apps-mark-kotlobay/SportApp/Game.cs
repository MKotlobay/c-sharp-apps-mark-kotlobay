using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.SportApp
{
    public class Game
    {
        private Team[] groupA;
        private Team[] groupB;
        private int groupAGoals;
        private int groupBGoals;
        private TimeOnly nowTime;
        private bool gameIsOn;
        private string groupsInfo; // Information about groups
        private string addionalInfo; // Addional information

        public Game(Team[] groupA, Team[] groupB)
        {
            this.groupA = groupA;
            this.groupB = groupB;

            #region Counter for goals
            int counterA = 0, counterB = 0;
            for (int i = 0; i < groupA.Length; i++)
                counterA += groupA[i].GetGoals();

            for (int i = 0; i < groupB.Length; i++)
                counterB += groupB[i].GetGoals();
            #endregion Counter for goals

            this.groupAGoals = counterA;
            this.groupBGoals = counterB;

            this.nowTime = new TimeOnly();
            this.gameIsOn = true;

            Console.WriteLine("Any group info ?");
            this.groupsInfo = Console.ReadLine();
            Console.WriteLine("Any addional info ?");
            this.addionalInfo = Console.ReadLine();
        }
    }
}
