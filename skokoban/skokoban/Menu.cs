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
        Game game = new Game();
         
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
        }

        public void run()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorTop = 0;
            //Console.WriteLine("###############################################################################################################################################################");

            for (int i = 0; i < 159; i++)
            {
                Console.Write("▓");
            }

            Console.Write("\n");

            for (int i = 0; i < 47; i++)
            {
                Console.WriteLine("▓                                                                                                                                                           ▓");
            }

            for (int i = 0; i < 159; i++)
            {
                Console.Write("▓");
            }

            // Console.WriteLine("▓▓#############################################################################################################################################################");

            //  Console.WriteLine("#                                                                                                                                                             #");
            //  Console.WriteLine("#                                                                                                                                                             #");

            int cursorTopPosition = 2;


            foreach (string line in title)
            {
                Console.CursorTop = cursorTopPosition;
                Console.CursorLeft = Console.WindowWidth / 4;
                Console.WriteLine(line);
                cursorTopPosition++; 
            }

            printMenuItem(0);
            printMenuItem(1);
            printMenuItem(2);

            do
            {
                checkKey = Console.ReadKey(true);

                if (checkKey.Key == ConsoleKey.W || checkKey.Key == ConsoleKey.UpArrow)
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
                else if (checkKey.Key == ConsoleKey.S || checkKey.Key == ConsoleKey.DownArrow)
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
                }else if (checkKey.Key == ConsoleKey.Enter)
                {
                    selectedAction(currentCursorPosition);
                }
            } while (true);
        }

        private void printMenuItem(int select)
        {
            switch (select)
            {
                case 0:
                    Console.CursorTop = menuItemPrintPositions[0];
                    foreach (string line in menuItemNewGame)
                    {
                        Console.CursorLeft = 50;
                        Console.WriteLine(line);
                    }
                    break;
                case 1:
                    Console.CursorTop = menuItemPrintPositions[1];
                    foreach (string line in menuItemRanking)
                    {
                        Console.CursorLeft = 57;
                        Console.WriteLine(line);
                    }
                    break;
                case 2:
                    Console.CursorTop = menuItemPrintPositions[2];
                    foreach (string line in menuItemExit)
                    {
                        Console.CursorLeft = 63;
                        Console.WriteLine(line);
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

        private void selectedAction(int select)
        {
            switch (select)
            {
                case 0:
                   // game.initMap(); //Start new game                   
                    break;
                case 1:
                    //Show ranking
                    break;
                case 2:
                    System.Environment.Exit(1);
                    break;
            }
        }
    }
}
