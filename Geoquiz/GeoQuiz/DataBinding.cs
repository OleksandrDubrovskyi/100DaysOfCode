using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz
{
    /// <summary>
    /// Class used for file IO
    /// </summary>
    class DataBinding
    {
        public static List<quizItem> LoadRecords(string quizName)
        {
            string dirPath = @"C:\QuizMachine\" + quizName;
            string filePath = dirPath + @"\entries.txt";
            var quiz = new List<quizItem>(15);

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            if (File.Exists(filePath))
            {
                var stringsFromFile = File.ReadAllLines(filePath);

                foreach (var item in stringsFromFile)
                {
                    var result = item.Split('>');
                    var entry = new quizItem();
                    entry.question = result[0];
                    entry.answer = result[1];
                    quiz.Add(entry);
                }

                /*
                for (int i = 0; i < stringsFromFile.Length; i++)
                {
                    var result = stringsFromFile[i].Split('>');
                    var entry = new quizItem();
                    entry.question = result[0];
                    entry.answer = result[1];
                    quiz.Add(entry);
                }
                */
            }
            return quiz;
        }

        public static void SubmitRecords(List<quizItem> quiz, string quizName)
        {
            string dirPath = @"C:\QuizMachine\" + quizName;
            string filePath = dirPath + @"\entries.txt";

            int size = quiz.Count();
            var stringArray = new string[size];
            string tempString;

            for (int i = 0; i < size; i++)
            {
                tempString = quiz[i].question + ">" + quiz[i].answer;
                stringArray[i] = tempString;
            }
            File.WriteAllLines(filePath, stringArray);
        }
    }
}
