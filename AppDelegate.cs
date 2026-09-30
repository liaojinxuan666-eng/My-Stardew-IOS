using Foundation;
using UIKit;
using System;
using System.IO;

namespace StardewiOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private Game1 _game;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            try
            {
                _game = new Game1();
                _game.Run();
            }
            catch (Exception ex)
            {
                // 崩溃时把错误写到手机文件App的Documents目录下
                string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "crash.log");
                File.WriteAllText(logPath, ex.ToString());
                Console.WriteLine("崩溃: " + ex.ToString());
            }
            return true;
        }
    }
}