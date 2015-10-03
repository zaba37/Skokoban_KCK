using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    public class Floor
    {
        private string[] graphics;
        public Floor()
        {
            this.graphics = new String[]
            {
                    @"   ",
                    @"   ",
                    @"   "
            };
        }
        public string[] getObject()
        {
            return graphics;
        }
    }

}
