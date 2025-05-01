using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public sealed class AfkGoldGainSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _ticks;
        private readonly IGroup<MetaEntity> _storage;

        public AfkGoldGainSystem(MetaContext metaContext)
        {
            _ticks = metaContext.GetGroup(MetaMatcher.Tick);
            _storage = metaContext.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Storage,
                MetaMatcher.Gold,
                MetaMatcher.GoldPerSeconds));
        }

        public void Execute()
        {
            foreach (var tick in _ticks)
            foreach (var storage in _storage)
            {
                storage.ReplaceGold(storage.Gold + tick.Tick * storage.GoldPerSeconds);
            }
        }
    }
}