using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public sealed class OrbitCenterFollowSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _orbitCenters;
        private readonly IGroup<GameEntity> _targets;

        public OrbitCenterFollowSystem(GameContext gameContext)
        {
            _orbitCenters = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.OrbitCenterPosition,
                GameMatcher.OrbitCenterFollowTarget));

            _targets = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var orbitCenter in _orbitCenters)
            foreach (var target in _targets)
            {
                if (orbitCenter.OrbitCenterFollowTarget == target.Id)
                {
                    orbitCenter.ReplaceOrbitCenterPosition(target.WorldPosition);
                }
            }
        }
    }
}