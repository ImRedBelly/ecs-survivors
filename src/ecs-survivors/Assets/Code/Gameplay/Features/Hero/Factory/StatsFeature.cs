using Code.Gameplay.Features.CharacterStats.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class StatsFeature : Feature
    {
        public StatsFeature(ISystemFactory factory)
        {
            Add(factory.Create<StatChangeSystem>());
            Add(factory.Create<ApplySpeedFromStatsSystem>());
        }
    }
}