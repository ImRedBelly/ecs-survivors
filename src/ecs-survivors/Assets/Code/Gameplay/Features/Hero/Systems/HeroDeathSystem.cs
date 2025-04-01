using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public sealed class HeroDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public HeroDeathSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.HeroAnimator,
                GameMatcher.Dead,
                GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (var hero in _heroes)
            {
                hero.isMovementAvailable = false;
                hero.HeroAnimator.PlayDied();
            }
        }
    }
}