﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// Gets whether a type is a Nullable&lt;T&gt;.
        /// </summary>
        /// <param name="type">A type</param>
        /// <returns>A boolean value that indicates whether the type is a Nullable&lt;T&gt;.</returns>
        public static bool IsNullableType(Type type)
        {
            return type != null && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Gets the underlying type if the type is a Nullable&lt;T&gt;. Otherwise gets the type itself.
        /// </summary>
        /// <param name="t">A type</param>
        /// <returns>A boolean value that indicates whether the type is a Nullable&lt;T&gt;.</returns>
        public static Type GetUnderlyingType(Type type)
        {
            return IsNullableType(type) ? type.GetGenericArguments()[0] : type;
        }

        private static int sampleInt = 2;
        private static long sampleLong = 2L;
        private static double sampleDouble = 2;
        private static int sampleStringCount = 1;
        private static DateTime sampleDateTime = new DateTime(2015, 5, 16, 3, 4, 0, 500, DateTimeKind.Utc);
        private static TimeSpan sampleTimeSpan = TimeSpan.FromMilliseconds(250);
        private static int sampleListCount = 1;
        private static int sampleDictionaryCount = 1;

        /// <summary>
        /// Creates an instance of the specified object with each of its properties initialized to non-default values.
        /// </summary>
        /// <param name="type">The type of object to create.</param>
        /// <returns>An object.</returns>
        public static object Create(Type type)
        {
            type = GetUnderlyingType(type);
            if (type == typeof(int))
                return sampleInt++;
            if (type == typeof(long))
                return sampleLong++;
            if (type == typeof(double))
                return sampleDouble++;
            if (type == typeof(string))
                return "test" + (sampleStringCount++);
            if (type == typeof(bool))
                return true;
            if (type == typeof(DateTime))
            {
                sampleDateTime = sampleDateTime.AddSeconds(1);
                return sampleDateTime;
            }
            if (type == typeof(TimeSpan))
            {
                sampleTimeSpan += TimeSpan.FromSeconds(1);
                return sampleTimeSpan;
            }
            if (type.IsEnum)
                return Enum.GetValues(type).Cast<object>().Last();
            if (type.IsInterface)
            {
                if (type.IsGenericType)
                {
                    var typeArguments = type.GetGenericArguments();
                    if (typeArguments.Length == 1)
                    {
                        var genericTypeDefinition = type.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(IEnumerable<>) || genericTypeDefinition == typeof(ICollection<>) || genericTypeDefinition == typeof(IList<>))
                        {
                            type = typeof(List<>).MakeGenericType(typeArguments);
                        }
                    }
                    else if (typeArguments.Length == 2)
                    {
                        var genericTypeDefinition = type.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(IDictionary<,>))
                        {
                            type = typeof(Dictionary<,>).MakeGenericType(typeArguments);
                        }
                    }
                }
                if (type.IsInterface)
                    throw new Exception("Unsupported interface type: " + type.FullName);
            }
            if (!type.IsClass)
                throw new Exception("Unsupported struct type: " + type.FullName);

            var obj = Activator.CreateInstance(type);

            var dictionaryType = GetDictionaryInterface(type);
            if (dictionaryType != null)
            {
                var typeArgs = dictionaryType.GetGenericArguments();
                var dictionary = (IDictionary)obj;
                var keyType = typeArgs[0];
                var valueType = typeArgs[1];
                for (var i = 0; i < sampleDictionaryCount; ++i)
                {
                    var key = Create(keyType);
                    var value = Create(valueType);
                    dictionary.Add(key, value);
                }
                sampleDictionaryCount = sampleDictionaryCount % 2 + 1;
                return obj;
            }
            var collectionType = GetListInterface(type);
            if (collectionType != null)
            {
                var typeArgs = collectionType.GetGenericArguments();
                var itemType = typeArgs[0];
                var collection = (IList)obj;
                for (var i = 0; i < sampleListCount; ++i)
                {
                    var value = Create(itemType);
                    collection.Add(value);
                }
                sampleListCount = sampleListCount % 2 + 1;
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
        /// <param name="forDefaults">Indicates whether the comparison is for default values. In defaults mode, only JSON-serializable properties should be compared, and [ComplexType] objects may be set even if the default is null.</param>
        /// <param name="propertyName">The property name to display in the error message if the assertion fails.</param>
        public static void AssertObjectEqualityRecursive(object a, object b, bool forDefaults = false, string propertyName = null)
        {
            if (propertyName == null)
                propertyName = b != null ? b.GetType().Name : "object";

            if (b == null)
            {
                if (forDefaults && a != null)
                {
                    // If the default value for a [ComplexType] object is null, we permit it to be set, because it must be non-null to be saveable in the database.
                    if (a.GetType().GetCustomAttribute<ComplexTypeAttribute>() != null)
                        return;
                }
                Assert.That(a, Is.Null, "Value for " + propertyName + " is incorrect.");
                return;
            }
            Assert.That(a, Is.Not.Null, "Value for " + propertyName + " is incorrect.");
            Assert.That(b, Is.Not.Null);
            var type = b.GetType();
            Assert.That(a, Is.InstanceOf(type), "Objects have different types (" + propertyName + ").");
            if (!type.IsClass || type == typeof(string))
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
                    AssertObjectEqualityRecursive(enumeratorA.Current, enumeratorB.Current, forDefaults, propertyName + "[" + i + "]");
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
                    if (forDefaults && property.GetCustomAttribute<JsonIgnoreAttribute>() != null)
                        continue;
                    var value1 = property.GetValue(a);
                    var value2 = property.GetValue(b);
                    AssertObjectEqualityRecursive(value1, value2, forDefaults, propertyName + property.Name);
                }
            }
        }

    }
}
