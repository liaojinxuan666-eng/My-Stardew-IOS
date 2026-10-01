using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace StardewiOS
{
    public class GameLocation
    {
        public string Name;
        public Rectangle Bounds;
        public List<Rectangle> Obstacles = new List<Rectangle>();

        public GameLocation(string name, Rectangle bounds)
        {
            Name = name;
            Bounds = bounds;
            Obstacles.Add(new Rectangle(300, 300, 64, 64));
            Obstacles.Add(new Rectangle(600, 400, 128, 128));
        }

        public bool IsColliding(Rectangle rect)
        {
            foreach (var obs in Obstacles)
            {
                if (rect.Intersects(obs)) return true;
            }
            if (!Bounds.Contains(rect)) return true;
            return false;
        }
    }
}