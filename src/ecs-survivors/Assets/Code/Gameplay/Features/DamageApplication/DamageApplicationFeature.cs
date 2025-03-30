using Code.Gameplay.Features.DamageApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.DamageApplication
{
    public class DamageApplicationFeature : Feature
    {
        public DamageApplicationFeature(ISystemFactory factory)
        {
            Add(factory.Create<ApplyDamageOnTargetsSystem>());
            Add(factory.Create<DestructOnZeroHpSystem>());
        }
    }
}