using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace StardewiOS
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // 👇 复制自星露谷原版 Game1.cs 的核心时间变量
        public static int timeOfDay = 600; // 游戏时间，从早上 6:00 开始
        public static int dayOfMonth = 1;  // 当前天数
        public static int season = 0;      // 季节：0=春, 1=夏, 2=秋, 3=冬
        public static int year = 1;        // 年份

        private int updateTick = 0; // 计时器

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
            // 每跑 60 帧，游戏时间增加 10 分钟 (模仿原版逻辑)
            updateTick++;
            if (updateTick >= 60)
            {
                updateTick = 0;
                timeOfDay += 10;

                // 如果超过凌晨 2:00 (2600)，就进入新的一天
                if (timeOfDay >= 2600)
                {
                    timeOfDay = 600; // 重置到早上 6:00
                    dayOfMonth++;
                    
                    if (dayOfMonth > 28) // 星露谷每月 28 天
                    {
                        dayOfMonth = 1;
                        season++;
                        if (season > 3) // 四季轮回
                        {
                            season = 0;
                            year++;
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // 根据游戏时间改变背景色（模拟日夜交替）
            if (timeOfDay < 1800) // 6:00 - 18:00 白天
                GraphicsDevice.Clear(Color.CornflowerBlue);
            else if (timeOfDay < 2000) // 18:00 - 20:00 傍晚
                GraphicsDevice.Clear(Color.Orange);
            else // 20:00 以后 夜晚
                GraphicsDevice.Clear(Color.DarkBlue);

            spriteBatch.Begin();
            
            Texture2D box = new Texture2D(GraphicsDevice, 1, 1);
            box.SetData(new[] { Color.White }); // 白天是白块，晚上可以变成黄块
            
            // 红方块根据游戏时间在屏幕上移动
            int yPos = (int)((timeOfDay % 2000) / 2000.0 * GraphicsDevice.Viewport.Height);

            spriteBatch.Draw(box, new Rectangle(
                (GraphicsDevice.Viewport.Width / 2) - 64,
                yPos,
                128, 128), Color.White);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}