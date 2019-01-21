using System;
using Game1.Helpers;
using NUnit.Framework;

namespace Game1.Tests
{
    [TestFixture]
    public class TileHelpersTests
    {
        [Test]
        [TestCase(new object[] { "Kp", 681 })]
        [TestCase(new object[] { "Kq", 682 })]
        [TestCase(new object[] { "K5", 697 })]
        [TestCase(new object[] { "K6", 698 })]
        public void Base64ToTile_Returns_Correct_Tile(string b64, int expected)
        {
            Assert.AreEqual(expected, TileHelpers.Base64ToTile(b64));
        }
    }
}
