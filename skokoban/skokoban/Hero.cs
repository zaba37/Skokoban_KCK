using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
   public class Hero
    {
        public string[] graphics;
        public Hero()
        {
            this.graphics = new String[]
            {
                    @" ☺ ",
                    @"┤█├",
                    @"┘ └"
            };
        }
    }
}
