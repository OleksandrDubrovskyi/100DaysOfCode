﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz
{
    class Menu
    {
        public static void Start()
        {
            var quizzes = DataBinding.LoadFileNames();

            for (int i = 0; i < quizzes.Length; i++)
            {
                string output = String.Format((i+1) + ". " + quizzes[i] + ".\n");
                Console.WriteLine(output);
            }
          

            Console.WriteLine("1. Take European capitals quiz.");
            Console.WriteLine("2. Create / take your own quiz.");
            Console.WriteLine("Press Enter to quit.\n\n");

            string usersInput = Console.ReadLine();

            switch (usersInput)
            {
                case "1":
                    GeographyQuiz.StartQuiz();
                    break;
                case "2":
                    UsersQuiz.Start();
                    break;
                case "":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("No such option.");
                    Start();
                    break;
            }
        }
    }
}
