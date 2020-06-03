using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TheExpanseRPG.CharacterSheet.Domain.Base
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; }

        protected Enumeration()
        { }

        protected Enumeration(string name)
        {
            this.Name = name;
        }

        public override string ToString() => this.Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }
        public static IEnumerable<Enumeration> GetAll(Type type)
        {
            ValidateTypeParam(type);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<Enumeration>();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Enumeration) obj);
        }

        public override int GetHashCode() => HashCode.Combine(Name);

        public static T FromName<T>(string name) where T : Enumeration
        {
            var matchingItem = Parse<T>(name, "display name", item => item.Name == name);
            return matchingItem;
        }
        public static Enumeration FromName(Type type, string name)
        {
            ValidateTypeParam(type);

            var matchingItem = Parse(type, name, "display name", item => item.Name == name);
            return matchingItem;
        }

        private static void ValidateTypeParam(Type type)
        {
            if (!type.IsSubclassOf(typeof(Enumeration)))
            {
                throw new ArgumentException("type must be deriving of Enumeration", nameof(type));
            }
        }

        private static T Parse<T>(string value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");

            return matchingItem;
        }

        private static Enumeration Parse(Type type, string value, string description, Func<Enumeration, bool> predicate) 
        {
            ValidateTypeParam(type);
            var matchingItem = GetAll(type).FirstOrDefault(predicate);

            if (matchingItem == null)
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {type}");

            return matchingItem;
        }

        public int CompareTo(object other) => string.Compare(Name, ((Enumeration)other).Name, StringComparison.Ordinal);

        protected bool Equals(Enumeration other)
        {
            return Name == other.Name;
        }

        public static bool operator ==(Enumeration left, Enumeration right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !Equals(left, right);
        }
    }
}
