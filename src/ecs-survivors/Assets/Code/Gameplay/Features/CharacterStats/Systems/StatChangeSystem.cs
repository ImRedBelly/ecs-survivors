using Code.Common.EntityIndices;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public sealed class StatChangeSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _statOwners;

        public StatChangeSystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _statOwners = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.BaseStats,
                GameMatcher.StatsModifiers));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            foreach (Stats stat in statOwner.BaseStats.Keys)
            {
                statOwner.StatsModifiers[stat] = 0;

                foreach (var statChange in _gameContext.TargetStatChanges(stat, statOwner.Id))
                {
                    statOwner.StatsModifiers[stat] += statChange.EffectValue;
                }
            }
        }
    }
}