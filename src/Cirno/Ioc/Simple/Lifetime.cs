using System;

namespace Cirno.Ioc.Simple
{
    public abstract class Lifetime : ILifetime
    {
        public abstract object GetValue();

        public virtual void RemoveValue()
        {
        }

        public abstract void SetValue(object newValue);
    }
}