﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace sokoban
{
    static class Constants
    {
        private static SoundPlayer soundPlayer = null;

        public static SoundPlayer getSoundPlayerInstance(){
            if(soundPlayer == null){
                soundPlayer = new SoundPlayer();
                return soundPlayer;
            }
            else
            {
                return soundPlayer;
            }
        }

        public static String[] title = new String[]
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

                public static String[] title1 = new String[]
            {
                   @"  ______    ______   __    __   ______   _______    ______   __    __ ",
                   @" /      \  /      \ |  \  /  \ /      \ |       \  /      \ |  \  |  \",
                   @"|  ######\|  $$$$$$\| $$ /  $$|  $$$$$$\| $$$$$$$\|  $$$$$$\| $$\ | $$",
                   @"| ##___\##| $$  | $$| $$/  $$ | $$  | $$| $$__/ $$| $$__| $$| $$$\| $$",
                   @" \##    \ | $$  | $$| $$  $$  | $$  | $$| $$    $$| $$    $$| $$$$\ $$",
                   @" _\######\| $$  | $$| $$$$$\  | $$  | $$| $$$$$$$\| $$$$$$$$| $$\$$ $$",
                   @"|  \__| ##| $$__/ $$| $$ \$$\ | $$__/ $$| $$__/ $$| $$  | $$| $$ \$$$$",
                   @" \##    ## \$$    $$| $$  \$$\ \$$    $$| $$    $$| $$  | $$| $$  \$$$",
                   @"  \######   \$$$$$$  \$$   \$$  \$$$$$$  \$$$$$$$  \$$   \$$ \$$   \$$"
            };

                public static String[] title2 = new String[]
            {
                   @"  ______    ______   __    __   ______   _______    ______   __    __ ",
                   @" /      \  /      \ |  \  /  \ /      \ |       \  /      \ |  \  |  \",
                   @"|  ######\|  ######\| $$ /  $$|  $$$$$$\| $$$$$$$\|  $$$$$$\| $$\ | $$",
                   @"| ##___\##| ##  | ##| $$/  $$ | $$  | $$| $$__/ $$| $$__| $$| $$$\| $$",
                   @" \##    \ | ##  | ##| $$  $$  | $$  | $$| $$    $$| $$    $$| $$$$\ $$",
                   @" _\######\| ##  | ##| $$$$$\  | $$  | $$| $$$$$$$\| $$$$$$$$| $$\$$ $$",
                   @"|  \__| ##| ##__/ ##| $$ \$$\ | $$__/ $$| $$__/ $$| $$  | $$| $$ \$$$$",
                   @" \##    ## \##    ##| $$  \$$\ \$$    $$| $$    $$| $$  | $$| $$  \$$$",
                   @"  \######   \######  \$$   \$$  \$$$$$$  \$$$$$$$  \$$   \$$ \$$   \$$"
            };

                public static String[] title3 = new String[]
            {
                   @"  ______    ______   __    __   ______   _______    ______   __    __ ",
                   @" /      \  /      \ |  \  /  \ /      \ |       \  /      \ |  \  |  \",
                   @"|  ######\|  ######\| ## /  ##|  $$$$$$\| $$$$$$$\|  $$$$$$\| $$\ | $$",
                   @"| ##___\##| ##  | ##| ##/  ## | $$  | $$| $$__/ $$| $$__| $$| $$$\| $$",
                   @" \##    \ | ##  | ##| ##  ##  | $$  | $$| $$    $$| $$    $$| $$$$\ $$",
                   @" _\######\| ##  | ##| #####\  | $$  | $$| $$$$$$$\| $$$$$$$$| $$\$$ $$",
                   @"|  \__| ##| ##__/ ##| ## \##\ | $$__/ $$| $$__/ $$| $$  | $$| $$ \$$$$",
                   @" \##    ## \##    ##| ##  \##\ \$$    $$| $$    $$| $$  | $$| $$  \$$$",
                   @"  \######   \######  \##   \##  \$$$$$$  \$$$$$$$  \$$   \$$ \$$   \$$"
            };

                public static String[] title4 = new String[]
            {
                   @"  ______    ______   __    __   ______   _______    ______   __    __ ",
                   @" /      \  /      \ |  \  /  \ /      \ |       \  /      \ |  \  |  \",
                   @"|  ######\|  ######\| ## /  ##|  ######\| $$$$$$$\|  $$$$$$\| $$\ | $$",
                   @"| ##___\##| ##  | ##| ##/  ## | ##  | ##| $$__/ $$| $$__| $$| $$$\| $$",
                   @" \##    \ | ##  | ##| ##  ##  | ##  | ##| $$    $$| $$    $$| $$$$\ $$",
                   @" _\######\| ##  | ##| #####\  | ##  | ##| $$$$$$$\| $$$$$$$$| $$\$$ $$",
                   @"|  \__| ##| ##__/ ##| ## \##\ | ##__/ ##| $$__/ $$| $$  | $$| $$ \$$$$",
                   @" \##    ## \##    ##| ##  \##\ \##    ##| $$    $$| $$  | $$| $$  \$$$",
                   @"  \######   \######  \##   \##  \######  \$$$$$$$  \$$   \$$ \$$   \$$"
            };

                public static String[] title5 = new String[]
            {
                   @"  ______    ______   __    __   ______   _______    ______   __    __ ",
                   @" /      \  /      \ |  \  /  \ /      \ |       \  /      \ |  \  |  \",
                   @"|  ######\|  ######\| ## /  ##|  ######\| #######\|  $$$$$$\| $$\ | $$",
                   @"| ##___\##| ##  | ##| ##/  ## | ##  | ##| ##__/ ##| $$__| $$| $$$\| $$",
                   @" \##    \ | ##  | ##| ##  ##  | ##  | ##| ##    ##| $$    $$| $$$$\ $$",
                   @" _\######\| ##  | ##| #####\  | ##  | ##| #######\| $$$$$$$$| $$\$$ $$",
                   @"|  \__| ##| ##__/ ##| ## \##\ | ##__/ ##| ##__/ ##| $$  | $$| $$ \$$$$",
                   @" \##    ## \##    ##| ##  \##\ \##    ##| ##    ##| $$  | $$| $$  \$$$",
                   @"  \######   \######  \##   \##  \######  \#######  \$$   \$$ \$$   \$$"
            };

                public static String[] title6 = new String[]
            {
                   @"  ______    ______   __    __   ______   _______    ______   __    __ ",
                   @" /      \  /      \ |  \  /  \ /      \ |       \  /      \ |  \  |  \",
                   @"|  ######\|  ######\| ## /  ##|  ######\| #######\|  ######\| $$\ | $$",
                   @"| ##___\##| ##  | ##| ##/  ## | ##  | ##| ##__/ ##| ##__| ##| $$$\| $$",
                   @" \##    \ | ##  | ##| ##  ##  | ##  | ##| ##    ##| ##    ##| $$$$\ $$",
                   @" _\######\| ##  | ##| #####\  | ##  | ##| #######\| ########| $$\$$ $$",
                   @"|  \__| ##| ##__/ ##| ## \##\ | ##__/ ##| ##__/ ##| ##  | ##| $$ \$$$$",
                   @" \##    ## \##    ##| ##  \##\ \##    ##| ##    ##| ##  | ##| $$  \$$$",
                   @"  \######   \######  \##   \##  \######  \#######  \##   \## \$$   \$$"
            };


                public static String[] title7 = new String[]
            {
                   @"  ______    ______   __    __   ______   _______    ______   __    __ ",
                   @" /      \  /      \ |  \  /  \ /      \ |       \  /      \ |  \  |  \",
                   @"|  ######\|  ######\| ## /  ##|  ######\| #######\|  ######\| ##\ | ##",
                   @"| ##___\##| ##  | ##| ##/  ## | ##  | ##| ##__/ ##| ##__| ##| ###\| ##",
                   @" \##    \ | ##  | ##| ##  ##  | ##  | ##| ##    ##| ##    ##| ####\ ##",
                   @" _\######\| ##  | ##| #####\  | ##  | ##| #######\| ########| ##\## ##",
                   @"|  \__| ##| ##__/ ##| ## \##\ | ##__/ ##| ##__/ ##| ##  | ##| ## \####",
                   @" \##    ## \##    ##| ##  \##\ \##    ##| ##    ##| ##  | ##| ##  \###",
                   @"  \######   \######  \##   \##  \######  \#######  \##   \## \##   \##"
            };

        public static String[] menuItemNewGame = new String[]
            {
                     @" _   _                  _____                      ",
                     @"| \ | |                / ____|                     ",
                     @"|  \| | _____      __ | |  __  __ _ _ __ ___   ___ ",
                     @"| . ` |/ _ \ \ /\ / / | | |_ |/ _` | '_ ` _ \ / _ \",
                     @"| |\  |  __/\ V  V /  | |__| | (_| | | | | | |  __/",
                     @"|_| \_|\___| \_/\_/    \_____|\__,_|_| |_| |_|\___|"
            };

        public static String[] gameOver = new String[]
        {
                    @"  ______    ______   __       __  ________         ______   __     __  ________  _______  ",      
                    @" /      \  /      \ |  \     /  \|        \       /      \ |  \   |  \|        \|       \ ",      
                    @"|  $$$$$$\|  $$$$$$\| $$\   /  $$| $$$$$$$$      |  $$$$$$\| $$   | $$| $$$$$$$$| $$$$$$$\",      
                    @"| $$ __\$$| $$__| $$| $$$\ /  $$$| $$__          | $$  | $$| $$   | $$| $$__    | $$__| $$",      
                    @"| $$|    \| $$    $$| $$$$\  $$$$| $$  \         | $$  | $$ \$$\ /  $$| $$  \   | $$    $$",      
                    @"| $$ \$$$$| $$$$$$$$| $$\$$ $$ $$| $$$$$         | $$  | $$  \$$\  $$ | $$$$$   | $$$$$$$\",      
                    @"| $$__| $$| $$  | $$| $$ \$$$| $$| $$_____       | $$__/ $$   \$$ $$  | $$_____ | $$  | $$",      
                    @" \$$    $$| $$  | $$| $$  \$ | $$| $$     \       \$$    $$    \$$$   | $$     \| $$  | $$",      
                    @"  \$$$$$$  \$$   \$$ \$$      \$$ \$$$$$$$$        \$$$$$$      \$     \$$$$$$$$ \$$   \$$"    
        };

        public static String[] menuItemRanking = new String[]
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

        public static String[] menuItemExit = new String[]
            {
                    @" ______          _   _   ",
                    @"|  ____|        (_) | |  ",
                    @"| |__    __  __  _  | |_ ",
                    @"|  __|   \ \/ / | | | __|",
                    @"| |____   >  <  | | | |_ ",
                    @"|______| /_/\_\ |_|  \__|"
            };

        public static String[] backButton = new String[]
        {
                    @"  ____             _    ",
                    @" |  _ \           | |   ",
                    @" | |_) | __ _  ___| | __",
                    @" |  _ < / _` |/ __| |/ /",
                    @" | |_) | (_| | (__|   < ",
                    @" |____/ \__,_|\___|_|\_\"
        };

        public static String[] arrowUp = new String[]
        {
                    @" /\ ",
                    @"|/\|"
        };

        public static String[] arrowDown = new String[]
        {
                    @"|\/|",
                    @" \/ "
        };

        public static String[] pause = new String[]
        {
                    @" _______    ______   __    __   ______   ________ ",
                    @"|       \  /      \ |  \  |  \ /      \ |        \",
                    @"| $$$$$$$\|  $$$$$$\| $$  | $$|  $$$$$$\| $$$$$$$$",
                    @"| $$__/ $$| $$__| $$| $$  | $$| $$___\$$| $$__    ",
                    @"| $$    $$| $$    $$| $$  | $$ \$$    \ | $$  \   ",
                    @"| $$$$$$$ | $$$$$$$$| $$  | $$ _\$$$$$$\| $$$$$   ",
                    @"| $$      | $$  | $$| $$__/ $$|  \__| $$| $$_____ ",
                    @"| $$      | $$  | $$ \$$    $$ \$$    $$| $$     \",
                    @" \$$       \$$   \$$  \$$$$$$   \$$$$$$  \$$$$$$$$"
        };

        public static String[] level = new String[]
        {
                    @" _        ______  __      __  ______   _      ",     
                    @"| |      |  ____| \ \    / / |  ____| | |     ",
                    @"| |      | |__     \ \  / /  | |__    | |     ",
                    @"| |      |  __|     \ \/ /   |  __|   | |     ",
                    @"| |____  | |____     \  /    | |____  | |____ ",
                    @"|______| |______|     \/     |______| |______|",
                    @"                                              ",
                    @"                Press any key to continue     "
        };

        public static String[] resume = new String[]
        {
                    @"  _____    ______    _____   _    _   __  __   ______ ",
                    @" |  __ \  |  ____|  / ____| | |  | | |  \/  | |  ____|",
                    @" | |__) | | |__    | (___   | |  | | | \  / | | |__   ",
                    @" |  _  /  |  __|    \___ \  | |  | | | |\/| | |  __|  ",
                    @" | | \ \  | |____   ____) | | |__| | | |  | | | |____ ",
                    @" |_|  \_\ |______| |_____/   \____/  |_|  |_| |______|"
        };

        public static String[] restart = new String[]
        {
                     @" _____  ______  _____ _______       _____ _______ ",
                     @"|  __ \|  ____|/ ____|__   __|/\   |  __ \__   __|",
                     @"| |__) | |__  | (___    | |  /  \  | |__) | | |   ",
                     @"|  _  /|  __|  \___ \   | | / /\ \ |  _  /  | |   ",
                     @"| | \ \| |____ ____) |  | |/ ____ \| | \ \  | |   ",
                     @"|_|  \_\______|_____/   |_/_/    \_\_|  \_\ |_|   "                                                 
        };

        public static String[] gameOvertext = new String[]
        {
                     @"  _____                                                                         _  _     _                             _     _                _ ",
                     @" / ____|                                                                       | || |   (_)                           | |   (_)              | |",
                     @"| (___    __ _ __   __ ___   _   _   ___   _   _  _ __   _ __  ___  ___  _   _ | || |_   _  _ __    _ __  __ _  _ __  | | __ _  _ __    __ _ | |",
                     @" \___ \  / _` |\ \ / // _ \ | | | | / _ \ | | | || '__| | '__|/ _ \/ __|| | | || || __| | || '_ \  | '__|/ _` || '_ \ | |/ /| || '_ \  / _` || |",
                     @" ____) || (_| | \ V /|  __/ | |_| || (_) || |_| || |    | |  |  __/\__ \| |_| || || |_  | || | | | | |  | (_| || | | ||   < | || | | || (_| ||_|",
                     @"|_____/  \__,_|  \_/  \___|  \__, | \___/  \__,_||_|    |_|   \___||___/ \__,_||_| \__| |_||_| |_| |_|   \__,_||_| |_||_|\_\|_||_| |_| \__, |(_)",
                     @"                             __/ |                                                                                                      __/ |    ",
                     @"                            |___/                                                                                                      |___/     "
        };

        public static String[] save = new String[]
        {
                     @"  _____      __      __ ______ ",
                     @" / ____|   /\\ \    / /|  ____|",
                     @"| (___    /  \\ \  / / | |__   ",
                     @" \___ \  / /\ \\ \/ /  |  __|  ",
                     @" ____) |/ ____ \\  /   | |____ ",
                     @"|_____//_/    \_\\/    |______|"
        };

        public static String[] number0 = new String[]
        {
                    @"  ___  ",
                    @" / _ \ ",
                    @"| | | |",
                    @"| | | |",
                    @"| |_| |",
                    @" \___/ "
        };

        public static String[] number1 = new String[]
        {
                    @" __ ",
                    @"/_ |",
                    @" | |",
                    @" | |",
                    @" | |",
                    @" |_|"   
        };

        public static String[] number2 = new String[]
        {
                    @" ___  ",
                    @"|__ \ ",
                    @"   ) |",
                    @"  / / ",
                    @" / /_ ",
                    @"|____|"
        };

        public static String[] number3 = new String[]
        {
                    @" ____  ",
                    @"|___ \ ",
                    @"  __) |",
                    @" |__ < ",
                    @" ___) |",
                    @"|____/ "    
        };

        public static String[] number4 = new String[]
        {
                    @" _  _   ",
                    @"| || |  ",
                    @"| || |_ ",
                    @"|__   _|",
                    @"   | |  ",
                    @"   |_|  "
        };

        public static String[] number5 = new String[]
        {
                    @" _____ ",
                    @"| ____|",
                    @"| |__  ",
                    @"|___ \ ",
                    @" ___) |",
                    @"|____/ "
        };

        public static String[] number6 = new String[]
        {
                    @"   __  ",
                    @"  / /  ",
                    @" / /_  ",
                    @"| '_ \ ",
                    @"| (_) |",
                    @" \___/ "
        };

        public static String[] number7 = new String[]
        {
                    @" ______ ",
                    @"|____  |",
                    @"    / / ",
                    @"   / /  ",
                    @"  / /   ",
                    @" /_/    "     
        };

        public static String[] number8 = new String[]
        {
                    @"  ___  ",
                    @" / _ \ ",
                    @"| (_) |",
                    @" > _ < ",
                    @"| (_) |",
                    @" \___/ "      
        };

        public static String[] number9 = new String[]
        {
                    @"  ___  ",
                    @" / _ \ ",
                    @"| (_) |",
                    @" \__, |",
                    @"   / / ",
                    @"  /_/  "       
        };

        public static void printFrame()
        {
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
        }

        public static void printRankingFrame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorTop = 22;
            Console.CursorLeft = 59;
            Console.WriteLine("╔════════════════╦════════════════╗");
            Console.CursorLeft = 59;
            Console.WriteLine("║      NAME      ║      SCORE     ║");
            Console.CursorLeft = 59;
            Console.WriteLine("╠════════════════╬════════════════╣");

            for (int i = 0; i < 20; i++)
            {
                Console.CursorLeft = 59;
                Console.WriteLine("║                ║                ║");
            }

            Console.CursorLeft = 59;
            Console.WriteLine("╚════════════════╩════════════════╝");
        }

        public static void printFrameForCounters()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorTop = 2;
            Console.CursorLeft = 4;
            Console.WriteLine("╔═════════════════════════════════╗");

            for (int i = 0; i < 42; i++)
            {
                Console.CursorLeft = 4;
                Console.WriteLine("║                                 ║");
            }

            Console.CursorLeft = 4;
            Console.WriteLine("╚═════════════════════════════════╝");
        }

        public static void printGameOverScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0,0);
            printFrame();

            Console.SetCursorPosition(0, 3);

            foreach(String line in gameOver)
            {
                Console.CursorLeft = 30;
                Console.WriteLine(line);
            }

            Console.CursorTop = Console.CursorTop + 2;

            foreach (String line in gameOvertext)
            {
                Console.CursorLeft = 7;
                Console.WriteLine(line);
            }

            Console.CursorTop = Console.CursorTop + 2;

            Console.CursorLeft = 70;
            Console.WriteLine("Enter your name");

            Console.CursorLeft = 60;
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.CursorLeft = 60;
            Console.WriteLine("║                                 ║");
            Console.CursorLeft = 60;
            Console.WriteLine("╚═════════════════════════════════╝");

            printSave();
            printExitInEnd();
            
        }

        public static void printSave()
        {
            Console.CursorTop = 40;
            foreach (String line in save)
            {
                Console.CursorLeft = 4;
                Console.WriteLine(line);
            }
        }

        public static void printExitInEnd()
        {
            Console.CursorTop = 40;
            foreach (String line in menuItemExit)
            {
                Console.CursorLeft = 130;
                Console.WriteLine(line);
            }
        }

        public static void printBackButton()
        {
            Console.CursorTop = 40;
           
            foreach (string line in backButton)
            {
                Console.CursorLeft = 4;
                Console.WriteLine(line);
            }
        }

        public static void printArrowUp()
        {
            Console.CursorTop = 40;

            foreach (string line in arrowUp)
            {
                Console.CursorLeft = 95;
                Console.WriteLine(line);
            }
        }

        public static void printArrowDown()
        {
            Console.CursorTop = 43;

            foreach (string line in arrowDown)
            {
                Console.CursorLeft = 95;
                Console.WriteLine(line);
            }
        }

        public static void printPauseMenu()
        {
            Console.Clear();
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            printFrame();

            Console.CursorTop = 3;

            foreach(string line in pause)
            {                            
                Console.CursorLeft = 55;
                Console.WriteLine(line);
            }

            printResumePM();
            printRestratPM();
            printExitPM();
        }

        public static void printResumePM()
        {
            Console.CursorTop = 15;

            foreach (string line in resume)
            {
                Console.CursorLeft = 53;
                Console.WriteLine(line);
            }
        }

        public static void printExitPM()
        {
            Console.CursorTop = 31;

            foreach (string line in menuItemExit)
            {
                Console.CursorLeft = 68;
                Console.WriteLine(line);
            }
        }

        public static void printRestratPM()
        {
            Console.CursorTop = 23;

            foreach (string line in restart)
            {
                Console.CursorLeft = 55;
                Console.WriteLine(line);
            }
        }


        public static void printLevel(int lvl)
        {
            printFrame();
            Console.CursorTop = 18;

            foreach (string line in level)
            {
                Console.CursorLeft = 50;
                Console.WriteLine(line);
            }

            Console.CursorTop = 18;

            switch (lvl)
            {
                case 1:
                    foreach (string line in number1)
                    {
                        Console.CursorLeft = 100;
                        Console.WriteLine(line);
                    }
                    break;
                case 2:
                    foreach (string line in number2)
                    {
                        Console.CursorLeft = 100;
                        Console.WriteLine(line);
                    }
                    break;
                case 3:
                    foreach (string line in number3)
                    {
                        Console.CursorLeft = 100;
                        Console.WriteLine(line);
                    }
                    break;
                case 4:
                    foreach (string line in number4)
                    {
                        Console.CursorLeft = 100;
                        Console.WriteLine(line);
                    }
                    break;
                case 5:
                    foreach (string line in number5)
                    {
                        Console.CursorLeft = 100;
                        Console.WriteLine(line);
                    }
                    break;
                case 6:
                    foreach (string line in number6)
                    {
                        Console.CursorLeft = 100;
                        Console.WriteLine(line);
                    }
                    break;
                case 7:
                    foreach (string line in number7)
                    {
                        Console.CursorLeft = 100;
                        Console.WriteLine(line);
                    }
                    break;
                case 8:
                    foreach (string line in number8)
                    {
                        Console.CursorLeft = 100;
                        Console.WriteLine(line);
                    }
                    break;
                case 9:
                    foreach (string line in number9)
                    {
                        Console.CursorLeft = 100;
                        Console.WriteLine(line);
                    }
                    break;
            }
        }
    }
}
