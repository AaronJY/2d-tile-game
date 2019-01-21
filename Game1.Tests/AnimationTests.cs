using Game1.Animations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Tests
{
    [TestFixture]
    public class AnimationTests
    {
        private readonly string _TestAniStr;

        public AnimationTests()
        {
            _TestAniStr = @"  GANI0001
                            SPRITE    1  bomy_alma0.png    5    5   38   41 bomy
                            SPRITE    2 bomy_birce0.png    5    5   38   41 bomy 2
                            SPRITE    3  bomy_alma0.png    5    5   38   41 bomy

                            LOOP
                            CONTINUOUS
                            DEFAULTHEAD head19.png
                            DEFAULTBODY body.png

                            ANI
                               1   7   4,    2  47   5
                               1 -60  19
                               1  26  37
                               1  15  30,    2 -24  45
                            WAIT 10

                               1   7   0,    2  36  18
                               1  26  18


                            ANIEND
                            ";
        }
        [Test]
        public void LoadAnimation_Does_Successfully_Load_Animation()
        {
            var animation = Animation.Load(_TestAniStr);
            Assert.IsTrue(true);
        }
    }
}
