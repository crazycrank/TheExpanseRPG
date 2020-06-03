namespace TheExpanseRPG.CharacterSheet.Domain.Aggregates.CharacterAggregate.Persona
{
    public class Persona
    {
        public string Name { get; set; } = string.Empty;
        public Origin Origin { get; set; }
        public Background Background { get; set; }
        public SocialClass SocialClass { get; set; }
        public Profession Profession { get; set; }
        public Drive Drive { get; set; }
        public string Goals { get; set; } = string.Empty;
        public string Appearance { get; set; } = string.Empty;
    }
}