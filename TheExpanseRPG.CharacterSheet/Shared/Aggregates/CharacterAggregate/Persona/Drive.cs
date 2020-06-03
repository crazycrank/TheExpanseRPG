using TheExpanseRPG.CharacterSheet.Domain.Base;

namespace TheExpanseRPG.CharacterSheet.Domain.Aggregates.CharacterAggregate.Persona
{
    public class Drive : Enumeration
    {
        private Drive(string name) : base(name)
        {
        }

        public static Drive Achiever = new Drive("Achiever");
        public static Drive Builder = new Drive("Builder");
        public static Drive Caregiver = new Drive("Caregiver");
        public static Drive Ecstatic = new Drive("Ecstatic");
        public static Drive Judge = new Drive("Judge");
        public static Drive Leader = new Drive("Leader");
        public static Drive Networker = new Drive("Networker");
        public static Drive Penitent = new Drive("Penitent");
        public static Drive Protector = new Drive("Protector");
        public static Drive Rebel = new Drive("Rebel");
        public static Drive Survivor = new Drive("Survivor");
        public static Drive Visionary = new Drive("Visionary");
    }
}