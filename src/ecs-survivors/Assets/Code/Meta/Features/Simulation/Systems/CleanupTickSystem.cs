using System.Collections.Generic;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public class CleanupTickSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _ticks;
        private readonly List<MetaEntity> _buffer = new(1);

        public CleanupTickSystem(MetaContext metaContext)
        {
            _ticks = metaContext.GetGroup(MetaMatcher.Tick);
        }

        public void Cleanup()
        {
            foreach (var tick in _ticks.GetEntities(_buffer))
            {
                tick.Destroy();
            }
        }
    }
}