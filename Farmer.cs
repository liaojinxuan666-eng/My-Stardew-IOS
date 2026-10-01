using Microsoft.Xna.Framework;
using System;

namespace StardewiOS
{
    public class Farmer
    {
        // 👇 从原版 Farmer.cs 提取出来的核心数据变量（去掉了 NetInt/NetBool 等网络包装）
        public string Name = "Player";
        public int health = 100;
        public int maxHealth = 100;
        public int stamina = 270;
        public int maxStamina = 270;
        public int farmingLevel = 0;
        public int money = 500;

        // 👇 基础移动变量
        public Vector2 Position;
        public int Speed = 4;
        public int FacingDirection = 2; // 0=上, 1=右, 2=下, 3=左

        // 👇 原版里的移动方法（精简版）
        public void Move(Vector2 direction)
        {
            Position += direction * Speed;
            
            // 限制玩家不要跑出地图边界（假设地图是 1000x1000）
            Position.X = Math.Clamp(Position.X, 0, 1000 - 64);
            Position.Y = Math.Clamp(Position.Y, 0, 1000 - 64);
        }
    }
}