﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    static class Constants
    {
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

        public static String[] menuItemNewGame = new String[]
            {
                     @" _   _                  _____                      ",
                     @"| \ | |                / ____|                     ",
                     @"|  \| | _____      __ | |  __  __ _ _ __ ___   ___ ",
                     @"| . ` |/ _ \ \ /\ / / | | |_ |/ _` | '_ ` _ \ / _ \",
                     @"| |\  |  __/\ V  V /  | |__| | (_| | | | | | |  __/",
                     @"|_| \_|\___| \_/\_/    \_____|\__,_|_| |_| |_|\___|"
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

        public static void printFrame(){
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
    }
}
