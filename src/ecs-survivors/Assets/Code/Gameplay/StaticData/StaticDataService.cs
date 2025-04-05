using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityId, AbilityConfig> _abilitiesById;

        public void LoadAll()
        {
            LoadAbilities();
        }

        public AbilityConfig GetAbilityConfig(AbilityId abilityId)
        {
            if (_abilitiesById.TryGetValue(abilityId, out var config))
            {
                return config;
            }

            throw new Exception($"AbilityConfig for {abilityId} was not found");
        }

        public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
        {
            var config = GetAbilityConfig(abilityId);

            if (level > config.levels.Count)
            {
                level = config.levels.Count;
            }

            return config.levels[level - 1];
        }

        private void LoadAbilities()
        {
            _abilitiesById = Resources.LoadAll<AbilityConfig>("Configs/Abilities/")
                .ToDictionary(x => x.abilityId, x => x);
        }
    }
}