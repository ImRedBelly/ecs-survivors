using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public sealed class ApplyPoisonEnchantVisualSystem : ReactiveSystem<GameEntity>
    {
        public ApplyPoisonEnchantVisualSystem(GameContext gameContext) : base(gameContext)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> gameContext)
        {
            return gameContext.CreateCollector(GameMatcher.AllOf
            (GameMatcher.PoisonEnchant,
                GameMatcher.Armament,
                GameMatcher.EnchantVisuals).Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isArmament && entity.hasEnchantVisuals;
        }

        protected override void Execute(List<GameEntity> armaments)
        {
            foreach (var armament in armaments)
            {
                armament.EnchantVisuals.ApplyPoison();
            }
        }
    }
}