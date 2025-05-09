﻿using System.Collections.Generic;
using System.Linq;
using OpenRpg.Core.Extensions;
using OpenRpg.Core.Utils;
using OpenRpg.Demos.Infrastructure.Extensions;
using OpenRpg.Demos.Infrastructure.Lookups;
using OpenRpg.Genres.Builders;
using OpenRpg.Genres.Populators.Entity;
using RandomNameGenerator;

namespace OpenRpg.Demos.Infrastructure.Builders
{
    public class DemoCharacterBuilder : CharacterBuilder
    {
        public IReadOnlyCollection<int> RaceTypes { get; }
        public IReadOnlyCollection<int> ClassTypes { get; }

        public DemoCharacterBuilder(IRandomizer randomizer, ICharacterPopulator characterPopulator) : base(randomizer, characterPopulator)
        {
            RaceTypes = typeof(RaceTypeLookups).GetTypeFieldsDictionary().Keys.Where(x => x > 0).ToArray();
            ClassTypes = typeof(ClassTypeLookups).GetTypeFieldsDictionary().Keys.Where(x => x > 0).ToArray();
        }
        
        protected override void RandomizeDefaults()
        {
            if (_raceId == 0) { _raceId = Randomizer.TakeRandomFrom(RaceTypes); }
            if (_classId == 0) { _classId = Randomizer.TakeRandomFrom(ClassTypes); }
            if (_genderId == 0) { _genderId = (byte)Randomizer.Random(1,2); }
            if (_classLevels == 0) { _classLevels = Randomizer.Random(1,5); }
            if (string.IsNullOrEmpty(_name)) { _name = NameGenerator.Generate(_genderId == 1 ? Gender.Male : Gender.Female); }
        }
    }
}