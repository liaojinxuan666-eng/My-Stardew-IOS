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
        Texture2D farmerTexture; // 新增：存放玩家贴图

        public static int gameMode = 0;
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

            // 👇 加载图片的核心代码
            try
            {
                using (var stream = TitleContainer.OpenStream("Content/farmer.png"))
                {
                    farmerTexture = Texture2D.FromStream(GraphicsDevice, stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("图片加载失败！错误：" + ex.Message);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            TouchCollection touches = TouchPanel.GetState();

            if (gameMode == 0)
            {
                if (touches.Count > 0 && touches[0].State == TouchLocationState.Pressed)
                    gameMode = 3;
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
                        player.Move(direction, currentLocation);
                    }
                }

                updateTick++;
                if (updateTick >= 60) { updateTick = 0; timeOfDay += 10; }
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
                spriteBatch.Draw(box, currentLocation.Bounds, Color.DarkGreen);
                foreach (var obs in currentLocation.Obstacles)
                    spriteBatch.Draw(box, obs, Color.Gray);

                // 👇 绘制真正的星露谷角色贴图
                if (farmerTexture != null)
                {
                    // 假设贴图里包含4个方向的行走帧，我们按64x64的尺寸裁切
                    // 这里先简单地画出整个图，测试能不能显示出来
                    spriteBatch.Draw(farmerTexture, new Rectangle((int)player.Position.X, (int)player.Position.Y, 64, 64), Color.White);
                }
                else
                {
                    // 如果图片依然加载失败，继续画白方块兜底
                    spriteBatch.Draw(box, new Rectangle((int)player.Position.X, (int)player.Position.Y, 64, 64), Color.White);
                }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}