using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Configuration
{
    public class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            Type[] typesProfiles = onGetTypesInNamespace(Assembly.GetExecutingAssembly(), "Mapper.Profile");

            return new MapperConfiguration(x =>
            {

                foreach (var item in typesProfiles)
                {
                    if (item.IsSubclassOf(typeof(AutoMapper.Profile)))
                        x.AddProfile(item);
                }

            }).CreateMapper();
        }


        private static Type[] onGetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => t.Namespace == nameSpace)
                      .ToArray();
        }
    }
}
