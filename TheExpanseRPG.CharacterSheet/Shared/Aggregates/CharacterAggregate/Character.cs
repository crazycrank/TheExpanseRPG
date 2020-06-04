using System;
using System.IO;
using TheExpanseRPG.CharacterSheet.Domain.Base;

namespace TheExpanseRPG.CharacterSheet.Domain.Aggregates.CharacterAggregate
{
    public class Character : IAggregateRoot
    {
        public Character()
        {
            RecalculateSecondaryAbilities();
        }

        public Persona.Persona Persona { get; set; } = new Persona.Persona();

        public Abilities Abilities { get; set; } = new Abilities();

        public SecondaryAbilities SecondaryAbilities { get; internal set; } = new SecondaryAbilities();

        public void RecalculateSecondaryAbilities()
        {
            SecondaryAbilities = new SecondaryAbilities
            {
                Speed = 10 + Abilities.Dexterity,
                Defense = 10 + Abilities.Dexterity,
                Toughness = Abilities.Constitution,
            };
        }
    }

    public class SecondaryAbilities
    {
        public int Speed { get; internal set; }
        public int Defense { get; internal set; }
        public int Toughness { get; internal set; }
    }

    public class Abilities
    {
        public int Accuracy { get; set; } = 0;
        public int Communication { get; set; } = 0;
        public int Constitution { get; set; } = 0;
        public int Dexterity { get; set; } = 0;
        public int Fighting { get; set; } = 0;
        public int Intelligence { get; set; } = 0;
        public int Perception { get; set; } = 0;
        public int Strength { get; set; } = 0;
        public int Willpower { get; set; } = 0;
    }
}
