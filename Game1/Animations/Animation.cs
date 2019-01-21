using System.Collections.Generic;

namespace Game1.Animations
{
    public class Animation
    {
        public bool Loop { get; set; }
        public bool Continous { get; set; }
        public IDictionary<int, SpriteDefinition> SpriteDefinitions { get; protected set; }

        public Animation()
        {
        }
    }
}

