using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace StardewiOS
{
    public class GameLocation
    {
        public string Name;
        public Rectangle Bounds;
        // 地图里的障碍物（石头/树），用来测试碰撞
        public List<Rectangle> Obstacles = new List<Rectangle>();

        public GameLocation(string name, Rectangle bounds)
        {
            Name = name;
            Bounds = bounds;
            // 放两个障碍物在地图上
            Obstacles.Add(new Rectangle(300, 300, 64, 64));
            Obstacles.Add(new Rectangle(600, 400, 128, 128));
        }

        // 检查某个矩形是否和地图上的障碍物碰撞
        public bool IsColliding(Rectangle rect)
        {
            foreach (var obs in Obstacles)
            {
                if (rect.Intersects(obs)) return true;
            }
            // 检查是否跑出地图边界
            if (!Bounds.Contains(rect)) return true;
            return false;
        }
    }
}