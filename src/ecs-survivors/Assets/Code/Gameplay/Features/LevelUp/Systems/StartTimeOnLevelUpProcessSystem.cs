using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public sealed class StartTimeOnLevelUpProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly ITimeService _timeService;

        public StartTimeOnLevelUpProcessSystem(GameContext gameContext, ITimeService timeService) : base(gameContext)
        {
            _timeService = timeService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Processed.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isLevelUp && entity.isProcessed;
        }

        protected override void Execute(List<GameEntity> levelUps)
        {
            foreach (var _ in levelUps)
            {
                _timeService.StartTime();
            }
        }
    }
}