using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    class Ranking
    {
        public void printRanking()
        {
            Menu.timerStop();
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorTop = 0;

            Constants.printFrame();

            int cursorTopPosition = 2;

            foreach (string line in Constants.title)
            {
                Console.CursorTop = cursorTopPosition;
                Console.CursorLeft = Console.WindowWidth / 4;
                Console.WriteLine(line);
                cursorTopPosition++;
            }

            Console.CursorTop = Console.CursorTop + 1;

            foreach (string line in Constants.menuItemRanking)
            {
                Console.CursorLeft = 57;
                Console.WriteLine(line);
            }
            
            Constants.printRankingFrame();

            readText();
        }

        public void readText()
        {
            Console.SetCursorPosition(10,10);
            string line;
            String fileName = @"ranking.txt";
            System.IO.StreamReader file;

            if(System.IO.File.Exists(fileName))
            {
                file = new System.IO.StreamReader(fileName);
            }
            else
            {
                System.IO.File.Create(fileName).Close();
                file = new System.IO.StreamReader(fileName);
            }

            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                Console.CursorLeft = 10;
            }

            file.Close();
            System.Console.ReadLine();
        }
    }
}
