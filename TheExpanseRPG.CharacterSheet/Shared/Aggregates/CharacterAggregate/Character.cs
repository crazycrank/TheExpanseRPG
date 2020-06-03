using System;
using System.IO;
using TheExpanseRPG.CharacterSheet.Domain.Base;

namespace TheExpanseRPG.CharacterSheet.Domain.Aggregates.CharacterAggregate
{
    public class Character : IAggregateRoot
    {
        public Persona.Persona Persona { get; set; } = new Persona.Persona();
    }
}
