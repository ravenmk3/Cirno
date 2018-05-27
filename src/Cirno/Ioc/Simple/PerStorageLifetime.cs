using System;
using System.Collections;

namespace Cirno.Ioc.Simple
{
    public abstract class PerStorageLifetime : ILifetime, IDisposable
    {
        private readonly Guid key = Guid.NewGuid();

        protected abstract IDictionary Storage { get; }

        public object GetValue()
        {
            object value = null;
            if (Storage != null && Storage.Contains(key))
            {
                value = Storage[key];
            }
            return value;
        }

        public void RemoveValue()
        {
            var value = this.GetValue();
            if (value != null)
            {
                this.Storage.Remove(this.key);
                if (value is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }

        public void SetValue(object newValue)
        {
            if (this.Storage != null)
            {
                Storage[this.key] = newValue;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.RemoveValue();
        }
    }
}