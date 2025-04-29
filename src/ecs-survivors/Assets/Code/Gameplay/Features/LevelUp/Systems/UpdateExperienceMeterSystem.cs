using Code.Gameplay.Features.LevelUp.Services;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public sealed class UpdateExperienceMeterSystem : IExecuteSystem
    {
        private readonly ILevelUpService _levelUpService;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _experienceMeters;

        public UpdateExperienceMeterSystem(GameContext gameContext, ILevelUpService levelUpService)
        {
            _levelUpService = levelUpService;
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
                experienceMeter.ExperienceMeter.SetExperience(hero.Experience, _levelUpService.ExperienceForLevelUp());
            }
        }
    }
}