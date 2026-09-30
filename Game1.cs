using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Foundation; // iOS 原生库，用来找文件路径

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
                // 尝试用 iOS 原生方式获取打包后的图片路径
                string path = NSBundle.MainBundle.PathForResource("StardewValley", "png", "Content");
                
                // 如果没找到，退回到当前目录查找
                if (string.IsNullOrEmpty(path))
                {
                    path = Path.Combine(Environment.CurrentDirectory, "Content", "StardewValley.png");
                }

                if (File.Exists(path))
                {
                    using (var stream = File.OpenRead(path))
                    {
                        chicken = Texture2D.FromStream(GraphicsDevice, stream);
                    }
                }
                else
                {
                    System.Console.WriteLine("找不到图片，尝试路径: " + path);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("加载图片崩溃: " + ex.Message);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            // 蓝屏背景
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            
            if (chicken != null)
            {
                // 画小鸡
                spriteBatch.Draw(chicken, new Rectangle(
                    (GraphicsDevice.Viewport.Width / 2) - 64,
                    (GraphicsDevice.Viewport.Height / 2) - 64,
                    128, 128), Color.White);
            }
            else
            {
                // 如果图片还是没加载出来，在屏幕中间画一个红色的方块作为警告
                Texture2D redBox = new Texture2D(GraphicsDevice, 1, 1);
                redBox.SetData(new[] { Color.Red });
                spriteBatch.Draw(redBox, new Rectangle(
                    (GraphicsDevice.Viewport.Width / 2) - 64,
                    (GraphicsDevice.Viewport.Height / 2) - 64,
                    128, 128), Color.White);
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}