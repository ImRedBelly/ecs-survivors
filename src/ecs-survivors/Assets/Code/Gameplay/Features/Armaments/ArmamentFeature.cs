using Code.Gameplay.Features.Armaments.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Armaments
{
    public class ArmamentFeature : Feature
    {
        public ArmamentFeature(ISystemFactory factory)
        {
            Add(factory.Create<MarkProcessedOnTargetLimitExceededSystem>());
            Add(factory.Create<FollowProducerSystem>());
            
            Add(factory.Create<FinalizeProcessedArmamentsSystem>());
        }
    }
}