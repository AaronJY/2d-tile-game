using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Animations
{
    public class SpriteDefinition
    {
        public int Index { get; set; }
        public Texture2D SourceTexture { get; set; }
        public int SourceX { get; set; }
        public int SourceY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Description { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public SpriteDefinition()
        {
        }
    }
}
