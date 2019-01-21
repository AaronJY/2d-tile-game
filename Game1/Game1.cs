using Game1.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        Player _player;
        Texture2D _tilesetTexture;
        Level _level;
        Camera _camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _camera = new Camera(_graphics.GraphicsDevice.Viewport);
            _camera.SetZoom(1f);

            _player = new Player
            {
                Name = "Aaron",
                Speed = 3f
            };

            _camera.SetPosition(_player);

            _level = Level.LoadFromFile("Content/Levels/storm_house.nw");

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _tilesetTexture = Content.Load<Texture2D>("dot_tileset1");

            //var cache = new ContentCache(Content);
            //cache.Load();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            UpdatePlayer();
            UpdateCamera();

            base.Update(gameTime);
        }

        protected void UpdatePlayer()
        {
            var playerSpeed = _player.Speed;

            // Left control makes the player move faster
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                playerSpeed = _player.Speed * 3;

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

            var newPlayerX = _player.Position.X + xState * playerSpeed;
            var newPlayerY = _player.Position.Y + yState * playerSpeed;
            var newPlayerPos = new Vector2(newPlayerX, newPlayerY);

            _player.Position = newPlayerPos;
        }

        protected void UpdateCamera()
        {
            var newPos = _player.Position;
            _camera.SetPosition(newPos);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clear everything
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            DrawLevel(gameTime);
            DrawPlayer(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void DrawPlayer(GameTime gameTime)
        {
            var playerRect = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            playerRect.SetData<Color>(new Color[] { Color.White });
            _spriteBatch.Draw(playerRect, new Rectangle(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2, 32, 32), Color.White);
        }

        protected void DrawLevel(GameTime gameTime)
        {
            var tileSize = 16 * _camera.Zoom;

            for (var i = 0; i < _level.TilesetTilePositions.Length; i++)
            {
                var renderX = (i % 64) * tileSize - _camera.Position.X;
                var renderY = (int)Math.Floor((double)i / 64) * tileSize - _camera.Position.Y;

                var tilePosX = _level.TilesetTilePositions[i].X;
                var tilePosY = _level.TilesetTilePositions[i].Y;

                _spriteBatch.Draw(
                    _tilesetTexture,
                    new Vector2(renderX, renderY),
                    new Rectangle(tilePosX, tilePosY, 16, 16), Color.White, 0, Vector2.Zero, _camera.Zoom, SpriteEffects.None, 0);
            }
        }
    }
}
