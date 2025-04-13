using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public sealed class ApplySpeedFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplySpeedFromStatsSystem(GameContext gameContext)
        {
            _statOwners = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.BaseStats,
                GameMatcher.StatsModifiers,
                GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (var statOwner in _statOwners)
            {
                statOwner.ReplaceSpeed(MoveSpeed(statOwner).ZeroIfNegative());
            }
        }

        private static float MoveSpeed(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.Speed] + statOwner.StatsModifiers[Stats.Speed];
        }
    }
}