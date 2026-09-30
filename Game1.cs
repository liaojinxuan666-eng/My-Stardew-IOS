using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch; // 引入触摸检测库
using System;

namespace StardewiOS
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // 👇 我们代替玩家的方块位置
        private Vector2 playerPosition;
        
        // 👇 复制自星露谷原版 Game1.cs 的时间变量
        public static int timeOfDay = 600; // 游戏时间，从早上 6:00 开始
        public static int dayOfMonth = 1;  // 当前天数
        public static int season = 0;      // 季节：0=春, 1=夏, 2=秋, 3=冬
        public static int year = 1;        // 年份
        private int updateTick = 0;        // 时间流逝计时器

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            // 把方块初始化在屏幕正中间
            playerPosition = new Vector2(
                GraphicsDevice.Viewport.Width / 2,
                GraphicsDevice.Viewport.Height / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            // 👇 1. 处理触摸输入（模拟玩家移动）
            TouchCollection touches = TouchPanel.GetState();
            if (touches.Count > 0)
            {
                // 获取第一个触摸点（手指）的位置
                // 减去 64 是因为方块宽高是 128，我们想让手指在方块正中心
                playerPosition.X = touches[0].Position.X - 64;
                playerPosition.Y = touches[0].Position.Y - 64;
            }

            // 👇 2. 处理星露谷时间流逝
            updateTick++;
            if (updateTick >= 60) // 每 60 帧算 10 分钟
            {
                updateTick = 0;
                timeOfDay += 10;

                // 超过凌晨 2:00 (2600)，进入新的一天
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
            // 👇 根据游戏时间改变背景色（模拟日夜交替）
            if (timeOfDay < 1800) // 6:00 - 18:00 白天
                GraphicsDevice.Clear(Color.CornflowerBlue);
            else if (timeOfDay < 2000) // 18:00 - 20:00 傍晚
                GraphicsDevice.Clear(Color.Orange);
            else // 20:00 以后 夜晚
                GraphicsDevice.Clear(Color.DarkBlue);

            spriteBatch.Begin();
            
            // 创建一个白色的纯色纹理来代表我们的"玩家"
            Texture2D playerBox = new Texture2D(GraphicsDevice, 1, 1);
            playerBox.SetData(new[] { Color.White });

            // 在触摸位置绘制这个方块
            spriteBatch.Draw(playerBox, new Rectangle(
                (int)playerPosition.X,
                (int)playerPosition.Y,
                128, 128), Color.White);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}