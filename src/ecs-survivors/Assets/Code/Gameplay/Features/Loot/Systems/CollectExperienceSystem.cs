using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public sealed class CollectExperienceSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _collected;

        public CollectExperienceSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher.Hero);
            _collected = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Collected, GameMatcher.Experience));
        }

        public void Execute()
        {
            foreach (var hero in _heroes)
            foreach (var collected in _collected)
            {
                hero.ReplaceExperience(hero.Experience + collected.Experience);
            }
        }
    }
}