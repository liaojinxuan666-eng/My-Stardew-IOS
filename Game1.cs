using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace StardewiOS
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int gameMode = 0; // 0 = 标题画面, 3 = 正常游戏
        private GameLocation currentLocation;
        private Farmer player;
        private int updateTick = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            currentLocation = new GameLocation("Farm", new Rectangle(0, 0, 1000, 1000));
            player = new Farmer { Position = new Vector2(500, 500) };
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
                if (touches.Count > 0 && touches[0].State == TouchLocationState.Pressed)
                {
                    gameMode = 3;
                }
            }
            else if (gameMode == 3)
            {
                if (touches.Count > 0)
                {
                    Vector2 target = new Vector2(touches[0].Position.X, touches[0].Position.Y);
                    Vector2 direction = target - player.Position;
                    if (direction.Length() > 10)
                    {
                        direction.Normalize();
                        // 把地图传进去，让玩家自己处理碰撞
                        player.Move(direction, currentLocation);
                    }
                }

                // 时间流逝
                updateTick++;
                if (updateTick >= 60)
                {
                    updateTick = 0;
                    timeOfDay += 10;
                }
            }
            base.Update(gameTime);
        }

        public static int timeOfDay = 600;
        public static int dayOfMonth = 1;
        public static int season = 0;
        public static int year = 1;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            Texture2D box = new Texture2D(GraphicsDevice, 1, 1);
            box.SetData(new[] { Color.White });

            if (gameMode == 0)
            {
                spriteBatch.Draw(box, new Rectangle((GraphicsDevice.Viewport.Width / 2) - 100, (GraphicsDevice.Viewport.Height / 2) - 50, 200, 100), Color.Green);
            }
            else if (gameMode == 3)
            {
                // 1. 画地图背景（深绿色）
                spriteBatch.Draw(box, currentLocation.Bounds, Color.DarkGreen);

                // 2. 画障碍物（灰色）
                foreach (var obs in currentLocation.Obstacles)
                {
                    spriteBatch.Draw(box, obs, Color.Gray);
                }

                // 3. 画玩家（白色方块）
                spriteBatch.Draw(box, new Rectangle((int)player.Position.X, (int)player.Position.Y, 64, 64), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}