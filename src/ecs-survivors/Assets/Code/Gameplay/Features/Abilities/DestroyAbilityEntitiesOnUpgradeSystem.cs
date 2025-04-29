using Entitas;

namespace Code.Gameplay.Features.Abilities
{
    public sealed class DestroyAbilityEntitiesOnUpgradeSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _upgradeRequests;
        private readonly IGroup<GameEntity> _abilities;

        public DestroyAbilityEntitiesOnUpgradeSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _upgradeRequests = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.UpgradeRequest, GameMatcher.AbilityId));
            _abilities = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.AbilityId, GameMatcher.RecreatedOnUpgrade));
        }

        public void Execute()
        {
            foreach (var upgradeRequest in _upgradeRequests)
            foreach (var ability in _abilities)
            {
                if (upgradeRequest.AbilityId == ability.AbilityId)
                {
                    foreach (var entity in _gameContext.GetEntitiesWithParentAbility(ability.AbilityId))
                    {
                        entity.isDestructed = true;
                    }

                    ability.isActive = false;
                }
            }
        }
    }
}