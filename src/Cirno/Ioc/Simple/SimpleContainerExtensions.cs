using System;

namespace Cirno.Ioc.Simple
{
    public static class SimpleContainerExtensions
    {
        public static ISimpleContainer Register(this ISimpleContainer container, Type from, Type mapTo, string name, ILifetime lifetime)
        {
            var key = new TypeRegistrationKey(from, name);
            container.Register(new TypeRegistration(key, mapTo, lifetime));
            return container;
        }

        public static ISimpleContainer RegisterInstance(this ISimpleContainer container, Type type, string name, object instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }
            var key = new TypeRegistrationKey(type, name);
            container.Register(new TypeRegistration(key, instance));
            return container;
        }

        public static ISimpleContainer Register<TFrom, TTo>(this ISimpleContainer container, string name, ILifetime lifetime)
        {
            container.Register(typeof(TFrom), typeof(TTo), name, lifetime);
            return container;
        }

        public static ISimpleContainer Register<TFrom, TTo>(this ISimpleContainer container, string name)
        {
            container.Register(typeof(TFrom), typeof(TTo), name, null);
            return container;
        }

        public static ISimpleContainer Register<TFrom, TTo>(this ISimpleContainer container, ILifetime lifetime)
        {
            container.Register(typeof(TFrom), typeof(TTo), null, lifetime);
            return container;
        }

        public static ISimpleContainer Register<TFrom, TTo>(this ISimpleContainer container)
        {
            container.Register(typeof(TFrom), typeof(TTo), null, null);
            return container;
        }

        public static ISimpleContainer RegisterInstance<T>(this ISimpleContainer container, string name, T instance)
        {
            container.RegisterInstance(typeof(T), name, instance);
            return container;
        }

        public static ISimpleContainer RegisterInstance<T>(this ISimpleContainer container, T instance)
        {
            container.RegisterInstance(typeof(T), null, instance);
            return container;
        }

        public static ISimpleContainer RegisterInstance(this ISimpleContainer container, object instance)
        {
            container.RegisterInstance(instance.GetType(), null, instance);
            return container;
        }

        public static ISimpleContainer RegisterSingleton<TFrom, TTo>(this ISimpleContainer container, string name)
        {
            return container.Register(typeof(TFrom), typeof(TTo), name, new SingletonLifetime());
        }

        public static ISimpleContainer RegisterSingleton<T>(this ISimpleContainer container, string name)
        {
            return container.Register(typeof(T), typeof(T), name, new SingletonLifetime());
        }

        public static ISimpleContainer RegisterSingleton<TFrom, TTo>(this ISimpleContainer container)
        {
            return container.Register(typeof(TFrom), typeof(TTo), null, new SingletonLifetime());
        }

        public static ISimpleContainer RegisterSingleton<T>(this ISimpleContainer container)
        {
            return container.Register(typeof(T), typeof(T), null, new SingletonLifetime());
        }

        public static ISimpleContainer RegisterMethod<T>(this ISimpleContainer container, string name, Func<ISimpleContainer, T> method)
        {
            var key = new TypeRegistrationKey(typeof(T), name);
            var registration = new TypeRegistration(key, typeof(T), new SingletonLifetime(), c => method.Invoke(c));
            return container.Register(registration);
        }

        public static ISimpleContainer RegisterMethod<T>(this ISimpleContainer container, Func<ISimpleContainer, T> method)
        {
            var key = new TypeRegistrationKey(typeof(T), null);
            var registration = new TypeRegistration(key, typeof(T), new SingletonLifetime(), c => method.Invoke(c));
            return container.Register(registration);
        }

        public static bool IsRegistered<T>(this ISimpleContainer container, string name)
        {
            return container.IsRegistered(new TypeRegistrationKey(typeof(T), name));
        }

        public static bool IsRegistered<T>(this ISimpleContainer container)
        {
            return container.IsRegistered(new TypeRegistrationKey(typeof(T), null));
        }
    }
}