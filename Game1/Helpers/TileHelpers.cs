using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Helpers
{
    public static class TileHelpers
    {
        private const string Base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        public static int Base64ToTile(string b64Tile)
        {
            return Base64.IndexOf(b64Tile.Substring(0, 1)) * 64 + Base64.IndexOf(b64Tile.Substring(1, 1));
        }

        public static Point TileToPos(int tile)
        {
            var x = ((tile % 16) * 16) + ((tile / 512) * 256);
            var y = ((tile / 16) * 16) % 512;

            return new Point(x, y);
        }
    }
}
