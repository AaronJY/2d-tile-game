using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Levels
{
    public class Tile
    {
        public int Value { get; private set; }
        public Tile(int value)
        {
            Value = value;
        }
    }
}
