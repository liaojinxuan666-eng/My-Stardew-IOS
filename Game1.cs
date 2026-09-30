using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace StardewiOS
{
    // 👇 模拟星露谷的"地图"类（GameLocation）
    public class SimpleLocation
    {
        public Rectangle Bounds;
        public SimpleLocation(Rectangle bounds) { Bounds = bounds; }
    }

    // 👇 模拟星露谷的"玩家"类（Farmer）
    public class SimpleFarmer
    {
        public Vector2 Position;
        public int Speed = 4;
        
        public void Move(Vector2 direction)
        {
            Position += direction * Speed;
            // 限制玩家不要跑出地图边界
            Position.X = Math.Clamp(Position.X, 0, 1000 - 64);
            Position.Y = Math.Clamp(Position.Y, 0, 1000 - 64);
        }
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // 👇 核心：游戏状态
        public static int gameMode = 0; // 0 = 标题画面, 3 = 正常游戏
        private SimpleLocation currentLocation;
        private SimpleFarmer player;

        // 时间变量
        public static int timeOfDay = 600;
        public static int dayOfMonth = 1;
        public static int season = 0;
        public static int year = 1;
        private int updateTick = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            // 初始化地图和玩家
            currentLocation = new SimpleLocation(new Rectangle(0, 0, 1000, 1000));
            player = new SimpleFarmer { Position = new Vector2(500, 500) };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            TouchCollection touches = TouchPanel.GetState();

            if (gameMode == 0)
            {
                // 标题画面：点一下屏幕就进入游戏
                if (touches.Count > 0 && touches[0].State == TouchLocationState.Pressed)
                {
                    gameMode = 3;
                    Console.WriteLine("进入游戏世界！");
                }
            }
            else if (gameMode == 3)
            {
                // 正常游戏：根据触摸位置控制玩家移动
                if (touches.Count > 0)
                {
                    Vector2 target = new Vector2(touches[0].Position.X, touches[0].Position.Y);
                    Vector2 direction = target - player.Position;
                    if (direction.Length() > 10) // 防止抖动
                    {
                        direction.Normalize();
                        player.Move(direction);
                    }
                }

                // 时间流逝逻辑（沿用之前代码）
                updateTick++;
                if (updateTick >= 60)
                {
                    updateTick = 0;
                    timeOfDay += 10;
                    if (timeOfDay >= 2600)
                    {
                        timeOfDay = 600;
                        dayOfMonth++;
                        if (dayOfMonth > 28)
                        {
                            dayOfMonth = 1;
                            season++;
                            if (season > 3) { season = 0; year++; }
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // 创建一个纯色纹理用来画方块
            Texture2D box = new Texture2D(GraphicsDevice, 1, 1);
            box.SetData(new[] { Color.White });

            if (gameMode == 0)
            {
                // 画一个白色的"开始按钮"
                spriteBatch.Draw(box, new Rectangle(
                    (GraphicsDevice.Viewport.Width / 2) - 100,
                    (GraphicsDevice.Viewport.Height / 2) - 50,
                    200, 100), Color.Green); // 绿色按钮
            }
            else if (gameMode == 3)
            {
                // 画地图（深绿色背景块代表草地）
                spriteBatch.Draw(box, new Rectangle(0, 0, 1000, 1000), Color.DarkGreen);

                // 画玩家（白色方块）
                spriteBatch.Draw(box, new Rectangle(
                    (int)player.Position.X,
                    (int)player.Position.Y,
                    64, 64), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}