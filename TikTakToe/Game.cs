using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Game
    {
        enum sign {X, O};
        static sign currentSign = sign.X;
        static char[,] gameBoard = new char[3, 3];

        public static void Start()
        {
            InitializeGameBoard();
            PrintGameBoard();

            while (true)
            {
                //Print prompt and receive coordinates of the turn
                Console.WriteLine("Enter coordinates. {0}:_", currentSign);
                string coordinates = Console.ReadLine();

                UpdateCurrentBoard(currentSign, coordinates);
                gameBoard[1, 1] = 'X';
                PrintGameBoard();
                ChangeCurrentSign();
            }
        }

        static void PrintGameBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == ' ')
                    {
                        Console.Write("{0},{1} | ", i, j);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(gameBoard[i, j]);
                        Console.ResetColor();
                        Console.Write("  |  ");
                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine("______________\n");
            }
        }

        static void UpdateCurrentBoard(sign currentSign, string coordinates)
        {

        }

        static void ChangeCurrentSign()
        {
            if (currentSign == sign.X)
                currentSign = sign.O;
            else if (currentSign == sign.O)
                currentSign = sign.X;
        }

        static void InitializeGameBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = ' ';
                }
            }
        }
    }
}
