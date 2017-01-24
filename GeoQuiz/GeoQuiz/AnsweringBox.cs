using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz
{
    class AnsweringBox
    {
        public struct Country
        {
            public string Name;
            public string Capital;
            public int Population;
            public int Area;
        }
        static List<Country> Countries = new List<Country>(5);

        static Dictionary<string, string> CapitalCities = new Dictionary<string, string>();
        static Dictionary<string, int> Population = new Dictionary<string, int>();
        static Dictionary<string, int> Area = new Dictionary<string, int>();

        public static void Start()
        {
            Initialize();
            Menu();
        }

        static void Initialize()
        {
            Country Israel = new Country();
            Israel.Name = "Israel"; Israel.Capital = "Jerusalem";
            Israel.Population = 8602000; Israel.Area = 20770;

            Country Italy = new Country();
            Italy.Name = "Italy"; Italy.Capital = "Rome";
            Italy.Population = 60674003; Italy.Area = 301338;

            Country Germany = new Country();
            Germany.Name = "Germany"; Germany.Capital = "Berlin";
            Germany.Population = 82175700; Germany.Area = 357168;

            Country France = new Country();
            France.Name = "France"; France.Capital = "Paris";
            France.Population = 66991000; France.Area = 551695;

            Country Greece = new Country();
            Greece.Name = "Greece"; Greece.Capital = "Athens";
            Greece.Population = 10955000; Greece.Area = 131957;

            Countries.Add(Israel);
            Countries.Add(Germany);
            Countries.Add(Italy);
            Countries.Add(France);
            Countries.Add(Greece);

            for (int i = 0; i < Countries.Count; i++)
            {
                CapitalCities.Add(Countries[i].Name, Countries[i].Capital);
                Population.Add(Countries[i].Name, Countries[i].Population);
                Area.Add(Countries[i].Name, Countries[i].Area);
            }

        }

        static void Menu()
        {
            Console.WriteLine("\tWe have information about following countries:\n");

            for (int i = 0; i < Countries.Count; i++)
            {
                Console.Write("{0}. {1}     ", i+1, Countries[i].Name);
            }
            Console.WriteLine("\n");
        }
    }
}
