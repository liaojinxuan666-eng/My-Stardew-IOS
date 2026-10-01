using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// 👇 我们自己声明这个命名空间，骗过编译器！
namespace StardewValley.Mods
{
    // 原版的空壳 ModHooks 类（只保留我们需要用的方法）
    public class ModHooks
    {
        public virtual void OnGame1_PerformTenMinuteClockUpdate(Action action) { }
        public virtual bool OnRendering(RenderSteps step, SpriteBatch sb, GameTime time, RenderTarget2D target_screen) { return true; }
    }

    // 原版的 RenderSteps 枚举
    public enum RenderSteps
    {
        FullScene,
        World,
        HUD,
        Overlays
    }
}