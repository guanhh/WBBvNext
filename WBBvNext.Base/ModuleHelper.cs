using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WBBvNext.Base
{
    public class ModuleHelper
    {
        private static List<Assembly> PlugAssemblies = null;
        private static List<IWBBModule> WBBModules = null;

        public static List<Assembly> GetPlugAssemblies()
        {
            if (PlugAssemblies == null)
            {
                PlugAssemblies = new List<Assembly>();
                var plugDir = $"{AppDomain.CurrentDomain.BaseDirectory}{WBBSetting.PLUG_DIR}";

                if (!Directory.Exists(plugDir))
                {
                    Directory.CreateDirectory(plugDir);
                }

                var files = Directory.GetFiles(plugDir, WBBSetting.PLUG_PATTERN, SearchOption.AllDirectories);
                List<string> assNames = new List<string>();

                foreach (var file in files)
                {
                    var assName = file[(file.LastIndexOf("\\") + 1)..];
                    if (assNames.Contains(assName))
                        continue;

                    assNames.Add(assName);
                    var ass = Assembly.LoadFrom(file);

                    if (!PlugAssemblies.Contains(ass))
                        PlugAssemblies.Add(ass);
                }
            }
            return PlugAssemblies;
        }

        public static List<Assembly> GetPlugPageAssemblies()
        {
            var plugAssemblies = GetPlugAssemblies();
            return plugAssemblies.Where(m => m.GetName().Name.EndsWith(WBBSetting.PAGE_END)).ToList();
        }

        public static List<Assembly> GetPlugServiceAssemblies()
        {
            var plugAssemblies = GetPlugAssemblies();
            return plugAssemblies.Where(m => m.GetName().Name.EndsWith(WBBSetting.EXTENSION_END)).ToList();
        }

        public static List<IWBBModule> GetWBBModules()
        {
            if (WBBModules != null)
                return WBBModules;

            WBBModules = new List<IWBBModule>();

            var assList = GetPlugServiceAssemblies();

            foreach (var assembly in assList)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (typeof(IWBBModule).IsAssignableFrom(type))
                    {
                        WBBModules.Add((IWBBModule)Activator.CreateInstance(type));
                    }
                }
            }
            return WBBModules;
        }

    }
}
