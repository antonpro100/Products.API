using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Products.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            ApplyMappyngFromAssembly(assembly);
        }

        private void ApplyMappyngFromAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && 
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");

                if(methodInfo == null)
                    methodInfo = typeof(IMapWith<>)
                        .GetMethod("Mapping")
                        .MakeGenericMethod(type);

                methodInfo?.Invoke(instance, new []{ this });
            }

        }
    }
}
