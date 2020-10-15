using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TheExpanseRPG.CharacterSheet.Domain.Base
{
    public abstract class KeyedEnumeration<T> : Enumeration
        where T: struct
    {
        public T Id { get; private set; }

        protected KeyedEnumeration()
        { }

        protected KeyedEnumeration(T id, string name)
        : base(name)
        {
            this.Id = id;
        }

        public override string ToString() => this.Name;

        public static int AbsoluteDifference(KeyedEnumeration<T> firstValue, KeyedEnumeration<T> secondValue)
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
