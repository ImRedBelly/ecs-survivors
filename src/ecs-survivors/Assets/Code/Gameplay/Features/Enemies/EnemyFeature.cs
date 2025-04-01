using Code.Gameplay.Features.Enemies.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemies
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory factory)
        {
            Add(factory.Create<ChaseHeroSystem>());
            Add(factory.Create<EnemyDeathSystem>());
            
            Add(factory.Create<FinalizeEnemyDeathProcessingSystem>());
        }
    }
}