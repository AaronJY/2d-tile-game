using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Game1
{
    public static class GameConsole
    {
        private static IList<string> _messages = new List<string>();
        public static IEnumerable<string> Messages => _messages;

        public static void Log(string msg)
        {
            var msgWithTime = $"[{DateTime.Now:h:m:s}]: " + msg;
            _messages.Add(msgWithTime);
        }

        public static void Clear()
        {
            _messages.Clear();
        }

        public static void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, SpriteFont font, GameTime gameTime)
        {
            var consoleHeight = 300;
            var messageCount = 10;

            var consoleBgTexture = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            consoleBgTexture.SetData<Color>(new[] { Color.White });

            var consoleBgRect = new Rectangle(0, graphicsDevice.Viewport.Height - consoleHeight, graphicsDevice.Viewport.Width, 300);

            spriteBatch.Draw(consoleBgTexture, consoleBgRect, Color.White * 0.5f);

            if (_messages.Count == 0)
                return;

            // Don't try and draw messages that don't exist (out of bounds)
            if (_messages.Count < messageCount)
                messageCount = _messages.Count;

            for (var i = 0; i < messageCount; i++)
            {
                var now = DateTime.Now;
                var text =  _messages[_messages.Count - 1 - i];
                var textY = consoleBgRect.Top + 20 + (30 * i);
                spriteBatch.DrawString(font, text, new Vector2(20, textY), Color.Black);
            }
        }
    }
}
