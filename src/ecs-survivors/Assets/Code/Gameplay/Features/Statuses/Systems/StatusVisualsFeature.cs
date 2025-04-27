using Code.Gameplay.Features.Enchants.Systems;
using Code.Gameplay.Features.Statuses.Systems.StatusVisuals;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class StatusVisualsFeature : Feature
    {
        public StatusVisualsFeature(ISystemFactory factory)
        {
            Add(factory.Create<ApplyPoisonVisualsSystems>());
            Add(factory.Create<ApplyFreezeVisualsSystems>());
            
            Add(factory.Create<UnapplyPoisonVisualsSystems>());
            Add(factory.Create<UnapplyFreezeVisualsSystems>());
            
            Add(factory.Create<RemoveUnappliedEnchantsFromHolder>());
        }
    }
}