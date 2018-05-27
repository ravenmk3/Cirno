using System;

namespace Cirno.Ioc.Simple
{
    public class TypeRegistration
    {
        public TypeRegistrationKey Key { get; set; }

        public Type MapTo { get; set; }

        public ILifetime Lifetime { get; set; }

        public Func<ISimpleContainer, object> Factory { get; set; }

        public TypeRegistration(TypeRegistrationKey key, Type mapTo)
            : this(key, mapTo, null) { }

        public TypeRegistration(TypeRegistrationKey key, Type mapTo, ILifetime lifetime)
        {
            this.Key = key;
            this.MapTo = mapTo;
            this.Lifetime = lifetime;
        }

        public TypeRegistration(TypeRegistrationKey key, Type mapTo, ILifetime lifetime, Func<ISimpleContainer, object> factory)
        {
            this.Key = key;
            this.MapTo = mapTo;
            this.Lifetime = lifetime;
            this.Factory = factory;
        }

        public TypeRegistration(TypeRegistrationKey key, Object instance)
        {
            this.Key = key;
            this.MapTo = instance.GetType();
            this.Lifetime = new SingletonLifetime();
            this.Lifetime.SetValue(instance);
        }
    }
}