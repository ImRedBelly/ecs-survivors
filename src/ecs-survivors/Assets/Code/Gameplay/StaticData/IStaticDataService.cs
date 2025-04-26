using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;

namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();
        AbilityConfig GetAbilityConfig(AbilityId abilityId);
        EnchantConfig GetEnchantConfig(EnchantTypeId enchantId);
        LootConfig GetLootConfig(LootTypeId lootId);
        AbilityLevel GetAbilityLevel(AbilityId abilityId, int level);
    }
}