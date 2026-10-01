using Microsoft.Xna.Framework;
using System;

namespace StardewiOS
{
    public class Farmer
    {
        public string Name = "Player";
        public int health = 100;
        public int maxHealth = 100;
        public int stamina = 270;
        public int maxStamina = 270;
        public int money = 500;

        // 👇 核心移动属性
        public Vector2 Position;
        public int Speed = 4;
        public int FacingDirection = 2; // 0=上, 1=右, 2=下, 3=左

        // 👇 获取角色当前的碰撞箱（星露谷里角色的碰撞箱比贴图小）
        public Rectangle GetBoundingBox()
        {
            return new Rectangle((int)Position.X + 16, (int)Position.Y + 32, 32, 32);
        }

        // 👇 核心移动逻辑（带碰撞和滑行）
        public void Move(Vector2 direction, GameLocation location)
        {
            // 判断移动方向
            if (direction.X > 0.1f) FacingDirection = 1;
            else if (direction.X < -0.1f) FacingDirection = 3;
            else if (direction.Y > 0.1f) FacingDirection = 2;
            else if (direction.Y < -0.1f) FacingDirection = 0;

            // 计算移动向量
            Vector2 moveVector = direction * Speed;

            // 尝试分别沿 X 轴和 Y 轴移动，如果某个方向被挡住，就只移动另一个方向（滑行）
            TryMove(new Vector2(moveVector.X, 0), location);
            TryMove(new Vector2(0, moveVector.Y), location);
        }

        private void TryMove(Vector2 offset, GameLocation location)
        {
            Rectangle nextBox = GetBoundingBox();
            nextBox.X += (int)offset.X;
            nextBox.Y += (int)offset.Y;

            if (!location.IsColliding(nextBox))
            {
                Position += offset;
            }
        }
    }
}