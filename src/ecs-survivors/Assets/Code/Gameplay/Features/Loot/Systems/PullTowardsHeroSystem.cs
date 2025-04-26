using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public sealed class PullTowardsHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _pullable;

        public PullTowardsHeroSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.WorldPosition));

            _pullable = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Pulling,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var hero in _heroes)
            foreach (var pullable in _pullable)
            {
                pullable.ReplaceDirection((hero.WorldPosition - pullable.WorldPosition).normalized);
                pullable.ReplaceSpeed(4);

                pullable.isMoving = true;
                pullable.isMovementAvailable = true;
            }
        }
    }
}