using TheExpanseRPG.CharacterSheet.Domain.Base;

namespace TheExpanseRPG.CharacterSheet.Domain.Aggregates.CharacterAggregate.Persona
{
    public class JobType : Enumeration
    {
        private JobType(string name) : base(name)
        {
        }

        public static JobType Physical = new JobType("Physical");
        public static JobType Social = new JobType("Social");
        public static JobType Skilled = new JobType("Skilled");
    }
}