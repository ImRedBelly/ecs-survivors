using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public sealed class UpdateExperienceMeterSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _experienceMeters;

        public UpdateExperienceMeterSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Experience
                ));

            _experienceMeters = gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.ExperienceMeter
                ));
        }

        public void Execute()
        {
            foreach (var experienceMeter in _experienceMeters)
            foreach (var hero in _heroes)
            {
                experienceMeter.ExperienceMeter.SetExperience(hero.Experience, 100);
            }
        }
    }
}