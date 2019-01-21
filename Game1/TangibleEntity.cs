﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public abstract class TangibleEntity
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }

        public TangibleEntity()
        {
            Position = Vector2.Zero;
        }
    }
}