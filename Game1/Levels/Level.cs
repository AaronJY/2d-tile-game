using Game1.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Game1.Levels
{
    public class Level
    {
        public Tile[,] Tiles { get; protected set; }
        public Point[] TilesetTilePositions { get; protected set; }

        public Level()
        {
        }

        public void SetTiles(Tile[,] tiles)
        {
            Tiles = tiles;
            TilesetTilePositions = GetTilesetTilePositions(tiles).ToArray();
        }

        public void LoadFromFile(string path)
        {
            var str = File.ReadAllText(path);
            LoadFromString(str);
        }

        public void LoadFromString(string levelString)
        {
            var level = new Level();

            var rowIndex = 0;
            var tiles = new Tile[64, 64];
            var lines = levelString.Split('\n');
            foreach (var line in lines)
            {
                if (!line.Trim().StartsWith("BOARD"))
                    continue;

                var rowTiles = new List<string>();
                var b64TilesLine = line.Substring(line.LastIndexOf(" ")).Trim();
                for (var i = 0; i < b64TilesLine.Length / 2; i++)
                {
                    var b64Tile = b64TilesLine.Substring(i * 2, 2);
                    var tile = TileHelpers.Base64ToTile(b64Tile);
                    tiles[rowIndex, i] = new Tile(tile);
                }

                rowIndex++;
            }

            SetTiles(tiles);
        }

        protected static IEnumerable<Point> GetTilesetTilePositions(Tile[,] tiles)
        {
            var points = new List<Point>();
            for (var x = 0; x < 64; x++)
            {
                for (var y = 0; y < 64; y++)
                {
                    var pos = TileHelpers.TileToPos(tiles[x,y].Value);
                    points.Add(pos);
                }
            }

            return points;
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Camera camera, Texture2D tilesetTexture, GameTime gameTime)
        {
            var tileSize = 16 * camera.Zoom;

            for (var i = 0; i < TilesetTilePositions.Length; i++)
            {
                var renderX = (int)((i % 64) * tileSize - (int)camera.Position.X);
                var renderY = (int)((int)Math.Floor((double)i / 64) * tileSize - (int)camera.Position.Y);

                var tilePosX = TilesetTilePositions[i].X;
                var tilePosY = TilesetTilePositions[i].Y;

                spriteBatch.Draw(
                    tilesetTexture,
                    new Vector2(renderX, renderY),
                    new Rectangle(tilePosX, tilePosY, 16, 16), Color.White, 0, Vector2.Zero, camera.Zoom, SpriteEffects.None, 0);
            }
        }
    }
}
