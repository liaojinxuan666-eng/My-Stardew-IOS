using System;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.Mods;

namespace StardewiOS
{
    // 👇 继承官方的 ModHooks，接管游戏的核心生命周期
    public class MyModHooks : ModHooks
    {
        public override void OnGame1_PerformTenMinuteClockUpdate(Action action)
        {
            // 每 10 分钟触发一次，我们在这里可以插入 Mod 的逻辑
            Console.WriteLine("【SMAPI iOS】游戏时钟更新！");
            action?.Invoke(); // 继续执行游戏原本的逻辑
        }

        public override bool OnRendering(RenderSteps step, SpriteBatch sb, GameTime time, RenderTarget2D target_screen)
        {
            // 我们可以在这里插入自定义的绘制代码（比如 Mod 的 UI）
            return true; // 返回 true 表示允许游戏继续正常绘制
        }
    }
}