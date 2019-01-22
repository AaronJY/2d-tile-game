using Game1.Infrastructure;
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

        GameWorld _world;

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
            var player = new Player
            {
                Name = "Aaron",
                Speed = 200f
            };

            _player = player;

            // Setup camera
            _camera = new Camera(_graphics.GraphicsDevice.Viewport);
            _camera.SetZoom(1f);
            _camera.SetPosition(player.Position);

            // Setup world
            _world = new GameWorld();
            _world.AddGameObject(player);

            _level = Level.LoadFromFile("Content/Levels/storm_house.nw");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _tilesetTexture = Content.Load<Texture2D>("dot_tileset1");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var gameObject in _world.GameObjects)
            {
                gameObject.Update(gameTime);
            }

            UpdateCamera();

            base.Update(gameTime);
        }

        protected void UpdateCamera()
        {
            var newPos = _player.Position;
            _camera.SetPosition(newPos);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear everything
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (var gameObject in _world.GameObjects)
            {
                gameObject.Draw(GraphicsDevice, _spriteBatch, gameTime);
            }

            DrawLevel(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void DrawLevel(GameTime gameTime)
        {
            var tileSize = 16 * _camera.Zoom;

            for (var i = 0; i < _level.TilesetTilePositions.Length; i++)
            {
                var renderX = (int)((i % 64) * tileSize - (int)_camera.Position.X);
                var renderY = (int)((int)Math.Floor((double)i / 64) * tileSize - (int)_camera.Position.Y);

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
