using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace StardewiOS
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private int updateCount = 0; // 计数器

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            updateCount++;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            // 红方块会随着 updateCount 的变化而上下跳动
            // 这就验证了 Update 循环和 Draw 循环是同步的
            Texture2D redBox = new Texture2D(GraphicsDevice, 1, 1);
            redBox.SetData(new[] { Color.Red });
            spriteBatch.Draw(redBox, new Rectangle(
                (GraphicsDevice.Viewport.Width / 2) - 64,
                (GraphicsDevice.Viewport.Height / 2) - 64 + (updateCount % 100), // 让它动起来！
                128, 128), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}