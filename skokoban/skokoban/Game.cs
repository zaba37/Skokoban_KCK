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
        private List<List<int>> map = new List<List<int>>();


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

            for (int i = 0; i < ReadNumbers.Count(); i++)
            {
                List<int> initList = new List<int>();
                for (int j = 0; j < ReadNumbers[i].Count(); j++)
                {
                    initList.Add(-1);
                }
                map.Add(initList);
            }
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
            drawMap(ReadNumbers, map);
            play(ReadNumbers);
        }

        //POSTAC: 5
        //PUDELKO:6
        //PODLOGA:3
        //SCIANA:2
        //PUNKT:4


        public void drawMap(List<List<int>> CurrentMap, List<List<int>> previousState)
        {
            bool writed = false;
            Console.CursorLeft = 57;
            Console.CursorTop = 7;
            for (int i = 0; i < CurrentMap.Count; i++)
            {
                for (int k = 0; k < hero.Count(); k++)
                {
                    for (int j = 0; j < CurrentMap[i].Count; j++)
                    {
                        if (CurrentMap[i][j] == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(hero[k]);
                            writed = true;
                        }

                        if (CurrentMap[i][j] == 3 && CurrentMap[i][j] != previousState[i][j])
                        {
                            Console.Write(floor[k]);
                            writed = true;
                        }
                        if (CurrentMap[i][j] == 6 && CurrentMap[i][j] != previousState[i][j])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(box[k]);
                            writed = true;
                        }

                        if (CurrentMap[i][j] == 4 && CurrentMap[i][j] != previousState[i][j])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(point[k]);
                            writed = true;
                        }
                        if (CurrentMap[i][j] == 2 && CurrentMap[i][j] != previousState[i][j])
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(wall[k]);
                            writed = true;
                        }

                        if (writed == false && Console.CursorLeft <= 57 + (CurrentMap[0].Count() * hero.Count()))
                            Console.CursorLeft = Console.CursorLeft + hero.Count();
                        writed = false;

                    }
                    Console.Write(Environment.NewLine);
                    Console.CursorLeft = 57;
                }

            }
        }


        int[] findHeroPosition(List<List<int>> numberMap)
        {
            int[] position = new int[2];
            for (int i = 0; i < numberMap.Count(); i++)
            {
                for (int j = 0; j < numberMap[i].Count(); j++)
                {
                    if (numberMap[i][j] == 5)
                    {
                        position[0] = i;
                        position[1] = j;
                        return position;
                    }
                }
            }
            return position;
        }

        List<List<int>> copyMap(List<List<int>> map1)
        {
            List<List<int>> mapToReturn = new List<List<int>>();
            for (int i = 0; i < map1.Count(); i++)
            {
                List<int> initList = new List<int>();
                for (int j = 0; j < map1[i].Count(); j++)
                {
                    initList.Add(map1[i][j]);
                }
                mapToReturn.Add(initList);
            }
            return mapToReturn;
        }


        List<List<List<int>>> refreshLists(List<List<int>> map, List<List<int>> previousState, int up, int down, int left, int right)
        {
            List<List<List<int>>> toReturn = new List<List<List<int>>>();

            if (up != 0)
            {
                int[] heroPosition = findHeroPosition(map);
                if (map[heroPosition[0] - 1][heroPosition[1]] == 2) //gdy na gorze bedzie sciana
                {
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
                if (map[heroPosition[0] - 1][heroPosition[1]] == 3) //gdy na gorze bedzie podloga
                {
                    previousState = copyMap(map);
                    map[heroPosition[0]][heroPosition[1]] = 3;
                    map[heroPosition[0] - 1][heroPosition[1]] = 5;
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
                if (map[heroPosition[0] - 1][heroPosition[1]] == 6) //gdy na gorze bedzie skrzynka
                {
                    if (map[heroPosition[0] - 2][heroPosition[1]] == 3 || map[heroPosition[0] - 2][heroPosition[1]] == 4) //sprawdz czy mozna przesunac skrzynke(podloga lub punkt)
                    {
                        previousState = copyMap(map);
                        map[heroPosition[0]][heroPosition[1]] = 3;
                        map[heroPosition[0] - 1][heroPosition[1]] = 5;
                        map[heroPosition[0] - 2][heroPosition[1]] = 6;
                        toReturn.Add(map);
                        toReturn.Add(previousState);
                    }
                    else
                    {
                        toReturn.Add(map);
                        toReturn.Add(previousState);
                    }
                }

                if (map[heroPosition[0] - 1][heroPosition[1]] == 4) //gdy na gorze bedzie punkt
                {
                    previousState = copyMap(map);
                    map[heroPosition[0]][heroPosition[1]] = 3;
                    map[heroPosition[0] - 1][heroPosition[1]] = 5;
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
            }




            if (down != 0)
            {
                int[] heroPosition = findHeroPosition(map);
                if (map[heroPosition[0] + 1][heroPosition[1]] == 2) //gdy na dole bedzie sciana
                {
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
                if (map[heroPosition[0] + 1][heroPosition[1]] == 3) //gdy na dole bedzie podloga
                {
                    previousState = copyMap(map);
                    map[heroPosition[0]][heroPosition[1]] = 3;
                    map[heroPosition[0] + 1][heroPosition[1]] = 5;
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
                if (map[heroPosition[0] + 1][heroPosition[1]] == 6) //gdy na dole bedzie skrzynka
                {
                    if (map[heroPosition[0] + 2][heroPosition[1]] == 3 || map[heroPosition[0] + 2][heroPosition[1]] == 4) //sprawdz czy mozna przesunac skrzynke(podloga lub punkt)
                    {
                        previousState = copyMap(map);
                        map[heroPosition[0]][heroPosition[1]] = 3;
                        map[heroPosition[0] + 1][heroPosition[1]] = 5;
                        map[heroPosition[0] + 2][heroPosition[1]] = 6;
                        toReturn.Add(map);
                        toReturn.Add(previousState);
                    }
                    else
                    {
                        toReturn.Add(map);
                        toReturn.Add(previousState);
                    }
                }

                if (map[heroPosition[0] + 1][heroPosition[1]] == 4) //gdy na dole bedzie punkt
                {
                    previousState = copyMap(map);
                    map[heroPosition[0]][heroPosition[1]] = 3;
                    map[heroPosition[0] + 1][heroPosition[1]] = 5;
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
            }



            if (right != 0)
            {
                int[] heroPosition = findHeroPosition(map);
                if (map[heroPosition[0]][heroPosition[1] + 1] == 2) //gdy na prawo bedzie sciana
                {
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
                if (map[heroPosition[0]][heroPosition[1] + 1] == 3) //gdy na prawo bedzie podloga
                {
                    previousState = copyMap(map);
                    map[heroPosition[0]][heroPosition[1]] = 3;
                    map[heroPosition[0]][heroPosition[1] + 1] = 5;
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
                if (map[heroPosition[0]][heroPosition[1] + 1] == 6) //gdy na prawo bedzie skrzynka
                {
                    if (map[heroPosition[0]][heroPosition[1] + 2] == 3 || map[heroPosition[0]][heroPosition[1] + 2] == 4) //sprawdz czy mozna przesunac skrzynke(podloga lub punkt)
                    {
                        previousState = copyMap(map);
                        map[heroPosition[0]][heroPosition[1]] = 3;
                        map[heroPosition[0]][heroPosition[1] + 1] = 5;
                        map[heroPosition[0]][heroPosition[1] + 2] = 6;
                        toReturn.Add(map);
                        toReturn.Add(previousState);
                    }
                    else
                    {
                        toReturn.Add(map);
                        toReturn.Add(previousState);
                    }
                }

                if (map[heroPosition[0]][heroPosition[1] + 1] == 4) //gdy na prawo bedzie punkt
                {
                    previousState = copyMap(map);
                    map[heroPosition[0]][heroPosition[1]] = 3;
                    map[heroPosition[0]][heroPosition[1] + 1] = 5;
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
            }



            if (left != 0)
            {
                int[] heroPosition = findHeroPosition(map);
                if (map[heroPosition[0]][heroPosition[1] - 1] == 2) //gdy na lewo bedzie sciana
                {
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
                if (map[heroPosition[0]][heroPosition[1] - 1] == 3) //gdy na lewo bedzie podloga
                {
                    previousState = copyMap(map);
                    map[heroPosition[0]][heroPosition[1]] = 3;
                    map[heroPosition[0]][heroPosition[1] - 1] = 5;
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
                if (map[heroPosition[0]][heroPosition[1] - 1] == 6) //gdy na lewo bedzie skrzynka
                {
                    if (map[heroPosition[0]][heroPosition[1] - 2] == 3 || map[heroPosition[0]][heroPosition[1] - 2] == 4) //sprawdz czy mozna przesunac skrzynke(podloga lub punkt)
                    {
                        previousState = copyMap(map);
                        map[heroPosition[0]][heroPosition[1]] = 3;
                        map[heroPosition[0]][heroPosition[1] - 1] = 5;
                        map[heroPosition[0]][heroPosition[1] - 2] = 6;
                        toReturn.Add(map);
                        toReturn.Add(previousState);
                    }
                    else
                    {
                        toReturn.Add(map);
                        toReturn.Add(previousState);
                    }
                }

                if (map[heroPosition[0]][heroPosition[1] - 1] == 4) //gdy na lewo bedzie punkt
                {
                    previousState = copyMap(map);
                    map[heroPosition[0]][heroPosition[1]] = 3;
                    map[heroPosition[0]][heroPosition[1] - 1] = 5;
                    toReturn.Add(map);
                    toReturn.Add(previousState);
                }
            }


            return toReturn;
        }

        void play(List<List<int>> map)
        {
            var checkKey = new ConsoleKeyInfo();
            List<List<int>> Map = map;
            List<List<int>> previousStateMap = copyMap(Map);
            List<List<List<int>>> helpList;
            int[] heroPosition = findHeroPosition(Map);
            do
            {
                checkKey = Console.ReadKey(true);
                int[] tab = new int[5];

                if (checkKey.Key == ConsoleKey.W || checkKey.Key == ConsoleKey.UpArrow)
                {
                    helpList = refreshLists(Map, previousStateMap, 1, 0, 0, 0);
                    drawMap(helpList[0], helpList[1]);
                }
                if (checkKey.Key == ConsoleKey.S || checkKey.Key == ConsoleKey.DownArrow)
                {
                    helpList = refreshLists(Map, previousStateMap, 0, 1, 0, 0);
                    drawMap(helpList[0], helpList[1]);
                }
                if (checkKey.Key == ConsoleKey.A || checkKey.Key == ConsoleKey.LeftArrow)
                {
                    helpList = refreshLists(Map, previousStateMap, 0, 0, 1, 0);
                    drawMap(helpList[0], helpList[1]);
                }
                if (checkKey.Key == ConsoleKey.D || checkKey.Key == ConsoleKey.RightArrow)
                {
                    helpList = refreshLists(Map, previousStateMap, 0, 0, 0, 1);
                    drawMap(helpList[0], helpList[1]);
                }
            } while (true);
        }

    }
}
