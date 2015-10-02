using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
//using System.Threading;


namespace sokoban
{
    public class Game
    {
        private String[] hero;
        private String[] box;
        private String[] wall;
        private String[] point;
        private String[] floor;
        private ConsoleKeyInfo checkKey;
        private List<PointPosition> pointsList;
        private int numberSteps;
        private int PreviousNumberSteps;
        private int NumberMovedBoxes;
        private int previousNumberMovedBoxes;
        private int mapNumber;

        DateTime startTime;

        public Game(string mapPath)
        {
            Hero heroObject = new Hero();
            hero = heroObject.graphics;

            Box boxObject = new Box();
            box = boxObject.graphics;

            Point pointObject = new Point();
            point = pointObject.graphics;

            Floor floorObject = new Floor();
            floor = floorObject.graphics;

            Wall wallObject = new Wall();
            wall = wallObject.graphics;

            mapNumber = 1;
            initMap(mapPath,true);

        }
        private List<List<int>> readFile(string path)
        {
            List<List<int>> intMap = null; ;
            try
            {
                var lines = File.ReadAllLines(path);
                var map = lines.Select(l => l.Split(' ')).ToList();
                intMap = map.Select(l => l.Select(i => int.Parse(i)).ToList()).ToList();
                return intMap;
            }
            catch
            {
                Environment.Exit(0);
            }
            return intMap;
        }

        private void printInformation()
        {
            Console.CursorTop = 4;
            Console.CursorLeft = 7;
            Console.Write("Ilosc krokow: 0");
            Console.CursorTop = 6;
            Console.CursorLeft = 7;
            Console.Write("Ilosc przesuniec skrzynek: 0");
            Console.CursorTop = 8;
            Console.CursorLeft = 7;
            Console.Write("Czas: 0");
        }


        private void initMap(string pathFileMap,bool firstStart)
        {
            Console.Clear();
            numberSteps = 0;
            PreviousNumberSteps = 0;
            NumberMovedBoxes = 0;
            previousNumberMovedBoxes = 0;
            Constants.printFrame();
            Constants.printFrameForCounters();
            printInformation();
            List<List<int>> map = new List<List<int>>();
            List<List<int>> ReadNumbers = readFile(pathFileMap);        
            pointsList = new List<PointPosition>();
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

            drawMap(ReadNumbers, map);

            Timer t = new Timer(100);
            t.AutoReset = true;
            t.Elapsed += (s, e) => UpdateTime(e);
            startTime = DateTime.Now;
            //t.Start();
            if(firstStart==true)
                play(ReadNumbers);
        }

        private void UpdateTime(ElapsedEventArgs e)
        {
            var elapsedTime = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorTop = 8;
            Console.CursorLeft = 13;

            Console.Write(elapsedTime);
        }


        //POSTAC: 5
        //PUDELKO:6
        //PODLOGA:3
        //SCIANA:2
        //PUNKT:4




        private void drawMap(List<List<int>> CurrentMap, List<List<int>> previousState)
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


        private int[] findHeroPosition(List<List<int>> numberMap)
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

        private List<List<int>> copyMap(List<List<int>> map1)
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


        private List<PointPosition> findPositionPoints(List<List<int>> map)
        {
            List<PointPosition> positionsList = new List<PointPosition>();
            for (int i = 0; i < map.Count(); i++)
            {

                for (int j = 0; j < map[i].Count(); j++)
                {
                    if (map[i][j] == 4)
                    {
                        PointPosition newPosition = new PointPosition(i, j);
                        positionsList.Add(newPosition);
                    }
                }
            }
            return positionsList;
        }

        private List<List<List<int>>> refreshLists(List<List<int>> map, List<List<int>> previousState, int up, int down, int left, int right, List<PointPosition> listPoints)
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
                    numberSteps++;
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
                        numberSteps++;
                        NumberMovedBoxes++;
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
                    numberSteps++;
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
                    numberSteps++;
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
                        numberSteps++;
                        NumberMovedBoxes++;
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
                    numberSteps++;
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
                    numberSteps++;
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
                        numberSteps++;
                        NumberMovedBoxes++;
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
                    numberSteps++;
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
                    numberSteps++;
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
                        numberSteps++;
                        NumberMovedBoxes++;
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
                    numberSteps++;
                }
            }


            foreach (PointPosition p in listPoints)
            {
                if (map[p.X][p.Y] == 3)
                    map[p.X][p.Y] = 4;
            }

            return toReturn;
        }

        private int numberSetBoxes(List<List<int>> map, List<PointPosition> listPoints)
        {
            int number = 0;
            foreach (PointPosition p in listPoints)
            {
                if (map[p.X][p.Y] == 6)
                    number++;
            }
            return number;
        }

        private bool CheckEndRound(int numberSetBox, List<PointPosition> PointsPositionList)
        {
            bool endRound = false;
            if (numberSetBox == PointsPositionList.Count())
                endRound = true;

            return endRound;
        }

        private void endRound()
        {
            Console.Clear();
            int number = mapNumber;
            mapNumber++;
            initMap("sokoban_" + mapNumber + ".txt",false);
        }

        private void printNumberSteps(int number, int previousNumber)
        {
            if (number != previousNumber)
            {
                previousNumber = number;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorTop = 4;
                Console.CursorLeft = 21;
                Console.Write(number.ToString());
            }

        }

        private void printNumberMovedBoxes(int number, int previousNumber)
        {
            if (number != previousNumber)
            {
                previousNumberMovedBoxes = number;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorTop = 6;
                Console.CursorLeft = 34;
                Console.Write(number.ToString());
            }

        }

        private void play(List<List<int>> map)
        {
            checkKey = new ConsoleKeyInfo();
            List<List<int>> Map = map;
            List<List<int>> previousStateMap = copyMap(Map);
            List<List<List<int>>> helpList;
            int[] heroPosition = findHeroPosition(Map);
            List<PointPosition> PointsPositionList = findPositionPoints(Map);
            int SetBoxes = 0;
            do
            {
                checkKey = Console.ReadKey(true);
                if (checkKey.Key == ConsoleKey.W || checkKey.Key == ConsoleKey.UpArrow)
                {
                    helpList = refreshLists(Map, previousStateMap, 1, 0, 0, 0, PointsPositionList);
                    drawMap(helpList[0], helpList[1]);
                    printNumberSteps(numberSteps, PreviousNumberSteps);
                    printNumberMovedBoxes(NumberMovedBoxes, previousNumberMovedBoxes);
                    SetBoxes = numberSetBoxes(Map, PointsPositionList);
                    if (CheckEndRound(SetBoxes, PointsPositionList))
                    {
                        endRound();
                        Map = readFile("sokoban_" + mapNumber + ".txt");
                        previousStateMap = copyMap(Map);
                        heroPosition = findHeroPosition(Map);
                        PointsPositionList = findPositionPoints(Map);
                    }

                }
                if (checkKey.Key == ConsoleKey.S || checkKey.Key == ConsoleKey.DownArrow)
                {
                    helpList = refreshLists(Map, previousStateMap, 0, 1, 0, 0, PointsPositionList);
                    drawMap(helpList[0], helpList[1]);
                    printNumberSteps(numberSteps, PreviousNumberSteps);
                    printNumberMovedBoxes(NumberMovedBoxes, previousNumberMovedBoxes);
                    SetBoxes = numberSetBoxes(Map, PointsPositionList);
                    if (CheckEndRound(SetBoxes, PointsPositionList))
                    {
                        endRound();
                        Map = readFile("sokoban_" + mapNumber + ".txt");
                        previousStateMap = copyMap(Map);
                        heroPosition = findHeroPosition(Map);
                        PointsPositionList = findPositionPoints(Map);
                    }
                }
                if (checkKey.Key == ConsoleKey.A || checkKey.Key == ConsoleKey.LeftArrow)
                {
                    helpList = refreshLists(Map, previousStateMap, 0, 0, 1, 0, PointsPositionList);
                    drawMap(helpList[0], helpList[1]);
                    printNumberSteps(numberSteps, PreviousNumberSteps);
                    printNumberMovedBoxes(NumberMovedBoxes, previousNumberMovedBoxes);
                    SetBoxes = numberSetBoxes(Map, PointsPositionList);
                    if (CheckEndRound(SetBoxes, PointsPositionList))
                    {
                        endRound();
                        Map = readFile("sokoban_" + mapNumber + ".txt");
                        previousStateMap = copyMap(Map);
                        heroPosition = findHeroPosition(Map);
                        PointsPositionList = findPositionPoints(Map);
                    }
                }
                if (checkKey.Key == ConsoleKey.D || checkKey.Key == ConsoleKey.RightArrow)
                {
                    helpList = refreshLists(Map, previousStateMap, 0, 0, 0, 1, PointsPositionList);
                    drawMap(helpList[0], helpList[1]);
                    printNumberSteps(numberSteps, PreviousNumberSteps);
                    printNumberMovedBoxes(NumberMovedBoxes, previousNumberMovedBoxes);
                    SetBoxes = numberSetBoxes(Map, PointsPositionList);
                    if (CheckEndRound(SetBoxes, PointsPositionList))
                    {
                        endRound();
                        Map = readFile("sokoban_" + mapNumber + ".txt");
                        previousStateMap = copyMap(Map);
                        heroPosition = findHeroPosition(Map);
                        PointsPositionList = findPositionPoints(Map);
                    }
                }
            } while (true);
        
        
        }

    }
}
