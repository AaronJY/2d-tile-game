using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Camera
    {
        public float Zoom { get; protected set; }
        public Vector2 Position { get; set; }
        public Rectangle VisibleArea { get; protected set; }
        public Rectangle Bounds { get; protected set; }

        public Camera(Viewport viewport)
        {
            Bounds = viewport.Bounds;
            Position = Vector2.Zero;
            Zoom = 1f;
        }

        public void SetZoom(float newZoom)
        {
            Zoom = newZoom;
        }

        public void SetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        public void SetPosition(TangibleEntity entity)
        {
            Position = entity.Position;
        }
    }
}
