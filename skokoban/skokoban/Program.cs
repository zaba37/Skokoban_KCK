using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(160,50);
            //Console.SetWindowSize(170, 59);
            //Game game = new Game();
            //game.initMap();
            //Console.ReadKey();

            Menu menu = new Menu();

            menu.run();
        }

    }
}
