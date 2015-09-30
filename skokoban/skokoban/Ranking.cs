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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorTop = 0;

            for (int i = 0; i < 159; i++)
            {
                Console.Write("▓");
            }

            Console.Write("\n");

            for (int i = 0; i < 47; i++)
            {
                Console.WriteLine("▓                                                                                                                                                             ▓");
            }

            for (int i = 0; i < 159; i++)
            {
                Console.Write("▓");
            }

            readText();
        }

        public void readText()
        {
            Console.SetCursorPosition(10,10);
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"text.txt");
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
