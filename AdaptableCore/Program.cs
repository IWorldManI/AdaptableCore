using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Plugin;

namespace AdaptableCore
{
    class Program
    {
        static void Main()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string dllFolderPath = Path.Combine(currentDirectory, "AdaptableDLL");

            if (!Directory.Exists(dllFolderPath))
            {
                Directory.CreateDirectory(dllFolderPath);
            }

            while (true)
            {
                string[] dllFiles = Directory.GetFiles(dllFolderPath, "*.dll");

                foreach (string dllFile in dllFiles)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(dllFile);

                        Type pluginType = assembly.GetTypes().FirstOrDefault(type => typeof(IPlugin).IsAssignableFrom(type));

                        if (pluginType != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(pluginType);

                            plugin.PerfomanceAction();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при загрузке DLL {dllFile}: {ex.Message}");
                    }
                }
            }

        }
    }
}
