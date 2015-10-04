using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(160, 50);
            SoundPlayer typewriter = Constants.getSoundPlayerInstance();
            typewriter.SoundLocation = "mainMusic.wav";
            //typewriter.PlayLooping();

            EndGame end = new EndGame(10);
            end.run();
          //  Console.ReadKey();
         //  Menu menu = new Menu();
          //1 menu.run();
        }

    }
}
