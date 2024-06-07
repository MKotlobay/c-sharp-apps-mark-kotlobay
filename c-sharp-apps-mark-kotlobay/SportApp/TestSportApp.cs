using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_mark_kotlobay.SportApp
{
    public class TestSportApp
    {
        public static void Test1()
        {

            Console.WriteLine("Test 1 - champions league mock");
            Season[] groups = CreateChampionsLeagueMock();

            for (int i = 0; i < groups.Length; i++)
            {
                groups[i].DisplayTable();
            }

        }
        public static Season[] CreateChampionsLeagueMock()
        {
            Season[] group = new Season[8];
            // Team 1
            Team bayern = new Team("Bayern", "Bayern");
            Team copenhagen = new Team("Copenhagen", "Copenhagen");
            Team galastray = new Team("Galastray", "Galastray");
            Team manUnited = new Team("Man United", "Manchester");

            // Team 2
            Team arsenal = new Team("Arsenal", "London");
            Team psv = new Team("psv", "eindhoven");
            Team lens = new Team("Lens", "Lens");
            Team sevilla = new Team("Sevilla", "Sevilla");

            // Team 3
            Team realMadrid = new Team("Real Madrid", "Madrid");
            Team napoli = new Team("Napoli", "Napoli");
            Team braja = new Team("Braja", "Braja");
            Team unionBerlin = new Team("Union Berlin", "Berlin");

            // Team 4
            Team realSociedad = new Team("Real Sociedad", "Sebastián");
            Team inter = new Team("Inter", "Milan");
            Team benfica = new Team("benfica", "lisbon");
            Team sazlburg = new Team("salzburg", "salzburg");

            // Team 5
            Team atleteco = new Team("Atletico Madrid", "Madrid");
            Team lazio = new Team("Lazio", "Roma");
            Team feyenoord = new Team("Feyenoord", "Rotterdam");
            Team celtic = new Team("Celtic", "Glasgow");

            // Team 6
            Team dortmund = new Team("Dortmund", "Dortmund");
            Team psg = new Team("PSG", "Paris");
            Team aCMilan = new Team("AC Milan ", "Milan");
            Team newCastle = new Team("NewCastle ", "United Kingdom");

            // Team 7
            Team manchesterCity = new Team("Manchester City ", "Manchester");
            Team rbLeipzig = new Team("RB Leipzig", "leipzig");
            Team youngBoys = new Team("Young Boys", "Bern");
            Team crvana = new Team("Crvena zvezda", "Belgrad");

            // Team 8
            Team barcelona = new Team("Barcelona", "Barcelona");
            Team porto = new Team("Porto", "Porto");
            Team shakhtarDonetsk = new Team("Shakhtar Donetsk", "Donetsk");
            Team antwerpFc = new Team("AntwerpFc", "Antwerp");

            // Teams
            Team[] teams1 = { bayern, copenhagen, galastray, manUnited };
            Team[] teams2 = { arsenal, psv, lens, sevilla };
            Team[] teams3 = { realMadrid, napoli, braja, unionBerlin };
            Team[] teams4 = { realSociedad, inter, benfica, sazlburg };
            Team[] teams5 = { atleteco, lazio, feyenoord, celtic };
            Team[] teams6 = { dortmund, psg, aCMilan, newCastle };
            Team[] teams7 = { manchesterCity, rbLeipzig, youngBoys, crvana };
            Team[] teams8 = { barcelona, porto, shakhtarDonetsk, antwerpFc };

            // Season groups
            Season groupA = new Season(2024, "soccer", "Champoins - Group A", teams1);
            Season groupB = new Season(2024, "soccer", "Champoins - Group B", teams2);
            Season groupC = new Season(2024, "soccer", "Champoins - Group C", teams3);
            Season groupD = new Season(2024, "soccer", "Champoins - Group D", teams4);
            Season groupE = new Season(2024, "soccer", "Champoins - Group E", teams5);
            Season groupF = new Season(2024, "soccer", "Champoins - Group F", teams6);
            Season groupG = new Season(2024, "soccer", "Champoins - Group G", teams7);
            Season groupH = new Season(2024, "soccer", "Champoins - Group H", teams8);

            group[0] = groupA;
            group[1] = groupB;
            group[2] = groupC;
            group[3] = groupD;
            group[4] = groupE;
            group[5] = groupF;
            group[6] = groupG;
            group[7] = groupH;


            //Team bayern = new Team("Bayern", "Bayern");
            return group;
        }
    }
}
