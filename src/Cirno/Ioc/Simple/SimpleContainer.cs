using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cirno.Properties;

namespace Cirno.Ioc.Simple
{
    public class SimpleContainer : ISimpleContainer
    {
        public TypeRegistry Registry { get; }

        public SimpleContainer()
        {
            this.Registry = new TypeRegistry();
        }

        public ISimpleContainer Register(TypeRegistration registration)
        {
            this.Registry.Insert(registration);
            return this;
        }

        public bool IsRegistered(TypeRegistrationKey key)
        {
            return this.Registry.IsRegistered(key);
        }

        public virtual object Resolve(Type type, string name)
        {
            var key = new TypeRegistrationKey(type, name);
            return this.Resovle(key);
        }

        public virtual object Resolve(Type type)
        {
            return this.Resolve(type, null);
        }

        public virtual IEnumerable<Object> ResolveAll(Type type)
        {
            var keys = this.Registry.GetKeyList(type);
            return keys.Select(item => this.Resovle(item)).ToArray();
        }

        public virtual object Resovle(TypeRegistrationKey key)
        {
            if (this.Registry.TryGetValue(key, out var entry))
            {
                var value = entry.Lifetime?.GetValue();
                if (value == null)
                {
                    if (entry.Factory != null)
                    {
                        value = entry.Factory.Invoke(this);
                    }
                    else
                    {
                        value = this.CreateInstance(entry.MapTo);
                    }
                }
                if (entry.Lifetime != null)
                {
                    entry.Lifetime.SetValue(value);
                }
                return value;
            }
            else
            {
                var type = key.Type;
                if (type.IsInterface || type.IsAbstract)
                {
                    throw new ContainerException(String.Format(SR.Error_NoInstanceConstructor, type.FullName));
                }
                return this.CreateInstance(type);
            }
        }

        private object CreateInstance(Type type)
        {
            var ctor = ConstructorFinder.Find(type);
            if (ctor != null)
            {
                return this.CreateInstance(ctor);
            }
            return null;
        }

        private object ResolveParameter(Type type)
        {
            return this.Resolve(type, null);
        }

        private object CreateInstance(ConstructorInfo ctor)
        {
            var parmInfos = ctor.GetParameters();
            if (parmInfos.Length > 0)
            {
                var parms = new object[parmInfos.Length];
                for (int i = 0; i < parms.Length; i++)
                {
                    var type = parmInfos[i].ParameterType;
                    parms[i] = this.ResolveParameter(type);
                }
                return ctor.Invoke(parms);
            }
            else
            {
                return ctor.Invoke(null);
            }
        }

        public object GetService(Type serviceType)
        {
            return this.Resolve(serviceType, null);
        }

        object IServiceProvider.GetService(Type serviceType)
        {
            return this.Resolve(serviceType, null);
        }
    }
}