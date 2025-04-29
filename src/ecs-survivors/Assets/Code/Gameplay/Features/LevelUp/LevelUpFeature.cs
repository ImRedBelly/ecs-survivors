using Code.Gameplay.Features.LevelUp.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.LevelUp
{
    public class LevelUpFeature : Feature
    {
        public LevelUpFeature(ISystemFactory factory)
        {
            Add(factory.Create<UpdateExperienceMeterSystem>());
            
            Add(factory.Create<OpenLevelUpWindowSystem>());
            Add(factory.Create<StopTimeOnLevelUpSystem>());
            
            Add(factory.Create<UpgradeAbilityOnRequestSystem>());
            Add(factory.Create<StartTimeOnLevelUpProcessSystem>());
            
            Add(factory.Create<FinalizeProcessedLevelUps>());
            
            
        }
    }
}