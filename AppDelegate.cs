using Foundation;
using UIKit;

namespace StardewiOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private Game1 _game;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            _game = new Game1();
            _game.Run(); // 启动 MonoGame 主循环
            return true;
        }
    }
}