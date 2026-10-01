using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// 👇 手动造的官方接口空壳，避免编译找不到类型
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

// 👇 我们自己的 Mod Hook 实现
namespace StardewiOS
{
    using StardewValley.Mods;

    public class MyModHooks : ModHooks
    {
        public override void OnGame1_PerformTenMinuteClockUpdate(Action action)
        {
            Console.WriteLine("【SMAPI iOS】游戏时钟更新！");
            action?.Invoke();
        }

        public override bool OnRendering(RenderSteps step, SpriteBatch sb, GameTime time, RenderTarget2D target_screen)
        {
            return true;
        }
    }
}