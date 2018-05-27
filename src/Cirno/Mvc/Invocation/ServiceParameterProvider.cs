using System;

namespace Cirno.Mvc.Invocation
{
    public class ServiceParameterProvider : IParameterProvider
    {
        private readonly IServiceProvider provider;
        private readonly Type type;

        public ServiceParameterProvider(IServiceProvider provider, Type type)
        {
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
            this.type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public object GetValue()
        {
            return this.provider.GetService(this.type);
        }
    }
}