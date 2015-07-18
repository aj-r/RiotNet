using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace RiotNet.Tests
{
    /// <summary>
    /// A base class for test classes.
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// Creates an instance of the specified object and initializes each of its properties to non-default values.
        /// </summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <returns>An object.</returns>
        public static T Create<T>() where T : class
        {
            return (T)Create(typeof(T));
        }

        /// <summary>
        /// Creates an instance of the specified object with each of its properties initialized to non-default values.
        /// </summary>
        /// <param name="type">The type of object to create.</param>
        /// <returns>An object.</returns>
        public static object Create(Type type)
        {
            if (type == typeof(int))
                return 2;
            if (type == typeof(long))
                return 2L;
            if (type == typeof(double))
                return 1.5;
            if (type == typeof(string))
                return "test";
            if (type == typeof(bool))
                return true;
            if (type == typeof(DateTime))
                return new DateTime(2015, 5, 16, 3, 4, 5, 500, DateTimeKind.Utc);
            if (type.IsEnum)
                return Enum.GetValues(type).Cast<object>().Last();
            if (!type.IsClass)
                throw new Exception("Unsupported struct type: " + type.FullName);

            var obj = Activator.CreateInstance(type);

            var dictionaryType = GetDictionaryInterface(type);
            if (dictionaryType != null)
            {
                var typeArgs = dictionaryType.GetGenericArguments();
                var key = Create(typeArgs[0]);
                var value = Create(typeArgs[1]);
                var dictionary = (IDictionary)obj;
                dictionary.Add(key, value);
                return obj;
            }
            var collectionType = GetListInterface(type);
            if (collectionType != null)
            {
                var typeArgs = collectionType.GetGenericArguments();
                var value = Create(typeArgs[0]);
                var collection = (IList)obj;
                collection.Add(value);
                return obj;
            }

            foreach (var property in type.GetProperties())
            {
                var value = Create(property.PropertyType);
                property.SetValue(obj, value);
            }
            return obj;
        }

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
        /// Gets the IDictionary&lt;,&gt; interface that the type implements, if any.
        /// </summary>
        /// <param name="type">The type of object that implements the interface.</param>
        /// <returns>The first IDictionary&lt;,&gt; interface found, or null if no interface was found.</returns>
        public static Type GetDictionaryInterface(Type type)
        {
            return GetGenericInterface(type, typeof(IDictionary<,>));
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
                var genericInterface = type.GetInterfaces().Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == genericInterfaceDefinition).FirstOrDefault();
                if (genericInterface != null)
                    return genericInterface;
                type = type.BaseType;
            }
            return null;
        }

        /// <summary>
        /// Asserts value equality for two objects.
        /// </summary>
        /// <param name="a">An object.</param>
        /// <param name="b">An object.</param>
        /// <param name="json">Indicates whether only JSON-serializable properties should be compared. If true, any property with a JsonIgnoreAttribute is ignored.</param>
        /// <param name="propertyName">The property name to display in the error message if the assertion fails.</param>
        public static void AssertObjectEqualityRecursive(object a, object b, bool json = false, string propertyName = null)
        {
            if (propertyName == null)
                propertyName = b != null ? b.GetType().Name : "object";

            if (b == null)
            {
                Assert.That(a, Is.Null, "Value for " + propertyName + " is incorrect.");
                return;
            }
            Assert.That(a, Is.Not.Null, "Value for " + propertyName + " is incorrect.");
            Assert.That(b, Is.Not.Null);
            var type = b.GetType();
            Assert.That(a, Is.InstanceOf(type), "Objects have different types (" + propertyName + ").");
            if (!type.IsClass)
            {
                Assert.That(a, Is.EqualTo(b), "Default value for " + propertyName + " is incorrect.");
                return;
            }

            if (a is IEnumerable)
            {
                var enumeratorA = ((IEnumerable)a).GetEnumerator();
                var enumeratorB = ((IEnumerable)b).GetEnumerator();
                int i = 0;
                var nextA = enumeratorA.MoveNext();
                var nextB = enumeratorB.MoveNext();
                while (nextA && nextB)
                {
                    AssertObjectEqualityRecursive(enumeratorA.Current, enumeratorB.Current, json, propertyName + "[" + i + "]");
                    nextA = enumeratorA.MoveNext();
                    nextB = enumeratorB.MoveNext();
                    ++i;
                }
                if (nextA && !nextB)
                    Assert.Fail("There are too many items in " + propertyName);
                if (!nextA && nextB)
                    Assert.Fail("There are not enough items in " + propertyName);
            }
            else
            {
                propertyName += ".";
                foreach (var property in type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance))
                {
                    if (json && property.GetCustomAttribute<JsonIgnoreAttribute>() != null)
                        continue;
                    var value1 = property.GetValue(a);
                    var value2 = property.GetValue(b);
                    AssertObjectEqualityRecursive(value1, value2, json, propertyName + property.Name);
                }
            }
        }

    }
}
