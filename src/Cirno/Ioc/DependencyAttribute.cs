using System;

namespace Cirno.Ioc
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    public class DependencyAttribute : Attribute
    {
        public string Name { get; set; }

        public DependencyAttribute()
        {
        }

        public DependencyAttribute(string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}