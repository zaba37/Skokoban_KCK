using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    public class Box
    {
        public string[] graphics;
        public Box()
        {
            this.graphics = new String[]
            {
                    @"[]]",
                    @"[]]",
                    @"[]]"           
            };
        }
    }
}
