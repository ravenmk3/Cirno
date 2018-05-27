using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Cirno.Ioc.Simple
{
    public class TypeKeyListMap : ConcurrentDictionary<Type, List<TypeRegistrationKey>>
    {
        public List<TypeRegistrationKey> GetOrCreate(Type key)
        {
            return this.GetOrAdd(key, x => new List<TypeRegistrationKey>());
        }

        public void Insert(TypeRegistrationKey item)
        {
            if (item.Name == null)
            {
                return;
            }
            var list = this.GetOrCreate(item.Type);
            if (!list.Any(x => x.Name == item.Name))
            {
                list.Add(item);
            }
        }
    }
}