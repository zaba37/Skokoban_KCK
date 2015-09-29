using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace sokoban
{
    class Menu
    {
        private String[] title;
        private String[] menuItemNewGame;
        private String[] menuItemRanking;
        private String[] menuItemExit;
        private int[] menuItemPrintPositions;
        private int currentCursorPosition;
        private static System.Timers.Timer timer;
        private ConsoleKeyInfo checkKey;

        public Menu()
        {
            currentCursorPosition = 0;

            menuItemPrintPositions = new int[3];
            menuItemPrintPositions[0] = 14;
            menuItemPrintPositions[1] = 21;
            menuItemPrintPositions[2] = 29;

            timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            checkKey = new ConsoleKeyInfo();

            title = new String[]
            {
                   @"  ______    ______   __    __   ______   _______    ______   __    __ ",
                   @" /      \  /      \ |  \  /  \ /      \ |       \  /      \ |  \  |  \",
                   @"|  $$$$$$\|  $$$$$$\| $$ /  $$|  $$$$$$\| $$$$$$$\|  $$$$$$\| $$\ | $$",
                   @"| $$___\$$| $$  | $$| $$/  $$ | $$  | $$| $$__/ $$| $$__| $$| $$$\| $$",
                   @" \$$    \ | $$  | $$| $$  $$  | $$  | $$| $$    $$| $$    $$| $$$$\ $$",
                   @" _\$$$$$$\| $$  | $$| $$$$$\  | $$  | $$| $$$$$$$\| $$$$$$$$| $$\$$ $$",
                   @"|  \__| $$| $$__/ $$| $$ \$$\ | $$__/ $$| $$__/ $$| $$  | $$| $$ \$$$$",
                   @" \$$    $$ \$$    $$| $$  \$$\ \$$    $$| $$    $$| $$  | $$| $$  \$$$",
                   @"  \$$$$$$   \$$$$$$  \$$   \$$  \$$$$$$  \$$$$$$$  \$$   \$$ \$$   \$$"
            };

            menuItemNewGame = new String[]
            {
                     @" _   _                  _____                      ",
                     @"| \ | |                / ____|                     ",
                     @"|  \| | _____      __ | |  __  __ _ _ __ ___   ___ ",
                     @"| . ` |/ _ \ \ /\ / / | | |_ |/ _` | '_ ` _ \ / _ \",
                     @"| |\  |  __/\ V  V /  | |__| | (_| | | | | | |  __/",
                     @"|_| \_|\___| \_/\_/    \_____|\__,_|_| |_| |_|\___|"
            };

            menuItemRanking = new String[]
            {
                    @" _____             _    _             ",
                    @"|  __ \           | |  (_)            ",
                    @"| |__) |__ _ _ __ | | ___ _ __   __ _ ",
                    @"|  _  // _` | '_ \| |/ / | '_ \ / _` |",
                    @"| | \ \ (_| | | | |   <| | | | | (_| |",
                    @"|_|  \_\__,_|_| |_|_|\_\_|_| |_|\__, |",
                    @"                                 __/ |",
                    @"                                |___/ "
            };

            menuItemExit = new String[]
            {
                    @" ______          _   _   ",
                    @"|  ____|        (_) | |  ",
                    @"| |__    __  __  _  | |_ ",
                    @"|  __|   \ \/ / | | | __|",
                    @"| |____   >  <  | | | |_ ",
                    @"|______| /_/\_\ |_|  \__|"
            };
            run();
        }

        public void run()
        {
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (string line in title)
            {
                Console.WriteLine(String.Format("{0," + 110 + "}", line));
            }

            printMenuItem(0);
            printMenuItem(1);
            printMenuItem(2);

            do
            {
                //while (Console.KeyAvailable == false) Thread.Sleep(250); // Loop until input is entered.
                checkKey = Console.ReadKey(true);

                if (checkKey.Key == ConsoleKey.W)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    printMenuItem(currentCursorPosition);

                    if (currentCursorPosition == 0)
                    {
                        currentCursorPosition = 2;
                    }
                    else
                    {
                        currentCursorPosition--;
                    }
                }
                else if (checkKey.Key == ConsoleKey.S)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    printMenuItem(currentCursorPosition);

                    if (currentCursorPosition == 2)
                    {
                        currentCursorPosition = 0;
                    }
                    else
                    {
                        currentCursorPosition++;
                    }
                }
            } while (checkKey.Key != ConsoleKey.X);
        }

        private void printMenuItem(int select)
        {
            switch (select)
            {
                case 0:
                    Console.CursorTop = menuItemPrintPositions[0];
                    foreach (string line in menuItemNewGame)
                    {
                        Console.WriteLine(String.Format("{0," + 104 + "}", line));
                    }
                    break;
                case 1:
                    Console.CursorTop = menuItemPrintPositions[1];
                    foreach (string line in menuItemRanking)
                    {
                        Console.WriteLine(String.Format("{0," + 98 + "}", line));
                    }
                    break;
                case 2:
                    Console.CursorTop = menuItemPrintPositions[2];
                    foreach (string line in menuItemExit)
                    {
                        Console.WriteLine(String.Format("{0," + 92 + "}", line));
                    }
                    break;
            }
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (Console.ForegroundColor == ConsoleColor.Yellow)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            printMenuItem(currentCursorPosition);
        }
    }
}
