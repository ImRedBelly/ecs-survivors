using Code.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public sealed class CollectStatusItemSystem : IExecuteSystem
    {
        private readonly IStatusApplier _statusApplier;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _collected;

        public CollectStatusItemSystem(GameContext gameContext, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _heroes = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.Id, GameMatcher.WorldPosition));
            _collected = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Collected, GameMatcher.StatusSetups));
        }

        public void Execute()
        {
            foreach (var collected in _collected)
            foreach (var hero in _heroes)
            foreach (var statusSetup in collected.StatusSetups)
            {
                _statusApplier.ApplyStatus(statusSetup, hero.Id, hero.Id);
            }
        }
    }
}