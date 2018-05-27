using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Cirno.Ioc.Simple
{
    public class TypeRegistry : ConcurrentDictionary<TypeRegistrationKey, TypeRegistration>
    {
        private readonly TypeKeyListMap map = new TypeKeyListMap();

        public void Insert(TypeRegistration value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            base[value.Key] = value;
            map.Insert(value.Key);
        }

        public List<TypeRegistrationKey> GetKeyList(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            return this.map.GetOrCreate(type);
        }

        public bool IsRegistered(TypeRegistrationKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return this.ContainsKey(key);
        }

        public bool IsRegistered(Type type, string name)
        {
            return this.ContainsKey(new TypeRegistrationKey(type, name));
        }
    }
}