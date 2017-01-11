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

        static quizItem GetUsersQuestions()
        {
            quizItem usersQuestion = new quizItem();

            Console.WriteLine("Enter your question:");
            usersQuestion.question = Console.ReadLine();
            Console.WriteLine("Enter the answer:");
            usersQuestion.answer = Console.ReadLine();

            return usersQuestion;
        }

        static List<quizItem> CreateListOfQuestions()
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

        public static void receiveUsersInput()
        {
            CreateListOfQuestions();
            Menu.Start();
        }
    }
}
