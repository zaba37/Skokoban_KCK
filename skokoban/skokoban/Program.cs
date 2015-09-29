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
            Console.SetWindowSize(170, 59);
            //Console.SetWindowSize(170, 59);
            Menu menu = new Menu();
            Console.ReadKey();
        }
    }
}
