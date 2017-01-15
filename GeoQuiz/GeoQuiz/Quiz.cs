using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz
{
    class Quiz
    {
        struct quizItem
        {
            public string question;
            public string answer;
        }

        List<quizItem> quiz = new List<quizItem>(20);

        public Quiz()
        {
            string filePath = "C:/Users/user/Desktop/Specter_C#/OtherProjects/GeoQuiz/capitals.txt";

            var stringsFromFile = File.ReadAllLines(filePath);

            foreach (var item in stringsFromFile)
            {
                var result = item.Split('#');
                var entry = new quizItem();
                entry.question = result[0];
                entry.answer = result[1];
                quiz.Add(entry);
            }

            //new Random().Shuffle(listOfQuestions);// Randomize countries in the array
        }

        public void TakeQuiz()
        {
            new Random().Shuffle(quiz);//Randomize question order

            int wrongAnswers = 0;
            int rightAnswers = 0;
            int number = 0; //number of the question being asked

            while (number < quiz.Count && wrongAnswers < 3)
            {
                Console.WriteLine(quiz[number].question);
                string usersAnswer = Console.ReadLine();

                if (usersAnswer.ToLower() == quiz[number].answer.ToLower())
                {
                    rightAnswers++;
                    Console.WriteLine("You are right! Your score is:{0}", rightAnswers);
                }
                else
                {
                    Console.WriteLine("Nope. The right answer is {0}.", quiz[number].answer);
                    wrongAnswers++;
                }

                number++;
            }

            Console.WriteLine("You have scored {0} points out of {1}!\n\n", rightAnswers, quiz.Count);

            Console.Clear();
            Menu.Start();
        }

    }
}
