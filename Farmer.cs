using Microsoft.Xna.Framework;
using System;

namespace StardewiOS
{
    public class Farmer
    {
        public Vector2 Position;
        public int Speed = 4;
        public int FacingDirection = 2; // 0=上, 1=右, 2=下, 3=左
        public string Name = "Player";

        public void Move(Vector2 direction)
        {
            Position += direction * Speed;

            // 限制玩家不要跑出地图边界（假设地图是1000x1000）
            Position.X = Math.Clamp(Position.X, 0, 1000 - 64);
            Position.Y = Math.Clamp(Position.Y, 0, 1000 - 64);
        }
    }
}