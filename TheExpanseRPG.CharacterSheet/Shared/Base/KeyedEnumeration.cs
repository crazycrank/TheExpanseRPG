using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TheExpanseRPG.CharacterSheet.Domain.Base
{
    public abstract class KeyedEnumeration : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected KeyedEnumeration()
        { }

        protected KeyedEnumeration(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString() => this.Name;

        public static IEnumerable<T> GetAll<T>() where T : KeyedEnumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as KeyedEnumeration;

            if (otherValue == null)
                return false;

            var typeMatches = this.GetType().Equals(obj.GetType());
            var valueMatches = this.Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => this.Id.GetHashCode();

        public static int AbsoluteDifference(KeyedEnumeration firstValue, KeyedEnumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
            return absoluteDifference;
        }

        public static T FromValue<T>(int value) where T : KeyedEnumeration
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : KeyedEnumeration
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : KeyedEnumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");

            return matchingItem;
        }

        public int CompareTo(object other) => this.Id.CompareTo(((KeyedEnumeration)other).Id);
    }
}
