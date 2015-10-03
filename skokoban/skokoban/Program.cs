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
            typewriter.PlayLooping();

            Menu menu = new Menu();
            menu.run();
        }

    }
}
