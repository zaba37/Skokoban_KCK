using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Media;


namespace sokoban
{
    public class Game
    {
        private Hero heroObject;
        private Box boxObject;
        private Point pointObject;
        private Floor floorObject;
        private Wall wallObject;
        private List<List<int>> Map;
        private ConsoleKeyInfo checkKey;
        private List<PointPosition> pointsList;
        private int numberSteps;
        private int PreviousNumberSteps;
        private int NumberMovedBoxes;
        private int previousNumberMovedBoxes;
        private int mapNumber;
        private object writelock;
        private DateTime startTime;
        private Timer timer;
        private Timer timerPauseMenu;
        private bool pauseMenu = false;
        private int currentPositionInPauseMenu;
        private SoundPlayer typewriter;
        private String elapsedTime;
        private DateTime pauseTime;
        private bool isNewLevel;
        private int totalPoints;
        private int totalRounds;
        public Game(string mapPath)
        {
            totalPoints = 0;

            totalRounds = 8; //TU ILE MAP MA GRA TRZEBA WPISAC
            typewriter = Constants.getSoundPlayerInstance();
            typewriter.Stop();
            typewriter.SoundLocation = "step.wav";

            isNewLevel = true;

            currentPositionInPauseMenu = 0;

            timerPauseMenu = new Timer(500);
            timerPauseMenu.AutoReset = true;
            timerPauseMenu.Elapsed += (s, e) => pasueMenuTick(e);
            timerPauseMenu.Start();

            heroObject = new Hero();
            boxObject = new Box();
            pointObject = new Point();
            floorObject = new Floor();
            wallObject = new Wall();

            mapNumber = 1;
            writelock = new object();
            initMap(mapPath, true);
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
            Console.Write("Number of steps: " + numberSteps.ToString());
            Console.CursorTop = 6;
            Console.CursorLeft = 7;
            Console.Write("Number of shifts boxes: " + NumberMovedBoxes.ToString());
            Console.CursorTop = 8;
            Console.CursorLeft = 7;
            Console.Write("Time: " + (DateTime.Now - startTime).ToString(@"hh\:mm\:ss"));
        }


        private void initMap(string pathFileMap, bool firstStart)
        {
            if (mapNumber == 1)
            {
                Constants.printLevel(mapNumber);
                Console.ReadKey();
            }

            Console.Clear();
            numberSteps = 0;
            PreviousNumberSteps = 0;
            NumberMovedBoxes = 0;
            previousNumberMovedBoxes = 0;


            List<List<int>> map = new List<List<int>>();
            List<List<int>> ReadNumbers = readFile(pathFileMap);
            pointsList = new List<PointPosition>();
            lock (writelock)
            {
                Constants.printFrame();
                Constants.printFrameForCounters();
                startTime = DateTime.Now;
                printInformation();
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

                timer = new Timer(100);
                timer.AutoReset = true;
                timer.Elapsed += (s, e) => UpdateTime(e);
                startTime = DateTime.Now;
                timer.Start();
            }
            if (firstStart == true)
                play(ReadNumbers);

        }

        private void UpdateTime(ElapsedEventArgs e)
        {
            lock (writelock)
            {
                if (!pauseMenu)
                {
                    elapsedTime = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.CursorTop = 8;
                    Console.CursorLeft = 13;

                    Console.Write(elapsedTime);
                }
                else
                {
                    if (Console.ForegroundColor == ConsoleColor.Yellow)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    printMenuItem(currentPositionInPauseMenu);
                }
            }
        }


        private void pasueMenuTick(ElapsedEventArgs e)
        {
            lock (writelock)
            {
                if (pauseMenu)
                {
                    if (Console.ForegroundColor == ConsoleColor.Yellow)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    printMenuItem(currentPositionInPauseMenu);
                }
            }
        }

        //POSTAC: 5
        //PUDELKO:6
        //PODLOGA:3
        //SCIANA:2
        //PUNKT:4

        private void drawMap(List<List<int>> CurrentMap, List<List<int>> previousState)
        {
            lock (writelock)
            {
                bool writed = false;
                Console.CursorLeft = 57;
                Console.CursorTop = 7;
                for (int i = 0; i < CurrentMap.Count; i++)
                {
                    for (int k = 0; k < heroObject.getObject().Count(); k++)
                    {
                        for (int j = 0; j < CurrentMap[i].Count; j++)
                        {
                            if (CurrentMap[i][j] == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(heroObject.getObject()[k]);
                                writed = true;
                            }

                            if (CurrentMap[i][j] == 3 && CurrentMap[i][j] != previousState[i][j])
                            {
                                Console.Write(floorObject.getObject()[k]);
                                writed = true;
                            }
                            if (CurrentMap[i][j] == 6 && CurrentMap[i][j] != previousState[i][j])
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(boxObject.getObject()[k]);
                                writed = true;
                            }

                            if (CurrentMap[i][j] == 4 && CurrentMap[i][j] != previousState[i][j])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(pointObject.getObject()[k]);
                                writed = true;
                            }
                            if (CurrentMap[i][j] == 2 && CurrentMap[i][j] != previousState[i][j])
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(wallObject.getObject()[k]);
                                writed = true;
                            }

                            if (writed == false && Console.CursorLeft <= 57 + (CurrentMap[0].Count() * heroObject.getObject().Count()))
                                Console.CursorLeft = Console.CursorLeft + heroObject.getObject().Count();
                            writed = false;

                        }
                        Console.Write(Environment.NewLine);
                        Console.CursorLeft = 57;
                    }

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
                    typewriter.Play();
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
                        typewriter.Play();
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
                    typewriter.Play();
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
                    typewriter.Play();
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
                        typewriter.Play();
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
                    typewriter.Play();
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
                    typewriter.Play();
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
                        typewriter.Play();
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
                    typewriter.Play();
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
                    typewriter.Play();
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
                        typewriter.Play();
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
                    typewriter.Play();
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
            timer.Stop();
            DateTime ElapsedTime = DateTime.Parse(elapsedTime);
            int totalSeconds = (ElapsedTime.Hour * 360) + (ElapsedTime.Minute * 60) + ElapsedTime.Second;
            if (totalSeconds < 20)
                totalPoints = totalPoints + 100;
            if (totalSeconds >= 20 && totalSeconds <= 40)
                totalPoints = totalPoints + 50;
            if (totalSeconds > 40)
                totalPoints = totalPoints + 20;
            double pointsForSteps = ((double)numberSteps) * 0.1;

            totalPoints = totalPoints - (int)pointsForSteps;

            int number = mapNumber;
            mapNumber++;
            isNewLevel = true;
            initMap("sokoban_" + mapNumber + ".txt", false);
        }

        private void printNumberSteps(int number, int previousNumber)
        {
            lock (writelock)
            {
                if (number != previousNumber)
                {
                    previousNumber = number;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.CursorTop = 4;
                    Console.CursorLeft = 24;
                    Console.Write(number.ToString());
                }
            }
        }

        private void printNumberMovedBoxes(int number, int previousNumber)
        {
            lock (writelock)
            {
                if (number != previousNumber)
                {
                    previousNumberMovedBoxes = number;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.CursorTop = 6;
                    Console.CursorLeft = 31;
                    Console.Write(number.ToString());
                }
            }
        }

        private bool checkEndGame(int number)
        {
            int mapnumber = mapNumber + 1;
            if (mapnumber > number)
                return true;
            else
                return false;
        }

        private void play(List<List<int>> map)
        {
            checkKey = new ConsoleKeyInfo();
            Map = map;
            List<List<int>> previousStateMap = copyMap(Map);
            List<List<List<int>>> helpList;
            int[] heroPosition = findHeroPosition(Map);
            List<PointPosition> PointsPositionList = findPositionPoints(Map);
            int SetBoxes = 0;

            do
            {
                if (isNewLevel && mapNumber != 1)
                {
                    timer.Stop();
                    pauseTime = DateTime.Now;
                    Console.Clear();
                    Constants.printLevel(mapNumber);
                }

                checkKey = Console.ReadKey(true);

                if (!pauseMenu)
                {
                    if (isNewLevel && mapNumber != 1)
                    {
                        Console.Clear();
                        isNewLevel = false;
                        resumeGame(Map);

                    }

                    if (checkKey.Key == ConsoleKey.W || checkKey.Key == ConsoleKey.UpArrow)
                    {
                        helpList = refreshLists(Map, previousStateMap, 1, 0, 0, 0, PointsPositionList);
                        drawMap(helpList[0], helpList[1]);
                        printNumberSteps(numberSteps, PreviousNumberSteps);
                        printNumberMovedBoxes(NumberMovedBoxes, previousNumberMovedBoxes);
                        SetBoxes = numberSetBoxes(Map, PointsPositionList);
                        if (CheckEndRound(SetBoxes, PointsPositionList))
                        {
                            if (checkEndGame(totalRounds))
                                break;
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
                            if (checkEndGame(totalRounds))
                                break;
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
                            if (checkEndGame(totalRounds))
                                break;
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
                            if (checkEndGame(totalRounds))
                                break;
                            endRound();
                            Map = readFile("sokoban_" + mapNumber + ".txt");
                            previousStateMap = copyMap(Map);
                            heroPosition = findHeroPosition(Map);
                            PointsPositionList = findPositionPoints(Map);
                        }
                    }

                    if (checkKey.Key == ConsoleKey.Escape)
                    {
                        pauseTime = DateTime.Now;
                        timer.Stop();
                        typewriter.SoundLocation = "pauseMusic.wav";
                        typewriter.PlayLooping();
                        pauseMenu = true;
                        lock (writelock)
                        {
                            Constants.printPauseMenu();
                        }
                    }
                }
                else
                {
                    if (checkKey.Key == ConsoleKey.W || checkKey.Key == ConsoleKey.UpArrow)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        lock (writelock)
                        {
                            printMenuItem(currentPositionInPauseMenu);
                        }

                        if (currentPositionInPauseMenu == 0)
                        {
                            currentPositionInPauseMenu = 2;
                        }
                        else
                        {
                            currentPositionInPauseMenu--;
                        }
                    }

                    if (checkKey.Key == ConsoleKey.S || checkKey.Key == ConsoleKey.DownArrow)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        lock (writelock)
                        {
                            printMenuItem(currentPositionInPauseMenu);
                        }

                        if (currentPositionInPauseMenu == 2)
                        {
                            currentPositionInPauseMenu = 0;
                        }
                        else
                        {
                            currentPositionInPauseMenu++;
                        }
                    }

                    if (checkKey.Key == ConsoleKey.Enter)
                    {
                        selectedAction(currentPositionInPauseMenu);

                    }
                }
            } while (true);

            timer.Stop();

            EndGame endgame = new EndGame(totalPoints);

            lock (writelock)
            {
                typewriter.SoundLocation = "mainMusic.wav";
                typewriter.PlayLooping();
                endgame.run();
            }
        }


        private void resumeGame(List<List<int>> Map)
        {
            typewriter.Stop();

            if (typewriter.SoundLocation.CompareTo("step.wav") != 0)
            {
                typewriter.SoundLocation = "step.wav";
            }

            List<List<int>> initMap = new List<List<int>>();
            for (int i = 0; i < Map.Count(); i++)
            {
                List<int> initList = new List<int>();
                for (int j = 0; j < Map[i].Count(); j++)
                {
                    initList.Add(-1);
                }
                initMap.Add(initList);
            }

            lock (writelock)
            {
                Constants.printFrame();
                Constants.printFrameForCounters();
                printInformation();
                printNumberSteps(numberSteps, PreviousNumberSteps);
                printNumberMovedBoxes(NumberMovedBoxes, previousNumberMovedBoxes);
            }

            drawMap(Map, initMap);
            var difference = DateTime.Now - pauseTime;
            startTime = startTime.Add(difference);
            timer.Start();
        }

        private void printMenuItem(int select)
        {
            switch (select)
            {
                case 0:
                    lock (writelock)
                    {
                        Constants.printResumePM();
                    }
                    break;
                case 1:
                    lock (writelock)
                    {
                        Constants.printRestratPM();
                    }
                    break;
                case 2:
                    lock (writelock)
                    {
                        Constants.printExitPM();
                    }
                    break;
            }
        }

        private void selectedAction(int select)
        {
            switch (select)
            {
                case 0:
                    pauseMenu = false;
                    Console.Clear();
                    resumeGame(Map);
                    break;
                case 1:
                    typewriter.Stop();

                    if (typewriter.SoundLocation.CompareTo("step.wav") != 0)
                    {
                        typewriter.SoundLocation = "step.wav";
                    }

                    pauseMenu = false;
                    Console.Clear();
                    double pointsForSteps = ((double)numberSteps) * 0.1;
                    totalPoints = totalPoints - (int)pointsForSteps;
                    initMap("sokoban_" + mapNumber + ".txt", true);
                    break;
                case 2:
                    timerPauseMenu.Stop();
                    Menu menu = new Menu();
                    menu.run();
                    break;
            }
        }
    }
}
