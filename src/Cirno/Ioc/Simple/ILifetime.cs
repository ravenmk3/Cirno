using System;

namespace Cirno.Ioc.Simple
{
    public interface ILifetime
    {
        object GetValue();

        void RemoveValue();

        void SetValue(object newValue);
    }
}