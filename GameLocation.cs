using Microsoft.Xna.Framework;

namespace StardewiOS
{
    public class GameLocation
    {
        public string Name;
        public Rectangle Bounds;

        public GameLocation(string name, Rectangle bounds)
        {
            Name = name;
            Bounds = bounds;
        }
    }
}