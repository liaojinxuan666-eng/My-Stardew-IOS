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
            
            // 从打包进 App 的 Content 文件夹加载刚才的图
            using (var stream = TitleContainer.OpenStream("Content/chicken.png"))
            {
                chicken = Texture2D.FromStream(GraphicsDevice, stream);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            // 把背景清成蓝色
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            // 把图放大 4 倍画在屏幕中间
            spriteBatch.Draw(chicken, new Rectangle(
                (GraphicsDevice.Viewport.Width / 2) - 64,
                (GraphicsDevice.Viewport.Height / 2) - 64,
                128, 128), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}