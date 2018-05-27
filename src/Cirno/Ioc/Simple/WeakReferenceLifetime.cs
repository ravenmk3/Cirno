using System;

namespace Cirno.Ioc.Simple
{
    public class WeakReferenceLifetime : Lifetime
    {
        private WeakReference value = new WeakReference(null);

        public override object GetValue()
        {
            return this.value.Target;
        }

        public override void SetValue(object newValue)
        {
            this.value = new WeakReference(newValue);
        }
    }
}