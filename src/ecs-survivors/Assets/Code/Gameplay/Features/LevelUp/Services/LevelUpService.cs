using Code.Common.Entity;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.LevelUp.Services
{
    public class LevelUpService : ILevelUpService
    {
        public float CurrentExperience { get; private set; }
        public int CurrentLevel { get; private set; }

        private readonly IStaticDataService _staticDataService;

        public LevelUpService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void AddExperience(float experience)
        {
            CurrentExperience += experience;

            UpdateLevel();
        }

        public float ExperienceForLevelUp()
        {
            return _staticDataService.ExperienceForLevel(CurrentLevel + 1);
        }

        private void UpdateLevel()
        {
            if (CurrentLevel >= _staticDataService.MaxLevel())
            {
                return;
            }

            float experienceForLevelUp = _staticDataService.ExperienceForLevel(CurrentLevel + 1);

            if (CurrentExperience < experienceForLevelUp)
            {
                return;
            }

            CreateEntity.Empty()
                .isLevelUp = true;

            CurrentExperience -= experienceForLevelUp;
            CurrentLevel++;

            UpdateLevel();
        }
    }
}