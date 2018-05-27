using System;

namespace Cirno.Ioc.Simple
{
    public sealed class TypeRegistrationKey : IEquatable<TypeRegistrationKey>
    {
        public Type Type { get; set; }

        public string Name { get; set; }

        public TypeRegistrationKey(Type type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public bool HasName
        {
            get { return this.Name != null; }
        }

        public override int GetHashCode()
        {
            int typeHash = (this.Type == null) ? 0 : this.Type.GetHashCode();
            int nameHash = (this.Name == null) ? 0 : this.Name.GetHashCode();
            return typeHash ^ nameHash;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is TypeRegistrationKey key)
            {
                return this.Equals(key);
            }
            return false;
        }

        public bool Equals(TypeRegistrationKey other)
        {
            if (other == null)
            {
                return false;
            }
            else if ((this.Name == null && other.Name != null) || (this.Name != null && other.Name == null))
            {
                return false;
            }
            return this.Type.Equals(other.Type)
                && (String.Compare(this.Name, other.Name, StringComparison.Ordinal) == 0);
        }

        public override string ToString()
        {
            return String.Format("Type:{0}, Name:{1}", this.Type.FullName, this.Name);
        }

        public static bool operator ==(TypeRegistrationKey left, TypeRegistrationKey right)
        {
            bool leftIsNull = left is null;
            bool rightIsNull = right is null;
            if (leftIsNull && rightIsNull)
            {
                return true;
            }
            if (leftIsNull || rightIsNull)
            {
                return false;
            }
            return ((left.Type == right.Type) && (string.Compare(left.Name, right.Name, StringComparison.Ordinal) == 0));
        }

        public static bool operator !=(TypeRegistrationKey left, TypeRegistrationKey right)
        {
            return !(left == right);
        }
    }
}