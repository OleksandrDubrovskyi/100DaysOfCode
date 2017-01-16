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

        public Quiz()
        {
            List<quizItem> quiz = new List<quizItem>(20);

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
        }

        public Quiz(string quizName) //If we work with an already existing quiz
        {
            List<quizItem> quiz = DataBinding.LoadRecords(quizName);

            foreach (var item in quiz)
            {
                Console.WriteLine(item.question);
            }
            Console.WriteLine("Quiz {0} exists. To take it press 1, "
                                + "to add more questions press 2.", quizName);
            string usersInput = Console.ReadLine();

            TakeQuiz(quiz);
/*
            switch (usersInput)
            {
                case "1":
                    TakeQuiz(quiz);
                    break;
                case "2":
                    CreateListOfQuestions(quiz, quizName);
                    break;
                default:
                    AskUser(quiz, quizName);
                    break;
            }*/
        }

        public void TakeQuiz(List<quizItem> quiz)
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
