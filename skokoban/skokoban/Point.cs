using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    public class Point
    {
        public string[] graphics;
        public Point()
        {
            this.graphics = new String[]
            {
                    @"---",
                    @"---",
                    @"---"
            };
        }
    }
}
