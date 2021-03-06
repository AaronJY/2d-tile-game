﻿using Game1.Levels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Tests
{
    [TestFixture]
    public class LevelTests
    {
        [Test]
        public void LoadLevelFromString_Does_Load_Level_Correctly()
        {
            var levelStr = @"GLEVNW01
                            BOARD 0 0 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 1 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 2 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 3 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 4 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 5 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 6 64 0 AgAgAgAgAgAgAgAgAgAgeiejejejejekAgAgeiejejejejejejejejejejejekAgAgeiejejejejekAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 7 64 0 AgAgAgAgAgAgAgAgAgAgeyeVfDfDeWelejejemeVfDfDfDfDfDfDfDfDfDeWelejejemeVfDfDeWe0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 8 64 0 AgAgAgAgAgAgAgAgAgAgeye0eoeofCfDfDfDfDfEeoeoeoeoeoeoeoeoeofCfDfDfDfDfEeoeoeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 9 64 0 AgAgAgAgAgAgAgAgAgAgeye0e4e4eneoeoeoeoepe4e4e4e4e4e4e4e4e4eneoeoeoeoepe4e4eye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 10 64 0 AgAgAgAgAgAgAgAgAgAgeye0e4e4e3e4e4e4e4e5e4e4e4e4e4e4e4e4e4e3e4e4e4e4e5e4e4eye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 11 64 0 AgAgAgAgAgAgAgAgAgAgeye0fIfIe3e4e4e4e4e5fIfIfIfIfIfIfIfIfIe3e4e4e4e4e5fIfIeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 12 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDfHfIfIfIfIfJgDgDgDgDgDgDgDgDgDfHfIfIfIfIfJgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 13 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 14 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeyelejejejejejekAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 15 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDfCfDfDfDfDfDeWe0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 16 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeneoeoeoeoeoeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 17 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDe3e4e4e4e4e4eye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 18 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDe3e4e4e4e4e4eye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 19 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDfHfIfIfIfIfIeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 20 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 21 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 22 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 23 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 24 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 25 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 26 64 0 AgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 27 64 0 AgAgAgAgAgAgAgAgAgAgeyelejejejekgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeiejejejejejeme0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 28 64 0 AgAgAgAgAgAgAgAgAgAgfCfDfDfDeWe0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeyeVfDfDfDfDfDfEAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 29 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 30 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 31 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 32 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 33 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeyelejejejejejejejejejejejejejejejejejekAgAgAgAgAgAgAg
                            BOARD 0 34 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDfCfDfDfDfDfDfDfDfDfDfDfDfDfDfDfDfDfDeWe0AgAgAgAgAgAgAg
                            BOARD 0 35 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeneoeoeoeoeoeoeoeoeoeoeoeoeoeoeoeoeoeye0AgAgAgAgAgAgAg
                            BOARD 0 36 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgeyelejejejejejekgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDe3e4e4e4e4e4e4e4e4e4e4e4e4e4e4e4e4e4eye0AgAgAgAgAgAgAg
                            BOARD 0 37 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgfCfDfDfDfDfDeWe0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDe3e4e4e4e4e4e4e4e4e4e4e4e4e4e4e4e4e4eye0AgAgAgAgAgAgAg
                            BOARD 0 38 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDfHfIfIfIfIfIfIfIfIfIfIfIfIfIfIfIfIfIeye0AgAgAgAgAgAgAg
                            BOARD 0 39 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAg
                            BOARD 0 40 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAg
                            BOARD 0 41 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAg
                            BOARD 0 42 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAg
                            BOARD 0 43 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAg
                            BOARD 0 44 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAg
                            BOARD 0 45 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAg
                            BOARD 0 46 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeiejejejejejejejejejejejejeme0AgAgAgAgAgAgAg
                            BOARD 0 47 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeyeVfDfDfDfDfDfDfDfDfDfDfDfDfEAgAgAgAgAgAgAg
                            BOARD 0 48 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 49 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeyelejejejejejejekgDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 50 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgfCfDfDfDfDfDfDeWe0gDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 51 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 52 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeye0gDgDgDgDgDgDgDgDgDgDgDgDgDeye0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 53 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgeyelejejejejejejejejejejejejejeme0AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 54 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgfCfDfDfDfDfDfDfDfDfDfDfDfDfDfDfDfEAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 55 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 56 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 57 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 58 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 59 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 60 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 61 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 62 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg
                            BOARD 0 63 64 0 AgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAgAg";

            var res = Level.LoadFromString(levelStr);
            Assert.NotNull(res);
            Assert.NotNull(res.Tiles);
            Assert.IsTrue(res.Tiles.Length > 0);
        }
    }
}
