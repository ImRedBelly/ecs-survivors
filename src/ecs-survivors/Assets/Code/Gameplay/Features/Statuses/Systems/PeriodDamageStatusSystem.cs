using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public sealed class PeriodDamageStatusSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _statuses;

        public PeriodDamageStatusSystem(GameContext gameContext, ITimeService timeService, IEffectFactory effectFactory)
        {
            _timeService = timeService;
            _effectFactory = effectFactory;
            _statuses = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Status,
                GameMatcher.Period,
                GameMatcher.EffectValue,
                GameMatcher.TimeSinceLastTick,
                GameMatcher.ProducerId,
                GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (var status in _statuses)
            {
                if (status.TimeSinceLastTick >= 0)
                {
                    status.ReplaceTimeSinceLastTick(status.TimeSinceLastTick - _timeService.DeltaTime);
                }
                else
                {
                    status.ReplaceTimeSinceLastTick(status.Period);
                    _effectFactory.CreateEffect(new EffectSetup() { effectTypeId = EffectTypeId.Damage, value = status.EffectValue }, status.ProducerId, status.TargetId);
                }
            }
        }
    }
}