using Code.Common.Destruct;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Lifetime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Statuses;
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
            Add(factory.Create<DeathFeature>());

            Add(factory.Create<MovementFeature>());
            Add(factory.Create<AbilityFeature>());
            Add(factory.Create<ArmamentFeature>());

            Add(factory.Create<CollectTargetsFeature>());
            Add(factory.Create<EffectApplicationFeature>());
            
            Add(factory.Create<EnchantFeature>());
            Add(factory.Create<EffectFeature>());
            Add(factory.Create<StatusFeature>());
            Add(factory.Create<StatsFeature>());

            Add(factory.Create<ProcessDestructedFeature>());

        }
    }
}