using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
    public class CollectTargetsFeature : Feature
    {
        public CollectTargetsFeature(ISystemFactory factory)
        {
            Add(factory.Create<CollectTargetsIntervalSystem>());
            
            Add(factory.Create<CastForTargetsNoLimitSystems>());
            Add(factory.Create<CastForTargetsWithLimitSystems>());
            
            Add(factory.Create<CleanupTargetsBufferSystem>());
        }
    }
}