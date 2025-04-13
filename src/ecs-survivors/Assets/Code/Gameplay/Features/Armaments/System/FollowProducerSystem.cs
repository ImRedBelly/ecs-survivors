using Entitas;

namespace Code.Gameplay.Features.Armaments.System
{
    public sealed class FollowProducerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _followers;
        private readonly IGroup<GameEntity> _producers;

        public FollowProducerSystem(GameContext gameContext)
        {
            _followers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.FollowingProduces,
                GameMatcher.WorldPosition,
                GameMatcher.ProducerId
            ));
            _producers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.WorldPosition
            ));
        }

        public void Execute()
        {
            foreach (var follower in _followers)
            foreach (var producer in _producers)
            {
                if (follower.ProducerId == producer.Id)
                {
                    follower.ReplaceWorldPosition(producer.WorldPosition);
                }
            }
        }
    }
}