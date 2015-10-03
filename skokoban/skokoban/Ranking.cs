using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace sokoban
{


    class RankingItem 
    {
        public int score { get; set; }
        public string name { get; set; }

        public RankingItem(string n, int s)
        {
            name = n;
            score = s;
        }

    }

   

    class Ranking
    {
        private System.Timers.Timer timer;
        private int currentCursorPosition;
        private ConsoleKeyInfo checkKey;
        public List<RankingItem> RankingItemList = new List<RankingItem>();
        private int from = 0;
        private int to = 20;

        public Ranking()
        {
            currentCursorPosition = 0;

            timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;

            checkKey = new ConsoleKeyInfo();
        }

        public void run()
        {
            int cursorTopPosition = 2;
            timer.Enabled = true;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorTop = 0;
            Constants.printFrame();
            Constants.printRankingFrame();

            printMenuItem(0);
            printMenuItem(1);
            printMenuItem(2);

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

            loadRanking();
            printRanking(0,20);
            while (true)
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
                }
                else if (checkKey.Key == ConsoleKey.Enter)
                {
                    selectedAction(currentCursorPosition);
                    break;
                }
            }

        }

        private void printRanking(int from, int to)
        {
            Console.SetCursorPosition(63, 25);
            for(var i = from; i < to; i++)
            {
                Console.Write(RankingItemList[i].name);
                Console.CursorLeft = 80;
                Console.WriteLine(RankingItemList[i].score);
                Console.CursorLeft = 63;
            }
        }

        private void loadRanking()
        {
            string line;
            String fileName = @"ranking.txt";
            System.IO.StreamReader file;

            if (System.IO.File.Exists(fileName))
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
                string[] namescore;
                namescore = line.Split(' ');
                RankingItemList.Add(new RankingItem(namescore[0], Int32.Parse(namescore[1])));
            }
            RankingItemList.Sort(delegate(RankingItem x, RankingItem y)
            {
                return y.score.CompareTo(x.score);
            });
            
            file.Close();
        }

        public void addScore(string name, int score)
        {
            RankingItemList.Add(new RankingItem(name, score));
        }

        private void saveRanking()
        {
            String fileName = @"ranking.txt";
            System.IO.StreamWriter file;
            if (System.IO.File.Exists(fileName))
            {
                file = new System.IO.StreamWriter(fileName);
            }
            else
            {
                System.IO.File.Create(fileName).Close();
                file = new System.IO.StreamWriter(fileName);
            }
            foreach (var RankingItem in RankingItemList)
            {
                file.WriteLine("{0} {1}", RankingItem.name, RankingItem.score);
            }
            file.Close();
            
            
        }

        private void printMenuItem(int select)
        {
            switch (select)
            {
                case 0: //arrow up
                    Constants.printArrowUp();
                    break;
                case 1: //arrow down
                    Constants.printArrowDown();
                    break;
                case 2: //back button
                    Constants.printBackButton();
                    break;
            }
        }

        private void selectedAction(int select)
        {
            switch (select)
            {
                case 0: //arrow up
                    
                    if(from > 0)
                    {
                        from--;
                        to--;
                        printRanking(from, to);
                    }
                    
                    break;
                case 1: //arrow down
                    from++;
                    to++;
                    printRanking(from,to);
                    
                    break;
                case 2: //back button
                    Menu menu = new Menu();
                    timer.Close();
                    menu.run();
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
