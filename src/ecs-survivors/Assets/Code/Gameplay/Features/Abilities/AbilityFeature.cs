using Code.Gameplay.Features.Abilities.Systems;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Abilities
{
    public class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory factory)
        {
            Add(factory.Create<CooldownSystem>());
            Add(factory.Create<VegetableBoltAbilitySystem>());
        }
    }
}