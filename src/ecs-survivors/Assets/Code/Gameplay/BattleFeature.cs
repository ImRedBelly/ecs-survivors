using Code.Common.Destruct;
using Code.Gameplay.Features.DamageApplication;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Lifetime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory factory)
        {
            Add(factory.Create<InputFeature>());
            Add(factory.Create<BindViewFeature>());
            
            Add(factory.Create<HeroFeature>());
            Add(factory.Create<EnemyFeature>());
            
            Add(factory.Create<MovementFeature>());
            
            Add(factory.Create<CollectTargetsFeature>());
            Add(factory.Create<DamageApplicationFeature>());
            
            Add(factory.Create<ProcessDestructedFeature>());
            
            Add(factory.Create<DeathFeature>());
        }
    }
}