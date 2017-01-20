using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Draw
    {
        public static void Welcome()
        {
            //Text generated @ patorjk.com/software/taag

            string welcome = 
                
                @"
 __      __        __                                  __             
/  \    /  \ ____ |  |   ____  ____   _____   ____   _/  |_  ____     
\   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \  \   __\/  _ \    
 \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/   |  | (  <_> )   
  \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >  |__|  \____/    
       \/       \/          \/            \/     \/                   
___________.__ __   ___________       __   ___________             ._.
\__    ___/|__|  | _\__    ___/____  |  | _\__    ___/___   ____   | |
  |    |   |  |  |/ / |    |  \__  \ |  |/ / |    | /  _ \_/ __ \  | |
  |    |   |  |    <  |    |   / __ \|    <  |    |(  <_> )  ___/   \|
  |____|   |__|__|_ \ |____|  (____  /__|_ \ |____| \____/ \___  >  __
                   \/              \/     \/                   \/   \/

";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(welcome);
            Console.ResetColor();
        }

        public static void InitialGameBoard(string[,] gameBoard)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = " ";
                }
            }

            CurrentGameBoard(gameBoard);
        }

        public static void CurrentGameBoard(string[,] gameBoard)
        {
            Console.Clear();
            Welcome();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("             ");

                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == " ")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0},{1}", i, j);
                        Console.ResetColor();
                        if (j < 2) Console.Write("  |  ");
                    }
                    else if (gameBoard[i, j] == sign.X.ToString())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + gameBoard[i, j] + " ");
                        Console.ResetColor();
                        if (j < 2) Console.Write("  |  ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" " + gameBoard[i, j] + " ");
                        Console.ResetColor();
                        if (j < 2) Console.Write("  |  ");
                    }
                }
                if (i < 2) Console.WriteLine("\n            ___________________\n");
            }
            Console.WriteLine("\n");
        }
    }
}
