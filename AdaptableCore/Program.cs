using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Plugin;

namespace AdaptableCore
{
    public class AdaptableService
    {
        public static string dllFolderPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "AdaptableDLL");

        public AdaptableService(string dllFolderPath)
        {
            if (!Directory.Exists(dllFolderPath))
            {
                Directory.CreateDirectory(dllFolderPath);
            }
        }

        public void ProcessPlugins()
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
                        IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;

                        plugin.PerformAction();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading DLL {dllFile}: {ex.Message}");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dllFolderPath = Path.Combine(currentDirectory, "AdaptableDLL");

            AdaptableService adaptableService = new AdaptableService(dllFolderPath);

            while (true)
            {
                adaptableService.ProcessPlugins();
            }
        }
    }
}
