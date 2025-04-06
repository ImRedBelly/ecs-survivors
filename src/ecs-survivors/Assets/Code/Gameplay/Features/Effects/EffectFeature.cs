using Code.Gameplay.Features.Effects.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Effects
{
    public class EffectFeature : Feature
    {
        public EffectFeature(ISystemFactory factory)
        {
            Add(factory.Create<RemoveEffectsWithoutTargetsSystem>());
            
            Add(factory.Create<ProcessDamageEffectSystem>());
            Add(factory.Create<CleanupProcessedEffectsSystem>());
        }
    }
}