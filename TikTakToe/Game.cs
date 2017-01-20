﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TikTakToe
{
    //Custom helper types
    enum sign { X, O };
    struct boardCoordinate { public int row; public int column; }

    class Game
    {
        //Initial values for the gameplay
        static string[,] gameBoard = new string[3, 3];
        static sign currentSign = sign.X;
        const int MAX_NUMBER_OF_TURNS = 9; //3 rows by 3 columns
        static int numberOfTurnsMade = 0;

        //The gameplay method
        public static void Start()
        {
            Draw.InitialGameBoard(gameBoard);

            while (true)
            {
                numberOfTurnsMade ++;

                //Print prompt and receive coordinates of the turn
                var coordinates = ReceiveCoordinates(currentSign);                
                gameBoard[coordinates.row, coordinates.column] = currentSign.ToString();

                Draw.CurrentGameBoard(gameBoard);
                ChangeCurrentSign();

                if(IsGameOver()) break;
            }

            //Output the final board and result of the game
        }

        static boardCoordinate ReceiveCoordinates(sign currentSign)
        {
            string rawCoordinates;
            boardCoordinate coordinates;
            bool isCellEmpty = false;
            bool isRightFormat = false;

            do
            {
                do
                {
                    Console.Write("\n  Enter coordinates of your move. {0}: ", currentSign);
                    rawCoordinates = Console.ReadLine();

                    if (!CheckCoordinates(rawCoordinates))
                        Console.WriteLine("\n  Invalid format or out of range. Please try again.");
                    else
                        isRightFormat = true;
                }
                while (!isRightFormat);

                coordinates = ParseCoordinates(rawCoordinates);

                if (gameBoard[coordinates.row, coordinates.column] != " ")
                    Console.WriteLine("\n  This cell is already occupied. Please try again.");
                else
                    isCellEmpty = true;

            } while (!isCellEmpty);
            
            return coordinates;
        }

        static bool CheckCoordinates(string rawCoordinates)
        {
            return Regex.Match(rawCoordinates, @"[012][ ,\.][012]").Success;
        }

        static boardCoordinate ParseCoordinates(string rawCoordinates)
        {
            var coordinate = new boardCoordinate();

            coordinate.row = int.Parse(rawCoordinates.ToCharArray()[0].ToString());
            coordinate.column = int.Parse(rawCoordinates.ToCharArray()[2].ToString());

            return coordinate;
        }

        static bool IsGameOver()
        {
            if (numberOfTurnsMade >= MAX_NUMBER_OF_TURNS)
            {
                Console.WriteLine("\nGame over!\n");
                return true;
            }
                

            else return false;
        }

        static void ChangeCurrentSign()
        {
            if (currentSign == sign.X)
                currentSign = sign.O;
            else if (currentSign == sign.O)
                currentSign = sign.X;
        }
    }
}
