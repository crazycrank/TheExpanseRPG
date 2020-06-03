using TheExpanseRPG.CharacterSheet.Domain.Base;

namespace TheExpanseRPG.CharacterSheet.Domain.Aggregates.CharacterAggregate.Persona
{
    public class SocialClass : Enumeration
    {
        public int Income { get; }

        private SocialClass(string name, int income) : base(name)
        {
            Income = income;
        }

        public static SocialClass Outsider = new SocialClass("Outsider", 0);
        public static SocialClass LowerClass = new SocialClass("Lower Class", 2);
        public static SocialClass MiddleClass = new SocialClass("Middle Class", 4);
        public static SocialClass UpperClass = new SocialClass("Upper Class", 6);
    }
}