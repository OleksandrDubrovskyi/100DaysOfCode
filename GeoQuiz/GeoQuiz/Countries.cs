using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz
{
    public static class GeographyQuiz
    {
        static int rigtAnswers = 0;
        static int wrongAnswers = 0;

        struct country
        {
            public string name;
            public string capital;
        }

        static country[] europe = new country[51];

        public static void Start()
        {
            GetEuropeanCountries();
            Quiz();
        }

        static void GetEuropeanCountries()
        {
            string[] lines = File.ReadAllLines("C:/Users/user/Desktop/Specter_C#/OtherProjects/GeoQuiz/capitals.txt");
            
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split('#');
                europe[i].name = words[0];
                europe[i].capital = words[1];
            }

            new Random().Shuffle(europe);// Randomize countries in the array
        }

        static void Quiz()
        {
            int number = 0; //number of the question being asked

            while (number < europe.Length && wrongAnswers < 3)
            {
                askQuestion(number);
                number++;
            }

            Console.WriteLine("You have scored {0} points!", rigtAnswers);
        }

        static void askQuestion(int number)
        {
            Console.WriteLine("What is the capital of {0}?", europe[number].name);
            string usersAnswer = Console.ReadLine();

            if (usersAnswer.ToLower() == europe[number].capital.ToLower())
            {
                rigtAnswers++;
                Console.WriteLine("You are right! Your score is:{0}", rigtAnswers);
            }
            else
            {
                Console.WriteLine("Nope. The right answer is {0}.", europe[number].capital);
                wrongAnswers++;
            }
        }
    }
}
