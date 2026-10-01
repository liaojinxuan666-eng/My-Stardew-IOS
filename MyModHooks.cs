using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// 👇 这里是我们本来打算新建的 StardewValleyStubs.cs 的内容
// 直接合并到这个文件顶部，就不需要新建文件了！
namespace StardewValley.Mods
{
    public class ModHooks
    {
        public virtual void OnGame1_PerformTenMinuteClockUpdate(Action action) { }
        public virtual bool OnRendering(RenderSteps step, SpriteBatch sb, GameTime time, RenderTarget2D target_screen) { return true; }
    }

    public enum RenderSteps
    {
        FullScene,
        World,
        HUD,
        Overlays
    }
}

// 👇 这才是我们真正的 Hook 实现
namespace StardewiOS
{
    using StardewValley.Mods;

    public class MyModHooks : ModHooks
    {
        public override void OnGame1_PerformTenMinuteClockUpdate(Action action)
        {
            // 每次游戏时间流逝 10 分钟，就会触发这里
            Console.WriteLine("【SMAPI iOS】游戏时钟更新！");
            action?.Invoke();
        }

        public override bool OnRendering(RenderSteps step, SpriteBatch sb, GameTime time, RenderTarget2D target_screen)
        {
            // 以后 Mod 绘制 UI 就可以在这里插入
            return true;
        }
    }
}