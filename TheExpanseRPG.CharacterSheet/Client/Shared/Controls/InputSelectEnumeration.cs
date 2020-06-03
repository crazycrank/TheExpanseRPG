using System;
using Microsoft.AspNetCore.Components.Forms;
using TheExpanseRPG.CharacterSheet.Domain.Base;

namespace TheExpanseRPG.CharacterSheet.Client.Shared.Controls
{
    public class InputSelectEnumeration<T> : InputSelect<T>
    {
        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            if (typeof(T).IsSubclassOf(typeof(Enumeration)))
            {
                result = (T)(object)Enumeration.FromName(typeof(T), value);

                validationErrorMessage = result is null ? $"'{value}' could not be parsed to '{typeof(T)}'" : "";
                return result != null;
            }

            return base.TryParseValueFromString(value, out result, out validationErrorMessage);
        }

        protected override string FormatValueAsString(T value)
        {
            return (value as Enumeration)?.Name ?? base.FormatValueAsString(value);
        }
    }
}