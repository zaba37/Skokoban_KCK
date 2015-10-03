using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    public class Point
    {
        private string[] graphics;
        public Point()
        {
            this.graphics = new String[]
            {
                    @"---",
                    @"---",
                    @"---"
            };
        }
        public string[] getObject()
        {
            return graphics;
        }
    }
}
