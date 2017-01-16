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
        public static string[] LoadFileNames()
        {
            string dirPath = @"C:\QuizMachine";
            int firstIndex = dirPath.Length + 1; //To retrieve only the filenames
                                                 //without path and extention

            var files = Directory.GetFiles(dirPath);

            for (int i = 0; i < files.Count(); i++)
            {
                int numberOfChars = (files[i].Length - dirPath.Length) - 5;
                string fileName = files[i].Substring(firstIndex, numberOfChars);
                files[i] = fileName;
            }

            return files;
        }

        public static List<quizItem> LoadRecords(string quizName)
        {
            string dirPath = @"C:\QuizMachine\";
            string filePath = dirPath + quizName + @"\.txt";
            var quiz = new List<quizItem>(15);

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            if (File.Exists(filePath))
            {
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
                tempString = quiz[i].question + "#" + quiz[i].answer;
                stringArray[i] = tempString;
            }
            File.WriteAllLines(filePath, stringArray);
        }
    }
}
