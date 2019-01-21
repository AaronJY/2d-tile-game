using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Game1.Animations
{
    public class AnimationManager
    {
        readonly ContentManager _ContentManager;

        public AnimationManager(ContentManager contentManager)
        {
            _ContentManager = contentManager;
        }

        public Animation LoadAnimation(string resourceName)
        {
            var input = _ContentManager.Load<string>(resourceName);
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception($"Resource {resourceName} not found");
            }

            var animation = new Animation();

            var parseIndex = -1;
            var lines = input.Split(Environment.NewLine.ToCharArray());
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Trim();

                if (parseIndex == -1)
                {
                    if (line.StartsWith("SPRITE"))
                    {
                        parseIndex = 0;
                    } else continue;
                }

                if (parseIndex == 0)
                {
                    var spriteDef = new SpriteDefinition();

                    // Tokenize parameters based on whitespace
                    var tokenMatches = Regex.Matches(line, @"([a-zA-Z0-9_.]+)");
                    spriteDef.Index = int.Parse(tokenMatches[1].Value);
                    spriteDef.SourceTexture = _ContentManager.Load<Texture2D>(tokenMatches[2].Value);
                }
            }

            return animation;
        }
    }
}
