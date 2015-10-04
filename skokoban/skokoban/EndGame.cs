using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace sokoban
{
    public class EndGame
    {
        private int points;
        private Timer timerPauseMenu;
        private Object writelock;
        private int currentOptionPosition;
        private ConsoleKeyInfo checkKey;
        private String name;
        private Menu menu;
        public EndGame(int points)
        {
            this.points = points;
            name = "";
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
                else if (checkKey.Key == ConsoleKey.Backspace)
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
                        if (name.Count() < 10)
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

        private void saveRanking(string name, int points)
        {
            RankingItem newItem = new RankingItem(name, points);
            String fileName = @"ranking.txt";
            System.IO.StreamWriter file;
            if (System.IO.File.Exists(fileName))
            {

                file = new System.IO.StreamWriter(fileName, true);
                file.WriteLine("{0} {1}", newItem.name, newItem.score);
            }
            else
            {
                System.IO.File.Create(fileName).Close();
                file = new System.IO.StreamWriter(fileName, true);
                file.WriteLine("{0} {1}", newItem.name, newItem.score);
            }

            file.Close();


        }

        private void selectedAction(int select)
        {
            switch (select)
            {
                case 0:
                    saveRanking(name, points);
                    timerPauseMenu.Stop();
                    menu = new Menu();
                    menu.run();
                    break;
                case 1:
                    timerPauseMenu.Stop();
                    menu = new Menu();
                    menu.run();
                    break;
            }
        }
    }
}
