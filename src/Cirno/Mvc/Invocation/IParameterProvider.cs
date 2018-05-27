using System;

namespace Cirno.Mvc.Invocation
{
    public interface IParameterProvider
    {
        object GetValue();
    }
}