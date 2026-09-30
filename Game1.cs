using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace StardewiOS
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D chicken;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            try
            {
                // 从打包进 App 的 Content 文件夹加载图片
                using (var stream = TitleContainer.OpenStream("Content/StardewValley.png"))
                {
                    chicken = Texture2D.FromStream(GraphicsDevice, stream);
                }
            }
            catch (System.Exception ex)
            {
                // 如果加载失败，记录到控制台，防止黑屏
                System.Console.WriteLine("图片加载失败: " + ex.Message);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // 把背景清成蓝色
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (chicken != null)
            {
                // 把图放大 4 倍画在屏幕中间
                spriteBatch.Draw(chicken, new Rectangle(
                    (GraphicsDevice.Viewport.Width / 2) - 64,
                    (GraphicsDevice.Viewport.Height / 2) - 64,
                    128, 128), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}