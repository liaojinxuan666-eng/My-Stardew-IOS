using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
                // 你提供的 Base64 字符串
                string base64String = "AAABAAIAEBAAAAEAIABoBAAAJgAAACAgAAABACAAqBAAAI4EAAAoAAAAEAAAACAAAAABACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////Af///wEQN2v/Idn//yHZ//87lOL/EDdr/zuU4v8h2f//Idn//xA3a/////8B////Af///wH///8B////Af///wH///8B////ARA3a/8QN2v/Fk+Z/xZPmf8WT5n/EDdr/xA3a/8WT5n/EDdr/xA3a/////8B////Af///wH///8B////ARA3a/8WT5n/WaDd/67h//9ZoN3/ruH//1mg3f+u4f//WaDd/1mg3f8WT5n/EDdr/////wH///8B////ARA3a/8WT5n/WaDd/67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//WaDd/xA3a/////8B////ARA3a/9ZoN3/WaDd/67h//9ZoN3/ruH//1mg3f+u4f//ruH//67h//+u4f//ruH//67h//8WT5n/EDdr/////wEQN2v/WaDd/1mg3f9ZoN3/ruH//1mg3f+u4f//ruH//67h//9ZoN3/EDdr/xA3a/9ZoN3/ruH//xA3a/////8BEDdr/1mg3f9ZoN3/ruH//67h//+u4f//ruH//67h//9ZoN3/EDdr/67h//9ZoN3/EDdr/67h//9ZoN3/EDdr/////wEQN2v/WaDd/1mg3f+u4f//ruH//67h//9ZoN3/WaDd/67h//+u4f//ruH//1mg3f+u4f//WaDd/xA3a/////8B////ARA3a/8WT5n/WaDd/67h//+u4f//ruH//67h//9ZoN3/ruH//67h//+u4f//ruH//xA3a/////8B////ARA3a/8h2f//Idn//yHZ//9ZoN3/ruH//xA3a/+u4f//EDdr/1mg3f+u4f//ruH//1mg3f9ZoN3/EDdr/////wH///8BEDdr/1mg3f8QN2v/ruH//67h//8QN2v/WaDd/xA3a/8QN2v/WaDd/67h//+u4f//ruH//xA3a/////8B////ARA3a/9ZoN3/EDdr/67h//+u4f//EDdr/1mg3f8QN2v/////ARA3a/8QN2v/EDdr/xA3a/////8B////Af///wH///8BEDdr/1mg3f+u4f//WaDd/1mg3f8QN2v/////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEQN2v/IyPC/yNO//8QN2v/EDdr/////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////ARA3a/8jTv//I07//yMjwv8QN2v/////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BEDdr/xA3a/8QN2v/EDdr/////wH///8B////Af///wH///8B////AcAfAADgBwAAwAMAAIADAAAAAQAAAAEAAAAAAACAAAAAwAEAAIAAAADAAAAAwCEAAOB/AADwfwAA+D8AAPw/AAAoAAAAIAAAAEAAAAABACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////Af///wH///8B////ARA3a/8QN2v/Idn//yHZ//8h2f//Idn//zuU4v87lOL/EDdr/xA3a/87lOL/O5Ti/yHZ//8h2f//Idn//yHZ//8QN2v/EDdr/////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BEDdr/xA3a/8h2f//Idn//yHZ//8h2f//O5Ti/zuU4v8QN2v/EDdr/zuU4v87lOL/Idn//yHZ//8h2f//Idn//xA3a/8QN2v/////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////ARA3a/8QN2v/EDdr/xA3a/8WT5n/Fk+Z/xZPmf8WT5n/Fk+Z/xZPmf8QN2v/EDdr/xA3a/8QN2v/Fk+Z/xZPmf8QN2v/EDdr/xA3a/8QN2v/////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BEDdr/xA3a/8QN2v/EDdr/xZPmf8WT5n/Fk+Z/xZPmf8WT5n/Fk+Z/xA3a/8QN2v/EDdr/xA3a/8WT5n/Fk+Z/xA3a/8QN2v/EDdr/xA3a/////8B////Af///wH///8B////Af///wH///8B////Af///wH///8BEDdr/xA3a/8WT5n/Fk+Z/1mg3f9ZoN3/ruH//67h//9ZoN3/WaDd/67h//+u4f//WaDd/1mg3f+u4f//ruH//1mg3f9ZoN3/WaDd/1mg3f8WT5n/Fk+Z/xA3a/8QN2v/////Af///wH///8B////Af///wH///8B////Af///wEQN2v/EDdr/xZPmf8WT5n/WaDd/1mg3f+u4f//ruH//1mg3f9ZoN3/ruH//67h//9ZoN3/WaDd/67h//+u4f//WaDd/1mg3f9ZoN3/WaDd/xZPmf8WT5n/EDdr/xA3a/////8B////Af///wH///8B////Af///wEQN2v/EDdr/xZPmf8WT5n/WaDd/1mg3f+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//WaDd/1mg3f8QN2v/EDdrEQ/////wH///8B////Af///NwH///8B////ARA3a/8QN2v/Fk+Z/xZPmf9ZoN3/WaDd/67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//9ZoN3/WaDd/xA3a/8QN2v/////Af///wH///8B////ARA3a/8QN2v/WaDd/1mg3f9ZoN3/WaDd/67h//+u4f//WaDd/1mg3f+u4f//ruH//1mg3f9ZoN3/ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//Fk+Z/xZPmf8QN2v/EDdr/////wH///8BEDdr/xA3a/9ZoN3/WaDd/1mg3f9ZoN3/ruH//67h//9ZoN3/WaDd/67h//+u4f//WaDd/1mg3f+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//8WT5n/Fk+Z/xA3a/8QN2v/////Af///w2v/EDdr/1mg3f9ZoN3/WaDd/1mg3f9ZoN3/WaDd/67h//+u4f//WaDd/1mg3f+u4f//ruH//67h//+u4f//ruH//67h//9ZoN3/WaDd/xA3a/8QN2v/EDdr/xA3a/9ZoN3/WaDd/67h//+u4f//EDdr/xA3a/////8B////ARA3a/8QN2v/WaDd/1mg3f9ZoN3/WaDd/1mg3f9ZoN3/ruH//67h//9ZoN3/WaDd/67h//+u4f//ruH//67h//+u4f//ruH//1mg3f9ZoN3/EDdr/xA3a/8QN2v/EDdr/1mg3f9ZoN3/ruH//67h//8QN2v/EDdr/////wH///8BEDdr/xA3a/9ZoN3/WaDd/1mg3f9ZoN3/ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//1mg3f9ZoN3/EDdr/xA3a/+u4f//ruH//1mg3f9ZoN3/EDdr/xA3a/+u4f//ruH//1mg3f9ZoN3/EDdr/xA3a/8QN2v/EDdr/1mg3f9ZoN3/WaDd/1mg3f+u4af//ruH//67h//+u4f//ru////H//67h//+u4f//ruH//67h//+u4f//WaDd/1mg3f8QN2v/EDdr/67h//+u4f//WaDd/1mg3f8QN2v/EDdr/67h//+u4f//WaDd/1mg3f8QN2v/EDdr/////wH///8BEDdr/xA3a/9ZoN3/WaDd/1mg3f9ZoN3/ruH//67h//+u4f//ruH//67h//+u4f//WaDd/1mg3f9ZoN3/WaDd/67h//+u4f//ruH//67h//+u4f//ruH//1mg3f9ZoN3/ruH//67h//9ZoN3/WaDd/xA3a/8QN2v/////Af///wEQN2v/EDdr/1mg3f9ZoN3/WaDd/1mg3f+u4f//ruH//67h//+u4f//ruH//67h//9ZoN3/WaDd/1mg3f9ZoN3/ruH//67h//+u4f//ruH//67h//+u4f//WaDd/1mg3f+u4f//ruH//1mg3f9ZoN3/EDdr/xA3a/////8B////Af///wH///8BEDdr/xA3a/8WT5n/Fk+Z/1mg3f9ZoN3/ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//9ZoN3/WaDd/67h//+u4f//ruH//67h//+u4f//ruH//67h//+u4f//EDdr/xA3a/////8B////Af///wH///8B////Af///wEQN2v/EDdr/xZPmf8WT5n/WaDd/1mg3f+u4f//ruH//67h//+u4f//ruH//67h//+u4f//ruH//1mg3f9ZoN3/ruH//67h//+u4f//ruH//67h//+u4f//ruH//67h//8QN2v/EDdr/////wH///8B////Af///wEQN2v/EDdr/yHZ//8h2f//Idn//yHZ//8h2f//Idn//1mg3f9ZoN3/ruH//67h//8QN2v/EDdr/67h//+u4f//EDdr/xA3a/9ZoN3/WaDd/67h//+u4f//ruH//67h//9ZoN3/WaDd/1mg3f9ZoN3/EDdr/xA3a/////8B////ARA3a/8QN2v/Idn//yHZ//8h2f//Idn//yHZ//8h2f//WaDd/1mg3f+u4f//ruH//xA3a/8QN2v/ruH//67h//8QN2v/EDdr/1mg3f9ZoN3/ruH//67h//+u4f//ruH//1mg3f9ZoN3/WaDd/1mg3f8QN2v/EDdr/////wH///8B////Af///wEQN2v/EDdr/1mg3f9ZoN3/EDdr/xA3a/+u4f//ruH//67h//+u4f//EDdr/xA3a/9ZoN3/WaDd/xA3a/8QN2v/EDdr/xA3a/9ZoN3/WaDd/67h//+u4f//ruH//67h//+u4f//ruH//xA3a/8QN2v/////Af///wH///8B////ARA3a/8QN2v/WaDd/1mg3f8QN2v/EDdr/67h//+u4f//ruH//67h//8QN2v/EDdr/1mg3f9ZoN3/EDdr/xA3a/8QN2v/EDdr/1mg3f9ZoN3/ruH//67h//+u4f//ruH//67h//+u4f//EDdr/xA3a/////8B////Af///wH///8BEDdr/xA3a/9ZoN3/WaDd/xA3a/8QN2v/ruH//67h//+u4f//ruH//xA3a/8QN2v/WaDd/1mg3f8QN2v/EDdr/////wH///8BEDdr/xA3a/8QN2v/EDdr/xA3a/8QN2v/EDdr/xA3/8B////Af///wH///8B////Af///wEQN2v/EDdr/1mg3f9ZoN3/EDdr/xA3a/+u4f//ruH//67h//+u4f//EDdr/xA3a/9ZoN3/WaDd/xA3a/8QN2v/////Af///wEQN2v/EDdr/xA3a/8QN2v/EDdr/xA3a/8QN2v/EDdr/////wH///8B////Af///wH///8B////Af///wH///8BEDdr/xA3a/9ZoN3/WaDd/67h//+u4f//WaDd/1mg3f9ZoN3/WaDd/xA3a/8QN2v/////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEQN2v/EDdr/1mg3f9ZoN3/ruH//67h//9ZoN3/WaDd/1mg3f9ZoN3/EDdr/xA3a/////8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BEDdr/xA3a/8jI8L/IyPC/yNO//8jTv//EDdr/xA3a/8QN2v/EDdr/////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEQN2v/EDdr/yMjwv8jI8L/I07//yNO//8QN2v/EDdr/xA3a/8QN2v/////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BEDdr/xA3a/8jTv//I07//yNO//8jTv//IyPC/yMjwv8QN2v/EDdr/////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEQN2v/EDdr/yNO//8jTv//I07//yNO//8jI8L/IyPC/xA3a/8QN2v/////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BEDdr/xA3a/8QN2v/EDdr/xA3a/8QN2v/EDdr/xA3a/////8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEQN2v/EDdr/xA3a/8QN2v/EDdr/xA3a/8QN2v/EDdr/////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AfAAA//wAAP//AAAP/wAAD/wAAAP8AAAD8AAAA/AAAAPAAAAAwAAAAMAAAADAAAAAwAAAAAAAAAAwAAAAMAAAADwAAAD8AAAA8AAAADAAAAA8AAAAPAAAADwAAwD8AAMA/wAP//8AD///wA///8AP///wA///8AP///wD///8A//";
                
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (var stream = new MemoryStream(imageBytes))
                {
                    chicken = Texture2D.FromStream(GraphicsDevice, stream);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Base64 解码或图片解析失败: " + ex.Message);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (chicken != null)
            {
                spriteBatch.Draw(chicken, new Rectangle(
                    (GraphicsDevice.Viewport.Width / 2) - 64,
                    (GraphicsDevice.Viewport.Height / 2) - 64,
                    128, 128), Color.White);
            }
            else
            {
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