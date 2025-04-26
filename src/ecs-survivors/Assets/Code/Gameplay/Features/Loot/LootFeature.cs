using Code.Gameplay.Features.Loot.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Loot
{
    public class LootFeature : Feature
    {
        public LootFeature(ISystemFactory factory)
        {
            Add(factory.Create<CastForPullablesSystem>());
            
            Add(factory.Create<PullTowardsHeroSystem>());
            Add(factory.Create<CollectWhenNearSystem>());
            
            Add(factory.Create<CollectExperienceSystem>());
            Add(factory.Create<CollectEffectItemSystem>());
            Add(factory.Create<CollectStatusItemSystem>());
            
            
            
            Add(factory.Create<CleanupCollected>());
        }
    }
}