using Game1.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Player : TangibleEntity
    {
        public Direction Direction { get; set; }
        public float Speed { get; set; }

        public Player()
        {
            Direction = Direction.Down;
            Speed = 0.8f;
        }
    }
}
