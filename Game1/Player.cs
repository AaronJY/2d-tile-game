using Game1.Enums;
using Game1.Infrastructure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Player : IGameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Rotation { get; set; }
        public Vector2 Scale { get; set; }

        public string Name { get; set; }
        public Direction Direction { get; set; }
        public float Speed { get; set; }

        public Player()
        {
            Direction = Direction.Down;
            Speed = 0.8f;
            Position = Vector2.Zero;

            GameConsole.Log("Player has been constructed!");
        }

        public void Update(GameTime gameTime)
        {
            var playerSpeed = Speed;

            // Left control makes the player move faster
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                playerSpeed = Speed * 3;

            // Implement x and y states to incorporate arrow keys cancelling
            // each other out. This way, no arrow key takes priority over the other
            // ex: Pressing left AND right will mean the character doesn't move at all
            var xState = 0;
            var yState = 0;

            // Move player with arrow keys
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) xState--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) xState++;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) yState--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) yState++;

            if (xState != 0 || yState != 0)
            {
                var direction = new Vector2(xState, yState);
                var xVelocity = direction * playerSpeed;
                var yVelocity = yState * playerSpeed;

                Position += direction * playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime)
        {
            var playerRect = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            playerRect.SetData<Color>(new Color[] { Color.White });

            var desinationRect = new Rectangle(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2, 32, 32);

            spriteBatch.Draw(playerRect, desinationRect, Color.White);
        }
    }
}
