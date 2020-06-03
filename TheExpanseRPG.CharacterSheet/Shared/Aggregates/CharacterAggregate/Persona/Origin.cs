using TheExpanseRPG.CharacterSheet.Domain.Base;

namespace TheExpanseRPG.CharacterSheet.Domain.Aggregates.CharacterAggregate.Persona
{
    public class Origin : Enumeration
    {
        private Origin(string name) : base(name)
        {
        }

        public static Origin Belter = new Origin(nameof(Belter));
        public static Origin Martian = new Origin(nameof(Martian));
        public static Origin Earther = new Origin(nameof(Earther));
    }
}