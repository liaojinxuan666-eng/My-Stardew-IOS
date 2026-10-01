using System;
using System.IO;
using System.Reflection;

namespace StardewiOS
{
    public static class ModLoader
    {
        public static void LoadAllMods()
        {
            // 获取 iOS 沙盒的 Documents 目录
            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string modsDir = Path.Combine(docs, "Mods");

            if (!Directory.Exists(modsDir))
            {
                Directory.CreateDirectory(modsDir);
                Console.WriteLine("创建 Mods 文件夹：" + modsDir);
                return;
            }

            Console.WriteLine("开始扫描 Mods 文件夹...");
            string[] dllFiles = Directory.GetFiles(modsDir, "*.dll", SearchOption.AllDirectories);

            foreach (var dll in dllFiles)
            {
                try
                {
                    // 👇 核心！动态加载外部 DLL！
                    Assembly asm = Assembly.LoadFrom(dll);
                    Console.WriteLine("成功加载 Mod: " + asm.FullName);

                    // 这里我们暂时不执行它，先证明能加载进去
                }
                catch (Exception ex)
                {
                    Console.WriteLine("加载 Mod 失败: " + dll + " 错误: " + ex.Message);
                }
            }
        }
    }
}