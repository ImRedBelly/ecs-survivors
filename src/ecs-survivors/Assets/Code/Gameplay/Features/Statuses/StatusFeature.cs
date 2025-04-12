using Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public class StatusFeature : Feature
    {
        public StatusFeature(ISystemFactory factory)
        {
            Add(factory.Create<StatusDurationSystem>());
            Add(factory.Create<PeriodDamageStatusSystem>());
            
            Add(factory.Create<StatusVisualsFeature>());
            
            Add(factory.Create<CleanupUnappliedStatuses>());
        }
    }
}