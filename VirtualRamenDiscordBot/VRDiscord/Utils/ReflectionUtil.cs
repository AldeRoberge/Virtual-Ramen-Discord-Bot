using System;
using System.Collections.Generic;
using System.Reflection;

namespace VRDiscord.Utils
{
    public static class ReflectionUtils<T>
    {
        /// <summary>
        /// Loads all the non-abstract classes that inherit from the given type using reflection.
        /// </summary>
        public static List<T> Load()
        {
            List<T> instances = new List<T>();

            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                // Make sure the type is not abstract
                if (type.IsAbstract)
                    continue;

                if (type.IsSubclassOf(typeof(T)))
                {
                    instances.Add((T) Activator.CreateInstance(type));
                }
            }

            return instances;
        }
    }
}