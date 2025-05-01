using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.LevelUp;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using Code.Meta.Features.AfkGain.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityId, AbilityConfig> _abilitiesById;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchantsById;
        private Dictionary<LootTypeId, LootConfig> _lootById;
        private Dictionary<WindowId, GameObject> _windowPrefabsById;
        private LevelUpConfig _levelUpConfig;
        private AfkGainConfig _afkGainConfig;
        public AfkGainConfig AfkGainConfig => _afkGainConfig;

        public void LoadAll()
        {
            LoadAbilities();
            LoadEnchants();
            LoadLoot();
            LoadWindows();
            LoadLevelUpConfig();
            LoadAfkGainConfig();
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

        public LootConfig GetLootConfig(LootTypeId lootId)
        {
            if (_lootById.TryGetValue(lootId, out var config))
            {
                return config;
            }

            throw new Exception($"LootConfig for {lootId} was not found");
        }

        public GameObject GetWindowPrefab(WindowId id) =>
            _windowPrefabsById.TryGetValue(id, out GameObject prefab)
                ? prefab
                : throw new Exception($"Prefab config for window {id} was not found");

        public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
        {
            var config = GetAbilityConfig(abilityId);

            if (level > config.levels.Count)
            {
                level = config.levels.Count;
            }

            return config.levels[level - 1];
        }

        public int MaxLevel() => _levelUpConfig.maxLevel;
        public float ExperienceForLevel(int level) => _levelUpConfig.experienceForLevel[level];

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

        private void LoadLoot()
        {
            _lootById = Resources.LoadAll<LootConfig>("Configs/Loot/")
                .ToDictionary(x => x.lootTypeId, x => x);
        }

        private void LoadWindows()
        {
            _windowPrefabsById = Resources
                .Load<WindowsConfig>("Configs/Windows/WindowsConfig")
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }

        private void LoadLevelUpConfig()
        {
            _levelUpConfig = Resources
                .Load<LevelUpConfig>("Configs/LevelUp/LevelUpConfig");
        }
        

        private void LoadAfkGainConfig()
        {
            _afkGainConfig = Resources
                .Load<AfkGainConfig>("Configs/AfkGainConfig");
        }

    }
}