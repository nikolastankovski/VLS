using AutoMapper;

namespace VLS.Shared
{
    public static class Helper
    {
        public static IEnumerable<Type> GetAutoMapperProfilesFromAllAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var assemblyType in assembly.GetTypes())
                {
                    if (assemblyType.IsClass && !assemblyType.IsAbstract && assemblyType.IsSubclassOf(typeof(Profile)))
                        yield return assemblyType;
                }
            }
        }
    }
}