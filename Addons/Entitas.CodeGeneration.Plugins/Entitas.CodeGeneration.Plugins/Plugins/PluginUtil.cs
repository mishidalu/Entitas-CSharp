using System;
using Entitas.CodeGeneration.CodeGenerator;
using System.Collections.Generic;

namespace Entitas.CodeGeneration.Plugins {

    public static class PluginUtil {

        public const string ASSEMBLY_RESOLVER_KEY = "Entitas.CodeGeneration.Plugins.AssemblyResolver";

        public static AssemblyResolver GetCachedAssemblyResolver(Dictionary<string, object> objectCache, string[] assemblies, string[] basePaths) {
            object cachedAssemblyResolver;
            if (!objectCache.TryGetValue(ASSEMBLY_RESOLVER_KEY, out cachedAssemblyResolver)) {
                cachedAssemblyResolver = new AssemblyResolver(AppDomain.CurrentDomain, basePaths);
                var resolver = (AssemblyResolver)cachedAssemblyResolver;
                foreach (var path in assemblies) {
                    resolver.Load(path);
                }
                objectCache.Add(ASSEMBLY_RESOLVER_KEY, cachedAssemblyResolver);
            }

            return (AssemblyResolver)cachedAssemblyResolver;
        }
    }
}
