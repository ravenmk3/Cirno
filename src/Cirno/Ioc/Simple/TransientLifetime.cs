using System;

namespace Cirno.Ioc.Simple
{
    public class TransientLifetime : ILifetime
    {
        public object GetValue()
        {
            // 返回一个null值，容器会重新实例化一个对象
            return null;
        }

        public void RemoveValue()
        {
            // Noop
        }

        public void SetValue(object newValue)
        {
            // Noop
        }
    }
}