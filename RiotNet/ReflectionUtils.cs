using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RiotNet
{
    /// <summary>
    /// Contains reflection-related helper methods.
    /// </summary>
    public static class ReflectionUtils
    {
        /// <summary>
        /// Gets the IList&lt;&gt; interface that the type implements, if any.
        /// </summary>
        /// <param name="type">The type of object that implements the interface.</param>
        /// <returns>The first IList&lt;&gt; interface found, or null if no interface was found.</returns>
        public static Type GetListInterface(Type type)
        {
            return GetGenericInterface(type, typeof(IList<>));
        }

        /// <summary>
        /// Gets the interface that a type implements that matches the specified generic interface definition.
        /// </summary>
        /// <param name="type">The type of object that implements the interface.</param>
        /// <param name="genericInterfaceDefinition">A generic type definition for an interface (e.g. typeof(IEnumerable&lt;&gt;)).</param>
        /// <returns>The first interface found that matches the generic interface definition, or null if no match was found.</returns>
        public static Type GetGenericInterface(Type type, Type genericInterfaceDefinition)
        {
            while (type != null)
            {
                var typeInfo = type.GetTypeInfo();
                var genericInterface = typeInfo.GetInterfaces().Where(t => t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == genericInterfaceDefinition).FirstOrDefault();
                if (genericInterface != null)
                    return genericInterface;
                type = typeInfo.BaseType;
            }
            return null;
        }

        /// <summary>
        /// Gets whether the specified type is a subclass of a generic type represented by the specified generic type definition.
        /// </summary>
        /// <param name="objectType">The type to check.</param>
        /// <param name="genericTypeDefinition">A generic type definition (e.g. typeof(List&lt;&gt;))</param>
        /// <returns>A value that indicates whether the type is a subclass of the generic type definition.</returns>
        public static bool IsSubclassOfGenericTypeDefinition(Type objectType, Type genericTypeDefinition)
        {
            while (objectType != null && objectType != typeof(object))
            {
                var typeInfo = objectType.GetTypeInfo();
                var cur = typeInfo.IsGenericType ? objectType.GetGenericTypeDefinition() : objectType;
                if (genericTypeDefinition == cur)
                    return true;
                objectType = typeInfo.BaseType;
            }
            return false;
        }
    }
}
