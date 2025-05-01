using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Systems;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public sealed class EmitTickSystem : TimerExecuteSystem
    {
        private readonly float _interval;
        private readonly IGroup<GameEntity> _entities;

        public EmitTickSystem(float interval, ITimeService timeService)
            : base(interval, timeService)
        {
            _interval = interval;
        }

        protected override void Execute()
        {
            CreateMetaEntity.Empty()
                .AddTick(_interval);
        }
    }
}