using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Infrastructure
{
    public interface IGameObject
    {
        Vector2 Position { get; set; }
        Vector2 Rotation { get; set; }
        Vector2 Scale { get; set; }

        void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime);
        void Update(GameTime gameTime);
    }
}
