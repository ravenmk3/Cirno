using System;
using System.Collections.Generic;

namespace Cirno.Ioc.Simple
{
    public class PerThreadLifetime : ILifetime
    {
        private readonly Guid key = Guid.NewGuid();

        [ThreadStatic]
        private static Dictionary<Guid, object> values;

        private static void EnsureValues()
        {
            if (values == null)
            {
                values = new Dictionary<Guid, object>();
            }
        }

        public virtual object GetValue()
        {
            EnsureValues();
            if (values.TryGetValue(this.key, out var value))
            {
                return value;
            }
            return null;
        }

        public virtual void RemoveValue()
        {
        }

        public virtual void SetValue(object newValue)
        {
            EnsureValues();
            values[this.key] = newValue;
        }
    }
}