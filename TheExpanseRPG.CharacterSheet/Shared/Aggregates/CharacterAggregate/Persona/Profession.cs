using TheExpanseRPG.CharacterSheet.Domain.Base;

namespace TheExpanseRPG.CharacterSheet.Domain.Aggregates.CharacterAggregate.Persona
{
    public class Profession : Enumeration
    {
        public JobType JobType { get; }
        public SocialClass SocialClass { get; }

        private Profession(string name, JobType jobType, SocialClass socialClass) : base(name)
        {
            SocialClass = socialClass;
            JobType = jobType;
        }

        public static Profession Artist = new Profession("Artist", JobType.Social, SocialClass.Outsider);
        public static Profession Athlete = new Profession("Athlete", JobType.Physical, SocialClass.LowerClass);
        public static Profession Brawler = new Profession("Brawler", JobType.Physical, SocialClass.Outsider);
    }
}