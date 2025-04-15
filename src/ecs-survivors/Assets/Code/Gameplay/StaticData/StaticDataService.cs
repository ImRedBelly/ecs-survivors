using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityId, AbilityConfig> _abilitiesById;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchantsById;

        public void LoadAll()
        {
            LoadAbilities();
            LoadEnchants();
        }

        public AbilityConfig GetAbilityConfig(AbilityId abilityId)
        {
            if (_abilitiesById.TryGetValue(abilityId, out var config))
            {
                return config;
            }

            throw new Exception($"AbilityConfig for {abilityId} was not found");
        }

        public EnchantConfig GetEnchantConfig(EnchantTypeId enchantId)
        {
            if (_enchantsById.TryGetValue(enchantId, out var config))
            {
                return config;
            }

            throw new Exception($"EnchantConfig for {enchantId} was not found");
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

        private void LoadEnchants()
        {
            _enchantsById = Resources.LoadAll<EnchantConfig>("Configs/Enchants/")
                .ToDictionary(x => x.typeId, x => x);
        }
    }
}