using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public sealed class BoosterDurationSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _ticks;
        private readonly IGroup<MetaEntity> _boosters;

        public BoosterDurationSystem(MetaContext metaContext)
        {
            _ticks = metaContext.GetGroup(MetaMatcher.Tick);
            _boosters = metaContext.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.GoldGameBoost,
                MetaMatcher.Duration));
        }

        public void Execute()
        {
            foreach (var tick in _ticks)
            foreach (var booster in _boosters)
            {
                booster.ReplaceDuration(booster.Duration - tick.Tick);
                if (booster.Duration <= 0)
                {
                    booster.isDestructed = true;
                }
            }
        }
    }
}