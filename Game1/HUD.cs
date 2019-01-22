using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class HUD
    {
        public string LevelName { get; set; }

        private SpriteFont _font;

        public HUD(SpriteFont font)
        {
            _font = font;
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!string.IsNullOrEmpty(LevelName))
            {
                var levelNamePosition = new Vector2(10, 10);
                spriteBatch.DrawString(_font, LevelName, levelNamePosition, Color.White);
            }
        }
    }
}
