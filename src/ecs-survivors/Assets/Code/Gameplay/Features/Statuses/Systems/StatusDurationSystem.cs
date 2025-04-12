using Code.Gameplay.Common.Time;

namespace Code.Gameplay.Features.Statuses.Systems
{
    using Entitas;

    public sealed class StatusDurationSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _statuses;

        public StatusDurationSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;
            _statuses = gameContext
                .GetGroup(
                    GameMatcher.AllOf(
                        GameMatcher.Duration,
                        GameMatcher.Status,
                        GameMatcher.TimeLeft));
        }

        public void Execute()
        {
            foreach (var status in _statuses)
            {
                if (status.TimeLeft >= 0)
                {
                    status.ReplaceTimeLeft(status.TimeLeft - _timeService.DeltaTime);
                }
                else
                {
                    status.isUnapplied = true;
                }
            }
        }
    }
}