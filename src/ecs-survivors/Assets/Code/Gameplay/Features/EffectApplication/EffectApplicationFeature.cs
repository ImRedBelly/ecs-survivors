using Code.Gameplay.Features.EffectApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.EffectApplication
{
    public class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory factory)
        {
            Add(factory.Create<ApplyEffectsOnTargetsSystem>());
            Add(factory.Create<ApplyStatusesOnTargetsSystem>());
        }
    }
}