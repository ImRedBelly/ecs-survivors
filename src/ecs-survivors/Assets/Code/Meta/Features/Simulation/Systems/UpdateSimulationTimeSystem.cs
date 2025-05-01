using Code.Progress.Provider;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public sealed class UpdateSimulationTimeSystem : IExecuteSystem
    {
        private readonly IProgressProvider _progressProvider;
        private readonly IGroup<MetaEntity> _ticks;

        public UpdateSimulationTimeSystem(MetaContext metaContext, IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
            _ticks = metaContext.GetGroup(MetaMatcher.Tick);
        }

        public void Execute()
        {
            foreach (var tick in _ticks)
            {
                _progressProvider.ProgressData.LastSimulationTickTime =
                    _progressProvider.ProgressData.LastSimulationTickTime
                        .AddSeconds(tick.Tick);
            }
        }
    }
}