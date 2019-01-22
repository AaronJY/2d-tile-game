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
        Level _level;
        Camera _camera;
        Texture2D _tilesetTexture;
        SpriteFont _font;
        HUD _hud;

        GameWorld _world;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 900;
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

            // Setup level
            _level = new Level();
            _level.LoadFromFile("Content/Levels/corinthia/onlinestartlocation.nw");

            // Setup HUD
            _hud = new HUD(_font);

            GameConsole.Log("Woot! The game has started!");
            GameConsole.Log("And this is the second message!");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Fonts/defaultFont");

            _tilesetTexture = Content.Load<Texture2D>("Images/Tiles/pics1");
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
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _level.Draw(GraphicsDevice, _spriteBatch, _camera, _tilesetTexture, gameTime);

            foreach (var gameObject in _world.GameObjects)
            {
                gameObject.Draw(GraphicsDevice, _spriteBatch, gameTime);
            }

            _hud.Draw(GraphicsDevice, _spriteBatch, gameTime);

            GameConsole.Draw(GraphicsDevice, _spriteBatch, _font, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void DrawLevel(GameTime gameTime)
        {
            
        }
    }
}
