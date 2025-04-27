using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public sealed class RemoveUnappliedEnchantsFromHolder : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _holders;

        public RemoveUnappliedEnchantsFromHolder(GameContext gameContext) : base(gameContext)
        {
            _holders = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.EnchantHolder));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(
                GameMatcher.AllOf(
                    GameMatcher.EnchantTypeId,
                    GameMatcher.Unapplied).Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            foreach (var holder in _holders)
            {
                holder.EnchantHolder.RemoveEnchant(entity.EnchantTypeId);
            }
        }
    }
}