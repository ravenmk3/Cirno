using System;

namespace Cirno.Ioc.Simple
{
    public interface ISimpleContainer : IContainer
    {
        TypeRegistry Registry { get; }

        ISimpleContainer Register(TypeRegistration registration);

        bool IsRegistered(TypeRegistrationKey key);
    }
}