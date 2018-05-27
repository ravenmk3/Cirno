using System;

namespace Cirno.Ioc.Simple
{
    public class SingletonLifetime : ILifetime
    {
        private object value;

        public object GetValue()
        {
            return this.value;
        }

        public void RemoveValue()
        {
            this.value = null;
        }

        public void SetValue(object newValue)
        {
            this.value = newValue;
        }
    }
}