using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Systems
{
    public sealed class CollectWhenNearSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _pullable;

        private const float CloseDistance = 0.2f;

        public CollectWhenNearSystem(GameContext gameContext)
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
                if (Vector3.Distance(hero.WorldPosition, pullable.WorldPosition) <= CloseDistance)
                {
                    pullable.isCollected = true;
                }
            }
        }
    }
}