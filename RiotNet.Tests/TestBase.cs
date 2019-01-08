using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RiotNet.Tests
{
    /// <summary>
    /// A base class for test classes.
    /// </summary>
    [TestFixture]
    public class TestBase
    {
        private static string apiKey;
        private static string tournamentApiKey;

        static TestBase()
        {
            // Load the API key from the text file.
            try
            {
                apiKey = File.ReadAllText("key.txt").Trim();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Please enter your API key in key.txt");
                throw;
            }
            try
            {
                tournamentApiKey = File.ReadAllText("tournament-key.txt").Trim();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Please enter your tournament API key in tournament-key.txt");
                throw;
            }
        }

        [SetUp]
        public void TestSetUp()
        {
            // Reset the settings after every test because some tests will mess up the settings.
            SetRiotClientSettings();
        }

        public string ApiKey
        {
            get { return apiKey; }
        }

        public string TournamentApiKey
        {
            get { return tournamentApiKey; }
        }

        /// <summary>
        /// Gets whether a type is a Nullable&lt;T&gt;.
        /// </summary>
        /// <param name="type">A type</param>
        /// <returns>A boolean value that indicates whether the type is a Nullable&lt;T&gt;.</returns>
        public static bool IsNullableType(Type type)
        {
            return type != null && type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
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
        private static double sampleDouble = 2.0;
        private static int sampleStringCount = 1;
        private static DateTime sampleDateTime = new DateTime(2015, 5, 16, 3, 4, 0, 500, DateTimeKind.Utc);
        private static TimeSpan sampleTimeSpan = TimeSpan.FromMilliseconds(250);
        private static int sampleListCount = 1;
        private static int sampleDictionaryCount = 1;

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
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsEnum)
                return Enum.GetValues(type).Cast<object>().Last();
            if (typeInfo.IsInterface)
            {
                if (typeInfo.IsGenericType)
                {
                    var typeArguments = type.GetGenericArguments();
                    if (typeArguments.Length == 1)
                    {
                        var genericTypeDefinition = type.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(IEnumerable<>) || genericTypeDefinition == typeof(ICollection<>) || genericTypeDefinition == typeof(IList<>))
                        {
                            type = typeof(List<>).MakeGenericType(typeArguments);
                            typeInfo = type.GetTypeInfo();
                        }
                    }
                    else if (typeArguments.Length == 2)
                    {
                        var genericTypeDefinition = type.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(IDictionary<,>))
                        {
                            type = typeof(Dictionary<,>).MakeGenericType(typeArguments);
                            typeInfo = type.GetTypeInfo();
                        }
                    }
                }
                if (typeInfo.IsInterface)
                    throw new Exception("Unsupported interface type: " + type.FullName);
            }
            if (!typeInfo.IsClass)
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
            var collectionType = ReflectionUtils.GetListInterface(type);
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
        /// Resets the sample values used for the Create method.
        /// </summary>
        public static void ResetSampleValues()
        {
            sampleInt = 2;
            sampleLong = 2L;
            sampleDouble = 2.0;
            sampleStringCount = 1;
            sampleDateTime = new DateTime(2015, 5, 16, 3, 4, 0, 500, DateTimeKind.Utc);
            sampleTimeSpan = TimeSpan.FromMilliseconds(250);
            sampleListCount = 1;
            sampleDictionaryCount = 1;
        }

        /// <summary>
        /// Asserts value equality for two objects.
        /// </summary>
        /// <param name="a">An object.</param>
        /// <param name="b">An object.</param>
        /// <param name="forDefaults">Indicates whether the comparison is for default values. In defaults mode, only JSON-serializable properties should be compared, and [ComplexType] objects may be set even if the default is null.</param>
        /// <param name="forDatabase">Indicates whether the comparison is for database values. In database mode, properties named 'DatabaseId' are not compared; instead they are checked for non-zero values.</param>
        /// <param name="propertyName">The property name to display in the error message if the assertion fails.</param>
        public static void AssertObjectEqualityRecursive(object a, object b, bool forDefaults = false, bool forDatabase = false, string propertyName = null)
        {
            if (propertyName == null)
                propertyName = b != null ? b.GetType().Name : "object";

            if (b == null)
            {
                if (forDefaults && a != null)
                {
                    // If the default value for a [ComplexType] object is null, we permit it to be set, because it must be non-null to be saveable in the database.
                    if (a.GetType().GetTypeInfo().GetCustomAttribute<ComplexTypeAttribute>() != null)
                        return;
                }
                Assert.That(a, Is.Null, "Value for " + propertyName + " is incorrect.");
                return;
            }
            Assert.That(a, Is.Not.Null, "Value for " + propertyName + " is incorrect.");
            Assert.That(b, Is.Not.Null);
            var type = b.GetType();
            Assert.That(a, Is.InstanceOf(type), "Objects have different types (" + propertyName + ").");
            if (!type.GetTypeInfo().IsClass || type == typeof(string))
            {
                Assert.That(a, Is.EqualTo(b), "Value for " + propertyName + " is incorrect.");
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
                    AssertObjectEqualityRecursive(enumeratorA.Current, enumeratorB.Current, forDefaults, forDatabase, propertyName + "[" + i + "]");
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
                    if (forDatabase && property.Name == "DatabaseId")
                    {
                        var value1 = property.GetValue(a);
                        AssertNonDefaultValuesRecursive(value1);
                    }
                    else
                    {
                        var value1 = property.GetValue(a);
                        var value2 = property.GetValue(b);
                        AssertObjectEqualityRecursive(value1, value2, forDefaults, forDatabase, propertyName + property.Name);
                    }
                }
            }
        }

        /// <summary>
        /// Asserts that an object (and its child objects) contains non-default values for each property.
        /// For list and dictionary types, asserts that at least one item has non-default values.
        /// </summary>
        /// <param name="obj">An object.</param>
        /// <param name="propertyName">The property name to display in the error message if the assertion fails.</param>
        public static void AssertNonDefaultValuesRecursive(object obj, string propertyName = null)
        {
            AssertNonDefaultValuesRecursive(new[] { obj }, propertyName);
        }

        /// <summary>
        /// Asserts that an object (and its child objects) contains non-default values for each property.
        /// For list and dictionary types, asserts that at least one item has non-default values.
        /// </summary>
        /// <param name="objects">A list of objects.</param>
        /// <param name="propertyPath">The property name to display in the error message if the assertion fails.</param>
        public static void AssertNonDefaultValuesRecursive(IEnumerable<object> objects, string propertyPath = null, PropertyInfo property = null)
        {
            Assert.That(objects, Is.Not.Null);

            var first = objects.FirstOrDefault();
            if (propertyPath == null)
                propertyPath = first != null ? first.GetType().Name : "Object";
            var defaultMessage = propertyPath + " was not deserialized correctly. ";

            Assert.That(objects.Any(), defaultMessage + "Collection is empty.");
            Assert.That(objects.All(o => o != null), defaultMessage + "Value is null.");

            var defaultValue = property?.GetCustomAttribute<DefaultValueAttribute>()?.Value;
            var type = first.GetType();

            if (first is int)
            {
                int defaultInt = defaultValue as int? ?? 0;
                Assert.That(objects.Cast<int>().Any(x => x != defaultInt), $"{defaultMessage}Value equals the default ({defaultInt}).");
            }
            else if (first is long)
            {
                long defaultLong = defaultValue as long? ?? 0L;
                Assert.That(objects.Cast<long>().Any(x => x != defaultLong), $"{defaultMessage}Value equals the default ({defaultLong}).");
            }
            else if (first is double)
            {
                double defaultDouble = defaultValue as double? ?? 0.0;
                Assert.That(objects.Cast<double>().Any(x => x != defaultDouble), $"{defaultMessage}Value equals the default ({defaultDouble}).");
            }
            else if (first is string)
            {
                string defaultString = defaultValue as string;
                Assert.That(objects.Cast<string>().Any(x => x != defaultString), $"{defaultMessage}Value equals the default ({defaultString}).");
            }
            else if (first is bool)
            {
                bool defaultBool = defaultValue as bool? ?? false;
                Assert.That(objects.Cast<bool>().Any(x => x != defaultBool), $"{defaultMessage}Value equals the default ({defaultBool}).");
            }
            else if (first is DateTime)
            {
                var dates = objects as ICollection<DateTime> ?? objects.Cast<DateTime>().ToList();
                Assert.That(dates.All(x => x.Kind == DateTimeKind.Utc), defaultMessage + "Date has wrong kind. Expected Utc.");
                Assert.That(dates.Any(x => x > default(DateTime) && x < DateTime.UtcNow), defaultMessage + "DateTime is equal to the default value.");
                Assert.That(dates.All(x => x < DateTime.UtcNow), defaultMessage + "Date is out of range.");
            }
            else if (first is TimeSpan)
            {
                Assert.That(objects.Cast<TimeSpan>().Any(x => x > TimeSpan.Zero), defaultMessage + "TimeSpan is equal to the default value.");
            }
            else if (type.GetTypeInfo().IsEnum)
            {
                var defaultEnum = defaultValue ?? Enum.GetValues(type).GetValue(0);
                Assert.That(objects.Any(x => !x.Equals(defaultEnum)), $"{defaultMessage}{type.Name} equals the default ({defaultEnum}).");
            }
            else if (first is IEnumerable<object>)
            {
                AssertNonDefaultValuesRecursive(objects.Cast<IEnumerable<object>>().SelectMany(x => x), propertyPath + "[]");
            }
            else if (first is IEnumerable)
            {
                AssertNonDefaultValuesRecursive(objects.Cast<IEnumerable>().Select(x => x.Cast<object>()).SelectMany(x => x), propertyPath + "[]");
            }
            else
            {
                var properties = type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public).Where(p => p.GetCustomAttribute<JsonIgnoreAttribute>() == null).ToList();
                if (properties.Count == 0)
                    Assert.Fail("Type '" + type.FullName + "' is not supported.");

                propertyPath += ".";
                foreach (var childProperty in properties.Where(p => !p.GetIndexParameters().Any()))
                {
                    var values = objects.Select(x => childProperty.GetValue(x)).ToList();
                    AssertNonDefaultValuesRecursive(values, propertyPath + childProperty.Name, childProperty);
                }
            }
        }

        /// <summary>
        /// Gets the IDictionary&lt;,&gt; interface that the type implements, if any.
        /// </summary>
        /// <param name="type">The type of object that implements the interface.</param>
        /// <returns>The first IDictionary&lt;,&gt; interface found, or null if no interface was found.</returns>
        public static Type GetDictionaryInterface(Type type)
        {
            return ReflectionUtils.GetGenericInterface(type, typeof(IDictionary<,>));
        }

        public static void SetRiotClientSettings()
        {
            RiotClient.DefaultPlatformId = PlatformId.NA1;
            RiotClient.DefaultSettings = () => new RiotClientSettings
            {
                ApiKey = apiKey,
                MaxRequestAttempts = 4,
                RetryOnConnectionFailure = true,
                RetryOnRateLimitExceeded = true,
                RetryOnTimeout = true
            };
        }
    }
}
