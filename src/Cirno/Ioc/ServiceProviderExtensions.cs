using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cirno.Properties;

namespace Cirno.Ioc
{
    public static class ServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            return (T)provider.GetService(typeof(T));
        }

        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            return (IEnumerable<T>)provider.GetService(typeof(IEnumerable<T>));
        }

        public static T CreateInstance<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (ctors.Length < 1)
            {
                throw new InvalidOperationException(String.Format(SR.Error_NoInstanceConstructor, typeof(T)));
            }
            if (ctors.Length > 1)
            {
                throw new InvalidOperationException(String.Format(SR.Error_TooManyConstructors, typeof(T)));
            }
            var ctor = ctors.First();
            var parameters = ctor.GetParameters();
            if (parameters == null || parameters.Length < 1)
            {
                return (T)ctor.Invoke(null);
            }
            var parameterValues = parameters
                .Select(p => provider.GetService(p.ParameterType))
                .ToArray();
            return (T)ctor.Invoke(parameterValues);
        }
    }
}