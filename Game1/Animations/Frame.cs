using Game1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Animations
{
    public class Frame
    {
        public double WaitSeconds { get; protected set; }

        public IEnumerable<Sprite> SpritesUp { get; protected set; }
        public IEnumerable<Sprite> SpritesLeft { get; protected set; }
        public IEnumerable<Sprite> SpritesDown { get; protected set; }
        public IEnumerable<Sprite> SpritesRight { get; protected set; }

        public IEnumerable<Sprite> GetDirectionalSprites(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return SpritesUp;
                case Direction.Left: return SpritesLeft;
                case Direction.Down: return SpritesDown;
                case Direction.Right: return SpritesRight;

                default: return null;
            }
        }
    }
}
