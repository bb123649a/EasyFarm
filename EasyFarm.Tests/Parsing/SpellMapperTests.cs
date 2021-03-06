﻿using System;
using EasyFarm.Parsing;
using EliteMMO.API;
using Xunit;
using TargetType = EliteMMO.API.TargetType;

namespace EasyFarm.Tests.Parsing
{
    public class SpellMapperTests
    {
        private readonly EliteAPI.ISpell input = new EliteAPI.ISpell();
        private readonly Ability expected = new Ability();
        private readonly SpellMapper sut = new SpellMapper();

        [Fact]
        public void Map_CastTime()
        {
            // Setup fixture
            input.CastTime = 1;
            expected.CastTime = 1;
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.CastTime, result.CastTime);
            // Teardown
        }

        [Fact]
        public void Map_English()
        {
            // Setup fixture
            expected.English = "Cure";
            input.Name = new[] {"Cure"};
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.English, result.English);
            // Teardown
        }

        [Fact]
        public void Map_Engish_SourceNull_TargetEmpty()
        {
            // Setup fixture
            expected.English = "";
            input.Name = null;
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.English, result.English);
            // Teardown
        }

        [Fact]
        public void Map_Distance()
        {
            // Setup fixture
            expected.Distance = 21;
            input.Range = 21;
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.Distance, result.Distance);
            // Teardown
        }

        [Fact]
        public void Map_ID()
        {
            // Setup fixture
            expected.Id = 1;
            input.ID = 1;
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.Id, result.Id);
            // Teardown
        }

        [Fact]
        public void Map_Index()
        {
            // Setup fixture
            expected.Index = 1;
            input.Index = 1;
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.Index, result.Index);
            // Teardown
        }

        [Fact]
        public void Map_Prefix()
        {
            // Setup fixture
            expected.Prefix = "/magic";
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.Prefix, result.Prefix);
            // Teardown
        }

        [Fact]
        public void Map_Recast()
        {
            // Setup fixture
            expected.Recast = 1;
            input.RecastDelay = 1;
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.Recast, result.Recast);
            // Teardown
        }

        [Fact]
        public void Map_MpCost()
        {
            // Setup fixture
            expected.MpCost = 1;
            input.MPCost = 1;
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.MpCost, result.MpCost);
            // Teardown
        }

        [Theory]
        [InlineData(TargetType.None, EasyFarm.Parsing.TargetType.Unknown)]
        [InlineData(TargetType.Self, EasyFarm.Parsing.TargetType.Self)]
        [InlineData(TargetType.Player, EasyFarm.Parsing.TargetType.Player)]
        [InlineData(TargetType.PartyMember, EasyFarm.Parsing.TargetType.Party)]
        [InlineData(TargetType.AllianceMember, EasyFarm.Parsing.TargetType.Ally)]
        [InlineData(TargetType.Npc, EasyFarm.Parsing.TargetType.Npc)]
        [InlineData(TargetType.Enemy, EasyFarm.Parsing.TargetType.Enemy)]
        [InlineData(TargetType.None, EasyFarm.Parsing.TargetType.Unknown)]
        public void Map_Targets(TargetType inputTargetType, EasyFarm.Parsing.TargetType expectedTargetType)
        {
            // Setup fixture
            expected.TargetType = expectedTargetType;
            input.ValidTargets = (UInt16) inputTargetType;
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.TargetType, result.TargetType);
            // Teardown
        }

        [Theory]
        [InlineData(TargetType.Unknown, 64)]
        [InlineData(TargetType.CorpseOnly, 128)]
        [InlineData(TargetType.Corpse, 157)]
        [InlineData(TargetType.Self | TargetType.Player, 3)]
        public void Map_TargetType_UnmappedValues(TargetType inputTargetType, EasyFarm.Parsing.TargetType expectedTargetType)
        {
            // Setup fixture
            expected.TargetType = expectedTargetType;
            input.ValidTargets = (UInt16)inputTargetType;
            // Exercise system
            var result = sut.Map(input);
            // Verify outcome
            Assert.Equal(expected.TargetType, result.TargetType);
            // Teardown
        }
    }
}
