using System;
using System.IO;
using System.Reflection;

namespace StardewiOS
{
    public static class ModLoader
    {
        public static void LoadAllMods()
        {
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
                    Assembly asm = Assembly.LoadFrom(dll);
                    Console.WriteLine("成功加载 Mod: " + asm.FullName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("加载 Mod 失败: " + dll + " 错误: " + ex.Message);
                }
            }
        }
    }
}