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

        public Vector2 Position;
        public int Speed = 4;
        public int FacingDirection = 2; 

        public Rectangle GetBoundingBox()
        {
            return new Rectangle((int)Position.X + 16, (int)Position.Y + 32, 32, 32);
        }

        public void Move(Vector2 direction, GameLocation location)
        {
            if (direction.X > 0.1f) FacingDirection = 1;
            else if (direction.X < -0.1f) FacingDirection = 3;
            else if (direction.Y > 0.1f) FacingDirection = 2;
            else if (direction.Y < -0.1f) FacingDirection = 0;

            Vector2 moveVector = direction * Speed;
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