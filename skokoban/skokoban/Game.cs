using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    public class Game
    {
        private String[] hero;
        private String[] box;
        private String[] wall;
        private String[] point;
        private String[] floor;
        private string[][] map;
        
        private List<List<int>> readFile(string path)
        {
            var lines = File.ReadAllLines(path);
            var map = lines.Select(l => l.Split(' ')).ToList();
            var intMap = map.Select(l => l.Select(i => int.Parse(i)).ToList()).ToList();
            return intMap;
        }


        public void initMap()
        {
            Console.Clear();
            Constants.printFrame();
            Constants.printFrameForCounters();

            List<List<int>> ReadNumbers = readFile("sokoban_1.txt");
            Console.CursorLeft = 57;
            Console.CursorTop = 7;
            
            hero = new String[]
            {
                    @" ☺ ",
                    @"┤█├",
                    @"┘ └"
            };

            box = new String[]
            {
                    @"[]]",
                    @"[]]",
                    @"[]]"
                 
            };

            wall = new String[]
            {
                    @"|||",
                    @"|||",
                    @"|||"
                 
            };

            point = new String[]
            {
                    @"---",
                    @"---",
                    @"---"
                 
            };

            floor = new String[]
            {
                    @"   ",
                    @"   ",
                    @"   "
                 
            };

            for (int i = 0; i < ReadNumbers.Count; i++)
            {
                for (int k = 0; k < hero.Count(); k++)
                {
                    for (int j = 0; j < ReadNumbers[i].Count; j++)
                    {
                        if (ReadNumbers[i][j] == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(hero[k]);
                        }

                        if (ReadNumbers[i][j] == 3)
                        {                           
                            Console.Write(floor[k]);
                        }
                        if (ReadNumbers[i][j] == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(box[k]);
                        }

                        if (ReadNumbers[i][j] == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(point[k]);
                        }
                        if (ReadNumbers[i][j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(wall[k]);
                        }

                    }
                    Console.Write(Environment.NewLine);
                    Console.CursorLeft = 57;
                }

            }
            Console.ReadKey();
        }
    }
}
