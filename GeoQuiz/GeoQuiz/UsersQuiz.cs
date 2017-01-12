using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz
{
    class UsersQuiz
    {
        struct quizItem
        {
            public string question;
            public string answer;
        }

        List<quizItem> listOfQuestions = new List<quizItem>(10);

        static Dictionary<string, List<quizItem>> userQuizes = new Dictionary<string, List<quizItem>>(10);

    // Methods

        static string GetQuizName()
        {
            Console.WriteLine("Enter the name of your quiz.");
            string quizName = Console.ReadLine();

            return quizName;
        }

        // Checks if there is existing quiz with a given name
        static List<quizItem> CheckQuizes(string quizName)
        {
            if (userQuizes.ContainsKey(quizName))
            {
                var value = userQuizes[quizName];
                return value;
            }
            else return null;
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

        // Creates user quiz based on questions put by user
        static List<quizItem> CreateListOfQuestions(string quizName)
        {
            var listOfQuestions = new List<quizItem>(10);

            while (true)
            {
                var newQuestion = GetUsersQuestions();

                if (newQuestion.question == "" || newQuestion.answer == "")
                    break;
                else listOfQuestions.Add(newQuestion);
            }
           
            return listOfQuestions;
        }

        // The quiz exists. Does user want to take it
        // or to add more questions
        static void AskUser(string quizName)
        {
            Console.WriteLine("Quiz {0} exists. To take it press 1," 
                                +"to add more questions press 2", quizName);
            string usersInput = Console.ReadLine();

            switch (usersInput)
            {
                case "1":
                    TakeQuiz(quizName);
                    break;
                case "2":
                    CreateListOfQuestions(quizName);
                    break;
                default:
                    AskUser(quizName);
                    break;

            }
        }

        static void TakeQuiz(string quizName)
        {

        }
        
        public static void ReceiveUsersInput()
        {
            string quizName = GetQuizName();

            if (CheckQuizes(quizName) == null)
            {
                var quiz = CreateListOfQuestions(quizName);
                userQuizes.Add(quizName, quiz);
            }
            else AskUser(quizName);
                
            
            Menu.Start();
        }
    }
}
