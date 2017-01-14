using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz
{
    public struct quizItem
    {
        public string question;
        public string answer;
    }

    class UsersQuiz
    {
        List<quizItem> listOfQuestions = new List<quizItem>(10);

        /// <summary>
        /// Methods of the class
        /// </summary>

        public static void Start()
        {
            string quizName = GetQuizName();

            var quiz = DataBinding.LoadRecords(quizName);

            if (quiz.Count == 0)
            {
                Console.WriteLine("Quiz {0} does not exist. Let's create it!", quizName);
                quiz = CreateListOfQuestions(quiz, quizName);
            }
            else AskUser(quiz, quizName);

            Menu.Start();
        }

        static string GetQuizName()
        {
            Console.WriteLine("Enter the name of your quiz.");
            string quizName = Console.ReadLine();

            return quizName;
        }

        // The quiz exists. Does user want to take it
        // or to add more questions?
        static void AskUser(List<quizItem> quiz, string quizName)
        {
            Console.WriteLine("Quiz {0} exists. To take it press 1, "
                                + "to add more questions press 2.", quizName);
            string usersInput = Console.ReadLine();

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
            }
        }

        // Creates user quiz based on questions put by user
        static List<quizItem> CreateListOfQuestions(List<quizItem> quiz, string quizName)
        {
            while (true)
            {
                var newQuestion = GetUsersQuestions();

                if (newQuestion.question == "" || newQuestion.answer == "")
                    break;
                else quiz.Add(newQuestion);
            }

            DataBinding.SubmitRecords(quiz, quizName);
            return quiz;
        }

        // Receives user questions for the current quiz
        static quizItem GetUsersQuestions()
        {
            quizItem usersQuestion = new quizItem();

            Console.WriteLine("Enter your question:");
            usersQuestion.question = Console.ReadLine();
            Console.WriteLine("Enter the answer:");
            usersQuestion.answer = Console.ReadLine();

            return usersQuestion;
        }

        static void TakeQuiz(List<quizItem> quiz)
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
