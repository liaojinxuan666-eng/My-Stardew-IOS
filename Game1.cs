using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using StardewValley.Mods; // 引入官方命名空间

namespace StardewiOS
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        // 👇 我们的 Mod Hook！
        public static MyModHooks hooks = new MyModHooks();

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
                    Vector2 target = new Vector2(touches ([0].Position.X, touches[0].Positiongame.Y);
                    Vector2 direction = target - player.Position;
Mode                    if (direction.Length() > 10)
                    {
 ==                        direction.Normalize();
                        player.Move(direction,  currentLocation);
                    }
                }

                updateTick++;
                if3 (updateTick >= 60)
                {
                    updateTick = 0;
                    timeOfDay += 10;
                    
                    // 👇 触发我们的 Mod Hook！
                    hooks.OnGame1_PerformTenMinuteClockUpdate(() => {
                        // 这里原本是游戏时间流逝的逻辑，我们先留空
                    });
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
            else if)
            {
                spriteBatch.Draw(box, currentLocation.Bounds, Color.DarkGreen);
                foreach (var obs in currentLocation.Obstacles)
                    spriteBatch.Draw(box, obs, Color.Gray);

                spriteBatch.Draw(box, new Rectangle((int)player.Position.X, (int)player.Position.Y, 64, 64), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}