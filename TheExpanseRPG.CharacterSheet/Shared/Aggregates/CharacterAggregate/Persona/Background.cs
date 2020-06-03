using TheExpanseRPG.CharacterSheet.Domain.Base;

namespace TheExpanseRPG.CharacterSheet.Domain.Aggregates.CharacterAggregate.Persona
{
    public class Background : Enumeration
    {
        public SocialClass SocialClass { get; }

        private Background(string name, SocialClass socialClass) : base(name)
        {
            SocialClass = socialClass;
        }

        public static Background Academic = new Background("Academic", SocialClass.MiddleClass);
        public static Background Aristocratic = new Background("Aristocratic", SocialClass.UpperClass);
    }
}