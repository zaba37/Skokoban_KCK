using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace sokoban
{
    class EndGame
    {
        private int points;
        private Timer timerPauseMenu;
        private Object writelock;
        private int currentOptionPosition;
        private ConsoleKeyInfo checkKey;
        private String name;

        public EndGame(int points)
        {
            this.points = points;
            currentOptionPosition = 0;
            writelock = new Object();
            timerPauseMenu = new Timer(500);
            timerPauseMenu.AutoReset = true;
            timerPauseMenu.Elapsed += (s, e) => timeEvent(e);
        }

        public void run()
        {
            checkKey = new ConsoleKeyInfo();
            Constants.printGameOverScreen();
            timerPauseMenu.Start();

            while (true)
            {
                checkKey = Console.ReadKey(true);

                if (checkKey.Key == ConsoleKey.UpArrow)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    printMenuItem(currentOptionPosition);

                    if (currentOptionPosition == 0)
                    {
                        currentOptionPosition = 1;
                    }
                    else
                    {
                        currentOptionPosition--;
                    }
                }
                else if (checkKey.Key == ConsoleKey.DownArrow)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    printMenuItem(currentOptionPosition);

                    if (currentOptionPosition == 1)
                    {
                        currentOptionPosition = 0;
                    }
                    else
                    {
                        currentOptionPosition++;
                    }
                }
                else if (checkKey.Key == ConsoleKey.Enter)
                {
                    selectedAction(currentOptionPosition);
                }
                else if(checkKey.Key == ConsoleKey.Backspace)
                {
                    lock (writelock)
                    {
                        if (name.Length != 0)
                        {
                            name = name.Remove(name.Length - 1);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.CursorLeft = 63;
                            Console.CursorTop = 26;
                            Console.Write(name + " ");
                        }
                    }
                }
                else
                {
                    lock (writelock)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.CursorLeft = 63;
                        Console.CursorTop = 26;
                        name += checkKey.Key;
                        Console.Write(name);
                    }
                }
            }
        }

        private void timeEvent(ElapsedEventArgs e)
        {
            lock (writelock)
            {

                if (Console.ForegroundColor == ConsoleColor.Yellow)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                printMenuItem(currentOptionPosition);
            }
        }

        private void printMenuItem(int select)
        {
            switch (select)
            {
                case 0:
                    Constants.printSave();
                    break;
                case 1:
                    Constants.printExitInEnd();
                    break;
            }
        }

        private void selectedAction(int select)
        {
            switch (select)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
    }
}
