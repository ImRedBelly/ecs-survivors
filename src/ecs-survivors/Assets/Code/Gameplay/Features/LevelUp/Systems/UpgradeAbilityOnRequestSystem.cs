using Code.Gameplay.Features.Abilities.Upgrade;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    using Entitas;

    public sealed class UpgradeAbilityOnRequestSystem : IExecuteSystem
    {
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IGroup<GameEntity> _levelUps;
        private readonly IGroup<GameEntity> _upgradeRequests;

        public UpgradeAbilityOnRequestSystem(GameContext gameContext, IAbilityUpgradeService abilityUpgradeService)
        {
            _abilityUpgradeService = abilityUpgradeService;

            _levelUps = gameContext.GetGroup(GameMatcher.LevelUp);

            _upgradeRequests = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.UpgradeRequest,
                GameMatcher.AbilityId));
        }

        public void Execute()
        {
            foreach (var upgradeRequest in _upgradeRequests)
            foreach (var levelUp in _levelUps)
            {
                _abilityUpgradeService.UpgradeAbility(upgradeRequest.AbilityId);

                levelUp.isProcessed = true;
                upgradeRequest.isDestructed = true;
            }
        }
    }
}