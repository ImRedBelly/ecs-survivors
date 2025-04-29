using System.Collections.Generic;
using Code.Gameplay.Windows;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public sealed class OpenLevelUpWindowSystem : ReactiveSystem<GameEntity>
    {
        private readonly IWindowService _windowService;

        public OpenLevelUpWindowSystem(GameContext gameContext, IWindowService windowService) : base(gameContext)
        {
            _windowService = windowService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.LevelUp.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> levelUps)
        {
            foreach (var _ in levelUps)
            {
                _windowService.Open(WindowId.LevelUpWindow);
            }
        }
    }
}