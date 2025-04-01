using Code.Gameplay.Features.Lifetime.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime
{
    public sealed class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory factory)
        {
            Add(factory.Create<MarkDeadSystem>());
        }
    }
}